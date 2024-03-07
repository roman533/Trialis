using Trialis.Domain.Interfaces;
using Trialis.Domain.ValueObjects;

namespace Trialis.Domain.Entities;

public class Klausur :IKlausurInformation
{
    public int Id { get; private set; }
    public DateTime Datum { get; private set; }
    public List<Pruefungsaufgabe> Pruefungsaufgaben { get; private set; }
    public Dictionary<int, Note> Ergebnisse { get; private set; }

    public Klausur(int id, DateTime datum, List<Pruefungsaufgabe> pruefungsaufgaben)
    {
        Id = id;
        Datum = datum;
        Pruefungsaufgaben = pruefungsaufgaben;
        Ergebnisse = new Dictionary<int, Note>();
    }

    public void ErgebnisHinzufuegen(Student student, Note note)
    {
        if (!Ergebnisse.ContainsKey(student.Id))
        {
            Ergebnisse.Add(student.Id, note);
        }
        else
        {
            Ergebnisse[student.Id] = note;
        }
    }
    
    public string GetKlausurInfo()
    {
        return $"Klausur ID: {Id}, Datum: {Datum}";
    }
}
