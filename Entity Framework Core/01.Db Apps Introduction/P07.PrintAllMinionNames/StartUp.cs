﻿using P01.InitialSetup;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace P07.PrintAllMinionNames
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            var names = new List<string>();

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string minionsQuery = "SELECT Name FROM Minions";

                using (SqlCommand command = new SqlCommand(minionsQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            names.Add((string)reader[0]);
                        }
                    }
                }
            }

            for (int i = 0; i < names.Count / 2; i++)
            {
                Console.WriteLine(names[i]);
                Console.WriteLine(names[names.Count - 1 - i]);
            }

            if (names.Count % 2 != 0)
            {
                Console.WriteLine(names[names.Count / 2]);
            }
        }
    }
}
