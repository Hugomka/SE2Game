using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentAdministration;
using StudentAdministration.Data;
using StudentAdministration.Logic;
using StudentAdministration.Models;

namespace StudentAdministrationTest
{
    [TestClass]
    public class GradeTest
    {
        private GradeRepository gradeRepo;

        [TestInitialize]
        public void Initialize()
        {
            this.gradeRepo = new GradeRepository(new GradeMemoryContext());
        }

        [TestMethod]
        public void NewGradesAllCorrect()
        {
            bool wrongResult = false;
            Random randomgrade = new Random();
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    Grade newGrades = new Grade(
                        randomgrade.Next(0, 101) / 10,
                        randomgrade.Next(0, 101) / 10,
                        randomgrade.Next(0, 101) / 10);
                }
            }
            catch (Grade.InvalidGradeException)
            {
                wrongResult = true;
            }
            finally
            {
                Assert.IsFalse(wrongResult);
            }
        }

        [TestMethod]
        public void NewGradesAllWrong()
        {
            int wrongResult = 0;
            Random randomgrade = new Random();

            try
            {
                Grade newGrades = new Grade(
                -3,
                randomgrade.Next(0, 101) / 10,
                randomgrade.Next(0, 101) / 10);
            }
            catch (Grade.InvalidGradeException)
            {
                wrongResult++;
            }

            try
            {
                Grade newGrades = new Grade(
                randomgrade.Next(0, 101) / 10,
                11,
                randomgrade.Next(0, 101) / 10);
            }
            catch (Grade.InvalidGradeException)
            {
                wrongResult++;
            }

            try
            {
                Grade newGrades = new Grade(
                randomgrade.Next(0, 101) / 10,
                randomgrade.Next(0, 101) / 10,
                98 / -10);
            }
            catch (Grade.InvalidGradeException)
            {
                wrongResult++;
            }

            Assert.AreEqual(wrongResult, 3);
        }

        [TestMethod]
        public void InsertTests()
        {
            StudentMemoryContext studentContext = new StudentMemoryContext();
            GradeMemoryContext gradeContext = new GradeMemoryContext();
            Student student = new Student("John Doe", "john.doe@student.fontys.nl");
            //die student hierboven heeft nog geen id als hij aangemaakt wordt
            student = studentContext.Insert(student);

            Assert.IsFalse(gradeContext.Insert(
                new Student("Hugo Mkandawire", "h.mkandawire@student.fontys.nl"),
                new Grade(10, 5, 9)
                )); //Check if the student doesn't exist in the table.
            Assert.IsTrue(gradeContext.Insert(
                student,
                new Grade(8, 8, 9)
                )); //Check if the student exists in the table.
            Assert.IsNull(gradeContext.GetForStudent(new Student("Hugo Mkandawire", "h.mkandawire@student.fontys.nl")));
        }

        [TestMethod]
        public void TestGrades()
        {
            Student studentA = new Student(1001, "Hank Schrader", "hank.schrader@student.fontys.nl");
            Student studentB = new Student(1002, "Jeff Johnson", "jeff.johnson@student.fontys.nl");
            Student studentC = new Student(1003, "Pietje Bell", "pietje.bell@student.fontys.nl");
            Grade gradesA = new Grade(5.6m, 5.7m, 9.0m);
            Grade gradesB = new Grade(4.5m, 7.1m, 6.6m);
            Grade gradesC = new Grade(2.1m, 3.1m, 6.2m);

            gradeRepo.Insert(studentA, gradesA);
            gradeRepo.Insert(studentB, gradesB);
            gradeRepo.Insert(studentC, gradesC);
            Assert.IsTrue(gradeRepo.CheckGrades(gradeRepo.GetForStudent(studentA)));
            Assert.IsFalse(gradeRepo.CheckGrades(gradeRepo.GetForStudent(studentB)));
            Assert.IsFalse(gradeRepo.CheckGrades(gradeRepo.GetForStudent(studentC)));
            Assert.AreEqual(gradeRepo.GetAverage(gradeRepo.GetForStudent(studentA)), 7);
            Assert.AreEqual(gradeRepo.GetAverage(gradeRepo.GetForStudent(studentB)), 5);
            Assert.AreEqual(gradeRepo.GetAverage(gradeRepo.GetForStudent(studentC)), 4);
            
        }
    }

    /// <summary>
    /// Mock class to mimic the real database to allow the unit tests to run
    /// without affecting any stored data.
    /// </summary>
    public class GradeMemoryContext : IGradeContext
    {
        // This list holds our grade data: consider this the database the 
        // unit tests will work with
        private Dictionary<Student, Grade> grades = new Dictionary<Student, Grade>();

        public Grade GetForStudent(Student student)
        {
            if (grades.ContainsKey(student))
            {
                return grades[student];
            }
            return null;
        }

        public bool Insert(Student student, Grade grade)
        {
            // The student should exist before grades can be entered: this can
            // be checked by seeing if the Id property has been set
            if (student.Id != -1)
            {
                grades[student] = grade;
                return true;
            }
            return false;
        }

        public bool CheckGrades(Grade grade)
        {
            if (grades.ContainsValue(grade))
            {
                return true;
            }
            return false;
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
    }
}
