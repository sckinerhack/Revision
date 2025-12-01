using System.ComponentModel;

namespace Revision.Models
{
    // Professor model class - represents a single professor
    public class Professeur : INotifyPropertyChanged
    {
        // Private fields to store data
        private string _nom;
        private string _prenom;
        private string _cin;

        // Property for professor's last name
        public string Nom
        {
            get { return _nom; }
            set
            {
                if (_nom != value)
                {
                    _nom = value;
                    OnPropertyChanged(nameof(Nom));
                }
            }
        }

        // Property for professor's first name
        public string Prenom
        {
            get { return _prenom; }
            set
            {
                if (_prenom != value)
                {
                    _prenom = value;
                    OnPropertyChanged(nameof(Prenom));
                }
            }
        }

        // Property for professor's ID number (CIN)
        public string CIN
        {
            get { return _cin; }
            set
            {
                if (_cin != value)
                {
                    _cin = value;
                    OnPropertyChanged(nameof(CIN));
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

