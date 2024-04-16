using Microsoft.AspNetCore.Mvc;
using Trialis.Domain.Entities;

namespace Trialis.Controllers
{
    [ApiController]
    [Route("api/professors")]
    public class ProfessorController : ControllerBase
    {
        private readonly List<Professor> _professors = new List<Professor>();

        [HttpGet]
        public IActionResult GetAllProfessors()
        {
            return Ok(_professors);
        }

        [HttpGet("{id}")]
        public IActionResult GetProfessorById(int id)
        {
            var professor = _professors.FirstOrDefault(p => p.Id == id);
            if (professor == null)
            {
                return NotFound();
            }

            return Ok(professor);
        }

        [HttpPost]
        public IActionResult AddProfessor([FromBody] Professor professor)
        {
            _professors.Add(professor);

            return CreatedAtAction(nameof(GetProfessorById), new { id = professor.Id }, professor);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProfessor(int id, [FromBody] Professor updatedProfessor)
        {
            var existingProfessor = _professors.FirstOrDefault(p => p.Id == id);
            if (existingProfessor == null)
            {
                return NotFound();
            }

            existingProfessor.Name = updatedProfessor.Name;
            existingProfessor.Fachgebiet = updatedProfessor.Fachgebiet;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProfessor(int id)
        {
            var professorToRemove = _professors.FirstOrDefault(p => p.Id == id);
            if (professorToRemove == null)
            {
                return NotFound();
            }

            _professors.Remove(professorToRemove);

            return NoContent();
        }
    }
}