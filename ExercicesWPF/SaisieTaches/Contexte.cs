using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SaisieTaches
{ public enum ModesEdition {Consultation, Edition};
    public class Contexte: INotifyPropertyChanged
    {
        //Evènements
        public event PropertyChangedEventHandler PropertyChanged;

        //Variables privées
        private ModesEdition _modeEdition;
        //Propriétés
        public ObservableCollection<Tache> Taches { get; private set; }
        public ModesEdition ModeEdit
        {
            get { return _modeEdition; }
            private set
            {
                _modeEdition = value;
                RaisePropertyChanged();
            }
        }
        private void RaisePropertyChanged([CallerMemberName] string prop = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public Contexte()
        {
            Taches = new ObservableCollection<SaisieTaches.Tache>(AccesDonnees.ChargerTaches());
        }
        #region Commandes
        //Variables
        private ICommand _cmdAjouter;
        private ICommand _cmdSupprimer;
        private ICommand _cmdEnregistrer;
        private ICommand _cmdAnnuler;


        //Propriétés
        public ICommand CmdAjouter
        {
            get
            {
                if (_cmdAjouter == null)
                    _cmdAjouter = new RelayCommand(AjouterTache);

                return _cmdAjouter;
            }
        }
        public ICommand CmdSupprimer
        {
            get
            {
                if (_cmdSupprimer == null)
                    _cmdSupprimer = new RelayCommand(SupprimerTache);

                return _cmdSupprimer;
            }
        }
        public ICommand CmdEnregistrer
        {
            get
            {
                if (_cmdEnregistrer == null)
                    _cmdEnregistrer = new RelayCommand(EnregistrerTache);

                return _cmdEnregistrer;
            }
        }
        public ICommand CmdAnnuler
        {
            get
            {
                if (_cmdAnnuler == null)
                    _cmdAnnuler = new RelayCommand(AnnulerTache);

                return _cmdAnnuler;
            }
        }

        #endregion

        #region Méthodes
        private void AjouterTache(Object o)
        {
            throw new NotImplementedException();
        }
        private void SupprimerTache(Object o)
        {
            throw new NotImplementedException();
        }
        private void EnregistrerTache(Object o)
        {
            throw new NotImplementedException();
        }
        private void AnnulerTache(Object o)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
