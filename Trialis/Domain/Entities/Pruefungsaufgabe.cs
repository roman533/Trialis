using Trialis.Domain.Interfaces;

namespace Trialis.Domain.Entities;

public class Pruefungsaufgabe : IInformation
{
    public int Id { get; private set; }
    public string Frage { get; private set; }

    public Pruefungsaufgabe(int id, string frage)
    {
        Id = id;
        Frage = frage;
    }
    
    public string GetInfo()
    {
        return $"Pruefungsaufgabe {Id}: {Frage}";
    }
}
