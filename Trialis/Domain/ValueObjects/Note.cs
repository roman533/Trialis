namespace Trialis.Domain.ValueObjects
{
    public class Note
    {
        public int Wert { get; set; }

        private Note(int wert)
        {
            if (wert < 1 || wert > 5)
            {
                throw new ArgumentException("Ungültiger Notenwert. Die Note muss zwischen 1 und 5 liegen.");
            }

            Wert = wert;
        }

        public override string ToString()
        {
            return Wert.ToString();
        }

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