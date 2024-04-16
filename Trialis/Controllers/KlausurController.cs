using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Trialis.Domain.Entities;
using Trialis.Domain.ValueObjects;

namespace Trialis.Controllers
{
    [ApiController]
    [Route("api/klausuren")]
    public class KlausurController : ControllerBase
    {
        private readonly List<Klausur> _klausuren = new List<Klausur>();

        [HttpGet]
        public IActionResult GetAllKlausuren()
        {
            return Ok(_klausuren);
        }

        [HttpGet("{id}")]
        public IActionResult GetKlausurById(int id)
        {
            var klausur = _klausuren.FirstOrDefault(k => k.Id == id);
            if (klausur == null)
            {
                return NotFound();
            }

            return Ok(klausur);
        }

        [HttpPost]
        public IActionResult AddKlausur([FromBody] Klausur klausur)
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

            // Hier könnte weitere spezifische Logik für die Validierung und Verarbeitung der Klausurdaten erfolgen

            klausur.Id = GenerateUniqueId(); // Generiert eine eindeutige ID für die Klausur
            _klausuren.Add(klausur);

            return CreatedAtAction(nameof(GetKlausurById), new { id = klausur.Id }, klausur);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateKlausur(int id, [FromBody] Klausur updatedKlausur)
        {
            if (updatedKlausur == null)
            {
                return BadRequest("Die Daten für die zu aktualisierende Klausur dürfen nicht leer sein.");
            }

            var existingKlausur = _klausuren.FirstOrDefault(k => k.Id == id);
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

            // Hier könnte weitere spezifische Logik für die Validierung und Verarbeitung der aktualisierten Klausurdaten erfolgen

            existingKlausur.Beschreibung = updatedKlausur.Beschreibung;
            existingKlausur.Datum = updatedKlausur.Datum;
            existingKlausur.Ergebnisse = updatedKlausur.Ergebnisse;

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteKlausur(int id)
        {
            var klausurToRemove = _klausuren.FirstOrDefault(k => k.Id == id);
            if (klausurToRemove == null)
            {
                return NotFound("Die zu löschende Klausur wurde nicht gefunden.");
            }
            
            if (KlausurBewertet(klausurToRemove))
            {
                return BadRequest("Die Klausur kann nicht gelöscht werden, da sie bereits bewertet wurde.");
            }

            _klausuren.Remove(klausurToRemove);

            return NoContent();
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
