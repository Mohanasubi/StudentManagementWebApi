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
            var students = iStudentService.GetAllStudents();
            return Ok(students);
        }

        [HttpGet]
        [Route("{studentId}")]
        // GetStudentById method to retrieve a student by ID
        public IActionResult GetStudentById(int studentId)
        {
            var student = iStudentService.GetStudent(studentId);
            if (student != null)
            {
                return Ok(student);
            }
            return NotFound();
        }

        // DeleteStudent method to delete a student by ID
        [HttpDelete]
        public IActionResult DeleteStudentById(int studentId)
        {
            var isDeleted = iStudentService.DeleteStudent(studentId);
            if (isDeleted)
            {
                return Ok(new { message = "Student deleted successfully" });
            }
            return NotFound(new { message = "Student not found" });
        }

        //put method to update student details

        [HttpPut]
        public IActionResult UpdateStudentById(int studentId, AddUpdateStudent addUpdateStudentObj)
        {
            var updatedStudent = iStudentService.UpdateStudent(studentId, addUpdateStudentObj);
            if (updatedStudent != null)
            {
                return Ok(new { message = "Student updated successfully" });
            }
            return NotFound(new { message = "Student not found" });
        }
    }
}
