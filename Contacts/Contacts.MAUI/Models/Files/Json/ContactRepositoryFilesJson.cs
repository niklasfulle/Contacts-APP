using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Maui.ApplicationModel.Communication;
using Contact = Contacts.MAUI.Models.Contact;

namespace Contacts.MAUI.Models.Files.Json
{
    public static class ContactRepositoryFilesJson
    {
        private static readonly string _fileName = FileSystem.AppDataDirectory + "/Contacts.json";

        public static List<Contact> _contacts = new List<Contact>();

        public async static void WriteToFile()
        {
            var writeData = JsonSerializer.Serialize(_contacts);
            File.WriteAllText(_fileName, writeData);
        }

        public async static void ReadFromFile()
        {
            if (File.Exists(_fileName) == false)
            {
                var writeData = JsonSerializer.Serialize(_contacts);
                File.WriteAllText(_fileName, writeData);
            }

            var rawData = File.ReadAllText(_fileName);
            _contacts = JsonSerializer.Deserialize<List<Contact>>(rawData);
        }

        public static List<Contact> GetContacts() 
        {
            ReadFromFile();

            return _contacts;
        }

        public static Contact? GetContactById(int contactId)
        {
            var contact = _contacts.FirstOrDefault(x => x.ContactId == contactId);

            if (contact != null)
            {
                return new Contact(contactId, contact.Name, contact.Email, contact.Phone, contact.Address);
            }

            return null;
        }

        public static void UpdateContact(int contactId, Contact contact)
        {
            if (contactId != contact.ContactId) return;

            var contactToUpdate = _contacts.FirstOrDefault(x => x.ContactId == contactId);

            if (contactToUpdate != null)
            {
                contactToUpdate.Name = contact.Name;
                contactToUpdate.Email = contact.Email;
                contactToUpdate.Phone = contact.Phone;
                contactToUpdate.Address = contact.Address;
            }

            WriteToFile();
        }

        public static void CreateContact(Contact contact)
        {
            var maxId = 0;
            if (_contacts.Count != 0)
            {
                maxId = _contacts.Max(x => x.ContactId);
            }

            contact.ContactId = maxId + 1;
            _contacts.Add(contact);

            WriteToFile();
        }

        public static void DeleteContact(int contactId)
        {
            var contact = _contacts.FirstOrDefault(x => x.ContactId == contactId);
            if (contact != null)
            {
                _contacts.Remove(contact);
            }

            WriteToFile();
        }

        public static List<Contact> SearchContacts(string SearchQuery)
        {
            var contacts = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Name) && x.Name.StartsWith(SearchQuery, StringComparison.OrdinalIgnoreCase))?.ToList();

            if (contacts == null || contacts.Count == 0)
                contacts = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Email) && x.Email.StartsWith(SearchQuery, StringComparison.OrdinalIgnoreCase))?.ToList();
            else
                return contacts;

            if (contacts == null || contacts.Count == 0)
                contacts = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Phone) && x.Phone.StartsWith(SearchQuery, StringComparison.OrdinalIgnoreCase))?.ToList();
            else
                return contacts;

            if (contacts == null || contacts.Count == 0)
                contacts = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Address) && x.Address.StartsWith(SearchQuery, StringComparison.OrdinalIgnoreCase))?.ToList();
            else
                return contacts;

            return contacts;
        }
    }
}
