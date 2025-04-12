namespace Contacts.MAUI.Models
{
    public class Contact
    {
        public Contact(int ContactId, string Name, string Email, string Phone, string Address)
        {
            this.ContactId = ContactId;
            this.Name = Name;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
        }

        public int ContactId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }
    }
}
