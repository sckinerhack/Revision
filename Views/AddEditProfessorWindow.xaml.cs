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
    public partial class AddEditProfessorWindow : Window
    {
        public Professeur Professor { get; set; }

        public AddEditProfessorWindow(Professeur professor = null)
        {
            InitializeComponent();
            
            if (professor != null)
            {
                this.Title = "Edit Professor";
                Professor = professor;
                NomTextBox.Text = professor.Nom;
                PrenomTextBox.Text = professor.Prenom;
                CINTextBox.Text = professor.CIN;
            }
            else
            {
                this.Title = "Add Professor";
                Professor = new Professeur();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NomTextBox.Text) || 
                string.IsNullOrWhiteSpace(PrenomTextBox.Text) ||
                string.IsNullOrWhiteSpace(CINTextBox.Text))
            {
                MessageBox.Show("Please fill in all fields", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Professor.Nom = NomTextBox.Text;
            Professor.Prenom = PrenomTextBox.Text;
            Professor.CIN = CINTextBox.Text;

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
