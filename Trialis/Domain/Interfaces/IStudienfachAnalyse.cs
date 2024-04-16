using Trialis.Domain.ValueObjects;

namespace Trialis.Domain.Interfaces;

public interface IStudienfachAnalyse
{
    void AddNote(Note note);
    double BerechneDurchschnittsNote();
    string GetNotenListe();
    bool IstBestanden(double mindestNote);
}