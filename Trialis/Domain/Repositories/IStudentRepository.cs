using Trialis.Domain.Entities;

namespace Trialis.Domain.Repositories;

public interface IStudentRepository
{
    public void HinzufuegenKlausur(Klausur klausur);
    public double BerechneDurchschnittsnote();
    public List<Student> GetAllStudents();
    public Student GetStudentById(int id);
    public void AddStudent(Student student);
    public void UpdateStudent(Student updatedStudent);
    public void DeleteStudent(int id);
    //public List<Student> GetStudentsByStudienfach(int id);
    public List<Studienfach> GetStudienfaecher();
}