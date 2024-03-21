using Trialis.Domain.Interfaces;

namespace Trialis.Domain.Entities
{
    public class Student : IStudentInformation
    {
        public int Id { get; private set; }
        public short Matrikelnummer { get; set; }
        public string Name { get; set; }
        public List<Klausur> Klausuren { get; set; } = new List<Klausur>();
        public string Studiengang { get; set; } 
        public int Semester { get; set; }


        public Student(int id, short matrikelnummer, string name, string studiengang, int semester)
        {
            Id = id;
            Matrikelnummer = matrikelnummer;
            Name = name;
            Studiengang = studiengang;
            Semester = semester;
        }

        public string GetStudentInfo()
        {
            return $"ID: {Id}, Matrikelnummer: {Matrikelnummer}, Name: {Name}, Studiengang: {Studiengang}, Semester: {Semester}";
        }
        
        public void HinzufuegenKlausur(Klausur klausur)
        {
            Klausuren.Add(klausur);
        }

        public double BerechneDurchschnittsnote()
        {
            if (Klausuren.Count == 0)
            {
                return 0.0;
            }

            double gesamtSumme = 0;
            int anzahlNoten = 0;

            foreach (var klausur in Klausuren)
            {
                foreach (var ergebnis in klausur.Ergebnisse.Values)
                {
                    gesamtSumme += ergebnis.Wert;
                    anzahlNoten++;
                }
            }

            return gesamtSumme / anzahlNoten;
        }
    }
}