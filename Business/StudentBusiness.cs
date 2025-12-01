using Prism.Commands;
using Revision.Models;
using Revision.Views;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Revision.Business
{
    // Business logic for managing students
    public class StudentBusiness
    {
        // Collection of students shown in the DataGrid
        public ObservableCollection<Student> ListOfObjects { get; set; } = new ObservableCollection<Student>();

        // Button labels
        public string ButtonAddContent { get; set; }
        public string ButtonEditContent { get; set; }
        public string ButtonDeleteContent { get; set; }

        // Label text for the page
        public string LabelContent { get; set; }

        // Commands for buttons (linked to click events)
        public DelegateCommand AddCommand { get; set; }
        public DelegateCommand EditCommand { get; set; }
        public DelegateCommand DeleteCommand { get; set; }

        // Track which student is selected in the grid
        private Student _selectedStudent = null;

        // Reference to the parent window (needed for dialogs)
        private Window _parentWindow = null;

        // Constructor - initialize all commands and create sample data
        public StudentBusiness()
        {
            // Set button labels
            ButtonAddContent = "Ajouter un étudiant";
            ButtonEditContent = "Modifier un étudiant";
            ButtonDeleteContent = "Supprimer un étudiant";
            LabelContent = "Gestion Des Etudiants";

            // Connect buttons to methods
            AddCommand = new DelegateCommand(AddStudent);
            EditCommand = new DelegateCommand(EditStudent);
            DeleteCommand = new DelegateCommand(DeleteStudent);

            // Create 10 sample students
            for (int i = 0; i < 10; i++)
            {
                Student student = new Student();
                student.Nom = "Bakkali" + i.ToString();
                student.Prenom = "Ahmed" + i.ToString();
                ListOfObjects.Add(student);
            }
        }

        // Set which student is selected (called by UI when grid selection changes)
        public void SetSelectedStudent(Student student)
        {
            _selectedStudent = student;
        }

        // Set the parent window (needed to show dialogs properly)
        public void SetParentWindow(Window parentWindow)
        {
            _parentWindow = parentWindow;
        }

        // Add a new student - opens dialog
        private void AddStudent()
        {
            try
            {
                // Create and show the Add/Edit dialog with no student (new mode)
                AddEditStudentWindow window = new AddEditStudentWindow();
                if (_parentWindow != null)
                    window.Owner = _parentWindow;

                // If user clicked Save (not Cancel)
                if (window.ShowDialog() == true)
                {
                    // Add the new student to the list
                    ListOfObjects.Add(window.Student);
                    MessageBox.Show("Student added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Edit the selected student - opens dialog
        private void EditStudent()
        {
            try
            {
                // Check if a student is selected
                if (_selectedStudent == null)
                {
                    MessageBox.Show("Please select a student to edit", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Create and show dialog with the selected student data
                AddEditStudentWindow window = new AddEditStudentWindow(_selectedStudent);
                if (_parentWindow != null)
                    window.Owner = _parentWindow;

                // If user clicked Save
                if (window.ShowDialog() == true)
                {
                    // The student object was modified directly, so the grid updates automatically
                    // (thanks to INotifyPropertyChanged in the Student model)
                    MessageBox.Show("Student updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Delete the selected student - asks for confirmation
        private void DeleteStudent()
        {
            try
            {
                // Check if a student is selected
                if (_selectedStudent == null)
                {
                    MessageBox.Show("Please select a student to delete", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Ask user to confirm deletion
                MessageBoxResult result = MessageBox.Show(
                    $"Are you sure you want to delete {_selectedStudent.Nom} {_selectedStudent.Prenom}?",
                    "Confirm Delete",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                // If user clicked Yes
                if (result == MessageBoxResult.Yes)
                {
                    // Remove from list
                    ListOfObjects.Remove(_selectedStudent);
                    _selectedStudent = null;
                    MessageBox.Show("Student deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}


