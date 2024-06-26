using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Trialis.Domain.Entities;
using Trialis.Domain.Interfaces;
using Trialis.Domain.ValueObjects;

namespace Trialis.Controllers
{
    [ApiController]
    [Route("api/klausuren")]
    public class KlausurController : ControllerBase
    {
        private readonly IKlausurService _klausurService;
        private readonly IStudentService _studentService;

        public KlausurController(IKlausurService klausurService, IStudentService studentRepository)
        {
            _klausurService = klausurService;
            _studentService = studentRepository;
        }

        [HttpGet]
        public IActionResult GetAllKlausuren()
        {
            try
            {
                var klausuren = _klausurService.GetAllKlausuren();
                return Ok(klausuren);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Abrufen aller Klausuren: {ex.Message}");
                return StatusCode(500, "Interner Serverfehler beim Abrufen aller Klausuren.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetKlausurById(int id)
        {
            try
            {
                var klausur = _klausurService.GetKlausurById(id);
            
                if (klausur == null)
                {
                    return NotFound($"Klausur mit der ID {id} wurde nicht gefunden.");
                }
            
                return Ok(klausur);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Abrufen der Klausur nach ID: {ex.Message}");
                return StatusCode(500, "Interner Serverfehler beim Abrufen der Klausur nach ID.");
            }
        }

        [HttpPost]
        public IActionResult AddKlausur(int studentId, int studienfachId, [FromBody] Klausur klausur)
        {
            try
            {
                if (klausur == null)
                {
                    return BadRequest("Die Klausurdaten dürfen nicht leer sein.");
                }

                if (string.IsNullOrWhiteSpace(klausur.Beschreibung))
                {
                    return BadRequest("Die Bezeichnung der Klausur darf nicht leer sein.");
                }

                if (klausur.Datum == default(DateTime))
                {
                    return BadRequest("Das Datum der Klausur ist ungültig.");
                }

                if (klausur.Ergebnisse == null || klausur.Ergebnisse.Count == 0)
                {
                    return BadRequest("Es müssen Ergebnisse für die Klausur angegeben werden.");
                }

                foreach (var ergebnis in klausur.Ergebnisse.Values)
                {
                    if (ergebnis.Wert < 1 || ergebnis.Wert > 5)
                    {
                        return BadRequest("Ungültige Noten wurden angegeben. Noten müssen im Bereich von 1 bis 5 liegen.");
                    }
                }
                
                var student = _studentService.GetStudentById(studentId);
                if (student == null)
                {
                    return NotFound("Student nicht gefunden.");
                }

                var studienfach = student.Studienfaecher.FirstOrDefault(sf => sf.Id == studienfachId);
                if (studienfach == null)
                {
                    return NotFound("Studienfach nicht gefunden oder dem Studenten nicht zugeordnet.");
                }
                
                _klausurService.AddKlausur(studienfach, student, klausur);
                return Ok("Klausur wurde erfolgreich hinzugefügt.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Hinzufügen der Klausur: {ex.Message}");            
                return StatusCode(500, "Interner Serverfehler beim Hinzufügen der Klausur.");
            }
        }


        [HttpPut("{id}")]
        public IActionResult UpdateKlausur(int id, [FromBody] Klausur updatedKlausur)
        {
            try
            {
                if (updatedKlausur == null)
                {
                    return BadRequest("Die Daten für die zu aktualisierende Klausur dürfen nicht leer sein.");
                }

                var existingKlausur = _klausurService.GetKlausurById(id);
                if (existingKlausur == null)
                {
                    return NotFound("Die Klausur wurde nicht gefunden.");
                }

                if (string.IsNullOrWhiteSpace(updatedKlausur.Beschreibung))
                {
                    return BadRequest("Die Bezeichnung der Klausur darf nicht leer sein.");
                }

                if (updatedKlausur.Datum == default(DateTime))
                {
                    return BadRequest("Das Datum der Klausur ist ungültig.");
                }

                if (updatedKlausur.Ergebnisse == null || updatedKlausur.Ergebnisse.Count == 0)
                {
                    return BadRequest("Es müssen Ergebnisse für die Klausur angegeben werden.");
                }

                foreach (var ergebnis in updatedKlausur.Ergebnisse.Values)
                {
                    if (ergebnis.Wert < 1 || ergebnis.Wert > 5)
                    {
                        return BadRequest("Ungültige Noten wurden angegeben. Noten müssen im Bereich von 1 bis 5 liegen.");
                    }
                }
            
                _klausurService.UpdateKlausur(updatedKlausur);

                return Ok("Klausur wurde erfolgreich aktualisiert.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Aktualisieren der Klausur: {ex.Message}");
                return StatusCode(500, "Interner Serverfehler beim Aktualisieren der Klausur.");
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteKlausur(int id)
        {
            try
            {
                var existingKlausur = _klausurService.GetKlausurById(id);
                if (existingKlausur == null)
                {
                    return NotFound($"Klausur mit der ID {id} wurde nicht gefunden.");
                }

                bool success = _klausurService.DeleteKlausur(id);
                if (!success)
                {
                    return StatusCode(500, $"Fehler beim Löschen der Klausur mit der ID {id}.");
                }

                return Ok("Klausur wurde erfolgreich gelöscht.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Löschen der Klausur: {ex.Message}");
                return StatusCode(500, "Interner Serverfehler beim Löschen der Klausur.");
            }
        }
    }
}
