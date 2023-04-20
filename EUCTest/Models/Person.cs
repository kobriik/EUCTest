namespace EUCTest.Models;

public partial class Person
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? IdentityNumber { get; set; }

    public string Email { get; set; } = null!;

    public DateTime Birthdate { get; set; }

    public int SexId { get; set; }

    public int CountryId { get; set; }

    public bool GdprAgree { get; set; }

    public virtual Country Country { get; set; } = null!;

    public virtual Sex Sex { get; set; } = null!;
}
