using System.ComponentModel.DataAnnotations;

namespace Dec27Task.Entities
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Surname { get; set; }
        [Required]
        public byte Age { get; set; }
    }
}
