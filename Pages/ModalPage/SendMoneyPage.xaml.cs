using CommunityToolkit.Maui.Views;
using Communication = Microsoft.Maui.ApplicationModel.Communication;

namespace LOFI.Pages.ModalPage;

public partial class SendMoneyPage : Popup
{
	public SendMoneyPage()
	{
		InitializeComponent();
	}

    private void btnClose_Clicked(object sender, EventArgs e)
    {
        Close();
    }

    private async void picContact_Clicked(object sender, EventArgs e)
    {
        try
        {
            var contact = await Communication.Contacts.Default.PickContactAsync();

            if (contact == null)
                return;

            string id = contact.Id;
            string namePrefix = contact.NamePrefix;
            string givenName = contact.GivenName;
            string middleName = contact.MiddleName;
            string familyName = contact.FamilyName;
            string nameSuffix = contact.NameSuffix;
            string displayName = contact.DisplayName;
            List<ContactPhone> phones = contact.Phones; // List of phone numbers
            List<ContactEmail> emails = contact.Emails; // List of email addresses
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Info", ex.Message, "OK");
        }
    }
}