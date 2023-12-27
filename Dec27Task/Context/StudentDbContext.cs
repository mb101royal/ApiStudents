using Dec27Task.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dec27Task.Context
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
