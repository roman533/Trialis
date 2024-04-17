using Trialis.Domain.Interfaces;
using Trialis.Domain.ValueObjects;

namespace Trialis.Domain.Entities
{
    public class Klausur :IKlausur
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public List<Pruefungsaufgabe> Pruefungsaufgaben { get; set; }
        public Dictionary<int, Note> Ergebnisse { get; set; }
        public string Thema { get; set; }
        public string Beschreibung { get; set; }
        private static List<Klausur> _klausurList = new List<Klausur>();


        public Klausur(int id, DateTime datum, string thema, string beschreibung, List<Pruefungsaufgabe> pruefungsaufgaben)
        {
            Id = id;
            Datum = datum;
            Thema = thema;
            Beschreibung = beschreibung;
            Pruefungsaufgaben = pruefungsaufgaben;
            Ergebnisse = new Dictionary<int, Note>();
        }

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
        
        public void AddKlausur(Klausur klausur)
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