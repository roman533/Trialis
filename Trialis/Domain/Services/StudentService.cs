using Trialis.Domain.Entities;
using Trialis.Domain.Interfaces;
using Trialis.Domain.Repositories;
using Trialis.Domain.RepositoryInterfaces;

namespace Trialis.Domain.Services;

public class StudentService : IStudentService
{
    private IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }
    
    public void HinzufuegenKlausur(Klausur klausur)
    {
        _studentRepository.HinzufuegenKlausur(klausur);
    }

    public double BerechneDurchschnittsnote()
    {
        return _studentRepository.BerechneDurchschnittsnote();
    }

    public List<Student> GetAllStudents()
    {
        return _studentRepository.GetAllStudents();
    }

    public Student GetStudentById(int id)
    {
        return _studentRepository.GetStudentById(id);
    }

    public void AddStudent(Student student)
    {
        _studentRepository.AddStudent(student);
    }

    public void UpdateStudent(Student updatedStudent)
    {
        _studentRepository.UpdateStudent(updatedStudent);
    }

    public void DeleteStudent(int id)
    {
        _studentRepository.DeleteStudent(id);
    }

    public List<Student> GetStudentsByStudienfach(int id)
    {
        throw new NotImplementedException();
    }

    //public List<Student> GetStudentsByStudienfach(int id);

    public List<Studienfach> GetStudienfaecher()
    {
        return _studentRepository.GetStudienfaecher();
    }
}