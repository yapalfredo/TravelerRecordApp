using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TravelerRecordApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ButtonLogin_Clicked(object sender, EventArgs e)
        {
           bool isEmailEmpty = string.IsNullOrEmpty(entryEmail.Text);
           bool isPasswordEmtpy = string.IsNullOrEmpty(entryPassword.Text);

            if (isEmailEmpty || isPasswordEmtpy)
            {

            }
            else
            {
                Navigation.PushAsync(new HomePage());
            }

        }
    }
}
