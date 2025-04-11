using System.Collections.ObjectModel;
using Contacts.MAUI.Models;
using Contact = Contacts.MAUI.Models.Contact;

namespace Contacts.MAUI.Views;

public partial class ContactsPage : ContentPage
{
	public ContactsPage()
	{
		InitializeComponent();
    }

    private void loadContacts()
    {
        var contacts = new ObservableCollection<Contact>(ContactRepository.GetContacts());

        listContacts.ItemsSource = contacts;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        loadContacts();
    }

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddContactPage));
    }

    private void SwipeItemDelete_Clicked(object sender, EventArgs e)
    {
        var menuItem = sender as MenuItem;
        var contact = menuItem.CommandParameter as Contact;

        if(contact != null)
        {
            ContactRepository.DeleteContact(contact.ContactId);
        }

        loadContacts();
    }

    private void SwipeItemEdit_Clicked(object sender, EventArgs e)
    {
        var menuItem = sender as MenuItem;
        var contact = menuItem.CommandParameter as Contact;

        if (contact != null)
        {
            Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={contact.ContactId}");
        }
    }

    private void SwipeItemView_Clicked(object sender, EventArgs e)
    {
        var menuItem = sender as MenuItem;
        var contact = menuItem.CommandParameter as Contact;

        if (contact != null)
        {
            Shell.Current.GoToAsync($"{nameof(ViewContactPage)}?Id={contact.ContactId}");
        }
    }

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        var contacts = new ObservableCollection<Contact>(ContactRepository.SearchContacts(((SearchBar)sender).Text));
        listContacts.ItemsSource = contacts;
    }
}
