using Trialis.Domain.Interfaces;
using Trialis.Domain.ValueObjects;

namespace Trialis.Domain.Entities;

public class Studienfach : IStudienfach
{
    public int Id { get; private set; }
    public string Name { get; set; }
    public Schwierigkeitsgrad Schwierigkeitsgrad { get; set; }
    private readonly List<Studienfach> _studienfächer;

    public Studienfach(int id, string name, Schwierigkeitsgrad schwierigkeitsgrad, List<Studienfach> studienfächer)
    {
        Id = id;
        Name = name;
        Schwierigkeitsgrad = schwierigkeitsgrad;
        _studienfächer = studienfächer;
    }
    
    public IEnumerable<Studienfach> GetAllStudienfächer()
    {
        try
        {
            return _studienfächer;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Abrufen aller Studienfächer: {ex.Message}");
            throw;
        }
    }
    
    public Studienfach GetStudienfachById(int id)
    {
        try
        {
            var studienfach = _studienfächer.FirstOrDefault(sf => sf.Id == id);
            if (studienfach == null)
            {
                throw new KeyNotFoundException($"Studienfach mit ID {id} wurde nicht gefunden.");
            }

            return studienfach;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Abrufen des Studienfachs mit ID {id}: {ex.Message}");
            throw;
        }
    }
    
    public void AddStudienfach(Studienfach studienfach)
    {
        try
        {
            if (studienfach == null)
            {
                throw new ArgumentNullException(nameof(studienfach), "Studienfach darf nicht null sein.");
            }

            if (string.IsNullOrWhiteSpace(studienfach.Name))
            {
                throw new ArgumentException("Studienfachname darf nicht leer oder null sein.", nameof(studienfach.Name));
            }

            if (studienfach.Schwierigkeitsgrad == Schwierigkeitsgrad.Undefined)
            {
                throw new ArgumentException("Schwierigkeitsgrad darf nicht Unbekannt sein.", nameof(studienfach.Schwierigkeitsgrad));
            }

            if (_studienfächer.Any(sf => sf.Name == studienfach.Name))
            {
                throw new InvalidOperationException($"Studienfach mit Name '{studienfach.Name}' existiert bereits.");
            }

            studienfach.Id = _studienfächer.Any() ? _studienfächer.Max(sf => sf.Id) + 1 : 1;
            _studienfächer.Add(studienfach);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Hinzufügen des Studienfachs mit Name {studienfach.Name}: {ex.Message}");
            throw;
        }
    }

    public void UpdateStudienfach(Studienfach updatedStudienfach)
    {
        try
        {
            if (updatedStudienfach == null)
            {
                throw new ArgumentNullException(nameof(updatedStudienfach), "Studienfach darf nicht null sein.");
            }

            if (string.IsNullOrWhiteSpace(updatedStudienfach.Name))
            {
                throw new ArgumentException("Studienfachname darf nicht leer oder null sein.", nameof(updatedStudienfach.Name));
            }

            if (updatedStudienfach.Schwierigkeitsgrad == Schwierigkeitsgrad.Undefined)
            {
                throw new ArgumentException("Schwierigkeitsgrad darf nicht Unbekannt sein.", nameof(updatedStudienfach.Schwierigkeitsgrad));
            }

            var existingStudienfach = _studienfächer.FirstOrDefault(sf => sf.Id == updatedStudienfach.Id);
            if (existingStudienfach == null)
            {
                throw new InvalidOperationException($"Studienfach mit ID {updatedStudienfach.Id} wurde nicht gefunden.");
            }

            existingStudienfach.Name = updatedStudienfach.Name;
            existingStudienfach.Schwierigkeitsgrad = updatedStudienfach.Schwierigkeitsgrad;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Ändern des Studienfachs mit Name {updatedStudienfach.Name}: {ex.Message}");
            throw;
        }
    }

    public void DeleteStudienfach(Studienfach studienfachToDelete)
    {
        if (studienfachToDelete == null)
        {
            throw new ArgumentNullException(nameof(studienfachToDelete), "Studienfach darf nicht null sein.");
        }

        if (!_studienfächer.Contains(studienfachToDelete))
        {
            throw new InvalidOperationException($"Studienfach {studienfachToDelete.Name} ist nicht in der Liste enthalten.");
        }

        try
        {
            _studienfächer.Remove(studienfachToDelete);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Löschen des Studienfachs {studienfachToDelete.Name}: {ex.Message}");
            throw;
        }
    }


    public void UpdateName(string newName)
    {
        Name = newName;
    }

}