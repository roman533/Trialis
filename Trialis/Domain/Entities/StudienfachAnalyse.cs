using Trialis.Domain.Interfaces;
using Trialis.Domain.ValueObjects;

namespace Trialis.Domain.Entities;

public class StudienfachAnalyse : IStudienfachAnalyse
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int StudienfachId { get; set; }
    public List<Note> Noten { get; set; }
    private readonly List<Note> _noten;


    public StudienfachAnalyse(int studentId, int studienfachId)
    {
        StudentId = studentId;
        StudienfachId = studienfachId;
        Noten = new List<Note>();
    }

    public void AddNote(Note note)
    {
        try
        {
            if (note == null)
            {
                throw new ArgumentNullException(nameof(note), "Note darf nicht null sein.");
            }

            if (_noten.Count >= 2)
            {
                throw new InvalidOperationException("Es können maximal 2 Noten hinzugefügt werden.");
            }

            _noten.Add(note);
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"Fehler beim Hinzufügen der Note: {ex.Message}");
            throw; 
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Fehler beim Hinzufügen der Note: {ex.Message}");
            throw; 
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unbekannter Fehler beim Hinzufügen der Note: {ex.Message}");
            throw; 
        }
    }
    
    public StudienfachAnalyse GetStudienfachAnalyse(int studentId, int studienfachId)
    {
        try
        {
            var studienfachAnalyse = new StudienfachAnalyse(studentId, studienfachId);
            
            studienfachAnalyse.Noten = _noten;

            return studienfachAnalyse;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Abrufen der Studienfachanalyse: {ex.Message}");
            throw;
        }
    }
    
    public void UpdateStudienfachAnalyse(StudienfachAnalyse updatedAnalyse)
    {
        try
        {
            if (updatedAnalyse == null)
            {
                throw new ArgumentNullException(nameof(updatedAnalyse), "Die aktualisierte StudienfachAnalyse darf nicht null sein.");
            }

            if (StudentId != updatedAnalyse.StudentId || StudienfachId != updatedAnalyse.StudienfachId)
            {
                throw new ArgumentException("Die IDs der aktualisierten StudienfachAnalyse stimmen nicht überein.");
            }

            if (updatedAnalyse.Noten.Count > 2)
            {
                throw new ArgumentException("Es dürfen maximal 2 Noten zur StudienfachAnalyse hinzugefügt werden.");
            }

            Noten = updatedAnalyse.Noten;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Aktualisieren der StudienfachAnalyse: {ex.Message}");
            throw; 
        }
    }
    
    // Methode zum Berechnen des Durchschnitts der Noten
    public double BerechneDurchschnittsNote()
    {
        if (Noten.Count == 0)
        {
            return 0;
        }

        double summe = 0;
        foreach (var note in Noten)
        {
            summe += note.Wert;
        }

        return summe / Noten.Count;
    }

    // Methode zum Abrufen der Liste der Noten als Zeichenfolge
    public string GetNotenListe()
    {
        string notenListe = "";
        foreach (var note in Noten)
        {
            notenListe += $"Note: {note.Wert}\n";
        }
        return notenListe;
    }

    // Methode zum Überprüfen, ob der Student das Studienfach bestanden hat
    public bool IstBestanden(double mindestNote)
    {
        return BerechneDurchschnittsNote() >= mindestNote;
    }
}