using Trialis.Domain.Entities;

namespace Trialis.Domain.Interfaces;

public interface IKlausurService
{
    public List<Klausur> GetAllKlausuren();
    public Klausur GetKlausurById(int id);
    public void AddKlausur(Studienfach studienfach, Student student, Klausur klausur);
    public void UpdateKlausur(Klausur klausur);
    public bool DeleteKlausur(int id);
}