using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PAC.BusinessLogic;
using PAC.Domain;
using PAC.IBusinessLogic;
using PAC.WebAPI.Filters;

namespace PAC.WebAPI
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentLogic _studentLogic;

        public StudentController(IStudentLogic studentLogic)
        {
            _studentLogic = studentLogic;
        }

        [HttpPost]
        [ServiceFilter(typeof(AuthorizationFilter))]
        public ActionResult<Student> AddStudent([FromBody] Student student)
        {
            try
            {
                _studentLogic.InsertStudents(student);
                return CreatedAtAction("GetStudentById", new { id = student.Id }, student);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudents(int? minAge, int? maxAge)
        {
            try
            {
                var students = _studentLogic.GetStudents(minAge, maxAge);
                return Ok(students);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }


        [HttpGet("{id}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            try
            {
                var student = _studentLogic.GetStudentById(id);
                if (student != null)
                {
                    return Ok(student);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

    }
}
   