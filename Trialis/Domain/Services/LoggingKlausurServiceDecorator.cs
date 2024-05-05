using Trialis.Domain.Entities;
using Trialis.Domain.Interfaces;
using Trialis.Services;

namespace Trialis.Domain.Services;

public class LoggingKlausurServiceDecorator : IKlausurService
{
    private readonly IKlausurService _decoratedKlausurService;

    public LoggingKlausurServiceDecorator(IKlausurService decoratedKlausurService)
    {
        _decoratedKlausurService = decoratedKlausurService;
    }

    public List<Klausur> GetAllKlausuren()
    {
        LoggingService.Instance.Log("[INFO] Calling GetAllKlausuren");
        var result = _decoratedKlausurService.GetAllKlausuren();
        LoggingService.Instance.Log("[INFO] Completed call to GetAllKlausuren");
        return result;
    }

    public Klausur GetKlausurById(int id)
    {
        LoggingService.Instance.Log($"[INFO] Calling GetKlausurById with id: {id}");
        var result = _decoratedKlausurService.GetKlausurById(id);
        LoggingService.Instance.Log("[INFO] Completed call to GetKlausurById");
        return result;
    }

    public void AddKlausur(Studienfach studienfach, Student student, Klausur klausur)
    {
        LoggingService.Instance.Log("[INFO] Calling AddKlausur");
        _decoratedKlausurService.AddKlausur(studienfach, student, klausur);
        LoggingService.Instance.Log("[INFO] Completed call to AddKlausur");
    }

    public void UpdateKlausur(Klausur klausur)
    {
        LoggingService.Instance.Log("[INFO] Calling UpdateKlausur");
        _decoratedKlausurService.UpdateKlausur(klausur);
        LoggingService.Instance.Log("[INFO] Completed call to UpdateKlausur");
    }

    public bool DeleteKlausur(int id)
    {
        LoggingService.Instance.Log($"[INFO] Calling DeleteKlausur with id: {id}");
        bool result = _decoratedKlausurService.DeleteKlausur(id);
        LoggingService.Instance.Log("[INFO] Completed call to DeleteKlausur");
        return result;
    }
}