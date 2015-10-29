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
    public class StudentTest
    {
        private StudentRepository studentRepo;

        [TestInitialize]
        public void Initialize()
        {
            // Create a new repository for persisting students, but as we are
            // currently using the repository for unit tests, we don't want to
            // touch the database. Instead, we use a "mocked" database that
            // mimics the behavior of the real database.
            studentRepo = new StudentRepository(new StudentMemoryContext());
            studentRepo.Insert(new Student(1, "John Doe", "j.doe@student.fontys.nl"));
        }

        [TestMethod]
        public void TestStudentConstructor()
        {
            try
            {
                Student student = new Student("Foo Bar", "f.bar.fontys.nl");
                Assert.Fail("At-sign (@) should be required in the email");
            }
            catch (FormatException) { }
            try
            {
                Student student = new Student("Foo Bar", "f.bar@fontys");
                Assert.Fail("A dot should be present after the at-sign");
            }
            catch (FormatException) { }
            try
            {
                Student student = new Student("Foo Bar", "f.bar@fontys.");
                Assert.Fail("A top-level domain should be present after the last dot");
            }
            catch (FormatException) { }
        }

        [TestMethod]
        public void TestById()
        {
            Assert.AreEqual(1, studentRepo.GetById(1).Id, "Student should exist");
            Assert.AreEqual(null, studentRepo.GetById(2), "Student should not exist");

            studentRepo.Insert(new Student(2, "Foo Bar", "f.bar@student.fontys.nl"));
            Assert.AreEqual(2, studentRepo.GetById(2).Id, "Inserted student should exist");
        }

        [TestMethod]
        public void TestInsertAndGetAll()
        {
            int startCount = studentRepo.GetAll().Count;

            studentRepo.Insert(new Student("Foo Bar", "f.bar@student.fontys.nl"));
            Assert.AreEqual(startCount + 1, studentRepo.GetAll().Count, "Student should have been added");

            studentRepo.Insert(new Student(2, "Foo Bar", "f.bar@student.fontys.nl"));
            Assert.AreEqual(startCount + 1, studentRepo.GetAll().Count, "Duplicate id not allowed");
        }

        [TestMethod]
        public void TestDelete()
        {
            Assert.AreEqual(true, studentRepo.Delete(1), "Deletion should have succeeded");
            Assert.AreEqual(0, studentRepo.GetAll().Count);

            Assert.IsTrue(studentRepo.Insert(new Student(1, "John Doe", "j.doe@student.fontys.nl")) != null);
            Assert.IsTrue(studentRepo.Insert(new Student(2, "Foo Bar", "f.bar@student.fontys.nl")) != null);
            Assert.AreEqual(2, studentRepo.GetAll().Count);
            Assert.AreEqual(true, studentRepo.Delete(1), "Deletion should have succeeded");
            Assert.AreEqual(1, studentRepo.GetAll().Count);
            Assert.AreEqual(false, studentRepo.Delete(1), "Deletion should have failed");
            Assert.AreEqual(1, studentRepo.GetAll().Count);
            Assert.AreEqual(true, studentRepo.Delete(2), "Deletion should have succeeded");
            Assert.AreEqual(0, studentRepo.GetAll().Count);

            Assert.IsTrue(studentRepo.Insert(new Student(2, "Foo Bar", "f.bar@fontys.nl")) == null, "Invalid email");
        }

        [TestMethod]
        public void TestUpdate()
        {
            Student student = studentRepo.GetById(1);
            Assert.AreEqual("John Doe", student.Name, "Expected student name incorrect");
            Assert.AreEqual("j.doe@student.fontys.nl", student.Email, "Expected student email incorrect");

            student.Name = "Foo Bar";
            Assert.IsTrue(studentRepo.Update(student), "Update should succeed");
            student = studentRepo.GetById(1);
            Assert.AreEqual("Foo Bar", student.Name, "Student name should have been updated");
            Assert.AreEqual("j.doe@student.fontys.nl", student.Email, "Student email should not have changed");

            student = new Student("Jane Doe", "jane.doe@student.fontys.nl");
            Assert.IsFalse(studentRepo.Update(student), "Can not update students that have no ID");

            student = new Student(9, "Jane Doe", "jane.doe@student.fontys.nl");
            Assert.IsFalse(studentRepo.Update(student), "Can not update students that are not in the database");

            student = studentRepo.GetById(1);
            student.Email = "j.doe@fontys.nl";
            Assert.IsFalse(studentRepo.Update(student), "Can not update students with an invalid email");
        }
    }

    /// <summary>
    /// Mock class to mimic the real database to allow the unit tests to run
    /// without affecting any stored data.
    /// </summary>
    public class StudentMemoryContext : IStudentContext
    {
        // This list holds our student data: consider this the database the 
        // unit tests will work with
        private List<Student> students = new List<Student>();

        public List<Student> GetAll()
        {
            return students;
        }

        public Student GetById(int id)
        {
            foreach (Student student in students)
            {
                if (student.Id == id)
                {
                    return student;
                }
            }
            return null;
        }

        public Student Insert(Student student)
        {
            // To properly mock the database behavior, we should check if a
            // student with this id already exists: it shouldn't be added if so
            if (this.GetById(student.Id) == null)
            {
                // If the student didn't exist, determine the new id to assign
                int maxId = 0;
                foreach (Student s in students)
                {
                    if (s.Id > maxId)
                    {
                        maxId = s.Id;
                    }
                }

                // Create the new student with the found id and insert it into
                // our mocked database (the students list)
                student = new Student(maxId + 1, student.Name, student.Email);
                students.Add(student);
                return student;
            }
            return null;
        }

        public bool Update(Student student)
        {
            // Updating students can be mimicked by removing an existing student
            // and replacing it with the passed instance
            foreach (Student s in students)
            {
                if (s.Id == student.Id)
                {
                    students.Remove(s);
                    students.Add(student);
                    return true;
                }
            }

            return false;
        }

        public bool Delete(int id)
        {
            if (this.GetById(id) != null)
            {
                students.Remove(this.GetById(id));
                return true;
            }
            return false;
        }
    }
}
