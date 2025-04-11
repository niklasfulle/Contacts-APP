namespace Contacts.MAUI.Views;

using Contacts.MAUI.Models;
using Contact = Contacts.MAUI.Models.Contact;

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
        ContactRepository.CreateContact(new Contact
        {
            Name = contactCtrl.Name,
            Email = contactCtrl.Email,
            Phone = contactCtrl.Phone,
            Address = contactCtrl.Address
        });
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