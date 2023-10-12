using PAC.Domain;

namespace PAC.IDataAccess;

public interface IStudentsRepository<T> where T : class
{
    Student GetStudentById(int id);
    void InsertStudents(Student? student);
    IEnumerable<Student> GetStudents(int? minAge, int? maxAge);

}

