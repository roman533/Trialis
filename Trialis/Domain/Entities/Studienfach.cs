using Trialis.Domain.ValueObjects;

namespace Trialis.Domain.Entities;

public class Studienfach
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Schwierigkeitsgrad Schwierigkeitsgrad { get; set; }

    public Studienfach(int id, string name, Schwierigkeitsgrad schwierigkeitsgrad)
    {
        Id = id;
        Name = name;
        Schwierigkeitsgrad = schwierigkeitsgrad;
    }
}