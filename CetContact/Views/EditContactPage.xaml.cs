using CetContact.Model;

namespace CetContact.Views;

[QueryProperty(nameof(ContactId),"id")]
public partial class EditContactPage : ContentPage
{
    ContactInfo contactInfo;
    ContactRepository contactRepository;
    public EditContactPage()
	{
		InitializeComponent();
        contactRepository = new ContactRepository();
	}

    public string ContactId { get; set; }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        contactInfo = await contactRepository.GetContactById(Int32.Parse(ContactId));
        if (contactInfo != null)
        {

            NameEntry.Text = contactInfo.Name;
            PhoneEntry.Text = contactInfo.Phone;
            EmailEntry.Text = contactInfo.Email;
            AdressEntry.Text = contactInfo.Address;
        }
        else
        {
           await DisplayAlert("Hata", "Kişi Bulunamadı", "Tamam");
        }
    }
   
    private  async void SaveButton_Clicked(object sender, EventArgs e)
    {

        if (string.IsNullOrWhiteSpace(NameEntry.Text))
        {
            await DisplayAlert("Uyarı", "Ad kısmı boş bırakılamaz.", "Tamam");
            return;
        }

        if (string.IsNullOrWhiteSpace(EmailEntry.Text))
        {
            await DisplayAlert("Uyarı", "Eposta kısmı boş bırakılamaz.", "Tamam");
            return;
        }

        contactInfo.Name = NameEntry.Text;
        contactInfo.Phone = PhoneEntry.Text;
        contactInfo.Address = AdressEntry.Text;
        contactInfo.Email = EmailEntry.Text;

        await contactRepository.Update(contactInfo);
        await Shell.Current.GoToAsync("..");

    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {

        bool answer = await DisplayAlert("Uyarı", "Bu kişiyi silmek istediğinize emin misiniz?", "Evet", "Hayır");

        if (answer)
        {
            contactInfo.Name = NameEntry.Text;
            contactInfo.Phone = PhoneEntry.Text;
            contactInfo.Address = AdressEntry.Text;
            contactInfo.Email = EmailEntry.Text;

            await contactRepository.DeleteContact(contactInfo);
            await Shell.Current.GoToAsync("..");
        }

    }

    private async void BackButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}