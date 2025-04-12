using CsvHelper.Configuration;

namespace Contacts.MAUI.Models.Files.Csv
{
    public class ContactReadMap : ClassMap<Contact>
    {
        public ContactReadMap()
        {
            Map(c => c.ContactId).Name("ContactId");
            Map(c => c.Name).Name("Name");
            Map(c => c.Email).Name("Email");
            Map(c => c.Phone).Name("Phone");
            Map(c => c.Address).Name("Address");
        }
    }
}
