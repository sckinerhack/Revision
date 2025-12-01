using Prism.Commands;
using Revision.Models;
using Revision.Views;
using Revision.Views.UCs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Revision.Business
{
    public class StudentBusiness
    {
        public ObservableCollection<Student> ListOfObjects { get; set; } = 
            new ObservableCollection<Student> ();

        public string ButtonAddContent { get; set; }
        public string ButtonEditContent { get; set; }
        public string ButtonDeleteContent { get; set; }

        public string LabelContent { get; set; }

        public DelegateCommand AddCommand { get; set; }
        public DelegateCommand EditCommand { get; set; }
        public DelegateCommand DeleteCommand { get; set; }

        private Student _selectedStudent = null;
        private Window _parentWindow = null;

        public StudentBusiness()
        {
            ButtonAddContent = "Ajouter un étudiant";
            ButtonEditContent = "Modifier un étudiant";
            ButtonDeleteContent = "Supprimer un étudiant";
            LabelContent = "GEstion Des etudiants";
            
            AddCommand = new DelegateCommand(AddStudent);
            EditCommand = new DelegateCommand(EditStudent);
            DeleteCommand = new DelegateCommand(DeleteStudent);
            
            for (int i = 0; i < 10; i++)
            {
                Student student = new Student();
                student.Nom = "Bakkali" + i.ToString();
                student.Prenom = "Ahmed" + i.ToString();

                ListOfObjects.Add(student);
            }
        }

        public void SetSelectedStudent(Student student)
        {
            _selectedStudent = student;
        }

        public void SetParentWindow(Window parentWindow)
        {
            _parentWindow = parentWindow;
        }

        private void AddStudent()
        {
            try
            {
                AddEditStudentWindow window = new AddEditStudentWindow();
                if (_parentWindow != null)
                    window.Owner = _parentWindow;
                
                if (window.ShowDialog() == true)
                {
                    ListOfObjects.Add(window.Student);
                    MessageBox.Show("Student added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EditStudent()
        {
            try
            {
                if (_selectedStudent == null)
                {
                    MessageBox.Show("Please select a student to edit", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                AddEditStudentWindow window = new AddEditStudentWindow(_selectedStudent);
                if (_parentWindow != null)
                    window.Owner = _parentWindow;
                
                if (window.ShowDialog() == true)
                {
                    MessageBox.Show("Student updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteStudent()
        {
            try
            {
                if (_selectedStudent == null)
                {
                    MessageBox.Show("Please select a student to delete", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                MessageBoxResult result = MessageBox.Show(
                    $"Are you sure you want to delete {_selectedStudent.Nom} {_selectedStudent.Prenom}?",
                    "Confirm Delete",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
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


