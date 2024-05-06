using NUnit.Framework;
using Trialis.Domain.Entities;
using Trialis.Domain.Repositories;

[TestFixture]
public class ProfessorRepositoryTests
{
    private ProfessorRepository _repository;
    private List<Professor> _professoren;

    [SetUp]
    public void Setup()
    {
        _professoren = new List<Professor>
        {
            new(1, "Professor 1", "Informatik", "prof1@university.com", 1234567890),
            new (2, "Professor 2", "Mathematik", "prof2@university.com", 1234567891),
            new (3, "Professor 3", "Biologie", "prof3@university.com", 1234567892),
        };
        _repository = new ProfessorRepository();
    }

    [Test]
    public void GetProfessorById_GivenId_ReturnsCorrectProfessor()
    {
        var actualProfessor = _repository.GetProfessorById(1);
        Assert.Equals("Professor 1", actualProfessor.Name);
    }

    [Test]
    public void GetAllProfessors_ReturnsAllProfessors()
    {
        var allProfessors = _repository.GetAllProfessors();
        Assert.Equals(3, allProfessors.Count);
    }

    [Test]
    public void AddProfessor_Always_AddsNewProfessor()
    {
        var newProfessor = new Professor(4, "Professor 4", "Physik", "prof4@university.com", 1234567893);
        _repository.AddProfessor(newProfessor);

        Assert.Equals(4, _repository.GetAllProfessors().Count);
        Assert.Equals("Professor 4", _repository.GetProfessorById(4).Name);
    }

    [Test]
    public void UpdateProfessor_UpdatesProfessorData()
    {
        var updatedProfessor = new Professor(2, "Professor 2 updated", "Mathematik", "prof2updated@university.com",
            1234567891);
        _repository.UpdateProfessor(updatedProfessor);

        Assert.Equals("Professor 2 updated", _repository.GetProfessorById(2).Name);
    }

    [Test]
    public void DeleteProfessor_RemovedProfessorFromRepository()
    {
        _repository.DeleteProfessor(3);

        Assert.Equals(2, _repository.GetAllProfessors().Count);
    }
}