using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boites
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    enum Couleurs { blanc, bleu, vert, jaune, orange, rouge, marron}
    enum Matière {carton, plastique, bois, métal}
    class Boite
    {
        #region Champs privés
        private double _hauteur;
        private double _largeur;
        private double _longueur;
        private Couleurs _couleur;
        private Matière _matière;

        #endregion
        /// <summary>
        /// création d'une instance de la classe "Boite"
        /// </summary>
        public Boite()
        {
            _hauteur = 30.0;
            _largeur = 30.0;
            _longueur = 30.0;
            _matière=Matière.carton;

        }

        #region Propriétés
        public double HauteurBoite
        { get { return _hauteur; }
        }

        public double LargeurBoite
        {
            get { return _largeur; }
        }

        public double LongueurBoite
        {
            get { return _longueur; }
        }

        public Couleurs CouleurMise
        {
            get {return _couleur; }
            set {_couleur =value; }
        }

        public Matière MatièreMise {
            get {return _matière; }
        }

        public double Volume
        { get {return _largeur * _longueur *_hauteur; } 
        }
        #endregion

        #region Méthodes publiques
        /// <summary>
        /// Etiquetage avec un destinatire
        /// </summary>
        /// <param name="destinataire">destinataire de l'étiquette</param>
        public void Etiqueter(string destinataire)
        {
            throw new NotImplementedException();

        }
        /// <summary>
        /// Etiquetage avec un destinatire et un booléen
        /// </summary>
        /// <param name="destinataire">destinataire de l'étiquette</param>
        /// <param name="fragile">Etat de fragilité</param>
        public void Etiqueter(string destinataire,bool fragile)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
