using System;
using System.Collections.Generic;
using StudentAdministration.Models;

namespace StudentAdministration.Data
{
    public interface IGradeContext
    {
        /// <summary>
        /// Retrieve the grade for a given student.
        /// </summary>
        /// <param name="student">The student to find the grade for.</param>
        /// <returns>The found grade, or null if no grades are registered for
        /// the given student.</returns>
        Grade GetForStudent(Student student);

        /// <summary>
        /// Insert a grade into the repository.
        /// </summary>
        /// <param name="student">The student to whom the grade applies.</param>
        /// <param name="grade">The grade to insert.</param>
        /// <returns>True if the grade was successfully inserted; or null if
        /// the insert failed.</returns>
        bool Insert(Student student, Grade grade);

        /// <summary>
        /// Check if every grade is a pass.
        /// </summary>
        /// <param name="grade">Student's grade</param>
        /// <returns>Every grade is a pass.</returns>
        bool CheckGrades(Grade grade);

        /// <summary>
        /// Get average of all grades.
        /// Grade for Analysis determines 20% of the average,
        /// for Design 30% and for Code 50%.
        /// </summary>
        /// <param name="grade">Student's grade</param>
        /// <returns>Average grade</returns>
        int GetAverage(Grade grade);
    }
}
