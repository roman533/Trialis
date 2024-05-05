using Trialis.Domain.Entities;
using Trialis.Domain.Interfaces;
using Trialis.Domain.Repositories;
using Trialis.Domain.RepositoryInterfaces;

namespace Trialis.Domain.Services;

public class StudienfachService : IStudienfachService
{
    private readonly IStudienfachRepository _studienfachRepository;
    
    public List<Studienfach> GetAllStudienfächer()
    {
        return _studienfachRepository.GetAllStudienfächer();
    }

    public Studienfach GetStudienfachById(int id)
    {
        return _studienfachRepository.GetStudienfachById(id);
    }

    public void AddStudienfach(Studienfach studienfach)
    {
        _studienfachRepository.AddStudienfach(studienfach);
    }

    public void UpdateStudienfach(Studienfach updatedStudienfach)
    {
        _studienfachRepository.UpdateStudienfach(updatedStudienfach);
    }

    public void DeleteStudienfach(Studienfach studienfachToDelete)
    {
        _studienfachRepository.DeleteStudienfach(studienfachToDelete);
    }
}