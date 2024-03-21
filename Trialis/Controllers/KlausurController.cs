using Microsoft.AspNetCore.Mvc;
using Trialis.Domain.Entities;

namespace Trialis.Api.Controllers
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

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] Student updatedStudent)
        {
            var existingStudent = _students.FirstOrDefault(s => s.Id == id);
            if (existingStudent == null)
            {
                return NotFound();
            }

            // Hier könnten Validierungen oder weitere Logik erfolgen
            existingStudent.Name = updatedStudent.Name;
            existingStudent.Matrikelnummer = updatedStudent.Matrikelnummer;
            existingStudent.Studiengang = updatedStudent.Studiengang;
            existingStudent.Semester = updatedStudent.Semester;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var studentToRemove = _students.FirstOrDefault(s => s.Id == id);
            if (studentToRemove == null)
            {
                return NotFound();
            }

            _students.Remove(studentToRemove);

            return NoContent();
        }
    }
}