using System;
using System.Collections.Generic;
using StudentAdministration.Data;
using StudentAdministration.Models;

namespace StudentAdministration.Logic
{
    public class GradeRepository
    {
        private IGradeContext context;

        public GradeRepository(IGradeContext context)
        {
            //Je kan hier een instantie van jezelf mee geven, deze constructor was er al.
            this.context = context;
        }

        /// <summary>
        /// Retrieve the grade for a given student.
        /// </summary>
        /// <param name="student">The student to find the grade for.</param>
        /// <returns>The found grade, or null if no grades are registered for
        /// the given student.</returns>
        public Grade GetForStudent(Student student)
        {
            return context.GetForStudent(student);
        }

        /// <summary>
        /// Insert a grade into the repository.
        /// </summary>
        /// <param name="student">The student to whom the grade applies.</param>
        /// <param name="grade">The grade to insert.</param>
        /// <returns>True if the grade was successfully inserted; or null if
        /// the insert failed.</returns>
        public bool Insert(Student student, Grade grade)
        {
            return context.Insert(student, grade);
        }

        public bool CheckGrades(Grade grade)
        {
            //if (Convert.ToDouble(grade.Analysis) > 5.5d &&
            //    Convert.ToDouble(grade.Design) > 5.5d &&
            //    Convert.ToDouble(grade.Code) > 5.5d)
            //{
                return context.CheckGrades(grade);
            //}
            //return false;
        }

        public int GetAverage(Grade grade)
        {
            int average = Convert.ToInt32(Math.Round(
                    grade.Analysis * 0.2m + grade.Design * 0.3m + grade.Code * 0.5m
                    ));
            if (CheckGrades(grade))
            {
                return average; // return rounded average grade
            }
            else if(average >= 6)
            {
                return 5; // In case if one or more grades are not a pass.
            }
            return average; // All of them fail.
        }
    }
}
