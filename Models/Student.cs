using System.ComponentModel.DataAnnotations;

namespace FARSbe.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string StudentNumber { get; set; } = string.Empty;

        [Required]
        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        // Later: store face embedding or photo path
        public string PhotoPath { get; set; } = string.Empty;
    }
}