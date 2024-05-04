using Trialis.Domain.Entities;
using Trialis.Domain.Repositories;

namespace Trialis.Services;

public class BusinessLogicDependency
{
    private readonly Student _student;
    private readonly StudentRepository _studentRepository;

    public BusinessLogicDependency(Student student)
    {
        _student = student;
    }

    public List<Student> GetAllStudents()
    {
        return _studentRepository.GetAllStudents();
    }
}