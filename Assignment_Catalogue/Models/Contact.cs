using Assignment_Catalogue.Interfaces;
using System.Diagnostics.Contracts;

namespace Assignment_Catalogue.Models;

public class Contact : IContact
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public IAddress? Address { get; set; }
    public string? FullName => $"{FirstName} {LastName}";

}


