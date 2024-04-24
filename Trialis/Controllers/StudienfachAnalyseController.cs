using Microsoft.AspNetCore.Mvc;
using Trialis.Domain.Entities;
using Trialis.Domain.Interfaces;
using Trialis.Domain.ValueObjects;

namespace Trialis.Controllers;

public class StudienfachAnalyseController : ControllerBase
{
    private readonly IStudienfachAnalyse _studienfachAnalyseRepository;

    public StudienfachAnalyseController(IStudienfachAnalyse studienfachAnalyseRepository)
    {
        _studienfachAnalyseRepository = studienfachAnalyseRepository;
    }
    
    [HttpPost("studienfach/{studienfachId}/student/{studentId}/note")]
    public IActionResult AddNote(int studienfachId, int studentId, [FromBody] Note note)
    {
        try
        {
            var studienfachAnalyse = _studienfachAnalyseRepository.GetStudienfachAnalyse(studentId, studienfachId);

            if (studienfachAnalyse == null)
            {
                return NotFound("Studienfachanalyse nicht gefunden.");
            }

            studienfachAnalyse.AddNote(note);

            _studienfachAnalyseRepository.UpdateStudienfachAnalyse(studienfachAnalyse);

            return Ok("Note wurde zur Studienfachanalyse hinzugefügt.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Hinzufügen der Note zur Studienfachanalyse: {ex.Message}");
            return StatusCode(500, "Interner Serverfehler beim Hinzufügen der Note zur Studienfachanalyse.");
        }
    }

    [HttpGet("studienfach/{studienfachId}/student/{studentId}/analyse")]
    public IActionResult GetStudienfachAnalyse(int studienfachId, int studentId)
    {
        try
        {
            var studienfachAnalyse = _studienfachAnalyseRepository.GetStudienfachAnalyse(studentId, studienfachId);

            if (studienfachAnalyse == null)
            {
                return NotFound("Studienfachanalyse nicht gefunden.");
            }

            return Ok(studienfachAnalyse);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Abrufen der Studienfachanalyse: {ex.Message}");
            return StatusCode(500, "Interner Serverfehler beim Abrufen der Studienfachanalyse.");
        }
    }

    [HttpPut("{studentId}/{studienfachId}")]
    public IActionResult UpdateStudienfachAnalyse(int studentId, int studienfachId, [FromBody] StudienfachAnalyse updatedAnalyse)
    {
        try
        {
            // Beispiel Logik zum Aktualisieren der Studienfachanalyse
            // Hier müsstest du deine tatsächliche Logik für die Aktualisierung einfügen
            var existingAnalyse = _studienfachAnalyseRepository.GetStudienfachAnalyse(studentId, studienfachId);

            if (existingAnalyse == null)
            {
                return NotFound("Studienfachanalyse nicht gefunden.");
            }

            // Aktualisiere die Werte mit den Werten aus updatedAnalyse
            existingAnalyse.Noten = updatedAnalyse.Noten;

            // Hier könnte auch weitere Logik für die Aktualisierung der Analyse stehen

            return Ok(existingAnalyse);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Aktualisieren der Studienfachanalyse: {ex.Message}");
            return StatusCode(500, "Interner Serverfehler beim Aktualisieren der Studienfachanalyse.");
        }
    }
}