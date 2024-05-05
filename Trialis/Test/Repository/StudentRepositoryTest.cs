using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using Trialis.Domain.Entities;
using Trialis.Domain.Repositories;
using Trialis.Domain.RepositoryInterfaces;
using Trialis.Domain.ValueObjects;

namespace Trialis.Test.Repository;

[TestFixture]
public class StudentRepositoryTests
{
    private StudentRepository _repository;
    private List<Student> _students;

    // SetUp for all tests
    [SetUp]
    public void Setup()
    {
        // Prepare list of Students 
        _students = new List<Student>
        {
            new Student(1, 1001, "Student 1", "Informatik", 2),
            new Student(2, 1002, "Student 2", "Informatik", 3),
            new Student(3, 1003, "Student 3", "Informatik", 1),
        };
        _repository = new StudentRepository();
    }

    // Thorough
    [Test]
    public void GetStudentById_GivenId_ReturnsCorrectStudent()
    {
        var actualStudent = _repository.GetStudentById(1);
        Assert.Equals("Student 1", actualStudent.Name);
    }

    // Atomic
    [Test]
    public void GetAllStudents_ReturnsAllStudents()
    {
        var allStudents = _repository.GetAllStudents();
        Assert.Equals(3, allStudents.Count);
    }

    // Repeatable
    [Test]
    public void AddStudent_Always_AddsNewStudent()
    {
        var newStudent = new Student(1, 1001, "Student 1", "Informatik", 2);
        _repository.AddStudent(newStudent);

        Assert.Equals(4, _repository.GetAllStudents().Count);
        Assert.Equals("Student 4", _repository.GetStudentById(4).Name);
    }

    // Independent
    [Test]
    public void UpdateStudent_UpdatesStudentData()
    {
        var updatedStudent = new Student(1, 1001, "Student 1", "Informatik", 2);
        _repository.UpdateStudent(updatedStudent);

        Assert.Equals("Updated Student", _repository.GetStudentById(2).Name);
    }

    // Professional
    [Test]
    public void DeleteStudent_RemovesStudentFromRepository()
    {
        _repository.DeleteStudent(3);

        Assert.Equals(2, _repository.GetAllStudents().Count);
    }
}


/*
public class StudentRepositoryTest
{
    [Test]
    public void BerechneDurchschnittsnote_ReturnsCorrectAverage_WhenKlausurenExist()
    {
        // Arrange
        var studentMock = new Mock<Student>();
        var student = studentMock.Object;

        var klausurMock1 = new Mock<Klausur>(1, DateTime.Now, "Thema 1", "Beschreibung 1", new List<Pruefungsaufgabe>(),
            1, 1);
        //klausurMock1.Setup(k => k.AddErgebnis(It.IsAny<int>(), It.IsAny<Note>()));

        var klausurMock2 = new Mock<Klausur>(2, DateTime.Now, "Thema 2", "Beschreibung 2", new List<Pruefungsaufgabe>(),
            1, 1);
        //klausurMock2.Setup(k => k.AddErgebnis(It.IsAny<int>(), It.IsAny<Note>()));

        var studentRepo = new StudentRepository();

        studentRepo.HinzufuegenKlausur(klausurMock1.Object);
        studentRepo.HinzufuegenKlausur(klausurMock2.Object);

        // Act
        var result = studentRepo.BerechneDurchschnittsnote();

        // Assert
        Assert.Equals(0.0, result); // Hier entsprechend den erwarteten Durchschnitt eintragen
    }

    [Test]
    public void BerechneDurchschnittsnote_ReturnsZero_WhenNoKlausuren()
    {
        // Arrange
        var studentRepo = new StudentRepository();

        // Act
        var result = studentRepo.BerechneDurchschnittsnote();

        // Assert
        Assert.Equals(0.0, result);
    }
    
    
    
}*/