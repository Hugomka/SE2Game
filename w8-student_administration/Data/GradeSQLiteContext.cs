using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentAdministration.Models;
using System.Data.SQLite;

namespace StudentAdministration.Data
{
    public class GradeSQLiteContext : IGradeContext
    {
        public GradeSQLiteContext()
        {
            Database.Initialize();
        }

        public bool CheckGrades(Grade grade)
        {

            return (Convert.ToDouble(grade.Analysis) > 5.5d &&
                Convert.ToDouble(grade.Design) > 5.5d &&
                Convert.ToDouble(grade.Code) > 5.5d);

        }

        public int GetAverage(Grade grade)
        {
            int average = Convert.ToInt32(Math.Round((
                    grade.Analysis * 0.2m + grade.Design * 0.3m + grade.Code * 0.5m
                    ) / 3));
            if (CheckGrades(grade))
            {
                return average; // return rounded average grade
            }
            else if (average >= 6)
            {
                return 5; // In case if one or more grades are not a pass.
            }
            return average; // All of them fail.
        }

        //public List<Grade> GetAll()
        //{
        //    List<Grade> result = new List<Grade>();
        //    using (SQLiteConnection connection = Database.Connection)
        //    {
        //        string query = "SELECT * FROM Grade ORDER BY StudentId";
        //        using (SQLiteCommand command = new SQLiteCommand(query, connection))
        //        {
        //            using (SQLiteDataReader reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    result.Add(CreateGradeFromReader(reader));
        //                }
        //            }
        //        }
        //    }
        //    return result;
        //}

        public Grade GetForStudent(Student student)
        {
            using (SQLiteConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM Grade WHERE StudentId=:studentId LIMIT 1";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("studentId", student.Id);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return CreateGradeFromReader(reader);
                        }
                    }
                }
            }

            return null;
        }

        public bool Insert(Student student, Grade grade)
        {
            using (SQLiteConnection connection = Database.Connection)
            {
               
                string query = "INSERT INTO Grade (StudentId, Analysis, Design, Code)" +
                    " VALUES (:studentId, :analysis, :design, :code)";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("studentId", student.Id);
                    command.Parameters.AddWithValue("analysis", grade.Analysis);
                    command.Parameters.AddWithValue("design", grade.Design);
                    command.Parameters.AddWithValue("code", grade.Code);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SQLiteException e)
                    {
                        // If a PK constraint was violated, handle the exception
                        if (e.ResultCode == SQLiteErrorCode.Constraint)
                        {
                            return false;
                        }

                        // Unexpected error: rethrow to let the caller handle it
                        throw;
                    }
                }

                // Retrieve the id of the inserted row to create a new grade object
                query = "SELECT last_insert_rowid()";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    int id = Convert.ToInt32(command.ExecuteScalar());
                    grade = new Grade(grade.Analysis, grade.Design, grade.Code);
                }
            }

            return true;
        }

        //public bool Update(Student student, Grade grade)
        //{
        //    using (SQLiteConnection connection = Database.Connection)
        //    {
        //        string query = "UPDATE Grade" +
        //            " SET Analysis=:analysis, Design=:design, Code=:code" +
        //            " WHERE StudentId=:studentId";
        //        using (SQLiteCommand command = new SQLiteCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("studentId", student.Id);
        //            command.Parameters.AddWithValue("analysis", grade.Analysis);
        //            command.Parameters.AddWithValue("design", grade.Design);
        //            command.Parameters.AddWithValue("code", grade.Code);
        //            if (Convert.ToInt32(command.ExecuteNonQuery()) > 0)
        //            {
        //                return true;
        //            }
        //        }
        //    }
        //    return false;
        //}

        //public bool Delete(Student student)
        //{
        //    using (SQLiteConnection connection = Database.Connection)
        //    {
        //        string query = "DELETE FROM Grade WHERE StudentId=:studentId";
        //        using (SQLiteCommand command = new SQLiteCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("studentId", student.Id);
        //            if (Convert.ToInt32(command.ExecuteNonQuery()) == 1)
        //            {
        //                return true;
        //            }
        //        }
        //    }

        //    return false;
        //}

        /// <summary>
        /// Helper function to construct a Student instance from a DataReader.
        /// Expects that read() has already been called.
        /// </summary>
        /// <param name="reader">The DataReader to read from.</param>
        /// <returns>A new Student instance based on the read data.</returns>
        private Grade CreateGradeFromReader(SQLiteDataReader reader)
        {
            return new Grade(
                Convert.ToDecimal(reader["Analysis"]),
                Convert.ToDecimal(reader["Design"]),
                Convert.ToDecimal(reader["Code"]));
        }

    }
}
