using Trialis.Domain.Interfaces;

namespace Trialis.Domain.Entities
{
    public class Pruefungsaufgabe : IPruefungsaufgabe
    {
        public int Id { get; private set; }
        public string Frage { get; private set; }
        public string Schwierigkeitsgrad { get; private set; }

        public Pruefungsaufgabe(int id, string frage, string schwierigkeitsgrad)
        {
            Id = id;
            Frage = frage;
            Schwierigkeitsgrad = schwierigkeitsgrad;
        }
        
        public string GetInfo()
        {
            return $"Pruefungsaufgabe {Id}: {Frage} (Schwierigkeitsgrad: {Schwierigkeitsgrad})";
        }

        public void UpdateFrage(string neueFrage)
        {
            Frage = neueFrage;
        }

        public void UpdateSchwierigkeitsgrad(string neuerSchwierigkeitsgrad)
        {
            Schwierigkeitsgrad = neuerSchwierigkeitsgrad;
        }
    }
}