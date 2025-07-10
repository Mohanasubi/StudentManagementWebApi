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
        //invoking the interface
        private readonly IStudentService iStudentService;

        //constructor to inject the service
        public StudentController(IStudentService studentService)
        {
            iStudentService = studentService;
        }

        [HttpPost]
        // AddNewStudentPost method to add a new student
        public IActionResult AddNewStudentPost(AddUpdateStudent addNewStudent)
        {
            var newStudent = iStudentService.AddStudent(addNewStudent);
            return Ok(new
            {
                message = "Success"
            });
        }
        [HttpGet]
        // GetAllStudents method to retrieve all students
        public IActionResult GetAllStudents()
        {
            var students = iStudentService.GettAllStudents();
            return Ok(students);
        }
    }
}
