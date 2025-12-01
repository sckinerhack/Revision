using Revision.Models;
using System.Windows;

namespace Revision.Views
{
    // Dialog for adding or editing a student
    public partial class AddEditStudentWindow : Window
    {
        // The student object being edited
        public Student Student { get; set; }

        // Constructor - if student is null, it's in Add mode; otherwise Edit mode
        public AddEditStudentWindow(Student student = null)
        {
            InitializeComponent();

            if (student != null)
            {
                // Edit mode - populate fields with existing data
                this.Title = "Edit Student";
                Student = student;
                NomTextBox.Text = student.Nom;
                PrenomTextBox.Text = student.Prenom;
            }
            else
            {
                // Add mode - create new empty student
                this.Title = "Add Student";
                Student = new Student();
            }
        }

        // Save button clicked - validate and save data
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if fields are empty
            if (string.IsNullOrWhiteSpace(NomTextBox.Text) || string.IsNullOrWhiteSpace(PrenomTextBox.Text))
            {
                MessageBox.Show("Please fill in all fields", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Update the student object with new values
            Student.Nom = NomTextBox.Text;
            Student.Prenom = PrenomTextBox.Text;

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
