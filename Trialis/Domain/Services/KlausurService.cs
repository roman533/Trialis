using Trialis.Domain.Entities;
using Trialis.Domain.Interfaces;
using Trialis.Domain.Repositories;
using Trialis.Domain.RepositoryInterfaces;

namespace Trialis.Domain.Services;

public class KlausurService : IKlausurService
{
    private readonly IKlausurRepository _klausurRepository;

    public KlausurService(IKlausurRepository klausurRepository)
    {
        _klausurRepository = klausurRepository;
    }

    public List<Klausur> GetAllKlausuren()
    {
        return _klausurRepository.GetAllKlausuren();
    }
    
    public Klausur GetKlausurById(int id)
    {
        return _klausurRepository.GetKlausurById(id);
    }

    public void AddKlausur(Studienfach studienfach, Student student, Klausur klausur)
    {
        _klausurRepository.AddKlausur(studienfach, student, klausur);
    }

    public void UpdateKlausur(Klausur klausur)
    {
        _klausurRepository.UpdateKlausur(klausur);
    }

    public bool DeleteKlausur(int id)
    {
        return _klausurRepository.DeleteKlausur(id);
    }
}