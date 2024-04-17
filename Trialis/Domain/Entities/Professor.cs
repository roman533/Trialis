using Trialis.Domain.Interfaces;

namespace Trialis.Domain.Entities;

public class Professor : IProfessor
{
    public int Id { get; private set; }
    public string Name { get; set; }
    public string Fachgebiet { get; set; }
    public string Email { get; set; }
    public int Telefonnummer { get; set; }
    
    private List<Professor> _professors = new List<Professor>();


    public Professor(int id, string name, string fachgebiet, string email, int telefonnummer)
    {
        Id = id;
        Name = name;
        Fachgebiet = fachgebiet;
        Email = email;
        Telefonnummer = telefonnummer;
    }
    
    public IEnumerable<Professor> GetAllProfessors()
    {
        try
        {
            return _professors;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Abrufen der Professoren: {ex.Message}");
            throw;
        }
    }
    
    public Professor GetProfessorById(int id)
    {
        try
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Die ID muss größer als 0 sein.");
            }

            var professor = _professors.FirstOrDefault(p => p.Id == id);

            if (professor == null)
            {
                throw new KeyNotFoundException($"Professor mit der ID {id} wurde nicht gefunden.");
            }

            return professor;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Abrufen des Professors mit der ID {id}: {ex.Message}");
            throw; 
        }
    }

    public void AddProfessor(Professor professor)
    {
        try
        {
            if (professor == null)
            {
                throw new ArgumentNullException(nameof(professor));
            }

            if (string.IsNullOrWhiteSpace(professor.Name))
            {
                throw new ArgumentException("Professor name cannot be null or empty.", nameof(professor.Name));
            }

            if (string.IsNullOrWhiteSpace(professor.Email))
            {
                throw new ArgumentException("Professor email cannot be null or empty.", nameof(professor.Email));
            }

            if (!IsValidEmail(professor.Email))
            {
                throw new ArgumentException("Invalid email format.", nameof(professor.Email));
            }

            if (professor.Telefonnummer <= 0)
            {
                throw new ArgumentException("Professor office number must be greater than 0.", nameof(professor.Telefonnummer));
            }

            _professors.Add(professor);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding professor: {ex.Message}");
            throw;
        }
    }

    private bool IsValidEmail(string email)
    {
        // Simple email validation logic
        return !string.IsNullOrWhiteSpace(email) && email.Contains("@");
    }

    public void UpdateProfessor(Professor updatedProfessor)
    {
        try
        {
            if (updatedProfessor == null)
            {
                throw new ArgumentNullException(nameof(updatedProfessor), "Das Professor-Objekt darf nicht null sein.");
            }

            var existingProfessor = _professors.FirstOrDefault(p => p.Id == updatedProfessor.Id);

            if (existingProfessor == null)
            {
                throw new KeyNotFoundException($"Professor mit der ID {updatedProfessor.Id} wurde nicht gefunden.");
            }

            existingProfessor.Name = updatedProfessor.Name;
            existingProfessor.Email = updatedProfessor.Email;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Aktualisieren des Professors: {ex.Message}");
            throw; 
        }
    }
    
    public void DeleteProfessor(int id)
    {
        try
        {
            var professorToDelete = _professors.FirstOrDefault(p => p.Id == id);
            if (professorToDelete == null)
            {
                throw new KeyNotFoundException($"Professor with ID {id} not found.");
            }
            
            _professors.Remove(professorToDelete);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting professor: {ex.Message}");
            throw;
        }
    }
    
    public string GetProfessorInfo()
    {
        return $"Professor ID: {Id}, Name: {Name}, Fachgebiet: {Fachgebiet}";
    }

    public void UpdateName(int id, string newName)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(newName))
            {
                throw new ArgumentException("Neuer Name darf nicht null oder leer sein.", nameof(newName));
            }

            var professorToUpdate = _professors.FirstOrDefault(p => p.Id == id);
            if (professorToUpdate == null)
            {
                throw new KeyNotFoundException($"Professor mit der ID {id} wurde nicht gefunden.");
            }

            if (professorToUpdate.Name == newName)
            {
                throw new InvalidOperationException("Der neue Name ist identisch mit dem aktuellen Namen des Professors. Keine Änderung erforderlich.");
            }

            professorToUpdate.Name = newName;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Aktualisieren des Professor-Namens: {ex.Message}");
            throw;
        }
    }


    public void UpdateFachgebiet(string newFachgebiet)
    {
        Fachgebiet = newFachgebiet;
    }
    
    public void UpdateFachgebiet(int id, string newFachgebiet)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(newFachgebiet))
            {
                throw new ArgumentException("Neues Fachgebiet darf nicht null oder leer sein.", nameof(newFachgebiet));
            }

            var professorToUpdate = _professors.FirstOrDefault(p => p.Id == id);
            if (professorToUpdate == null)
            {
                throw new KeyNotFoundException($"Professor mit der ID {id} wurde nicht gefunden.");
            }

            if (professorToUpdate.Fachgebiet == newFachgebiet)
            {
                throw new InvalidOperationException("Das neue Fachgebiet ist identisch mit dem aktuellen Fachgebiet des Professors. Keine Änderung erforderlich.");
            }

            professorToUpdate.Fachgebiet = newFachgebiet;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Aktualisieren des Fachgebiets des Professors: {ex.Message}");
            throw;
        }
    }
}