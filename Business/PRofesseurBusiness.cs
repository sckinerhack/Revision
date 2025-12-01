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
    public class PRofesseurBusiness
    {
        public ObservableCollection<Professeur> ListOfObjects { get; set; } =
            new ObservableCollection<Professeur>();

        public string ButtonAddContent { get; set; }
        public string ButtonEditContent { get; set; }
        public string ButtonDeleteContent { get; set; }

        public string LabelContent { get; set; }

        public DelegateCommand AddCommand { get; set; }
        public DelegateCommand EditCommand { get; set; }
        public DelegateCommand DeleteCommand { get; set; }

        private Professeur _selectedProfessor = null;
        private Window _parentWindow = null;

        public PRofesseurBusiness()
        {
            ButtonAddContent = "Ajouter un Prof";
            ButtonEditContent = "Modifier un Prof";
            ButtonDeleteContent = "Supprimer un Prof";
            LabelContent = "Gestion Des Prof";
            
            AddCommand = new DelegateCommand(AddProfesseur);
            EditCommand = new DelegateCommand(EditProfesseur);
            DeleteCommand = new DelegateCommand(DeleteProfesseur);
            
            for (int i = 0; i < 10; i++)
            {
                Professeur prof = new Professeur();
                prof.Nom = "Bakkali" + i.ToString();
                prof.Prenom = "Ahmed" + i.ToString();
                prof.CIN = "CIN" + i.ToString();

                ListOfObjects.Add(prof);
            }
        }

        public void SetSelectedProfessor(Professeur professor)
        {
            _selectedProfessor = professor;
        }

        public void SetParentWindow(Window parentWindow)
        {
            _parentWindow = parentWindow;
        }

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


