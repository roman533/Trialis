using Trialis.Domain.Entities;

namespace Trialis.Services;

public class BusinessLogicDependency
{
    private readonly Student _student;

    public BusinessLogicDependency(Student student)
    {
        _student = student;
    }

    public List<Student> GetAllStudents()
    {
        return _student.GetAllStudents();
    }
}