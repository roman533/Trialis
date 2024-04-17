using Microsoft.AspNetCore.Mvc;
using Trialis.Domain.Entities;
using Trialis.Domain.Interfaces;

namespace Trialis.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentController : ControllerBase
    {
        private List<Student> _students = new List<Student>();
        private readonly IStudent _studentRepository;

        public StudentController(IStudent studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            try
            {
                var students = _studentRepository.GetAllStudents();
                return Ok(students);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Abrufen aller Studenten: {ex.Message}");
                return StatusCode(500, "Interner Serverfehler beim Abrufen aller Studenten.");
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            try
            {
                var student = _studentRepository.GetStudentById(id);
            
                if (student == null)
                {
                    return NotFound($"Student mit ID {id} wurde nicht gefunden.");
                }
            
                return Ok(student);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Abrufen des Studenten mit ID {id}: {ex.Message}");
                return StatusCode(500, "Interner Serverfehler beim Abrufen des Studenten.");
            }
        }


        [HttpPost]
        public IActionResult AddStudent([FromBody] Student student)
        {
            try
            {
                _studentRepository.AddStudent(student);
                return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Hinzufügen des Studenten: {ex.Message}");
                return StatusCode(500, "Interner Serverfehler beim Hinzufügen des Studenten.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, string newName)
        {
            try
            {
                var existingStudent = _studentRepository.GetStudentById(id);

                if (existingStudent == null)
                {
                    return NotFound("Student nicht gefunden.");
                }

                existingStudent.Name = newName;
                _studentRepository.UpdateStudent(existingStudent);
                return Ok("Student erfolgreich aktualisiert.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Aktualisieren des Studenten: {ex.Message}");
                return StatusCode(500, "Interner Serverfehler beim Aktualisieren des Studenten.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                _studentRepository.DeleteStudent(id);
                return Ok("Student erfolgreich gelöscht.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Löschen des Studenten: {ex.Message}");
                return StatusCode(500, "Interner Serverfehler beim Löschen des Studenten.");
            }
        }
        
        [HttpGet("{id}")]
        public IActionResult GetStudentsByStudienfach(int studienfachId)
        {
            try
            {
                var students = _studentRepository.GetStudentsByStudienfach(studienfachId);
            
                if (students == null || students.Count == 0)
                {
                    return NotFound($"Keine Studenten gefunden, die das Studienfach mit ID {studienfachId} haben.");
                }
            
                return Ok(students);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Abrufen von Studenten nach Studienfach: {ex.Message}");
                return StatusCode(500, "Interner Serverfehler beim Abrufen von Studenten nach Studienfach.");
            }
        }
    }
}