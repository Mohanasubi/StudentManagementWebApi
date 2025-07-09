using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementWebApi.Controllers.Models;
using StudentManagementWebApi.Controllers.Services;

namespace StudentManagementWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService iStudentService;

        public StudentController(IStudentService studentService)
        {
            iStudentService = studentService;
        }

        [HttpPost]
        public IActionResult AddNewStudentPost(AddUpdateStudent addNewStudent)
        {
            var newStudent = iStudentService.AddStudent(addNewStudent);
            return Ok(new
            {
                message = "Success"
            });
        }
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = iStudentService.GettAllStudents();
            return Ok(students);
        }
    }
}
