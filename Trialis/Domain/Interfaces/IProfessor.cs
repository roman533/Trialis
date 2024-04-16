namespace Trialis.Domain.Interfaces
{
    public interface IProfessor
    {
        string GetProfessorInfo();
        void UpdateName(string newName);
        void UpdateFachgebiet(string newFachgebiet);
    }
}