using System;
using System.Collections.Generic;
using System.Text;
using TravelerRecordApp.ViewModel.Commands;

namespace TravelerRecordApp.ViewModel
{
    public class HomeVM
    {
        public NavigationCommands NavCommand { get; set; }

        public HomeVM()
        {
            NavCommand = new NavigationCommands(this);
        }

        public async void Navigate()
        {
            //TODO
           await App.Current.MainPage.Navigation.PushAsync(new NewTravelPage());
        }


    }
}
