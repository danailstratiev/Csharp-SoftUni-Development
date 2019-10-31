namespace MiniORM
{
    // TODO: Create your ChangeTracker class here.

    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Reflection;
    using System.ComponentModel.DataAnnotations;

    internal class ChangeTracker<T>
        where T : class, new()
    {
        private readonly List<T> allEntities;
        private readonly List<T> added;
        private readonly List<T> removed;

        public ChangeTracker(IEnumerable<T> entities)
        {
            this.added = new List<T>();
            this.removed = new List<T>();

            this.allEntities = CloneEntities(entities);

        }

        public IReadOnlyCollection<T> AllEntities => allEntities;
        public IReadOnlyCollection<T> Added => added;
        public IReadOnlyCollection<T> Removed => removed;

        public void Add(T item) => this.added.Add(item);

        public void Remove(T item) => this.removed.Add(item);

        public IEnumerable<T> GetModifiedEntities(DbSet<T> dbSet)
        {
            var modifiedEntities = new List<T>();

            var primaryKeys = typeof(T).GetProperties().Where(x => x.HasAttribute<KeyAttribute>()).ToArray();

            foreach (var proxyEntity in this.AllEntities)
            {
                var primayKeyValues = GetPrimaryKeyValues(primaryKeys, proxyEntity).ToArray();

                var entity = dbSet.Entities
                    .Single(e => GetPrimaryKeyValues(primaryKeys, e).SequenceEqual(primayKeyValues));
                var isModified = IsModified(proxyEntity, entity);

                if (isModified)
                {
                    modifiedEntities.Add(entity);
                }
            }

            return modifiedEntities;
        }

        private bool IsModified(T proxyEntity, T entity)
        {
            var monitoredProperties = typeof(T).GetProperties()
                .Where(x => DbContext.AllowedSqlTypes.Contains(x.PropertyType)).ToArray();

            var modifiedProperties = monitoredProperties.
                Where(x => !Equals(x.GetValue(proxyEntity), x.GetValue(entity))).
                ToArray();

            var isModified = modifiedProperties.Any();

            return isModified;
        }

        private static IEnumerable<object> GetPrimaryKeyValues(PropertyInfo[] primaryKeys, T entity)
        {
            return primaryKeys.Select(x => x.GetValue(entity));
        }

        private List<T> CloneEntities(IEnumerable<T> entities)
        {
            var clonedEntities = new List<T>();

            var propertiesToClone = typeof(T).GetProperties()
                .Where(x => DbContext.AllowedSqlTypes.Contains(x.PropertyType))
                .ToArray();

            foreach (var entity in entities)
            {
                var clonedEntity = Activator.CreateInstance<T>();

                foreach (var property in propertiesToClone)
                {
                    var value = property.GetValue(entity);
                    property.SetValue(clonedEntity, value);
                }

                clonedEntities.Add(clonedEntity);
            }

            return clonedEntities;
        }
    }
}