using System.ComponentModel.DataAnnotations;

namespace Dec27Task.DTOs.StudentDTOs
{
    public class StudentDetailsDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public byte Age { get; set; }
    }
}
