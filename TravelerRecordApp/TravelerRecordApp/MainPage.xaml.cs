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
           bool isEmailEmpty = string.IsNullOrEmpty(entryEmail.Text);
           bool isPasswordEmtpy = string.IsNullOrEmpty(entryPassword.Text);

            if (isEmailEmpty || isPasswordEmtpy)
            {

            }
            else
            {
                //Get the table in the cloud
                var user = (await App.MobileService.GetTable<User>().Where(u => u.Email == entryEmail.Text).ToListAsync()).FirstOrDefault();

                if (user != null)
                {
                    App.user = user;
                    if (user.Password == entryPassword.Text)
                    {
                      await  Navigation.PushAsync(new HomePage());
                    }
                    else
                    {
                       await DisplayAlert("Error", "Tjhe email or password is incorrect", "Ok");
                    }
                }
            }

        }

        private void ButtonRegister_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistrationPage());
        }
    }
}
