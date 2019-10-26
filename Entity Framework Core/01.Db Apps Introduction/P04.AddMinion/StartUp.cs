using P01.InitialSetup;
using System;
using System.Data.SqlClient;

namespace P04.AddMinion
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var minionInfo = Console.ReadLine().Split();
            var villainInfo = Console.ReadLine().Split();

            var minionName = minionInfo[1];
            var age = int.Parse(minionInfo[2]);
            var townName = minionInfo[3];

            var villainName = villainInfo[1];

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();
                               
                var id = GetTownId(connection, townName);

                AddNewMinion(connection, minionName, age, id);

                int? villainId = GetVillainByName(connection, villainName);

                if (villainId == null)
                {
                    AddVillain(connection, villainName);
                }

                villainId = GetVillainByName(connection, villainName);
                int minionId = GetMinionByName(connection, minionName);
                AddMinionVillain(connection, villainId, minionId, villainName, minionName);
            }
        }

        private static int GetTownId(SqlConnection connection, string townName)
        {
            var townIdQuery = "SELECT Id FROM Towns WHERE Name = @townName";

            using (SqlCommand command = new SqlCommand(townIdQuery, connection))
            {
                command.Parameters.AddWithValue("@townName", townName);
                int? id = (int?)command.ExecuteScalar();

                if (id == null)
                {
                    AddTown(connection, townName);
                    Console.WriteLine($"Town {townName} was added to the database.");
                }

                return (int)id;
            }
        }
        private static void AddMinionVillain(SqlConnection connection, int? villainId, int minionId, string villainName, string minionName)
        {
            var insertQuery = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)";

            using (SqlCommand command = new SqlCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@villainId", villainId);
                command.Parameters.AddWithValue("@minionId", minionId);

                command.ExecuteNonQuery();
            }

            Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
        }

        private static int GetMinionByName(SqlConnection connection, string minionName)
        {
            string minionQuery = "SELECT Id FROM Minions WHERE Name = @Name";

            using (SqlCommand command = new SqlCommand(minionQuery, connection))
            {
                command.Parameters.AddWithValue("@Name", minionName);
                return (int)command.ExecuteScalar();
            }
        }

        private static void AddVillain(SqlConnection connection, string villainName)
        {
            string insertVillain = "INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";

            using (SqlCommand command = new SqlCommand(insertVillain, connection))
            {
                command.Parameters.AddWithValue("@villainName", villainName);

                command.ExecuteNonQuery();
            }

            Console.WriteLine($"Villain {villainName} was added to the database.");
        }

        private static int? GetVillainByName(SqlConnection connection, string villainName)
        {
            var villainIdQuery = "SELECT Id FROM Villains WHERE Name = @Name";

            using (SqlCommand command = new SqlCommand(villainIdQuery, connection))
            {
                command.Parameters.AddWithValue("@Name", villainName);
                int? id = (int?)command.ExecuteScalar();
                return id;
            }
        }

        private static void AddNewMinion(SqlConnection connection, string minionName, int age, int? id)
        {
            string insertMinionSql = "INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";

            using (SqlCommand command = new SqlCommand(insertMinionSql, connection))
            {
                command.Parameters.AddWithValue("@name", minionName);
                command.Parameters.AddWithValue("@age", age);
                command.Parameters.AddWithValue("@townId", id);

                command.ExecuteNonQuery();
            }
        }

        private static void AddTown(SqlConnection connection, string townName)
        {
            var insertTownSQL = "INSERT INTO Towns (Name) VALUES (@townName)";

            using (SqlCommand command = new SqlCommand(insertTownSQL, connection))
            {
                command.Parameters.AddWithValue("@townName", townName);
                command.ExecuteNonQuery();
            }

            Console.WriteLine($"Town {townName} was added to the database.");
        }
    }
}
