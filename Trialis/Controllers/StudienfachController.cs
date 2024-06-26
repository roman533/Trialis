using Microsoft.AspNetCore.Mvc;
using Trialis.Domain.Entities;
using Trialis.Domain.Interfaces;

namespace Trialis.Controllers;

[ApiController]
[Route("api/studienfach")]
public class StudienfachController : ControllerBase
{
    private readonly IStudienfachService _studienfachSerivce;

    public StudienfachController(IStudienfachService studienfachSerivce)
    {
        _studienfachSerivce = studienfachSerivce;
    }
    
    public IActionResult GetAllStudienfächer()
    {
        try
        {
            var studienfächer = _studienfachSerivce.GetAllStudienfächer();
            return Ok(studienfächer);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Abrufen aller Studienfächer: {ex.Message}");
            return StatusCode(500, "Interner Serverfehler beim Abrufen aller Studienfächer.");
        }
    }
    
    [HttpGet("{id}")]
    public IActionResult GetStudienfachById(int id)
    {
        try
        {
            var studienfach = _studienfachSerivce.GetStudienfachById(id);
            if (studienfach == null)
            {
                return NotFound($"Studienfach mit ID {id} wurde nicht gefunden.");
            }

            return Ok(studienfach);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Abrufen des Studienfachs mit ID {id}: {ex.Message}");
            return StatusCode(500, "Interner Serverfehler beim Abrufen des Studienfachs.");
        }
    }

    [HttpPost]
    public IActionResult AddStudienfach(Studienfach studienfach)
    {
        try
        {
            _studienfachSerivce.AddStudienfach(studienfach);
            return CreatedAtAction(nameof(GetStudienfachById), new { id = studienfach.Id }, studienfach);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Hinzufügen des Studienfachs: {ex.Message}");
            return StatusCode(500, "Interner Serverfehler beim Hinzufügen des Studienfachs.");
        }
    }
    
    [HttpPut("{id}")]
    public IActionResult UpdateStudienfach(int id, Studienfach updatedStudienfach)
    {
        try
        {
            var existingStudienfach = _studienfachSerivce.GetStudienfachById(id);
            if (existingStudienfach == null)
            {
                return NotFound($"Studienfach mit ID {id} wurde nicht gefunden.");
            }

            if (updatedStudienfach == null)
            {
                return BadRequest("Ungültige Daten für das Studienfach.");
            }

            existingStudienfach.Name = updatedStudienfach.Name;
            existingStudienfach.Schwierigkeitsgrad = updatedStudienfach.Schwierigkeitsgrad;

            _studienfachSerivce.UpdateStudienfach(existingStudienfach);

            return Ok("Studienfach erfolgreich aktualisiert.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Aktualisieren des Studienfachs: {ex.Message}");
            return StatusCode(500, "Interner Serverfehler beim Aktualisieren des Studienfachs.");
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteStudienfach(int id)
    {
        try
        {
            var studienfachToDelete = _studienfachSerivce.GetStudienfachById(id);
            if (studienfachToDelete == null)
            {
                return NotFound($"Studienfach mit ID {id} wurde nicht gefunden.");
            }

            _studienfachSerivce.DeleteStudienfach(studienfachToDelete);
        
            return NoContent();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Löschen des Studienfachs mit ID {id}: {ex.Message}");
            return StatusCode(500, "Interner Serverfehler beim Löschen des Studienfachs.");
        }
    }

}