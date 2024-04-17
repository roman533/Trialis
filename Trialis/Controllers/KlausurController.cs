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
        private readonly IKlausur _klausurRepository;

        public KlausurController(IKlausur klausurRepository)
        {
            _klausurRepository = klausurRepository;
        }

        [HttpGet]
        public IActionResult GetAllKlausuren()
        {
            try
            {
                var klausuren = _klausurRepository.GetAllKlausuren();
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
                var klausur = _klausurRepository.GetKlausurById(id);
            
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
        public IActionResult AddKlausur([FromBody] Klausur klausur)
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
                
                _klausurRepository.AddKlausur(klausur);
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

                var existingKlausur = _klausurRepository.GetKlausurById(id);
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
            
                _klausurRepository.UpdateKlausur(updatedKlausur);

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
                var existingKlausur = _klausurRepository.GetKlausurById(id);
                if (existingKlausur == null)
                {
                    return NotFound($"Klausur mit der ID {id} wurde nicht gefunden.");
                }

                bool success = _klausurRepository.DeleteKlausur(id);
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

        private bool KlausurBewertet(Klausur klausur)
        {
            foreach (var ergebnis in klausur.Ergebnisse.Values)
            {
                if (ergebnis.Wert != 0) 
                {
                    return true;
                }
            }
            return false;
        }
        
        private int GenerateUniqueId()
        {
            return new Random().Next(1000, 9999);
        }
    }
}
