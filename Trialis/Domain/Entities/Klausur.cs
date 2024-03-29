using Trialis.Domain.Interfaces;
using Trialis.Domain.ValueObjects;

namespace Trialis.Domain.Entities
{
    public class Klausur :IKlausurInformation
    {
        public int Id { get; private set; }
        public DateTime Datum { get; private set; }
        public List<Pruefungsaufgabe> Pruefungsaufgaben { get; private set; }
        public Dictionary<int, Note> Ergebnisse { get; private set; }
        public string Thema { get; private set; }
        public string Beschreibung { get; private set; }

        public Klausur(int id, DateTime datum, string thema, string beschreibung, List<Pruefungsaufgabe> pruefungsaufgaben)
        {
            Id = id;
            Datum = datum;
            Thema = thema;
            Beschreibung = beschreibung;
            Pruefungsaufgaben = pruefungsaufgaben;
            Ergebnisse = new Dictionary<int, Note>();
        }

        public void ErgebnisHinzufuegen(Student student, Note note)
        {
            if (!Ergebnisse.ContainsKey(student.Id))
            {
                Ergebnisse.Add(student.Id, note);
                student.HinzufuegenKlausur(this); // Hinzufügen der Klausur zum Studenten
            }
            else
            {
                // Optional: Logik für Aktualisierung des Ergebnisses
                Ergebnisse[student.Id] = note;
            }
        }

        public string GetKlausurInfo()
        {
            var pruefungsaufgabenInfo = string.Join(", ", Pruefungsaufgaben.Select(p => $"Frage: {p.Frage} (Schwierigkeitsgrad: {p.Schwierigkeitsgrad})"));
            return $"Klausur ID: {Id}, Datum: {Datum}, Thema: {Thema}, Beschreibung: {Beschreibung}, Pruefungsaufgaben: {pruefungsaufgabenInfo}";
        }
    }
}