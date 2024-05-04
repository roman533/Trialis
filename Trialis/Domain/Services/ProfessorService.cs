using Trialis.Domain.Entities;
using Trialis.Domain.Interfaces;
using Trialis.Domain.Repositories;

namespace Trialis.Domain.Services;

public class ProfessorService : IProfessorService
{
    private readonly ProfessorRepository _professorRepository;
    public List<Professor> GetAllProfessors()
    {
        return _professorRepository.GetAllProfessors();
    }

    public Professor GetProfessorById(int id)
    {
        return _professorRepository.GetProfessorById(id);
    }

    public void AddProfessor(Professor professor)
    {
        _professorRepository.AddProfessor(professor);
    }

    public bool IsValidEmail(string email)
    {
        return _professorRepository.IsValidEmail(email);
    }

    public void UpdateProfessor(Professor updatedProfessor)
    {
        _professorRepository.UpdateProfessor(updatedProfessor);
    }

    public void DeleteProfessor(int id)
    {
        _professorRepository.DeleteProfessor(id);
    }

    public void UpdateName(int id, string newName)
    {
        _professorRepository.UpdateName(id, newName);
    }

    public void UpdateFachgebiet(int id, string newFachgebiet)
    {
        _professorRepository.UpdateFachgebiet(id, newFachgebiet);
    }
}