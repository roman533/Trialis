using Trialis.Domain.Entities;

namespace Trialis.Domain.Utilities;

public class StudentManagementSystem
{
    private readonly List<Student> _students;

    public StudentManagementSystem()
    {
        _students = new List<Student>();
    }
    
    public void AddStudent(Student student)
    {
        _students.Add(student);
        Console.WriteLine($"Student {student.Name} erfolgreich hinzugefügt.");
    }

    public void UpdateStudent(int studentId, Student updatedStudent)
    {
        var existingStudent = GetStudentById(studentId);
        if (existingStudent != null)
        {
            existingStudent.Name = updatedStudent.Name;
            existingStudent.Matrikelnummer = updatedStudent.Matrikelnummer;
            existingStudent.Studiengang = updatedStudent.Studiengang;
            existingStudent.Semester = updatedStudent.Semester;
            
            Console.WriteLine($"Student {existingStudent.Name} erfolgreich aktualisiert.");
        }
        else
        {
            Console.WriteLine($"Student mit der ID {studentId} wurde nicht gefunden.");
        }
    }

    public void DeleteStudent(int studentId)
    {
        var studentToRemove = GetStudentById(studentId);
        if (studentToRemove != null)
        {
            _students.Remove(studentToRemove);
            Console.WriteLine($"Student mit der ID {studentId} erfolgreich gelöscht.");
        }
        else
        {
            Console.WriteLine($"Student mit der ID {studentId} wurde nicht gefunden.");
        }
    }

    public Student GetStudentById(int studentId)
    {
        return _students.FirstOrDefault(student => student.Id == studentId);
    }
}