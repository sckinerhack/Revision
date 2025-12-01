using System.Windows;
using System.Windows.Controls;

namespace Revision.Views.UCs
{
    // Grid view user control - displays students or professors
    public partial class UcGestion : UserControl
    {
        public UcGestion()
        {
            InitializeComponent();
            this.Loaded += UcGestion_Loaded;
        }

        // Called when the grid is fully loaded
        private void UcGestion_Loaded(object sender, RoutedEventArgs e)
        {
            // Setup grid selection event
            if (GestionGrid != null)
            {
                GestionGrid.SelectionChanged += GestionGrid_SelectionChanged;
            }

            // Pass parent window reference to business class
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null && this.DataContext != null)
            {
                // Get the business class type and call SetParentWindow if it exists
                var businessType = this.DataContext.GetType().Name;
                var method = this.DataContext.GetType().GetMethod("SetParentWindow");
                if (method != null)
                {
                    method.Invoke(this.DataContext, new[] { parentWindow });
                }
            }
        }

        // Called when user selects a row in the grid
        private void GestionGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = GestionGrid.SelectedItem;
            
            if (selectedItem != null && this.DataContext != null)
            {
                // Determine which business class this is and call appropriate method
                var businessType = this.DataContext.GetType().Name;
                string methodName = (businessType == "StudentBusiness") ? "SetSelectedStudent" : "SetSelectedProfessor";
                
                var method = this.DataContext.GetType().GetMethod(methodName);
                if (method != null)
                {
                    // Call the SetSelected* method to update the business class
                    method.Invoke(this.DataContext, new[] { selectedItem });
                }
            }
        }
    }
}
