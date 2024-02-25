using System.ComponentModel.DataAnnotations;

namespace Student_Management_System_API.Models
{
    public class Student
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; } = "";

        [MaxLength(100)]
        public string LastName { get; set; } = "";
        public DateTime DateOfBirth { get; set; }

        [MaxLength(100)]
        public string Address { get; set; } = "";

    }
}
