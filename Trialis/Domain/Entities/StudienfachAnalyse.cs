using Trialis.Domain.ValueObjects;

namespace Trialis.Domain.Entities;

public class StudienfachAnalyse
{
    public int Id { get; set; }
    public short Matrikelnummer { get; set; }
    public int StudienfachId { get; set; }
    public List<Note> Noten { get; set; }

    public StudienfachAnalyse(short matrikelnummer, int studienfachId)
    {
        Matrikelnummer = matrikelnummer;
        StudienfachId = studienfachId;
        Noten = new List<Note>();
    }

    // Methode zum Hinzufügen einer Note zur Analyse
    public void AddNote(Note note)
    {
        Noten.Add(note);
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