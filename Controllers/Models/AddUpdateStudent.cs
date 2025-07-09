namespace StudentManagementWebApi.Controllers.Models
{
    public class AddUpdateStudent
    {
        public string FullName { get; set; }
        public string Department { get; set; }
        public int YearOfStudy { get; set; }
        public List<int> Marks { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
    }
}
