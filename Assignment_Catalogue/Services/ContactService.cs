using Assignment_Catalogue.Interfaces;
using Assignment_Catalogue.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Text.Json.Serialization;

namespace Assignment_Catalogue.Services;

public class ContactService : IContactService
{
    public ContactService()  //CTOR that runs first and tries to load an existing file, if it exists.
    {
        LoadContactsFromFile();
    }

    private List<IContact> _contacts = new();  //new instance of the IContact List
    private readonly string _filePath = @"c:\Users\eriko\contacts.json";
    public void CreateContact(IContact contact) // Adds a contact to the _contacts in the list IContact, which then saves it using the SaveContactsToFile method aswell.
    {
        _contacts.Add(contact);

        SaveContactsToFile();
    }

    public IEnumerable<IContact> GetAllContacts() //IEnumerable list of the interface IContact which returns the _contacts registered in that list.
    {
        return _contacts;
    }

    public IContact GetOneContact(string email) //returns one contact based on the email provided.
    {
        return _contacts.FirstOrDefault(x => x.Email == email)!;
    }

    public void RemoveContact(string email) // removes a contact if the contact is not null and the email provided is registered to an existing contact. It then also saves it with SaveContacts..
    {
        var contact = GetOneContact(email);
        if (contact != null)
        {
            _contacts.Remove(contact);

            SaveContactsToFile();
        }
    }

    public void LoadContactsFromFile() //the method that the CTOR runs which is a readfromfile method built in FileService.
    {

        string content = FileService.ReadFromFile(_filePath); //uses the filepath provided and reads that file.
        
        if (!string.IsNullOrEmpty(content))  //checks so it is not null or empty.
                _contacts = JsonConvert.DeserializeObject<List<IContact>>(content, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto })!;
    }  // Deserializes the object. with the help of JsonSerializerSettings & TypeNameHandling to specify what type name handling options the file has since it is not possible to deserialize a list of an interface.

    public void SaveContactsToFile() // Method that converts the _contacts into a Json obj, with the use of JsonSerializerSettings it provides the method with its filetype. Uses the FileService method SaveToFile.
    {
        string json = JsonConvert.SerializeObject(_contacts, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
        FileService.SaveToFile(json, _filePath);
    }

   
}
