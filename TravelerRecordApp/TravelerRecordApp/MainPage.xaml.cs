using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelerRecordApp.Model;
using Xamarin.Forms;

namespace TravelerRecordApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var assembly = typeof(MainPage);
            imageLogo.Source = ImageSource.FromResource("TravelerRecordApp.Assets.Images.plane.png", assembly);

        }

        private async void ButtonLogin_Clicked(object sender, EventArgs e)
        {
            bool canLogin = await User.Login(entryEmail.Text, entryPassword.Text);

            if (canLogin)
            {
                await Navigation.PushAsync(new HomePage());
            }
            else
            {
                await DisplayAlert("Error", "The email or password is incorrect", "Ok");
            }

        }

        private void ButtonRegister_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistrationPage());
        }
    }
}
