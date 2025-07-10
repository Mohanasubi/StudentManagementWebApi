using StudentManagementWebApi.Controllers.Models;

namespace StudentManagementWebApi.Controllers.Services
{
    public interface IStudentService
    {
        // Add method
        public Student AddStudent(AddUpdateStudent student);
        //get all students method
        public List<Student> GetAllStudents();

        //get student by id method
        public Student GetStudent(int studentId);

        //delete student
        public bool DeleteStudent(int studentId);

        //update student method 
        public Student UpdateStudent(int studentId, AddUpdateStudent addUpdateStudentObj);
    }
    // service class that implements the IStudentService interface
    public class StudentService : IStudentService
    {
        // List to hold student data
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

        // Method to add a new student
        public Student AddStudent(AddUpdateStudent addUpdateStudentObj)
        {
            var newStudent = new Student
            {
                StudentId = students.Max(o => o.StudentId) + 1,
                FullName = addUpdateStudentObj.FullName,
                Department = addUpdateStudentObj.Department,
                YearOfStudy = addUpdateStudentObj.YearOfStudy,
                Marks = addUpdateStudentObj.Marks,
                DateOfBirth = addUpdateStudentObj.DateOfBirth,
                Email = addUpdateStudentObj.Email,
                Gender = addUpdateStudentObj.Gender
            };
            students.Add(newStudent);
            return newStudent;
        }

        // Method to get all students
        public List<Student> GetAllStudents()
        {
            return students.ToList();
        }

        // Method to get a student by ID
        public Student GetStudent(int studentId)
        {
            var selectStudent = students.FirstOrDefault(o => o.StudentId == studentId);
            return selectStudent;
        }

        //method to delete a student by ID
        public bool DeleteStudent(int studentId)
        {
            var student = students.FirstOrDefault(o => o.StudentId == studentId);
            if (student != null)
            {
                students.Remove(student);
                return true;
            }
            return false;
        }

        // Method to update a student by ID

        public Student UpdateStudent(int studentId, AddUpdateStudent addUpdateStudentObj)
        {
            var student = students.FirstOrDefault(o => o.StudentId == studentId);
            if (student != null)
            {
                student.FullName = addUpdateStudentObj.FullName;
                student.Department = addUpdateStudentObj.Department;
                student.YearOfStudy = addUpdateStudentObj.YearOfStudy;
                student.Marks = addUpdateStudentObj.Marks;
                student.DateOfBirth = addUpdateStudentObj.DateOfBirth;
                student.Email = addUpdateStudentObj.Email;
                student.Gender = addUpdateStudentObj.Gender;
                return student;
            }
            return null;



        }
    }
}
