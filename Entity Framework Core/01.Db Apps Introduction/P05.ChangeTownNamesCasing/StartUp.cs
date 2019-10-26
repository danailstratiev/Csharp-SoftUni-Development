using P01.InitialSetup;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace P05.ChangeTownNamesCasing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var countryName = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                var updateTownNames = @"UPDATE Towns
   SET Name = UPPER(Name)
 WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

                using (SqlCommand command = new SqlCommand(updateTownNames, connection))
                {
                    command.Parameters.AddWithValue("@countryName", countryName);
                    var rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine($"{rowsAffected} town names were affected.");
                    }
                    else
                    {
                        Console.WriteLine("No town names were affected.");
                        return;
                    }
                }

                var townsQuery = @"SELECT t.Name 
   FROM Towns as t
   JOIN Countries AS c ON c.Id = t.CountryCode
  WHERE c.Name = @countryName";

                var towns = new List<string>();

                using (SqlCommand command = new SqlCommand(townsQuery, connection))
                {
                    command.Parameters.AddWithValue("@countryName", countryName);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            towns.Add((string)reader[0]);
                        }
                    }
                }

                Console.WriteLine("[" + string.Join(", ", towns) + "]");
            }
        }
    }
}
