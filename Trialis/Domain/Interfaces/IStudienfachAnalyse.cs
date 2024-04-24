using Trialis.Domain.Entities;
using Trialis.Domain.ValueObjects;

namespace Trialis.Domain.Interfaces;

public interface IStudienfachAnalyse
{
    public void AddNote(Note note);
    public StudienfachAnalyse GetStudienfachAnalyse(int studentId, int studienfachId);
    public void UpdateStudienfachAnalyse(StudienfachAnalyse updatedAnalyse);
    double BerechneDurchschnittsNote();
    string GetNotenListe();
    bool IstBestanden(double mindestNote);
}