using Trialis.Domain.Entities;
using Trialis.Domain.ValueObjects;

namespace Trialis.Domain.Interfaces
{
    public interface IKlausur
    {
        List<Klausur> GetAllKlausuren();
        public Klausur GetKlausurById(int id);
        public void AddKlausur(Klausur klausur);
        public void UpdateKlausur(Klausur klausur);
        public bool DeleteKlausur(int id);
    }

}