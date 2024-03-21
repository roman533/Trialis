namespace Trialis.Domain.Entities;

public class Studienfach
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    public Studienfach(int id, string name)
    {
        Id = id;
        Name = name;
    }
    
    public string GetStudienfachInfo()
    {
        return $"Studienfach ID: {Id}, Name: {Name}";
    }

    public void UpdateName(string newName)
    {
        Name = newName;
    }

}