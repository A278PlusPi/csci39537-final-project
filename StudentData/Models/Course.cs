namespace StudentData.Models
{
    public class Course
    {
        public string CourseId { get; set; }
        public string? CourseName { get; set; } = null;

        public List<Student> Students { get; set; } = new();
    }
}
