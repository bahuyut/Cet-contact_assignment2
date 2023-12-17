
using CetContact.Views;


namespace CetContact
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(ContactsPage), typeof(ContactsPage));
            Routing.RegisterRoute(nameof(AddContactPage), typeof(AddContactPage));
            Routing.RegisterRoute(nameof(EditContactPage), typeof(EditContactPage));


    //< ShellContent
    //    Title = "Home"
    //    ContentTemplate = "{DataTemplate views:ContactsPage}"
    //    Route = "ContactsPage" />

            //  <Button Text="Kişi Ekle" x:Name="AddContactButton" Clicked="AddContactButton_Clicked"></Button>
            //Shell.Current.GoToAsync(nameof(AddContactPage));


        }
    }
}