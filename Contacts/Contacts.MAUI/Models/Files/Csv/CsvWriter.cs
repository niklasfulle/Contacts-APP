using System.Globalization;
using CsvHelper.Configuration;

namespace Contacts.MAUI.Models.Files.Csv
{
    public static class CsvWriter
    {
        public static void WriteToCsv(string path, List<Contact> contacts)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                NewLine = Environment.NewLine,
                Delimiter = ";"
            };

            using var writer = new StreamWriter(path);
            using var csv = new CsvHelper.CsvWriter(writer, config);

            csv.Context.RegisterClassMap<ContactReadMap>();

            csv.WriteRecords<Contact>(contacts);
        }
    }
}
