using Trialis.Domain.Interfaces;

namespace Trialis.Domain.Entities;

public class Professor
{
    public int Id { get; private set; }
    public string Name { get; set; }
    public string Fachgebiet { get; set; }
    public string Email { get; set; }
    public int Telefonnummer { get; set; }

    public Professor(int id, string name, string fachgebiet, string email, int telefonnummer)
    {
        Id = id;
        Name = name;
        Fachgebiet = fachgebiet;
        Email = email;
        Telefonnummer = telefonnummer;
    }
}