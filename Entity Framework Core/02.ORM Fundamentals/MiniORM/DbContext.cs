namespace MiniORM
{
    // TODO: Create your DbContext class here.

    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Data.SqlClient;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class DbContext
    {
        private readonly DatabaseConnection connection;
        private readonly Dictionary<Type, PropertyInfo> dbSetProperties;

        public DbContext(string connectionString)
        {
            this.connection = new DatabaseConnection(connectionString);

            this.dbSetProperties = this.DiscoverDbSets();

            using (new ConnectionManager(connection))
            {
                this.InitializeDbSets();
            }

            this.MapAllRelations();
        }

        public void SaveChanges()
        {
            var dbSets = this.dbSetProperties.Select(x => x.Value.GetValue(this)).ToArray();

            foreach (IEnumerable<object> dbSet in dbSets)
            {
                var invalidEntities = dbSet.Where(x => !IsObjectValid(x)).ToArray();

                if (invalidEntities.Any())
                {
                    throw new InvalidOperationException($"{invalidEntities.Length} Invalid Entities found in {dbSet.GetType().Name}!");
                }
            }

            using (new ConnectionManager(this.connection))
            {
                using (var transaction = this.connection.StartTransaction())
                {
                    foreach (var dbSet in dbSets)
                    {
                        var dbSetType = dbSet.GetType().GetGenericArguments().First();

                        var persistMethod = typeof(DbContext)
                            .GetMethod("Persist", BindingFlags.NonPublic | BindingFlags.Instance)
                            .MakeGenericMethod(dbSetType);

                        try
                        {
                            persistMethod.Invoke(this, new object[] { dbSet });
                        }
                        catch (TargetInvocationException tie)
                        {
                            throw tie.InnerException;
                        }
                        catch (InvalidOperationException)
                        {
                            transaction.Rollback();
                        }
                        catch (SqlException)
                        {
                            transaction.Rollback();
                            throw;
                        }   
                    }

                    transaction.Commit();
                }
            }
        }

        private void Persist<TEntity>(DbSet<TEntity> dbSet)
            where TEntity: class, new()
        {
            var tableName = GetTableName(typeof(TEntity));

            var columns = this.connection.FetchColumnNames(tableName).ToArray();

            if (dbSet.ChangeTracker.Added.Any())
            {
                this.connection.InsertEntities(dbSet.ChangeTracker.Added, tableName, columns);
            }

            if (dbSet.ChangeTracker.Removed.Any())
            {
                this.connection.DeleteEntities(dbSet.ChangeTracker.Removed, tableName, columns);
            }

            var modifiedEntities = dbSet.ChangeTracker.GetModifiedEntities(dbSet).ToArray();

            if (modifiedEntities.Any())
            {
                this.connection.UpdateEntities(modifiedEntities, tableName, columns);
            }
        }        

        private void InitializeDbSets()
        {
            foreach (var dbSetProperty in this.dbSetProperties)
            {
                var dbSetType = dbSetProperty.Key;
                var dbSetPropertyType = dbSetProperty.Value;

                var populateDbSetGeneric = typeof(DbContext)
                    .GetMethod("PopulateDbSet" ,BindingFlags.NonPublic | BindingFlags.Instance)
                    .MakeGenericMethod(dbSetType);

                populateDbSetGeneric.Invoke(this, new object[] { dbSetPropertyType});
            }
        }

        private void MapAllRelations()
        {
            foreach (var dbSetProperty in this.dbSetProperties)
            {
                var dbSetType = dbSetProperty.Key;

                var mapRelations = typeof(DbContext)
                    .GetMethod("MapRelations", BindingFlags.NonPublic | BindingFlags.Instance)
                    .MakeGenericMethod(dbSetType);

                var dbSet = dbSetProperty.Value.GetValue(this);

                mapRelations.Invoke(this, new object[] { dbSet });
            }
        }

        private void MapRelations<TEntity>(DbSet<TEntity> dbSet)
            where TEntity:class, new()
        {
            var entityType = typeof(TEntity);

            MapNavigationProperties(dbSet);

            var collections = entityType.GetProperties()
                .Where(x => x.GetType().IsGenericType && x.GetType().GetGenericTypeDefinition() == typeof(ICollection<>))
                .ToArray();

            foreach (var collection in collections)
            {
                var collectionType = collection.GetType().GetGenericArguments().First();

                var mapCollection = typeof(DbContext)
                    .GetMethod("MapCollection", BindingFlags.NonPublic | BindingFlags.Instance)
                    .MakeGenericMethod(entityType, collectionType);

                mapCollection.Invoke(this, new object[] { dbSet, collectionType });
            }
        }

        private void MapCollection<TDbSet, TcCollection>(DbSet<TDbSet> dbSet, PropertyInfo collectionProperty)
            where TDbSet: class, new()
            where TcCollection: class, new()
        {
            var entityType = typeof(TDbSet);
            var collectionType = typeof(TcCollection);

            var primaryKeys = collectionType.GetProperties().
                Where(x => x.HasAttribute<KeyAttribute>()).
                ToArray();

            var primaryKey = primaryKeys.First();
            var foreignKey = entityType.GetProperties().
                First(x => x.HasAttribute<KeyAttribute>());

            var isManyToMany = primaryKeys.Length >= 2;

            if (isManyToMany)
            {
                primaryKey = collectionType.GetProperties().
                    First(x => collectionType.GetProperty(x.GetCustomAttribute<ForeignKeyAttribute>().Name).
                    PropertyType == entityType);
            }

            var navigationDbSet = (DbSet<TcCollection>)this.dbSetProperties[collectionType].GetValue(this);

            foreach (var entity in dbSet)
            {
                var primaryKeyValue = foreignKey.GetValue(entity);

                var navigationEntities = navigationDbSet
                    .Where(navigationEntity => primaryKey.GetValue(navigationEntity).Equals(primaryKeyValue))
                    .ToArray();

                ReflectionHelper.ReplaceBackingField(this, collectionProperty.Name, navigationEntities);
            }
        }

        private void MapNavigationProperties<TEntity>(DbSet<TEntity> dbSet) 
            where TEntity : class, new()
        {
            var entityType = typeof(TEntity);

            var foreignKeys = entityType.GetProperties().
                Where(x => x.HasAttribute<ForeignKeyAttribute>()).ToArray();

            foreach (var foreignKey in foreignKeys)
            {
                var navigationPropertyName = foreignKey.GetCustomAttribute<ForeignKeyAttribute>().Name;

                var navigationProperty = entityType.GetProperty(navigationPropertyName);

                var navigationDbSet = this.dbSetProperties[navigationProperty.PropertyType].GetValue(this);

                var navigationPrimaryKey = navigationProperty.PropertyType.GetProperties()
                    .First(x => x.HasAttribute<KeyAttribute>());

                foreach (var entity in dbSet)
                {
                    var foreignKeyValue = foreignKey.GetValue(entity);

                    var navigationPropertyValue = ((IEnumerable<object>)navigationDbSet)
                        .First(currentNavigationProperty => navigationProperty.GetValue(currentNavigationProperty)
                        .Equals(foreignKeyValue));

                    navigationProperty.SetValue(entity, navigationPropertyValue); 
                }
            }
        }

        private void PopulateDbSet<TEntity>(PropertyInfo dbSet)
            where  TEntity: class, new()
        {
            var tableEntities = LoadTableEntities<TEntity>();
            var dbSetInstance = new DbSet<TEntity>(tableEntities);

            ReflectionHelper.ReplaceBackingField(this, dbSet.Name, dbSetInstance);
        }

        private IEnumerable<TEntity> LoadTableEntities<TEntity>()
            where TEntity:class
        {
            var table = typeof(TEntity);

            var columns = GetColumnNames(table);

            var tableName = GetTableName(table);

            var fetchedRows = this.connection.FetchResultSet<TEntity>(tableName, columns.ToString());

            return fetchedRows; 
        }       

        private string GetTableName(Type tableType)
        {
            var tableName = ((TableAttribute)Attribute.GetCustomAttribute(tableType, typeof(TableAttribute))).Name;

            if (tableName == null)
            {
                tableName = this.dbSetProperties[tableType].Name;
            }

            return tableName; 
        }
        private PropertyInfo[] GetColumnNames(Type table)
        {
            var tableName = GetTableName(table);

            var dbColumns = this.connection.FetchColumnNames(tableName);

            var columns = table.GetProperties().
                Where(x => dbColumns.Contains(x.Name) &&
                !x.HasAttribute<NotMappedAttribute>() &&
                AllowedSqlTypes.Contains(x.PropertyType)).
                ToArray();

            return columns;
        }

        private bool IsObjectValid(object x)
        {
            var validationContext = new ValidationContext(x);

            var validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(x, validationContext, validationResults, true);
        }
        
         
        private Dictionary<Type, PropertyInfo> DiscoverDbSets()
        {
            return this.GetType().
                GetProperties().
                Where(x => x.GetType().GetGenericTypeDefinition() == typeof(DbSet<>)).
                ToDictionary(x => x.PropertyType.GetGenericArguments().First(), v => v);
        }

        internal static Type[] AllowedSqlTypes =
        {
            typeof(bool),
            typeof(int),
            typeof(string),
            typeof(uint),
            typeof(DateTime),
            typeof(double),
            typeof(decimal),
            typeof(long),
            typeof(ulong)
        };
    }
}