using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentData.Models
{
    public class Student
    {
        [Key]
        [Column(Order=1)]
        public int EMPLID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [ForeignKey("Course")]
        public string CourseId { get; set; }
        public short? Semester { get; set; } = null;
        public double? GPA { get; set; } = null;
        public Course? Course { get; set; } = null;
    }
}
