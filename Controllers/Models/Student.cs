namespace StudentManagementWebApi.Controllers.Models
{
   
    // This class represents a student entity in the system
    public class Student
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }
        public int YearOfStudy { get; set; }
        public List<int> Marks { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
    }
}
