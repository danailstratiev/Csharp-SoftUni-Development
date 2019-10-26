using P01.InitialSetup;
using System;
using System.Data.SqlClient;

namespace P02._Villain_Names
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Configuration.ConnectionString))
            {
                sqlConnection.Open();

                string sqlQuery = @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
    FROM Villains AS v
    JOIN MinionsVillains AS mv ON v.Id = mv.VillainId
GROUP BY v.Id, v.Name
  HAVING COUNT(mv.VillainId) > 3
ORDER BY COUNT(mv.VillainId)";

                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {                        
                        while (reader.Read())
                        {
                            string name = (string)reader[0];
                            int count = (int)reader[1];

                            Console.WriteLine($"{name} - {count}");
                        }
                    }
                }
            }
        }
    }
}
