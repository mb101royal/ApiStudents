using Dec27Task.Context;
using Dec27Task.DTOs.StudentDTOs;
using Dec27Task.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;

namespace Dec27Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        StudentDbContext _context { get; }

        public StudentsController(StudentDbContext db)
        {
            _context = db;
        }

        [HttpGet("All")]
        public async Task<IActionResult> Get()
        {
            var studentsFromDb = await _context.Students.AsNoTracking().Select(student => new StudentDetailsDto
            {
                Name = student.Name,
                Surname = student.Surname,
                Age = student.Age,
                Id = student.Id,
            }).ToListAsync();

            return Ok(studentsFromDb);
        }

        [HttpGet("GetById/{id?}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null || id <= 0) return BadRequest();
            
            var studentFromDb = await _context.Students.AsNoTracking().FirstOrDefaultAsync(student => student.Id == id);

            if (studentFromDb == null) return NotFound();

            return Ok(studentFromDb);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Post(StudentCreateDto studentDto)
        {
            Student newStudent = new()
            {
                Name = studentDto.Name,
                Surname = studentDto.Surname,
                Age = studentDto.Age,
            };

            await _context.AddAsync(newStudent);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("Update/{id?}")]
        public async Task<IActionResult> Put(int? id, StudentUpdateDto studentDto)
        {
            if (id == null || id <= 0) return BadRequest();

            var studentFromDb = await _context.Students.FindAsync(id);

            if (studentFromDb == null) return NotFound();

            studentFromDb.Name = studentDto.Name;
            studentFromDb.Surname = studentDto.Surname;
            studentFromDb.Age = studentDto.Age;

            await _context.SaveChangesAsync();

            return Ok(studentFromDb);
        }

        [HttpDelete("Delete/{id?}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id <= 0) return BadRequest();

            var studentFromDb = await _context.Students.FindAsync(id);

            if (studentFromDb == null) return NotFound();

            _context.Students.Remove(studentFromDb);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
