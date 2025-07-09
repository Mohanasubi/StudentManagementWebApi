using StudentManagementWebApi.Controllers.Models;

namespace StudentManagementWebApi.Controllers.Services
{
    public interface IStudentService
    {
        // Define methods for student service operations 
        public Student AddStudent(AddUpdateStudent student);

        public List<Student> GettAllStudents(); 
    }
    public class StudentService: IStudentService
    {
       private readonly List<Student> students;
        public StudentService()
        {
            students = new List<Student>()
            {
                new Student
                {
                    StudentId=1,
                    FullName="Subi",
                    Department="Computer Science",
                    YearOfStudy=2022,
                    Marks=new List<int>{85,90,78},
                    DateOfBirth=new DateOnly(2000,5,15),
                    Email="subi@gmail.com"
                }
            };
        }

        public Student AddStudent(AddUpdateStudent addUpdateStudentObj)
        {
            var newStudent = new Student
            {
                StudentId=students.Max(o=>o.StudentId)+1,
                FullName=addUpdateStudentObj.FullName,
                Department=addUpdateStudentObj.Department,
                YearOfStudy=addUpdateStudentObj.YearOfStudy,
                Marks=addUpdateStudentObj.Marks,
                DateOfBirth=addUpdateStudentObj.DateOfBirth,
                Email=addUpdateStudentObj.Email,
                Gender= addUpdateStudentObj.Gender
            };
            students.Add(newStudent);
            return newStudent;
        }

        public List<Student> GettAllStudents()
        {
            return students.ToList();
        }
    }
}
