using Prism.Commands;
using System;
using System.ComponentModel;

namespace Revision.Business
{
    // Business logic for login authentication
    public class LoginBusiness : INotifyPropertyChanged
    {
        // Private fields for properties
        private string _username = "";
        private string _password = "";
        private string _errorMessage = "";

        // Public property for username - binds to TextBox
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

        // Public property for password - synced from PasswordBox
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

        // Public property for error message - shows when login fails
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

        // Command for Login button
        public DelegateCommand LoginCommand { get; set; }

        // Event fired when login is successful
        public event EventHandler LoginSuccessful;

        // Event required for property binding
        public event PropertyChangedEventHandler PropertyChanged;

        // Constructor - initialize the Login command
        public LoginBusiness()
        {
            LoginCommand = new DelegateCommand(Login);
        }

        // Login method - called when Login button is clicked
        private void Login()
        {
            ErrorMessage = ""; // Clear previous error

            // Check if username and password are entered
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                ErrorMessage = "Please enter username and password";
                return;
            }

            // Check credentials - username: admin, password: admin
            if (Username == "admin" && Password == "admin")
            {
                // Login successful - fire event to open main window
                LoginSuccessful?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                // Login failed
                ErrorMessage = "Invalid username or password";
            }
        }

        // Helper method to raise PropertyChanged event
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
