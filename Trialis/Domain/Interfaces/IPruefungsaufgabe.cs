namespace Trialis.Domain.Interfaces;

public interface IPruefungsaufgabe
{
    string GetInfo();
    void UpdateFrage(string neueFrage);
    void UpdateSchwierigkeitsgrad(string neuerSchwierigkeitsgrad);
}