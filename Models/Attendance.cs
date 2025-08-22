using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FARSbe.Models
{
    public class Attendance
    {
        public int Id { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student? Student { get; set; }

        [ForeignKey("Class")]
        public int ClassId { get; set; }
        public Class? Class { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public DateTime? TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }

        public string Status { get; set; } = "Present"; // Present, Absent, Late, etc.
    }
}