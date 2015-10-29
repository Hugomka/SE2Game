using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace StudentAdministration.Data
{
    public class Database
    {
        // De bestandsnaam voor de database
        private static readonly string databaseFilename = "Database.sqlite";
        private static readonly string connectionString = "Data Source=" + databaseFilename + ";Version=3";

        /// <summary>
        /// Creates a new database connection and directly opens it. The caller
        /// is resposible for properly closing the connection.
        /// </summary>
        public static SQLiteConnection Connection
        {
            get
            {
                SQLiteConnection connection = new SQLiteConnection(connectionString);
                connection.Open();
                return connection;
            }
        }

        /// <summary>
        /// Create a new database if it doesn't exist, and fill it with some
        /// dummy data.
        /// </summary>
        public static void Initialize()
        {
            bool recreateDatabase = false;

            // Check if the database already exists
            if (File.Exists("Database.sqlite"))
            {
                // If this source file is also found when running the program,
                // see if it was modified after the database was last written to
                if (File.Exists(@"..\..\Data\Database.cs") &&
                        (new FileInfo(@".\Database.sqlite").LastWriteTime <
                         new FileInfo(@"..\..\Data\Database.cs").LastWriteTime))
                {
                    recreateDatabase = true;
                }
            }
            else
            {
                recreateDatabase = true;
            }

            // File doesn't exist, or this file was modified after the database
            // was created: recreate the database
            if (recreateDatabase)
            {
                Console.WriteLine("Database (re)created.");
                SQLiteConnection.CreateFile(databaseFilename);

                // Create some dummy data to work with
                using (SQLiteConnection connection = Database.Connection)
                {
                    string[] queries = new string[] {
                        "CREATE TABLE Student (Id INT PRIMARY KEY, Name VARCHAR(100), Email VARCHAR(100))",
                        "INSERT INTO Student (Id, Name, Email) VALUES (1001, 'John Doe', 'john.doe@student.fontys.nl')",
                        "INSERT INTO Student (Id, Name, Email) VALUES (1002, 'Hank Schrader', 'hank.schrader@student.fontys.nl')",
                        "INSERT INTO Student (Id, Name, Email) VALUES (1003, 'Jeff Johnson', 'jeff.johnson@student.fontys.nl')",

                        "CREATE TABLE Grade (StudentId INT PRIMARY KEY, Analysis INT, Design INT, Code INT" +
                            ", FOREIGN KEY(StudentId) REFERENCES Student(Id))",
                        "INSERT INTO Grade (StudentId, Analysis, Design, Code) VALUES (1001, 6, 7, 8)",
                    };

                    foreach (string query in queries)
                    {
                        using (SQLiteCommand command = new SQLiteCommand(query, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
    }
}
