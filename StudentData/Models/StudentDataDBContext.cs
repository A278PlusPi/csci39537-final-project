using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using StudentData.Models;
using System.Data.Common;

namespace StudentData.Models
{
    public class StudentDataDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public StudentDataDBContext(DbContextOptions<StudentDataDBContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("Connect278-1");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<Student> StudentData { get; set; } = null!;
        public DbSet<Course> CourseData { get; set; } = null!;
    }
}
