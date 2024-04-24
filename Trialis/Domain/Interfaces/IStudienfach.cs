using Trialis.Domain.Entities;

namespace Trialis.Domain.Interfaces;

public interface IStudienfach
{
    public IEnumerable<Studienfach> GetAllStudienfächer();
    public Studienfach GetStudienfachById(int id);
    public void AddStudienfach(Studienfach studienfach);
    public void UpdateStudienfach(Studienfach updatedStudienfach);
    public void DeleteStudienfach(Studienfach studienfachToDelete);
}