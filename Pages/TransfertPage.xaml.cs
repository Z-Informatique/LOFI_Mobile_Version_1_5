using LOFI.ViewModels;
using Communication = Microsoft.Maui.ApplicationModel.Communication;


namespace LOFI.Pages;

public partial class TransfertPage : ContentPage
{
	public TransfertPage(TransfertViewModel transfertViewModel)
	{
		InitializeComponent();
        BindingContext = transfertViewModel;
	}

	private async void picContact_Clicked(object sender, EventArgs e)
	{
        //try
        //{
        //    var contact = await Contacts.Default.PickContactAsync();

        //    if (contact == null)
        //        return;

        //    string id = contact.Id;
        //    string namePrefix = contact.NamePrefix;
        //    string givenName = contact.GivenName;
        //    string middleName = contact.MiddleName;
        //    string familyName = contact.FamilyName;
        //    string nameSuffix = contact.NameSuffix;
        //    string displayName = contact.DisplayName;
        //    List<ContactPhone> phones = contact.Phones; // List of phone numbers
        //    List<ContactEmail> emails = contact.Emails; // List of email addresses

        //    await DisplayAlert("Contact", familyName + " " + middleName + ", " + phones.SingleOrDefault().PhoneNumber, "OK");

        //}
        //catch (Exception ex)
        //{
        //    //throw;
        //}
        
    }
}