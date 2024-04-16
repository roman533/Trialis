using Trialis.Domain.Entities;
using Trialis.Domain.ValueObjects;

namespace Trialis.Domain.Interfaces
{
    public interface IKlausur
    {
        void ErgebnisHinzufuegen(Student student, Note note);
        string GetKlausurInfo();
    }

}