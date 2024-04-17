using Microsoft.AspNetCore.Mvc;
using Trialis.Domain.Entities;
using Trialis.Domain.Interfaces;

namespace Trialis.Controllers
{
    [ApiController]
    [Route("api/professors")]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessor _professorRepository;

        public ProfessorController(IProfessor professorRepository)
        {
            _professorRepository = professorRepository;
        }
        
        [HttpGet]
        public IActionResult GetAllProfessors()
        {
            try
            {
                var professors = _professorRepository.GetAllProfessors();

                return Ok(professors);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Abrufen der Professoren: {ex.Message}");
                return StatusCode(500, "Interner Serverfehler beim Abrufen der Professoren.");
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetProfessorById(int id)
        {
            try
            {
                var professor = _professorRepository.GetProfessorById(id);

                if (professor == null)
                {
                    return NotFound($"Professor mit der ID {id} wurde nicht gefunden.");
                }

                return Ok(professor);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Abrufen des Professors: {ex.Message}");
                return StatusCode(500, "Interner Serverfehler beim Abrufen des Professors.");
            }
        }


        [HttpPost]
        public IActionResult AddProfessor([FromBody] Professor professor)
        {
            try
            {
                if (professor == null)
                {
                    return BadRequest("Das Professor-Objekt darf nicht null sein.");
                }

                _professorRepository.AddProfessor(professor);

                return Ok(professor);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Hinzufügen des Professors: {ex.Message}");
                return StatusCode(500, "Interner Serverfehler beim Hinzufügen des Professors.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProfessor(int id, [FromBody] Professor updatedProfessor)
        {
            try
            {
                if (updatedProfessor == null)
                {
                    return BadRequest("Das Professor-Objekt darf nicht null sein.");
                }

                if (id != updatedProfessor.Id)
                {
                    return BadRequest("Die ID im Pfad stimmt nicht mit der ID im übergebenen Professor-Objekt überein.");
                }

                _professorRepository.UpdateProfessor(updatedProfessor);

                return Ok(updatedProfessor);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Aktualisieren des Professors: {ex.Message}");
                return StatusCode(500, "Interner Serverfehler beim Aktualisieren des Professors.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProfessor(int id)
        {
            try
            {
                _professorRepository.DeleteProfessor(id);
                return Ok($"Professor with ID {id} has been deleted.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting professor: {ex.Message}");
                return StatusCode(500, "Internal server error while deleting professor.");
            }
        }

        [HttpPut("{id}/name")]
        public IActionResult UpdateName(int id, [FromBody] string newName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(newName))
                {
                    return BadRequest("Neuer Name kann nicht null oder leer sein.");
                }

                _professorRepository.UpdateName(id, newName);
                return Ok($"Name des Professors mit ID {id} wurde geändert.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Aktualisieren vom Namen: {ex.Message}");
                return StatusCode(500, "Interner Serverfehler beim Aktualisieren des Namens.");
            }
        }
        
        [HttpPut("{id}/fachgebiet")]
        public IActionResult UpdateFachgebiet(int id, [FromBody] string newFachgebiet)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(newFachgebiet))
                {
                    return BadRequest("Neues Fachgebiet darf nicht null oder leer sein.");
                }

                _professorRepository.UpdateFachgebiet(id, newFachgebiet);
                return Ok($"Fachgebiet des Professors mit der ID {id} wurde aktualisiert.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Aktualisieren des Fachgebiets des Professors: {ex.Message}");
                return StatusCode(500, "Interner Serverfehler beim Aktualisieren des Fachgebiets des Professors.");
            }
        }
    }
}