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
    public class Contexte: ViewModelBase
    {
        //Variables privées
        private ModesEdition _modeEdition;
        private List<Tache> _tachesAjoutees;
        //Propriétés
        public ObservableCollection<Tache> Taches
        {
            get;
            private set;
        }
        public ModesEdition ModeEdit
        {
            get { return _modeEdition; }
            private set
            {
                SetProperty(ref _modeEdition, value);
            }
        }

        #region Constructeur
        public Contexte()
        {
            Taches = new ObservableCollection<Tache>(AccesDonnees.ChargerTaches());
            _tachesAjoutees = new List<Tache>();
        }
        #endregion
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
            ModeEdit = ModesEdition.Edition;
            var p = Taches.Max(x => x.Id);
            Tache t = new Tache();
            t.Id = p + 1;
            t.Creation = DateTime.Now;
            t.Prio = 1;
            t.Term = DateTime.Now;
            Taches.Add(t);
            _tachesAjoutees.Add(t);
        }
        private void SupprimerTache(Object o)
        {
            ModeEdit = ModesEdition.Edition;
        }
        private void EnregistrerTache(Object o)
        {
            ModeEdit = ModesEdition.Consultation;
            AccesDonnees.EnregistrerTaches(_tachesAjoutees);
        }
        private void AnnulerTache(Object o)
        {
            ModeEdit = ModesEdition.Consultation;
        }
        #endregion
    }
}
