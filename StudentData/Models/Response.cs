namespace StudentData.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string StatusDescription { get; set; }
        public List<Student> GetStudents { get; set; } = new();
    }
}
