using Trialis.Domain.Interfaces;

namespace Trialis.Domain.Entities
{
    public class Student : IStudent
    {
        public int Id { get; private set; }
        public short Matrikelnummer { get; set; }
        public string Name { get; set; }
        public List<Klausur> Klausuren { get; set; } = new List<Klausur>();
        public string Studiengang { get; set; } 
        public int Semester { get; set; }
        private static List<Student> _studentList = new List<Student>();

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

        public List<Student> GetAllStudents()
        {
            List<Student> studentList = _studentList;

            if (studentList == null)
            {
                Console.WriteLine("Keine Studenten vorhanden.");
                return null;
            }

            return studentList;
        }

        public Student GetStudentById(int id)
        {
            try
            {
                Student student = _studentList.Find(s => s.Id == id);
                
                if (student == null)
                {
                    Console.WriteLine($"Student mit ID {id} wurde nicht gefunden.");
                    return null;
                }

                return student;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Fehler beim Löschen des Studenten: {ex.Message}");
                throw;
            }
        }

        public void AddStudent(Student student)
        {
            try
            {
                student.Id = _studentList.Count + 1;
                _studentList.Add(student);
                Console.WriteLine("Student erfolgreich hinzugefügt.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Hinzufügen des Studenten: {ex.Message}");
            }
        }

        public void UpdateStudent(Student updatedStudent)
        {
            try
            {
                var existingStudent = _studentList.Find(s => s.Id == updatedStudent.Id);
            
                if (existingStudent == null)
                {
                    Console.WriteLine("Student nicht gefunden.");
                    return;
                }

                existingStudent.Name = updatedStudent.Name;
                existingStudent.Matrikelnummer = updatedStudent.Matrikelnummer;
                existingStudent.Semester = updatedStudent.Semester;
                existingStudent.Studiengang = updatedStudent.Studiengang;

                Console.WriteLine("Student erfolgreich aktualisiert.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Aktualisieren des Studenten: {ex.Message}");
            }
        }

        public void DeleteStudent(int id)
        {
            try
            {
                var studentToRemove = _studentList.Find(s => s.Id == id);

                if (studentToRemove != null)
                {
                    _studentList.Remove(studentToRemove);
                    Console.WriteLine("Student erfolgreich gelöscht.");
                }
                else
                {
                    Console.WriteLine("Student nicht gefunden.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Löschen des Studenten: {ex.Message}");
            }
        }

        public IEnumerable<Student> GetStudentsByStudienfach(string studienfach)
        {
            throw new NotImplementedException();
        }
    }
}