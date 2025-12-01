using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revision.Business
{
    public class LoginBusiness : INotifyPropertyChanged
    {
        private string _username = "";
        private string _password = "";
        private string _errorMessage = "";
        private bool _isLoading = false;

        public string Username
        {
            get { return _username; }
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged(nameof(Username));
                }
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                if (_errorMessage != value)
                {
                    _errorMessage = value;
                    OnPropertyChanged(nameof(ErrorMessage));
                }
            }
        }

        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                if (_isLoading != value)
                {
                    _isLoading = value;
                    OnPropertyChanged(nameof(IsLoading));
                }
            }
        }

        public DelegateCommand LoginCommand { get; set; }
        public event EventHandler LoginSuccessful;

        public LoginBusiness()
        {
            LoginCommand = new DelegateCommand(Login);
        }

        private void Login()
        {
            ErrorMessage = "";

            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                ErrorMessage = "Please enter username and password";
                return;
            }

            // Simple dummy authentication: admin / admin
            if (Username == "admin" && Password == "admin")
            {
                // Raise event to notify that login was successful
                LoginSuccessful?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                ErrorMessage = "Invalid username or password";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

