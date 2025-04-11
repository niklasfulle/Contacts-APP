using Contacts.MAUI.Models;
using Contact = Contacts.MAUI.Models.Contact;

namespace Contacts.MAUI.Views;

[QueryProperty(nameof(ContactId), "Id")]
public partial class ViewContactPage : ContentPage
{

    private Contact contact;
    public ViewContactPage()
	{
		InitializeComponent();
	}

    public string ContactId
    {
        set
        {
            contact = ContactRepository.GetContactById(int.Parse(value));
            if (contact != null)
            {
                contactView.Name = contact.Name;
                contactView.Email = contact.Email;
                contactView.Phone = contact.Phone;
                contactView.Address = contact.Address;
            }
        }
    }

    private void contactView_OnCancel(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
    }
}
