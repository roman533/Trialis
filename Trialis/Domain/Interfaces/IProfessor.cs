using Trialis.Domain.Entities;

namespace Trialis.Domain.Interfaces
{
    public interface IProfessor
    {
        public IEnumerable<Professor> GetAllProfessors();
        public Professor GetProfessorById(int id);
        public void AddProfessor(Professor professor);
        public void UpdateProfessor(Professor updatedProfessor);
        public void DeleteProfessor(int id);
        public void UpdateName(int id, string newName);
        public void UpdateFachgebiet(int id, string newFachgebiet);
    }
}