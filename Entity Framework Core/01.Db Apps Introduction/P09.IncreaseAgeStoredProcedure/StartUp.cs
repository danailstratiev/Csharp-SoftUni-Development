using P01.InitialSetup;
using System;
using System.Data.SqlClient;

namespace P09.IncreaseAgeStoredProcedure
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int id = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string uspGetOlder = "SELECT Name, Age FROM Minions WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(uspGetOlder, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        string name = (string)reader[0];
                        int age = (int)reader[1];

                        Console.WriteLine($"{name} - {age} years old");
                    }
                }
            }
        }
    }
}
