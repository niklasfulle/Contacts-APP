using ContactRepository = Contacts.MAUI.Models.Files.Csv.ContactRepositoryFilesCsv;

namespace Contacts.MAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            ContactRepository.ReadFromFile();
        }
    }
}
