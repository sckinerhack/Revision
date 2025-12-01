using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revision.Models
{
    public class Professeur : INotifyPropertyChanged
    {
        private string _nom;
        private string _prenom;
        private string _cin;

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

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
