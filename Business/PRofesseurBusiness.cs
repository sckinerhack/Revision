using Prism.Commands;
using Revision.Models;
using Revision.Views;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Revision.Business
{
    // Business logic for managing professors - same structure as StudentBusiness
    public class PRofesseurBusiness
    {
        // Collection of professors shown in the DataGrid
        public ObservableCollection<Professeur> ListOfObjects { get; set; } = new ObservableCollection<Professeur>();

        // Button labels
        public string ButtonAddContent { get; set; }
        public string ButtonEditContent { get; set; }
        public string ButtonDeleteContent { get; set; }

        // Label text for the page
        public string LabelContent { get; set; }

        // Commands for buttons
        public DelegateCommand AddCommand { get; set; }
        public DelegateCommand EditCommand { get; set; }
        public DelegateCommand DeleteCommand { get; set; }

        // Track which professor is selected
        private Professeur _selectedProfessor = null;

        // Reference to the parent window
        private Window _parentWindow = null;

        // Constructor
        public PRofesseurBusiness()
        {
            // Set button labels
            ButtonAddContent = "Ajouter un Prof";
            ButtonEditContent = "Modifier un Prof";
            ButtonDeleteContent = "Supprimer un Prof";
            LabelContent = "Gestion Des Professeurs";

            // Connect buttons to methods
            AddCommand = new DelegateCommand(AddProfesseur);
            EditCommand = new DelegateCommand(EditProfesseur);
            DeleteCommand = new DelegateCommand(DeleteProfesseur);

            // Create 10 sample professors
            for (int i = 0; i < 10; i++)
            {
                Professeur prof = new Professeur();
                prof.Nom = "Bakkali" + i.ToString();
                prof.Prenom = "Ahmed" + i.ToString();
                prof.CIN = "CIN" + i.ToString();
                ListOfObjects.Add(prof);
            }
        }

        // Set which professor is selected
        public void SetSelectedProfessor(Professeur professor)
        {
            _selectedProfessor = professor;
        }

        // Set the parent window
        public void SetParentWindow(Window parentWindow)
        {
            _parentWindow = parentWindow;
        }

        // Add a new professor
        private void AddProfesseur()
        {
            try
            {
                AddEditProfessorWindow window = new AddEditProfessorWindow();
                if (_parentWindow != null)
                    window.Owner = _parentWindow;

                if (window.ShowDialog() == true)
                {
                    ListOfObjects.Add(window.Professor);
                    MessageBox.Show("Professor added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Edit the selected professor
        private void EditProfesseur()
        {
            try
            {
                if (_selectedProfessor == null)
                {
                    MessageBox.Show("Please select a professor to edit", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                AddEditProfessorWindow window = new AddEditProfessorWindow(_selectedProfessor);
                if (_parentWindow != null)
                    window.Owner = _parentWindow;

                if (window.ShowDialog() == true)
                {
                    MessageBox.Show("Professor updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Delete the selected professor
        private void DeleteProfesseur()
        {
            try
            {
                if (_selectedProfessor == null)
                {
                    MessageBox.Show("Please select a professor to delete", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                MessageBoxResult result = MessageBox.Show(
                    $"Are you sure you want to delete {_selectedProfessor.Nom} {_selectedProfessor.Prenom}?",
                    "Confirm Delete",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    ListOfObjects.Remove(_selectedProfessor);
                    _selectedProfessor = null;
                    MessageBox.Show("Professor deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}


