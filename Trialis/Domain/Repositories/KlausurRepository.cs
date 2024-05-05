using Trialis.Domain.Entities;
using Trialis.Domain.RepositoryInterfaces;
using Trialis.Domain.ValueObjects;

namespace Trialis.Domain.Repositories;

public class KlausurRepository : IKlausurRepository
{
    private static List<Klausur> _klausurList = new List<Klausur>();
    
    public List<Klausur> GetAllKlausuren()
    {
        try
        {
            List<Klausur> klausuren = _klausurList;
            if (klausuren == null)
            {
                Console.WriteLine("Keine Klasuren vorhanden.");
                return null;
            }
                
            return _klausurList;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Abrufen aller Klausuren: {ex.Message}");
            throw;
        }
    }
    
    public Klausur GetKlausurById(int id)
    {
        try
        {
            Klausur klausur = _klausurList.FirstOrDefault(k => k.Id == id);

            if (klausur == null)
            {
                Console.WriteLine($"Klausur mit der ID {id} wurde nicht gefunden.");
            }

            return klausur;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Abrufen der Klausur nach ID: {ex.Message}");
            throw;
        }
    }
    
    public void AddKlausur(Studienfach studienfach, Student student, Klausur klausur)
    {
        try
        {
            if (klausur == null)
            {
                throw new ArgumentNullException(nameof(klausur), "Klausurdaten fehlen.");
            }

            if (_klausurList.Any(k => k.Id == klausur.Id))
            {
                throw new InvalidOperationException($"Eine Klausur mit der ID {klausur.Id} existiert bereits.");
            }

            klausur.StudentId = student.Id;
            klausur.StudienfachId = studienfach.Id;
            
            _klausurList.Add(klausur);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Hinzufügen der Klausur: {ex.Message}");
            throw;
        }
    }
    
    public void UpdateKlausur(Klausur klausur)
    {
        try
        {
            if (klausur == null)
            {
                throw new ArgumentNullException(nameof(klausur), "Klausurdaten fehlen.");
            }

            var existingKlausur = _klausurList.FirstOrDefault(k => k.Id == klausur.Id);
            if (existingKlausur == null)
            {
                throw new InvalidOperationException($"Klausur mit der ID {klausur.Id} wurde nicht gefunden.");
            }
            
            existingKlausur.Id = klausur.Id;
            existingKlausur.Datum = klausur.Datum;
            existingKlausur.Thema = klausur.Thema;
            existingKlausur.Beschreibung = klausur.Beschreibung;
            existingKlausur.Pruefungsaufgaben = klausur.Pruefungsaufgaben;
            existingKlausur.StudentId = klausur.StudentId;
            existingKlausur.StudienfachId = klausur.StudienfachId;
            existingKlausur.Ergebnisse = new Dictionary<int, Note>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Aktualisieren der Klausur: {ex.Message}");
            throw;
        }
    }
    
    public bool DeleteKlausur(int id)
    {
        try
        {
            var existingKlausur = _klausurList.FirstOrDefault(k => k.Id == id);
            if (existingKlausur == null)
            {
                throw new KeyNotFoundException($"Klausur mit der ID {id} wurde nicht gefunden.");
            }

            if (existingKlausur.Ergebnisse == null || !existingKlausur.Ergebnisse.Any())
            {
                throw new InvalidOperationException("Die Klausur kann nicht gelöscht werden, da sie bereits bewertet wurde.");
            }

            _klausurList.Remove(existingKlausur);

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Löschen der Klausur: {ex.Message}");
            return false;
        }
    }
}