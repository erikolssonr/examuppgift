using Assignment_Catalogue.Models;

namespace Assignment_Catalogue.Interfaces;

public interface IContactService
{
    void CreateContact(IContact contact);
    IEnumerable<IContact> GetAllContacts();
    IContact GetOneContact(string email);
    void RemoveContact(string email);
}
