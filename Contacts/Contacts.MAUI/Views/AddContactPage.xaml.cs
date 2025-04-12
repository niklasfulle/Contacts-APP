using Contact = Contacts.MAUI.Models.Contact;
using ContactRepository = Contacts.MAUI.Models.Files.Csv.ContactRepositoryFilesCsv;

namespace Contacts.MAUI.Views;

public partial class AddContactPage : ContentPage
{
    private Contact contact;
    public AddContactPage()
    {
        InitializeComponent();
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
    }

    private void contactCtrl_OnSave(object sender, EventArgs e)
    {
        ContactRepository.CreateContact(new Contact(0, contactCtrl.Name, contactCtrl.Email, contactCtrl.Phone, contactCtrl.Address));
        Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
    }

    private void contactCtrl_OnCancel(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
    }

    private void contactCtrl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "OK");
    }
}