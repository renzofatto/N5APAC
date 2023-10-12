namespace PAC.IBusinessLogic;
using PAC.Domain;

public interface IStudentLogic
{
    IEnumerable<Student> GetStudents(int? minAge, int? maxAge);
    Student GetStudentById(int id);
    void InsertStudents(Student? student);

}

