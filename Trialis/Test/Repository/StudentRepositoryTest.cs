using Moq;
using NUnit.Framework;
using Trialis.Domain.Entities;
using Trialis.Domain.Repositories;
using Trialis.Domain.RepositoryInterfaces;
using Trialis.Domain.ValueObjects;

namespace Trialis.Test.Repository;

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

    /*[Test]
    public void HinzufuegenKlausur_AddsKlausurToStudent()
    {
        // Arrange
        var studentMock = new Mock<Student>();
        var student = studentMock.Object;
        var klausurMock =
            new Mock<Klausur>(1, DateTime.Now, "Thema", "Beschreibung", new List<Pruefungsaufgabe>(), 1, 1);
        klausurMock.Setup(k => k.AddErgebnis(It.IsAny<int>(), It.IsAny<Note>()));
        var studentRepo = new StudentRepository();
        // Act
        studentRepo.HinzufuegenKlausur(student, klausurMock.Object);
        // Assert
        Assert.Contains(klausurMock.Object, student.Klausuren);
    }*/
}