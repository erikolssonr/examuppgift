namespace Assignment_Catalogue.Interfaces;

public interface IAddress
{
    string? City { get; set; }
    string? PostalCode { get; set; }
    string? StreetName { get; set; }
    string? FullAddress { get; }
}
