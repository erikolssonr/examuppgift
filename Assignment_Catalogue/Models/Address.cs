using Assignment_Catalogue.Interfaces;

namespace Assignment_Catalogue.Models;

public class Address : IAddress
{
    public string? StreetName { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }
    
    public string? FullAddress => $"{StreetName}, {PostalCode} {City}";
}

