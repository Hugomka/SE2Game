using System;
using System.Collections.Generic;
using System.Data.SQLite;
using StudentAdministration.Models;


namespace StudentAdministration.Data
{
    public class StudentSQLiteContext : IStudentContext
    {
        public StudentSQLiteContext()
        {
            Database.Initialize();
        }

        public List<Student> GetAll()
        {
            List<Student> result = new List<Student>();
            using (SQLiteConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM Student ORDER BY Id";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(CreateStudentFromReader(reader));
                        }
                    }
                }
            }
            return result;
        }

        public Student GetById(int id)
        {
            using (SQLiteConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM Student WHERE Id=:id LIMIT 1";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return CreateStudentFromReader(reader);
                        }
                    }
                }
            }

            return null;
        }

        public Student Insert(Student student)
        {
            using (SQLiteConnection connection = Database.Connection)
            {
                string query = "INSERT INTO Student (Id, Name, Email)" +
                    " VALUES ((SELECT (MAX(Id)+1) FROM Student)," +
                    " :name, :email)";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("name", student.Name);
                    command.Parameters.AddWithValue("email", student.Email);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SQLiteException e)
                    {
                        // If a PK constraint was violated, handle the exception
                        if (e.ResultCode == SQLiteErrorCode.Constraint)
                        {
                            return null;
                        }

                        // Unexpected error: rethrow to let the caller handle it
                        throw;
                    }
                }

                // Retrieve the id of the inserted row to create a new student object
                query = "SELECT last_insert_rowid()";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    int id = Convert.ToInt32(command.ExecuteScalar());
                    student = new Student(id, student.Name, student.Email);
                }
            }

            return student;
        }

        public bool Update(Student student)
        {
            using (SQLiteConnection connection = Database.Connection)
            {
                string query = "UPDATE Student" +
                    " SET Name=:name, Email=:email" +
                    " WHERE Id=:id";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("id", student.Id);
                    command.Parameters.AddWithValue("name", student.Name);
                    command.Parameters.AddWithValue("email", student.Email);
                    if (Convert.ToInt32(command.ExecuteNonQuery()) > 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool Delete(int id)
        {
            using (SQLiteConnection connection = Database.Connection)
            {
                string query = "DELETE FROM Student WHERE Id=:id";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    if (Convert.ToInt32(command.ExecuteNonQuery()) == 1)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Helper function to construct a Student instance from a DataReader.
        /// Expects that read() has already been called.
        /// </summary>
        /// <param name="reader">The DataReader to read from.</param>
        /// <returns>A new Student instance based on the read data.</returns>
        private Student CreateStudentFromReader(SQLiteDataReader reader)
        {
            return new Student(
                Convert.ToInt32(reader["Id"]),
                Convert.ToString(reader["Name"]),
                Convert.ToString(reader["Email"]));
        }
    }
}
