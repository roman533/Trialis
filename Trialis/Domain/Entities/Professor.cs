namespace Trialis.Domain.Entities;

public class Professor
{
    public int Id { get; private set; }
    public string Name { get; set; }
    public string Fachgebiet { get; set; }

    public Professor(int id, string name, string fachgebiet)
    {
        Id = id;
        Name = name;
        Fachgebiet = fachgebiet;
    }
    
    public string GetProfessorInfo()
    {
        return $"Professor ID: {Id}, Name: {Name}, Fachgebiet: {Fachgebiet}";
    }

    public void UpdateName(string newName)
    {
        Name = newName;
    }

    public void UpdateFachgebiet(string newFachgebiet)
    {
        Fachgebiet = newFachgebiet;
    }
}