using Trialis.Domain.Interfaces;

namespace Trialis.Domain.Entities
{
// Domain/Entities/Student.cs

    public class Student : IStudentInformation
    {
        public int Id { get; private set; }
        public short Matrikelnummer { get; private set; }
        public string Name { get; private set; }

        public Student(int id, short matrikelnummer, string name)
        {
            Id = id;
            Matrikelnummer = matrikelnummer;
            Name = name;
        }

        public string GetStudentInfo()
        {
            return $"Student ID: {Id}, Matrikelnummer: {Matrikelnummer}, Name: {Name}";
        }
    }
}