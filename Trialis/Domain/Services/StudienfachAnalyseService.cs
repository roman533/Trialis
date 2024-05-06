using Trialis.Domain.Entities;
using Trialis.Domain.Interfaces;
using Trialis.Domain.Repositories;
using Trialis.Domain.RepositoryInterfaces;
using Trialis.Domain.ValueObjects;

namespace Trialis.Domain.Services;

public class StudienfachAnalyseService : IStudienfachAnalyseService
{
    private readonly IStudienfachAnalyseRepository _studienfachAnalyseRepository;
    
    public StudienfachAnalyseService(IStudienfachAnalyseRepository studienfachAnalyseRepository)
    {
        _studienfachAnalyseRepository = studienfachAnalyseRepository;
    }
    
    public void AddNote(Note note)
    {
        _studienfachAnalyseRepository.AddNote(note);
    }

    public StudienfachAnalyse GetStudienfachAnalyse(int studentId, int studienfachId)
    {
        return _studienfachAnalyseRepository.GetStudienfachAnalyse(studentId, studienfachId);
    }

    public void UpdateStudienfachAnalyse(StudienfachAnalyse updatedAnalyse)
    {
        _studienfachAnalyseRepository.UpdateStudienfachAnalyse(updatedAnalyse);
    }

    public double CalculateDurchschnittsnote()
    {
        return _studienfachAnalyseRepository.CalculateDurchschnittsnote();
    }

    public bool IstBestanden(int studentId, int studienfachId)
    {
        return _studienfachAnalyseRepository.IstBestanden(studentId, studienfachId);
    }
}