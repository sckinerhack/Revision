using Revision.Business;
using System.Windows;
using System.Windows.Controls;

namespace Revision.Views.UCs
{
    // Login form user control
    public partial class UcLogin : UserControl
    {
        public UcLogin()
        {
            InitializeComponent();
        }

        // Sync PasswordBox text to the business class
        // (We can't use binding for PasswordBox for security reasons)
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is LoginBusiness loginBusiness)
            {
                loginBusiness.Password = PasswordBox.Password;
            }
        }
    }
}

