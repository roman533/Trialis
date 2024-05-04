using Trialis.Domain.Entities;
using Trialis.Domain.ValueObjects;

namespace Trialis.Domain.Repositories;

public interface IPruefungsaufgabeRepository
{
    public List<Pruefungsaufgabe> GetAllPruefungsaufgaben();
    public Pruefungsaufgabe GetPruefungsaufgabeById(int id);
    public void AddPruefungsaufgabe(Pruefungsaufgabe pruefungsaufgabe);
    public void UpdatePruefungsaufgabe(int id, Pruefungsaufgabe updatedPruefungsaufgabe);
    public void DeletePruefungsaufgabe(int id);
    public void UpdateFrageAntwort(int id, string neueFrage, string neueAntwort);
    public void UpdateSchwierigkeitsgrad(int id, Schwierigkeitsgrad neuerSchwierigkeitsgrad);
}