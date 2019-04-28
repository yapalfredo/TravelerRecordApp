using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TravelerRecordApp.Model;

namespace TravelerRecordApp.ViewModel.Commands
{
    public class LoginCommands : ICommand
    {
        public MainVM MainViewModel { get; set; }

        public LoginCommands(MainVM mainVM)
        {
            MainViewModel = mainVM;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            //Just for this one
            var user = (User)parameter;

            if (user == null)
            {
                return false;
            }

            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
