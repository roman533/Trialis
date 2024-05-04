using Trialis.Domain.Interfaces;
using Trialis.Domain.ValueObjects;

namespace Trialis.Domain.Entities
{
    public class Pruefungsaufgabe
    {
        public int Id { get; set; }
        public string Frage { get; set; }
        public Schwierigkeitsgrad Schwierigkeitsgrad { get; set; }
        public string Antwort { get; set; }

        private List<Pruefungsaufgabe> _pruefungsaufgaben = new();
        private int _nextId = 1;

        public Pruefungsaufgabe(int id, string frage, Schwierigkeitsgrad schwierigkeitsgrad, string antwort)
        {
            Id = id;
            Frage = frage;
            Antwort = antwort;
            Schwierigkeitsgrad = schwierigkeitsgrad;
        }

    }
}
