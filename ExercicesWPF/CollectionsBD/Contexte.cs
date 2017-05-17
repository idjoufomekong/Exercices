using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace CollectionsBD
{
    public class Contexte 
    {
        //Champs privés
        ICollectionView _view;
        public List<CollectionBD> CollectionsBD { get; }

        // Commande
        #region Commandes
        
        private ICommand _cmdNavigation;
        public ICommand CmdNavigation
        {
            get
            {
                if (_cmdNavigation == null)
                    _cmdNavigation = new RelayCommand(Navigation);

                return _cmdNavigation;
            }
        }
        #endregion
        #region Constructeur
        public Contexte()
        {
            CollectionsBD = BD_DAL.ChargerCollectionsBD();
            _view = CollectionViewSource.GetDefaultView(CollectionsBD);
        }
        #endregion

        #region Méthodes
        private void Navigation(Object o)
        {
            string dir = o.ToString();
            // Navigue dans la collection selon la direction souhaitée
            if (dir == "F")
                _view.MoveCurrentToFirst(); // premier élément
            else if (dir == "P" && _view.CurrentPosition >0)
                _view.MoveCurrentToPrevious(); // élément précédent
            else if (dir == "N" && !_view.IsCurrentAfterLast)
            {
                _view.MoveCurrentToNext(); // élément suivant
                if (_view.IsCurrentAfterLast) _view.MoveCurrentToPrevious();
            }
            else if (dir == "L")
                _view.MoveCurrentToLast(); // dernier élément

        }
        #endregion
    }
}
