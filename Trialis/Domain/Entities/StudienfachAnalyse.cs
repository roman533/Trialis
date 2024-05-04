using Trialis.Domain.Interfaces;
using Trialis.Domain.ValueObjects;

namespace Trialis.Domain.Entities;

public class StudienfachAnalyse
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int StudienfachId { get; set; }
    public List<Note> Noten { get; set; }

    public StudienfachAnalyse(int studentId, int studienfachId, List<Note> noten = null)
    {
        StudentId = studentId;
        StudienfachId = studienfachId;
        Noten = noten;
    }

    /*public void AddNote(Note note)
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
    
    public double CalculateDurchschnittsnote()
    {
        if (Noten == null || Noten.Count == 0)
        {
            return 0;
        }

        double summe = 0;

        foreach (var note in Noten)
        {
            summe += note.Wert; 
        }

        double durchschnittsnote = summe / Noten.Count;

        return durchschnittsnote;
    }

    public bool IstBestanden(int studentId, int studienfachId)
    {
        try
        {
            var studienfachAnalyse = GetStudienfachAnalyse(studentId, studienfachId);

            double durchschnittsnote = studienfachAnalyse.CalculateDurchschnittsnote();

            const double bestehensgrenze = 4.0;

            return durchschnittsnote >= bestehensgrenze;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Überprüfen, ob das Studienfach bestanden ist: {ex.Message}");
            throw;
        }
    }*/
}