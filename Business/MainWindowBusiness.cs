using Prism.Commands;
using Revision.Views;
using Revision.Views.UCs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Revision.Business
{
    public class MainWindowBusiness
    {
        public DelegateCommand GestionEtudiantCommand { get; set; }
        public DelegateCommand GestionProfCommand { get; set; }
        public DelegateCommand LogoutCommand { get; set; }

        private Revision.MainWindow _mainWindow;

        public MainWindowBusiness()
        {
            GestionEtudiantCommand = new DelegateCommand(ShowGestionEtudiant);
            GestionProfCommand = new DelegateCommand(ShowGestionProf);
            LogoutCommand = new DelegateCommand(Logout);
        }

        public void Initialize(Revision.MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            UcGestion uc = new UcGestion();
            uc.DataContext = new StudentBusiness();
            mainWindow.GrContent.Children.Add(uc);
        }

        private void ShowGestionProf()
        {
            if (_mainWindow == null) return;
            
            foreach (var item in _mainWindow.GrContent.Children)
            {
                if (item is UcGestion)
                {
                    ((UcGestion)item).DataContext = new PRofesseurBusiness();
                }
                else
                {
                    UcGestion uc = new UcGestion();
                    uc.DataContext = new StudentBusiness();
                    _mainWindow.GrContent.Children.Add(uc);
                }
            }
        }

        private void ShowGestionEtudiant()
        {
            if (_mainWindow == null) return;

            foreach (var item in _mainWindow.GrContent.Children)
            {
                if (item is UcGestion)
                {
                   ((UcGestion)item).DataContext = new StudentBusiness();
                }
                else
                {
                    UcGestion uc = new UcGestion();
                    uc.DataContext = new StudentBusiness();
                    _mainWindow.GrContent.Children.Add(uc);
                }
            }
        }

        private void Logout()
        {
            // Close the main window
            if (_mainWindow != null)
            {
                _mainWindow.Close();
            }

            // Open the login window
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }
    }
}




