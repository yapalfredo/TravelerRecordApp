using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelerRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelerRecordApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegistrationPage : ContentPage
	{
		public RegistrationPage ()
		{
			InitializeComponent ();
		}

        private async void ButtonRegister_Clicked(object sender, EventArgs e)
        {
            if (entryPassword.Text == entryConfirmPassword.Text)
            {
                User user = new User()
                {
                    Email = entryEmail.Text,
                    Password = entryPassword.Text
                
                };

                await App.MobileService.GetTable<User>().InsertAsync(user);
            }
            else
            {
                await DisplayAlert("Error", "Passwords don't match", "Ok");
            }
        }
    }
}