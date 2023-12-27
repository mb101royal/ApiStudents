using System.ComponentModel.DataAnnotations;

namespace Dec27Task.DTOs.StudentDTOs
{
    public class StudentUpdateDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Surname { get; set; }
        [Required]
        public byte Age { get; set; }
    }
}
