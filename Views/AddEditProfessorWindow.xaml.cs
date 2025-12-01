using Revision.Models;
using System.Windows;

namespace Revision.Views
{
    // Dialog for adding or editing a professor
    public partial class AddEditProfessorWindow : Window
    {
        // The professor object being edited
        public Professeur Professor { get; set; }

        // Constructor - if professor is null, it's in Add mode; otherwise Edit mode
        public AddEditProfessorWindow(Professeur professor = null)
        {
            InitializeComponent();

            if (professor != null)
            {
                // Edit mode - populate fields with existing data
                this.Title = "Edit Professor";
                Professor = professor;
                NomTextBox.Text = professor.Nom;
                PrenomTextBox.Text = professor.Prenom;
                CINTextBox.Text = professor.CIN;
            }
            else
            {
                // Add mode - create new empty professor
                this.Title = "Add Professor";
                Professor = new Professeur();
            }
        }

        // Save button clicked - validate and save data
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if all fields are filled
            if (string.IsNullOrWhiteSpace(NomTextBox.Text) ||
                string.IsNullOrWhiteSpace(PrenomTextBox.Text) ||
                string.IsNullOrWhiteSpace(CINTextBox.Text))
            {
                MessageBox.Show("Please fill in all fields", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Update the professor object with new values
            Professor.Nom = NomTextBox.Text;
            Professor.Prenom = PrenomTextBox.Text;
            Professor.CIN = CINTextBox.Text;

            // Close dialog and return Success
            this.DialogResult = true;
            this.Close();
        }

        // Cancel button clicked - close without saving
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
