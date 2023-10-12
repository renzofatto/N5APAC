using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PAC.Domain;
using PAC.IDataAccess;

namespace PAC.DataAccess;

public class StudentsRepository<T> : IStudentsRepository<Student> where T : class
{
    public static List<Student> students = new List<Student> { new Student() { Id = 1, Name = "Pedro" }, new Student() { Id = 2, Name = "Juan"}} ;

    public Student GetStudentById(int id)
    {
        return students.Find(u => u.Id == id);
    }

    public void InsertStudents(Student? student)
    {
        student!.Id = students.Count + 1;
        students.Add(student!);
    }

    public IEnumerable<Student> GetStudents(int? minAge, int? maxAge)
    {
        if (minAge.HasValue && maxAge.HasValue)
        {
            return students.Where(s => s.Age >= minAge && s.Age <= maxAge);
        }
        else if (minAge.HasValue)
        {
            return students.Where(s => s.Age >= minAge);
        }
        else if (maxAge.HasValue)
        {
            return students.Where(s => s.Age <= maxAge);
        }
        else
        {
            return students;
        }
    }
}





