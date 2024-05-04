using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Trialis.Domain.Entities;
using Trialis.Domain.Interfaces;
using Trialis.Domain.ValueObjects;

namespace Trialis.Controllers;

[ApiController]
[Route("api/pruefungsaufgabe")]
public class PruefungsaufgabeController : ControllerBase
{
    private readonly IPruefungsaufgabeService _pruefungsaufgabeService;

    public PruefungsaufgabeController(IPruefungsaufgabeService pruefungsaufgabeService)
    {
        _pruefungsaufgabeService = pruefungsaufgabeService;
    }

    [HttpGet]
    public IActionResult GetAllPruefungsaufgaben()
    {
        try
        {
            var pruefungsaufgaben = _pruefungsaufgabeService.GetAllPruefungsaufgaben();
            return Ok(pruefungsaufgaben);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Abrufen aller Prüfungsaufgaben: {ex.Message}");
            return StatusCode(500, "Interner Serverfehler beim Abrufen aller Prüfungsaufgaben.");
        }
    }
    
    [HttpGet("{id}")]
    public IActionResult GetPruefungsaufgabeById(int id)
    {
        try
        {
            var pruefungsaufgabe = _pruefungsaufgabeService.GetPruefungsaufgabeById(id);
            if (pruefungsaufgabe == null)
            {
                return NotFound($"Prüfungsaufgabe mit der ID {id} wurde nicht gefunden.");
            }

            return Ok(pruefungsaufgabe);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Abrufen der Prüfungsaufgabe mit der ID {id}: {ex.Message}");
            return StatusCode(500, "Interner Serverfehler beim Abrufen der Prüfungsaufgabe.");
        }
    }

    
    [HttpPost]
    public IActionResult AddPruefungaufgabe([FromBody] Pruefungsaufgabe newPruefungsaufgabe)
    {
        try
        {
            if (newPruefungsaufgabe == null)
            {
                return BadRequest("Neue Prüfungsaufgabe darf nicht null sein.");
            }

            _pruefungsaufgabeService.AddPruefungsaufgabe(newPruefungsaufgabe);
            return CreatedAtAction(nameof(GetPruefungsaufgabeById), new { id = newPruefungsaufgabe.Id }, newPruefungsaufgabe);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Hinzufügen der neuen Prüfungsaufgabe: {ex.Message}");
            return StatusCode(500, "Interner Serverfehler beim Hinzufügen der neuen Prüfungsaufgabe.");
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePruefungsaufgabe(int id, Pruefungsaufgabe pruefungsaufgabe)
    {
        try
        {
            _pruefungsaufgabeService.UpdatePruefungsaufgabe(id, pruefungsaufgabe);
            return Ok("Prüfungsaufgabe erfolgreich aktualisiert.");
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Aktualisieren der Prüfungsaufgabe mit der ID {id}: {ex.Message}");
            return StatusCode(500, "Interner Serverfehler beim Aktualisieren der Prüfungsaufgabe.");
        }
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeletePruefungsaufgabe(int id)
    {
        try
        {
            _pruefungsaufgabeService.DeletePruefungsaufgabe(id);
            return Ok("Prüfungsaufgabe erfolgreich gelöscht.");
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Löschen der Prüfungsaufgabe mit der ID {id}: {ex.Message}");
            return StatusCode(500, "Interner Serverfehler beim Löschen der Prüfungsaufgabe.");
        }
    }
    
    [HttpPut("{id}/frageantwort")]
    public IActionResult UpdateFrageAntwort(int id, [FromBody] Pruefungsaufgabe pruefungsaufgabe)
    {
        try
        {
            _pruefungsaufgabeService.UpdateFrageAntwort(id, pruefungsaufgabe.Frage, pruefungsaufgabe.Antwort);
            return Ok("Frage und Antwort der Prüfungsaufgabe erfolgreich aktualisiert.");
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Aktualisieren der Frage und Antwort der Prüfungsaufgabe mit der ID {id}: {ex.Message}");
            return StatusCode(500, "Interner Serverfehler beim Aktualisieren der Frage und Antwort der Prüfungsaufgabe.");
        }
    }
    
    [HttpPut("{id}/schwierigkeitsgrad")]
    public IActionResult UpdateSchwierigkeitsgrad(int id, [FromBody] Schwierigkeitsgrad neuerSchwierigkeitsgrad)
    {
        try
        {
            _pruefungsaufgabeService.UpdateSchwierigkeitsgrad(id, neuerSchwierigkeitsgrad);
            return Ok("Schwierigkeitsgrad der Prüfungsaufgabe erfolgreich aktualisiert.");
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Aktualisieren des Schwierigkeitsgrads der Prüfungsaufgabe mit der ID {id}: {ex.Message}");
            return StatusCode(500, "Interner Serverfehler beim Aktualisieren des Schwierigkeitsgrads der Prüfungsaufgabe.");
        }
    }
}