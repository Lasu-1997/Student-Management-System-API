using Microsoft.EntityFrameworkCore;
using Student_Management_System_API.Models;

namespace Student_Management_System_API.Services
{
    public class StudentManagementDbContext : DbContext
    {
        public StudentManagementDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
    }
}
