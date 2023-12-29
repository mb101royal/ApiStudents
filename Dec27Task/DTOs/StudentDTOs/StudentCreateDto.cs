using System.ComponentModel.DataAnnotations;

namespace Dec27Task.Dtos.StudentDtos
{
    public class StudentCreateDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Surname { get; set; }
        [Required]
        public byte Age { get; set; }
    }
}
