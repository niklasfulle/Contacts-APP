using System.Globalization;
using CsvHelper.Configuration;

namespace Contacts.MAUI.Models.Files.Csv
{
    public static class CsvReader
    {
        public static List<Contact> ReadCsvFile(string path)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                NewLine = Environment.NewLine,
                Delimiter = ";"
            };

            using var reader = new StreamReader(path);
            using var csv = new CsvHelper.CsvReader(reader, config);

            csv.Context.RegisterClassMap<ContactReadMap>();
            List<Contact> _contacts = (List<Contact>)csv.GetRecords<Contact>();

            return _contacts;
        }
    }
}
