using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace TravelerRecordApp.ViewModel.Commands
{
    public class NavigationCommands : ICommand
    {
        public HomeVM HomeViewModel { get; set; }

        public NavigationCommands(HomeVM homeVM)
        {
            HomeViewModel = homeVM;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            //this is going to always return true
            return true;
        }

        public void Execute(object parameter)
        {
            HomeViewModel.Navigate();
        }
    }
}
