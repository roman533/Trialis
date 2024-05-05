using Trialis.Domain.Entities;
using Trialis.Domain.ValueObjects;

namespace Trialis.Domain.RepositoryInterfaces;

public interface IStudienfachAnalyseRepository
{
    public void AddNote(Note note);
    public StudienfachAnalyse GetStudienfachAnalyse(int studentId, int studienfachId);
    public void UpdateStudienfachAnalyse(StudienfachAnalyse updatedAnalyse);
    public double CalculateDurchschnittsnote();
    public bool IstBestanden(int studentId, int studienfachId);
}