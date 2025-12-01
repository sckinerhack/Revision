using Prism.Commands;
using Revision.Views;
using Revision.Views.UCs;
using System.Windows;

namespace Revision.Business
{
    // Business logic for the main application window
    public class MainWindowBusiness
    {
        // Commands for navigation buttons
        public DelegateCommand GestionEtudiantCommand { get; set; }
        public DelegateCommand GestionProfCommand { get; set; }
        public DelegateCommand LogoutCommand { get; set; }

        // Reference to the main window
        private Revision.MainWindow _mainWindow;

        // Constructor - link buttons to methods
        public MainWindowBusiness()
        {
            GestionEtudiantCommand = new DelegateCommand(ShowGestionEtudiant);
            GestionProfCommand = new DelegateCommand(ShowGestionProf);
            LogoutCommand = new DelegateCommand(Logout);
        }

        // Initialize the main window with the student grid
        public void Initialize(Revision.MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            
            // Create the grid view user control
            UcGestion uc = new UcGestion();
            uc.DataContext = new StudentBusiness(); // Show students by default
            mainWindow.GrContent.Children.Add(uc);
        }

        // Show student management grid
        private void ShowGestionEtudiant()
        {
            if (_mainWindow == null) return;

            // Find and update the grid with StudentBusiness
            foreach (var item in _mainWindow.GrContent.Children)
            {
                if (item is UcGestion)
                {
                    ((UcGestion)item).DataContext = new StudentBusiness();
                    return;
                }
            }
        }

        // Show professor management grid
        private void ShowGestionProf()
        {
            if (_mainWindow == null) return;

            // Find and update the grid with ProfessorBusiness
            foreach (var item in _mainWindow.GrContent.Children)
            {
                if (item is UcGestion)
                {
                    ((UcGestion)item).DataContext = new PRofesseurBusiness();
                    return;
                }
            }
        }

        // Logout - close main window and show login window
        private void Logout()
        {
            if (_mainWindow != null)
                _mainWindow.Close();

            // Return to login screen
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }
    }
}



