using Android.Media.TV;

namespace Contacts.MAUI.Views.Components;

public partial class ContactView : ContentView
{
    public event EventHandler<EventArgs> OnCancel;
    public ContactView()
	{
		InitializeComponent();
	}

    public string Name
    {
        get
        {
            return LabelName.Text;
        }
        set
        {
            LabelName.Text = value;
        }
    }

    public string Email
    {
        get
        {
            return LabelEmail.Text;
        }
        set
        {
            LabelEmail.Text = value;
        }
    }

    public string Phone
    {
        get
        {
            return LabelPhone.Text;
        }
        set
        {
            LabelPhone.Text = value;
        }
    }

    public string Address
    {
        get
        {
            return LabelAddress.Text;
        }
        set
        {
            LabelAddress.Text = value;
        }
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        OnCancel?.Invoke(sender, e);
    }
}