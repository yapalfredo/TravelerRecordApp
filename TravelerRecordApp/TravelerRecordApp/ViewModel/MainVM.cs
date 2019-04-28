using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TravelerRecordApp.Model;
using TravelerRecordApp.ViewModel.Commands;

namespace TravelerRecordApp.ViewModel
{
    public class MainVM : INotifyPropertyChanged
    {
        private User user;
        public User User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }


        public LoginCommands LoginCommand { get; set; }

        private string email;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                User = new User()
                {
                    Email = this.Email,
                    Password = this.Password
                };
                OnPropertyChanged("Email");
            }
        }

        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                User = new User()
                {
                    Email = this.Email,
                    Password = this.Password
                };
                OnPropertyChanged("Password");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

        }

        public MainVM()
        {
            User = new User();
            LoginCommand = new LoginCommands(this);
        }

        public async void Login()
        {
            bool canLogin = await User.Login(User.Email, User.Password);

            if (canLogin)
            {
                await App.Current.MainPage.Navigation.PushAsync(new HomePage());
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "The email or password is incorrect", "Ok");
            }
        }
    }
}
