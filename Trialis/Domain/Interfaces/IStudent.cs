using Trialis.Domain.Entities;

namespace Trialis.Domain.Interfaces
{
    public interface IStudent
    {
        List<Student> GetAllStudents();
        Student GetStudentById(int id);
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);
        List<Student> GetStudentsByStudienfach(int id);
    }
}