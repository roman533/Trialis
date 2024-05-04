using Microsoft.AspNetCore.Mvc;
using Trialis.Domain.Entities;
using Trialis.Domain.Interfaces;
using Trialis.Domain.ValueObjects;

namespace Trialis.Controllers;

public class StudienfachAnalyseController : ControllerBase
{
    private readonly IStudienfachAnalyseService _studienfachAnalyseService;

    public StudienfachAnalyseController(IStudienfachAnalyseService studienfachAnalyseService)
    {
        _studienfachAnalyseService = studienfachAnalyseService;
    }
    
    [HttpPost("studienfach/{studienfachId}/student/{studentId}/note")]
    public IActionResult AddNote(int studienfachId, int studentId, [FromBody] Note note)
    {
        try
        {
            var studienfachAnalyse = _studienfachAnalyseService.GetStudienfachAnalyse(studentId, studienfachId);

            if (studienfachAnalyse == null)
            {
                return NotFound("Studienfachanalyse nicht gefunden.");
            }

            _studienfachAnalyseService.AddNote(note);

            _studienfachAnalyseService.UpdateStudienfachAnalyse(studienfachAnalyse);

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
            var studienfachAnalyse = _studienfachAnalyseService.GetStudienfachAnalyse(studentId, studienfachId);

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
            var existingAnalyse = _studienfachAnalyseService.GetStudienfachAnalyse(studentId, studienfachId);

            if (existingAnalyse == null)
            {
                return NotFound("Studienfachanalyse nicht gefunden.");
            }

            existingAnalyse.Noten = updatedAnalyse.Noten;
            
            return Ok(existingAnalyse);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Aktualisieren der Studienfachanalyse: {ex.Message}");
            return StatusCode(500, "Interner Serverfehler beim Aktualisieren der Studienfachanalyse.");
        }
    }
    
    [HttpGet("durchschnittsnote/{studentId}/{studienfachId}")]
    public IActionResult GetStudienfachDurchschnittsnote(int studentId, int studienfachId)
    {
        try
        {
            var studienfachAnalyse = _studienfachAnalyseService.GetStudienfachAnalyse(studentId, studienfachId);

            if (studienfachAnalyse == null)
            {
                return NotFound($"Studienfachanalyse für Student mit der ID {studentId} im Studienfach mit der ID {studienfachId} wurde nicht gefunden.");
            }

            double durchschnittsnote = _studienfachAnalyseService.CalculateDurchschnittsnote();

            return Ok(durchschnittsnote);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Abrufen der Durchschnittsnote des Studienfachs für Student mit der ID {studentId} im Studienfach mit der ID {studienfachId}: {ex.Message}");
            return StatusCode(500, "Interner Serverfehler beim Abrufen der Durchschnittsnote des Studienfachs.");
        }
    }

    [HttpGet("istbestanden/{studentId}/{studienfachId}")]
    public IActionResult IstBestanden(int studentId, int studienfachId)
    {
        try
        {
            var studienfachAnalyse = _studienfachAnalyseService.GetStudienfachAnalyse(studentId, studienfachId);

            if (studienfachAnalyse == null)
            {
                return NotFound($"StudienfachAnalyse für Student {studentId} und Studienfach {studienfachId} nicht gefunden.");
            }

            bool istBestanden = _studienfachAnalyseService.IstBestanden(studentId, studienfachId);

            return Ok(istBestanden);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Überprüfen, ob das Studienfach bestanden ist: {ex.Message}");
            return StatusCode(500, "Interner Serverfehler beim Überprüfen, ob das Studienfach bestanden ist.");
        }
    }
}