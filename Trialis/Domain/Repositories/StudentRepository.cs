using Trialis.Domain.Entities;
using Trialis.Domain.RepositoryInterfaces;

namespace Trialis.Domain.Repositories;

public class StudentRepository : IStudentRepository
{
    public List<Studienfach> Studienfaecher { get; set; } = new();
    public List<Klausur> Klausuren { get; set; } = new();
    private static List<Student> _studentList = new();
    
    public void HinzufuegenKlausur(Klausur klausur)
    {
        Klausuren.Add(klausur);
    }

    /* Dies ist die Methode zur Berechnung der Durchschnittsnote */
    public double BerechneDurchschnittsnote()
    {
        // Überprüfe, ob die Liste der Klausuren leer ist
        if (Klausuren.Count == 0)
        {
            // Wenn die Liste leer ist, geben wir 0.0 zurück
            return 0.0;
        }
        // Initialisiere die Variable für die Gesamtsumme der Noten
        double gesamtSumme = 0;
        // Initialisiere die Variable für die Anzahl der Noten
        int anzahlNoten = 0;

        // Gehe durch jede Klausur in der Liste der Klausuren
        foreach (var klausur in Klausuren)
        {
            // Gehe durch jedes Ergebnis in der Klausur
            foreach (var ergebnis in klausur.Ergebnisse.Values)
            {
                // Addiere den Wert des Ergebnisses zur Gesamtsumme
                gesamtSumme += ergebnis.Wert;
                // Erhöhe die Anzahl der Noten um 1
                anzahlNoten++;
            }
        }

        // Gebe die Durchschnittsnote zurück, indem du die Gesamtsumme durch die Anzahl der Noten teilst
        return gesamtSumme / anzahlNoten;
    }

    public List<Student> GetAllStudents()
    {
        try
        {
            List<Student> studentList = _studentList;

            if (studentList == null)
            {
                Console.WriteLine("Keine Studenten vorhanden.");
                return null;
            }

            return studentList;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Laden aller Studenten: {ex.Message}");
            throw;
        }
    }

    public Student GetStudentById(int id)
    {
        try
        {
            Student student = _studentList.Find(s => s.Id == id);
            
            if (student == null)
            {
                Console.WriteLine($"Student mit ID {id} wurde nicht gefunden.");
                throw new Exception($"Student mit der ID {id} nicht gefunden.");
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

    public List<Studienfach> GetStudienfaecher()
    {
        try
        {
            return Studienfaecher;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Laden des der Studienfächer");
            throw;
        }
    }
}