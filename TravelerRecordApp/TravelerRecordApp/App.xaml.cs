using Microsoft.WindowsAzure.MobileServices;
using System;
using TravelerRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TravelerRecordApp
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;

        public static MobileServiceClient MobileService = new MobileServiceClient("https://travelerrecordapp.azurewebsites.net");

        public static User user = new User(); 

        public App()
        {
            InitializeComponent();
            //creating a navigation and setting the root page
            MainPage = new NavigationPage(new MainPage());
        }

        public App(string databaselocation)
        {
            InitializeComponent();
            //creating a navigation and setting the root page
            MainPage = new NavigationPage(new MainPage());

            DatabaseLocation = databaselocation;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
