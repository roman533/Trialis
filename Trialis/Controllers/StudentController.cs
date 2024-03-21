using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Trialis.Domain.Entities;

namespace Trialis.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentController : ControllerBase
    {
        private List<Student> _students = new List<Student>();

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            return Ok(_students);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost]
        public IActionResult AddStudent([FromBody] Student student)
        {
            // Hier könnten Validierungen oder weitere Logik erfolgen
            _students.Add(student);

            return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
        }
    }
}