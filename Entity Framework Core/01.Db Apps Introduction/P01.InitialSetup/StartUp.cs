using System;
using System.Data.SqlClient;


namespace P01.InitialSetup
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            // CREATE DATABASE MINIONSDB

            using (SqlConnection sqlConnection = new SqlConnection(Configuration.ConnectionString))
            {
                sqlConnection.Open();

                //string[] createstatements =
                //{
                //    "create table countries (id int primary key identity,name varchar(50))",
                //    "create table towns(id int primary key identity,name varchar(50), countrycode int foreign key references countries(id))",
                //    "create table minions(id int primary key identity,name varchar(30), age int, townid int foreign key references towns(id))",
                //    "create table evilnessfactors(id int primary key identity, name varchar(50))",
                //    "create table villains (id int primary key identity, name varchar(50), evilnessfactorid int foreign key references evilnessfactors(id))",
                //    "create table minionsvillains (minionid int foreign key references minions(id),villainid int foreign key references villains(id),constraint pk_minionsvillains primary key (minionid, villainid))"
                //};

                //foreach (var statement in createstatements)
                //{
                //    execnonquery(sqlconnection, statement);
                //}

                string[] insertStatements =
                {
                    "INSERT INTO Countries ([Name]) VALUES ('Bulgaria'),('England'),('Cyprus'),('Germany'),('Norway')",
                    "INSERT INTO Towns ([Name], CountryCode) VALUES ('Plovdiv', 1),('Varna', 1),('Burgas', 1),('Sofia', 1),('London', 2),('Southampton', 2),('Bath', 2),('Liverpool', 2),('Berlin', 3),('Frankfurt', 3),('Oslo', 4)",
                    "INSERT INTO Minions (Name,Age, TownId) VALUES('Bob', 42, 3),('Kevin', 1, 1),('Bob ', 32, 6),('Simon', 45, 3),('Cathleen', 11, 2),('Carry ', 50, 10),('Becky', 125, 5),('Mars', 21, 1),('Misho', 5, 10),('Zoe', 125, 5),('Json', 21, 1)",
                    "INSERT INTO EvilnessFactors (Name) VALUES ('Super good'),('Good'),('Bad'), ('Evil'),('Super evil')",
                    "INSERT INTO Villains (Name, EvilnessFactorId) VALUES ('Gru',2),('Victor',1),('Jilly',3),('Miro',4),('Rosen',5),('Dimityr',1),('Dobromir',2)",
                    "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (4,2),(1,1),(5,7),(3,5),(2,6),(11,5),(8,4),(9,7),(7,1),(1,3),(7,3),(5,3),(4,3),(1,2),(2,1),(2,7)"
                };

                foreach (var statement in insertStatements)
                {
                    ExecNonQuery(sqlConnection, statement);
                }
            }
        }
        private static void ExecNonQuery(SqlConnection connection, string cmdText)
        {
            using (SqlCommand command = new SqlCommand(cmdText, connection))
            {
                // Returns int - number of rows
                command.ExecuteNonQuery();
            }
        }
    }
}
