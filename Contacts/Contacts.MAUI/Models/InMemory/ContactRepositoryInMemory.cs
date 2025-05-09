﻿namespace Contacts.MAUI.Models.InMemory
{
    public static class ContactRepositoryInMemory
    {
        public static List<Contact> _contacts = new List<Contact>()
        {
            new Contact(1,"John Doe","JohnDoe@gmail.com","308974204","Test"),
            new Contact(2,"Jane Doe","JaneDoe@gmail.com","308974204","Test"),
            new Contact(3,"Tom Hanks","TomHanks@gmail.com","308974204","Test"),
            new Contact(4,"Frank Liu","FrankLiu@gmail.com","308974204","Test")
        };

        public static List<Contact> GetContacts() => _contacts;

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
        }

        public static void DeleteContact(int contactId)
        {
            var contact = _contacts.FirstOrDefault(x => x.ContactId == contactId);
            if (contact != null)
            {
                _contacts.Remove(contact);
            }
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
