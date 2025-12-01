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
using System.Windows.Shapes;
using Revision.Models;

namespace Revision.Views
{
    public partial class AddEditStudentWindow : Window
    {
        public Student Student { get; set; }

        public AddEditStudentWindow(Student student = null)
        {
            InitializeComponent();
            
            if (student != null)
            {
                this.Title = "Edit Student";
                Student = student;
                NomTextBox.Text = student.Nom;
                PrenomTextBox.Text = student.Prenom;
            }
            else
            {
                this.Title = "Add Student";
                Student = new Student();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NomTextBox.Text) || string.IsNullOrWhiteSpace(PrenomTextBox.Text))
            {
                MessageBox.Show("Please fill in all fields", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Student.Nom = NomTextBox.Text;
            Student.Prenom = PrenomTextBox.Text;

            this.DialogResult = true;
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
