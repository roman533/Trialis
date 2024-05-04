using Trialis.Domain.Interfaces;
using Trialis.Domain.ValueObjects;

namespace Trialis.Domain.Entities
{
    public class Klausur
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public List<Pruefungsaufgabe> Pruefungsaufgaben { get; set; }
        public Dictionary<int, Note> Ergebnisse { get; set; }
        public string Thema { get; set; }
        public string Beschreibung { get; set; }
        public int StudentId { get; set; }
        public int StudienfachId { get; set; }

        public Klausur(int id, DateTime datum, string thema, string beschreibung,
            List<Pruefungsaufgabe> pruefungsaufgaben, int studentId, int studienfachId)
        {
            Id = id;
            Datum = datum;
            Thema = thema;
            Beschreibung = beschreibung;
            Pruefungsaufgaben = pruefungsaufgaben;
            Ergebnisse = new Dictionary<int, Note>();
            StudentId = studentId;
            StudienfachId = studienfachId;
        }
    }
}