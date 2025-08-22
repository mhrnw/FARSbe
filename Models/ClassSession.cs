using System.ComponentModel.DataAnnotations;

namespace FARSbe.Models
{
    public class Class
    {
        public int Id { get; set; }

        [Required]
        public string ClassName { get; set; } = string.Empty;

        public string Subject { get; set; } = string.Empty;

        public string Professor { get; set; } = string.Empty;

        public DateTime Schedule { get; set; }
    }
}