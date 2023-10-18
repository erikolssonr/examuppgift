using Assignment_Catalogue.Interfaces;
using Assignment_Catalogue.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace Assignment_Catalogue.Services;

public class MenuService
{
    private static readonly IContactService _contactService = new ContactService(); //Private and static instance for the use of handling the created contacts.
    public static void CreateContactMenu() //Method for creating a contact which then adds it in to the existing list of contacts with the help of .CreateContactAsync
    {
        IContact contact = new Contact(); //new contact instance
        do
        {
            Console.WriteLine("First name: ");
            contact.FirstName = Console.ReadLine();
            Console.WriteLine("Last name: ");
            contact.LastName = Console.ReadLine();
            Console.WriteLine("Email: ");
            contact.Email = Console.ReadLine();
            if (contact.Email == string.Empty)
            {
                Console.WriteLine("You didn't provide a valid email, please enter a valid one:");
                break;
            }
            Console.WriteLine("Phone: ");
            contact.PhoneNumber = Console.ReadLine();

            contact.Address = new Address();
            Console.WriteLine("Street name: ");
            contact.Address.StreetName = Console.ReadLine();
            Console.WriteLine("Postal code: ");
            contact.Address.PostalCode = Console.ReadLine();
            Console.WriteLine("City: ");
            contact.Address.City = Console.ReadLine();

            _contactService.CreateContact(contact);
            break;
        
        } while (true);

    }

    public static void ViewAllContactsMenu() //Method for viewing all the current contacts in the list.
    {
        foreach (var contact in _contactService.GetAllContacts()) // foreach loop that goes through each contact and writes out its name and adress.
        {
            Console.WriteLine(contact.FullName);
            Console.WriteLine(contact.Address?.FullAddress);
            Console.WriteLine();
        }
    }
    
    public static void ViewOneContactMenu() //Method for viewing a specific contact provided the user inputs an email that is registered to a contact in the list.
    {
        Console.WriteLine("Please provide the email associated with the account you wish to view: ");
        var email = Console.ReadLine();

        
        var contact = _contactService.GetOneContact(email!);

        Console.WriteLine(contact?.FullName);
        Console.WriteLine(contact?.Address?.FullAddress);
        Console.WriteLine();
    }

    public static void RemoveOneContactMenu() //Method for removing a specific contact provided the user inputs an email that is registered to a contact in the list.
    {
        Console.WriteLine("Please provide the Email associated with the account ou wish to delete: ");
        var email = Console.ReadLine();

        _contactService.RemoveContact(email!);
    }

    public static void MainMenu()
    {
        do // Constant loop of the main menu that displays the options you have as a user
        {
            Console.Clear();
            Console.WriteLine("1. Create a new user");
            Console.WriteLine("2. Show all users");
            Console.WriteLine("3. Show specific user");
            Console.WriteLine("4. Remove a specific user");
            Console.WriteLine("0. Quit");
            Console.WriteLine("Choose one of the options (1,2,3,4 or 0 to quit).");
            var option = Console.ReadLine();

            Console.Clear();

            switch (option) //Switch case setup to make the options do something. we use our MenuService class to grab the correct methods in each case.
            {
                case "1":
                    MenuService.CreateContactMenu();
                    break;

                case "2":
                    MenuService.ViewAllContactsMenu();
                    break;

                case "3":
                    MenuService.ViewOneContactMenu();
                    break;

                case "4":
                    MenuService.RemoveOneContactMenu();
                    break;

                case "0":
                    Environment.Exit(0);
                    break;

            }

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

          

        } while (true);
    }
}







