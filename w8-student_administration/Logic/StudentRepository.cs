using System;
using System.Collections.Generic;
using StudentAdministration.Data;
using StudentAdministration.Models;

namespace StudentAdministration.Logic
{
    public class StudentRepository
    {
        private IStudentContext context;

        public StudentRepository(IStudentContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Retrieve all students currently in the repository.
        /// </summary>
        /// <returns>A list of students.</returns>
        public List<Student> GetAll()
        {
            return context.GetAll();
        }

        /// <summary>
        /// Retrieve a student by id.
        /// </summary>
        /// <param name="id">The id of the student to retrieve.</param>
        /// <returns>A filled Student object. </returns>
        public Student GetById(int id)
        {
            return context.GetById(id);
        }

        /// <summary>
        /// Insert a student into the repository.
        /// </summary>
        /// <param name="student">The student to insert.</param>
        /// <returns>A new student instance with the Id field filled based on
        /// the insertion; or null if the insert failed.</returns>
        public Student Insert(Student student)
        {
            if (VerifyEmail(student.Email))
            {
                return context.Insert(student);
            }
            return null;
        }

        /// <summary>
        /// Update the details for the given student into the repository.
        /// </summary>
        /// <param name="student">The student to update.</param>
        /// <returns>True when the student was successfully updated.</returns>
        public bool Update(Student student)
        {
            if (VerifyEmail(student.Email))
            {
                return context.Update(student);
            }
            return false;
        }

        /// <summary>
        /// Delete a student from the repository.
        /// </summary>
        /// <param name="id">The id of the student to delete.</param>
        /// <returns>True when the student was successfully deleted.</returns>
        public bool Delete(int id)
        {
            return context.Delete(id);
        }

        /// <summary>
        /// Simple business logic: this application only accepts email
        /// addresses of a given domain
        /// </summary>
        /// <param name="email">The string to verify.</param>
        /// <returns>True when the address was accepted.</returns>
        private bool VerifyEmail(string email)
        {
            return email.EndsWith("@student.fontys.nl");
        }
    }
}
