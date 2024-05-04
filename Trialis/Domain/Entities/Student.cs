using Trialis.Domain.Interfaces;

namespace Trialis.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public short Matrikelnummer { get; set; }
        public string Name { get; set; }
        public string Studiengang { get; set; } 
        public int Semester { get; set; }
        public List<Studienfach> Studienfaecher { get; set; } = new();
        public List<Klausur> Klausuren { get; set; } = new();

        private static List<Student> _studentList = new();
        
        public Student(int id, short matrikelnummer, string name, string studiengang, int semester)
        {
            Id = id;
            Matrikelnummer = matrikelnummer;
            Name = name;
            Studiengang = studiengang;
            Semester = semester;
        }
    }
}