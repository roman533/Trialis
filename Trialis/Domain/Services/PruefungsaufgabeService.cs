using Trialis.Domain.Entities;
using Trialis.Domain.Interfaces;
using Trialis.Domain.Repositories;
using Trialis.Domain.ValueObjects;

namespace Trialis.Domain.Services;

public class PruefungsaufgabeService : IPruefungsaufgabeService
{
    private readonly IPruefungsaufgabeRepository _pruefungsaufgabeRepository;
    
    public List<Pruefungsaufgabe> GetAllPruefungsaufgaben()
    {
        return _pruefungsaufgabeRepository.GetAllPruefungsaufgaben();
    }

    public Pruefungsaufgabe GetPruefungsaufgabeById(int id)
    {
        return _pruefungsaufgabeRepository.GetPruefungsaufgabeById(id);
    }

    public void AddPruefungsaufgabe(Pruefungsaufgabe pruefungsaufgabe)
    {
        _pruefungsaufgabeRepository.AddPruefungsaufgabe(pruefungsaufgabe);
    }

    public void UpdatePruefungsaufgabe(int id, Pruefungsaufgabe updatedPruefungsaufgabe)
    {
        _pruefungsaufgabeRepository.UpdatePruefungsaufgabe(id, updatedPruefungsaufgabe);
    }

    public void DeletePruefungsaufgabe(int id)
    {
        _pruefungsaufgabeRepository.DeletePruefungsaufgabe(id);
    }

    public void UpdateFrageAntwort(int id, string neueFrage, string neueAntwort)
    {
        _pruefungsaufgabeRepository.UpdateFrageAntwort(id, neueFrage, neueAntwort);
    }

    public void UpdateSchwierigkeitsgrad(int id, Schwierigkeitsgrad neuerSchwierigkeitsgrad)
    {
        _pruefungsaufgabeRepository.UpdateSchwierigkeitsgrad(id, neuerSchwierigkeitsgrad);
    }
}