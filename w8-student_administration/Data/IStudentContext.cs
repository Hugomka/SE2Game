using System;
using System.Collections.Generic;
using StudentAdministration.Models;

namespace StudentAdministration.Data
{
    public interface IStudentContext
    {
        List<Student> GetAll();

        Student GetById(int id);

        Student Insert(Student student);

        bool Update(Student student);

        bool Delete(int id);
    }
}
