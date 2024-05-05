using Trialis.Domain.Entities;
using Trialis.Domain.RepositoryInterfaces;
using Trialis.Domain.ValueObjects;

namespace Trialis.Domain.Repositories;

public class PruefungsaufgabeRepository : IPruefungsaufgabeRepository
{
    private List<Pruefungsaufgabe> _pruefungsaufgaben = new();
    private int _nextId = 1;

    public List<Pruefungsaufgabe> GetAllPruefungsaufgaben()
    {
        try
        {
            return _pruefungsaufgaben;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Abrufen aller Prüfungsaufgaben: {ex.Message}");
            throw;
        }
    }

    public Pruefungsaufgabe GetPruefungsaufgabeById(int id)
    {
        try
        {
            var pruefungsaufgabe = _pruefungsaufgaben.FirstOrDefault(p => p.Id == id);
            return pruefungsaufgabe;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Abrufen der Prüfungsaufgabe mit der ID {id}: {ex.Message}");
            throw;
        }
    }

    public virtual void AddPruefungsaufgabe(Pruefungsaufgabe pruefungsaufgabe)
    {
        try
        {
            if (pruefungsaufgabe == null)
            {
                throw new ArgumentNullException(nameof(pruefungsaufgabe), "Prüfungsaufgabe darf nicht null sein.");
            }

            if (string.IsNullOrWhiteSpace(pruefungsaufgabe.Frage))
            {
                throw new ArgumentException("Die Frage der Prüfungsaufgabe darf nicht leer oder null sein.",
                    nameof(pruefungsaufgabe.Frage));
            }

            if (string.IsNullOrWhiteSpace(pruefungsaufgabe.Antwort))
            {
                throw new ArgumentException("Die Antwort der Prüfungsaufgabe darf nicht leer oder null sein.",
                    nameof(pruefungsaufgabe.Antwort));
            }

            if (pruefungsaufgabe.Schwierigkeitsgrad == Schwierigkeitsgrad.Undefined)
            {
                throw new ArgumentException("Der Schwierigkeitsgrad der Prüfungsaufgabe muss angegeben werden.",
                    nameof(pruefungsaufgabe.Schwierigkeitsgrad));
            }

            pruefungsaufgabe.Id = _nextId++;
            _pruefungsaufgaben.Add(pruefungsaufgabe);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Hinzufügen der Prüfungsaufgabe: {ex.Message}");
            throw;
        }
    }

    public void UpdatePruefungsaufgabe(int id, Pruefungsaufgabe updatedPruefungsaufgabe)
    {
        try
        {
            var existingPruefungsaufgabe = _pruefungsaufgaben.FirstOrDefault(p => p.Id == id);
            if (existingPruefungsaufgabe == null)
            {
                throw new ArgumentException($"Prüfungsaufgabe mit der ID {id} wurde nicht gefunden.");
            }

            // Validierung der Eingabedaten
            if (string.IsNullOrWhiteSpace(updatedPruefungsaufgabe.Frage))
            {
                throw new ArgumentException("Die Frage der Prüfungsaufgabe darf nicht leer oder null sein.",
                    nameof(updatedPruefungsaufgabe.Frage));
            }

            if (string.IsNullOrWhiteSpace(updatedPruefungsaufgabe.Antwort))
            {
                throw new ArgumentException("Die Antwort der Prüfungsaufgabe darf nicht leer oder null sein.",
                    nameof(updatedPruefungsaufgabe.Antwort));
            }

            if (updatedPruefungsaufgabe.Schwierigkeitsgrad == Schwierigkeitsgrad.Undefined)
            {
                throw new ArgumentException("Der Schwierigkeitsgrad der Prüfungsaufgabe muss angegeben werden.",
                    nameof(updatedPruefungsaufgabe.Schwierigkeitsgrad));
            }

            // Aktualisierung der Prüfungsaufgabe
            existingPruefungsaufgabe.Frage = updatedPruefungsaufgabe.Frage;
            existingPruefungsaufgabe.Antwort = updatedPruefungsaufgabe.Antwort;
            existingPruefungsaufgabe.Schwierigkeitsgrad = updatedPruefungsaufgabe.Schwierigkeitsgrad;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Aktualisieren der Prüfungsaufgabe mit der ID {id}: {ex.Message}");
            throw;
        }
    }

    public void DeletePruefungsaufgabe(int id)
    {
        var pruefungsaufgabeToDelete = _pruefungsaufgaben.FirstOrDefault(p => p.Id == id);
        if (pruefungsaufgabeToDelete == null)
        {
            throw new ArgumentException($"Prüfungsaufgabe mit der ID {id} wurde nicht gefunden.");
        }

        _pruefungsaufgaben.Remove(pruefungsaufgabeToDelete);
    }

    public void UpdateFrageAntwort(int id, string neueFrage, string neueAntwort)
    {
        var pruefungsaufgabeToUpdate = _pruefungsaufgaben.FirstOrDefault(p => p.Id == id);
        if (pruefungsaufgabeToUpdate == null)
        {
            throw new ArgumentException($"Prüfungsaufgabe mit der ID {id} wurde nicht gefunden.");
        }

        if (string.IsNullOrWhiteSpace(neueFrage) || string.IsNullOrWhiteSpace(neueAntwort))
        {
            throw new ArgumentException("Frage und Antwort dürfen nicht leer sein.");
        }

        pruefungsaufgabeToUpdate.Frage = neueFrage;
        pruefungsaufgabeToUpdate.Antwort = neueAntwort;
    }


    public void UpdateSchwierigkeitsgrad(int id, Schwierigkeitsgrad neuerSchwierigkeitsgrad)
    {
        var pruefungsaufgabeToUpdate = _pruefungsaufgaben.FirstOrDefault(p => p.Id == id);
        if (pruefungsaufgabeToUpdate == null)
        {
            throw new ArgumentException($"Prüfungsaufgabe mit der ID {id} wurde nicht gefunden.");
        }

        pruefungsaufgabeToUpdate.Schwierigkeitsgrad = neuerSchwierigkeitsgrad;
    }
}

public class MultipleChoiceAufgabe : PruefungsaufgabeRepository
{
    public MultipleChoiceAufgabe(int id, string frage, Schwierigkeitsgrad schwierigkeitsgrad, string antwort)
    {
        
    }

    public override void AddPruefungsaufgabe(Pruefungsaufgabe pruefungsaufgabe)
    {
        Console.WriteLine("Führe spezifische Erstellungsschritte für Multiple-Choice-Aufgabe durch...");
    }
}

