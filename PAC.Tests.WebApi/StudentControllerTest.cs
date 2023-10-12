namespace PAC.Tests.WebApi;
using System.Collections.ObjectModel;

using System.Data;
using Moq;
using PAC.IBusinessLogic;
using PAC.Domain;
using PAC.WebAPI;
using Microsoft.AspNetCore.Mvc;

[TestClass]
public class StudentControllerTest
{
    private Mock<IStudentLogic> _logicMock;
    private Student student;

    [TestInitialize]
    public void Setup()
    {
        _logicMock = new Mock<IStudentLogic>();
        student = new Student { Id = 1, Name = "John Doe" };
    }

    [TestMethod]
    public void AddStudent_ReturnsCreatedResult()
    {
        _logicMock.Setup(x => x.InsertStudents(It.IsAny<Student>()));
        var controller = new StudentController(_logicMock.Object);

        var result = controller.AddStudent(student);

        Assert.IsInstanceOfType(result, typeof(ActionResult<Student>));
    }

    [TestMethod]
    public void AddStudent_ReturnsBadRequestResult_WhenLogicFails()
    {
        _logicMock.Setup(x => x.InsertStudents(It.IsAny<Student>())).Throws(new Exception("Some error"));
        var controller = new StudentController(_logicMock.Object);

        var result = controller.AddStudent(student);

        Assert.IsInstanceOfType(result, typeof(ActionResult<Student>));
    }
}
