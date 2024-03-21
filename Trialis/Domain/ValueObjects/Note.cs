namespace Trialis.Domain.ValueObjects
{
    public class Note
    {
        public int Wert { get; private set; }

        // Konstruktor für eine gültige Note
        private Note(int wert)
        {
            if (wert < 1 || wert > 5)
            {
                throw new ArgumentException("Ungültiger Notenwert. Die Note muss zwischen 1 und 5 liegen.");
            }

            Wert = wert;
        }

        // Öffentliche Factory-Methode zum Erstellen einer Note
        public static Note Erstelle(int wert)
        {
            return new Note(wert);
        }

        // Überschreiben der ToString-Methode für eine bessere Darstellung
        public override string ToString()
        {
            return Wert.ToString();
        }

        // Überschreiben der Equals- und GetHashCode-Methoden für die Vergleichbarkeit
        public override bool Equals(object obj)
        {
            var otherNote = obj as Note;
            return otherNote != null && Wert == otherNote.Wert;
        }

        public override int GetHashCode()
        {
            return Wert.GetHashCode();
        }
    
        public string GetInfo()
        {
            return $"Note: {Wert}";
        }

    }
}