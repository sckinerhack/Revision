using System.ComponentModel;

namespace Revision.Models
{
    // Student model class - represents a single student
    public class Student : INotifyPropertyChanged
    {
        // Private fields to store data
        private string _nom;
        private string _prenom;

        // Property for student's last name
        public string Nom
        {
            get { return _nom; }
            set
            {
                if (_nom != value)
                {
                    _nom = value;
                    OnPropertyChanged(nameof(Nom)); // Notify UI when value changes
                }
            }
        }

        // Property for student's first name
        public string Prenom
        {
            get { return _prenom; }
            set
            {
                if (_prenom != value)
                {
                    _prenom = value;
                    OnPropertyChanged(nameof(Prenom)); // Notify UI when value changes
                }
            }
        }

        // Event for property change notification - required for DataGrid to update
        public event PropertyChangedEventHandler PropertyChanged;

        // Helper method to raise PropertyChanged event
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

