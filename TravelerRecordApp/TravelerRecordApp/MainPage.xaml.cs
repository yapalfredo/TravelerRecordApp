using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelerRecordApp.Model;
using TravelerRecordApp.ViewModel;
using Xamarin.Forms;

namespace TravelerRecordApp
{
    public partial class MainPage : ContentPage
    {

        MainVM viewModel;


        public MainPage()
        {
            InitializeComponent();

            var assembly = typeof(MainPage);
            viewModel = new MainVM();
            BindingContext = viewModel;
            imageLogo.Source = ImageSource.FromResource("TravelerRecordApp.Assets.Images.plane.png", assembly);

        }



        private void ButtonRegister_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistrationPage());
        }
    }
}
