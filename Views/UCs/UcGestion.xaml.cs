using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Revision.Views.UCs
{
    /// <summary>
    /// Logique d'interaction pour UcGestion.xaml
    /// </summary>
    public partial class UcGestion : UserControl
    {
        public UcGestion()
        {
            InitializeComponent();
            this.Loaded += UcGestion_Loaded;
        }

        private void UcGestion_Loaded(object sender, RoutedEventArgs e)
        {
            // Wire up the DataGrid selection change event to notify the business class
            if (GestionGrid != null)
            {
                GestionGrid.SelectionChanged += GestionGrid_SelectionChanged;
            }

            // Find parent window and pass it to business class
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null)
            {
                var businessContext = this.DataContext;
                if (businessContext != null)
                {
                    var methodType = businessContext.GetType().Name;
                    if (methodType == "StudentBusiness")
                    {
                        var method = businessContext.GetType().GetMethod("SetParentWindow");
                        if (method != null)
                        {
                            method.Invoke(businessContext, new[] { parentWindow });
                        }
                    }
                    else if (methodType == "PRofesseurBusiness")
                    {
                        var method = businessContext.GetType().GetMethod("SetParentWindow");
                        if (method != null)
                        {
                            method.Invoke(businessContext, new[] { parentWindow });
                        }
                    }
                }
            }
        }

        private void GestionGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = GestionGrid.SelectedItem;
            
            // Notify the business class (which could be StudentBusiness or PRofesseurBusiness)
            var businessContext = this.DataContext;
            
            if (businessContext != null)
            {
                // Use reflection to call SetSelectedStudent or SetSelectedProfessor
                var methodType = businessContext.GetType().Name;
                if (methodType == "StudentBusiness")
                {
                    var method = businessContext.GetType().GetMethod("SetSelectedStudent");
                    if (method != null)
                    {
                        method.Invoke(businessContext, new[] { selectedItem });
                    }
                }
                else if (methodType == "PRofesseurBusiness")
                {
                    var method = businessContext.GetType().GetMethod("SetSelectedProfessor");
                    if (method != null)
                    {
                        method.Invoke(businessContext, new[] { selectedItem });
                    }
                }
            }
        }
    }
}
