using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace Trombinoscope
{
    public class ContexteEmploye : ViewModelBase
    {
      

        //Variables privées
        #region Champs privés
        private Employe _nouvelEmploye;

        #endregion
        #region Commandes

        //Variables commandes
        private ICommand _cmdAjouter;
        private ICommand _cmdSupprimer;

        public ICommand CmdAjouter
        {
            get
            {
                if (_cmdAjouter == null)
                    _cmdAjouter = new RelayCommand(AjouterEmploye);

                return _cmdAjouter;
            }
        }

        public ICommand CmdSupprimer
        {
            get
            {
                if (_cmdSupprimer == null)
                    _cmdSupprimer = new RelayCommand(SupprimerEmploye);

                return _cmdSupprimer;
            }
        }
        #endregion
        #region propriétés


        public ObservableCollection<Employe> Employes { get; }

        

        public Employe NouvelEmploye
        {
            get { return _nouvelEmploye; }
            private set
            {
                SetProperty(ref _nouvelEmploye, value);
            }
        }

        
        #endregion
        public ContexteEmploye()
        {
            Employes = new ObservableCollection<Employe>(DAL.GetEmployeesTerritories());
            NouvelEmploye = new Employe();
        }
        
        private void AjouterEmploye(Object o)
        {
            //if (!string.IsNullOrEmpty(NouvelEmploye.Nom) && !string.IsNullOrEmpty(NouvelEmploye.Prenom))
            //{
            //    Employes.Add(NouvelEmploye);
            //    DAL.AjouterEmploye(NouvelEmploye);
            //    NouvelEmploye = new Employe();
            //}
            WndAjoutEmploye dlg = new WndAjoutEmploye(NouvelEmploye);
            bool? res = dlg.ShowDialog();
            if (res.Value)
            {
                Employes.Add(NouvelEmploye);
                NouvelEmploye = new Employe();
            }
        }

        private void SupprimerEmploye(Object o)
        {
            var e = (Employe)CollectionViewSource.GetDefaultView(Employes).CurrentItem;
            Employes.Remove(e);
            try
            {
                DAL.SupprimerEmploye(e);
            }
            catch (SqlException)
            {

                MessageBox.Show("L'employé choisi est reférencé. Il n'est pas possible de le supprimer",
                    "Erreur", MessageBoxButton.OK);
            }
        }
    }
}
