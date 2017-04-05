using System.Collections.Generic;
using System.Collections;

namespace Boites
{
    public enum Couleurs { blanc, bleu, vert, jaune, orange, rouge, marron }
    public enum Matières { carton, plastique, bois, métal }
    public class Boite
    {
        #region Champs privés
        private double _hauteur;
        private double _largeur;
        private double _longueur;
        //private Couleurs _couleur;
        //private Matière _matière;
        private static int _compteur=0;
        private Etiquette _etiquetteDest;
        private Etiquette _etiquetteFragile;

        #endregion
        /// <summary>
        /// création d'une instance de la classe "Boite"
        /// </summary>
        
        public Boite()
        {
           // _hauteur = 30.0;
           // _largeur = 30.0;
           // _longueur = 30.0;
           //Matière = Matières.carton; //Le private set n'est pas obligatoire
            _compteur++;
            Articles = new SortedDictionary<string, Article>();

        }
        
        public Boite(double haut, double larg, double longr):this()
        {
            _hauteur = haut;
            _largeur = larg;
            _longueur = longr;
        }

        public Boite(double haut, double larg, double longr, Matières mat): this(haut,larg,longr)
        {
            Matière = mat; //This n'est pas obligatoire car les noms des variables sont différents
            
        }

        #region Propriétés
        public SortedDictionary<string,Article> Articles { get; }
        public double Hauteur
        {
            get { return _hauteur; }
        }

        public double Largeur
        {
            get { return _largeur; }
        }

        public double Longueur
        {
            get { return _longueur; }
        }

        //public Couleurs CouleurMise
        //{
        //    get { return _couleur; }
        //    set { _couleur = value; }
        //}

        public Couleurs Couleur { get; set; }

        //public Matière MatièreMise
        //{
        //    get { return _matière; }
        //}

        public Matières Matière { get; private set; }//Car en normal, il n'y avait pas de set

        public double Volume
        {
            get { return _largeur * _longueur * _hauteur; }
        }

        public static int Compteur
        {
            get
            {
                return _compteur;
            }
                       
        }

        public Etiquette EtiquetteDest
        {
            get
            {
                return _etiquetteDest;
            }
        }

        public Etiquette EtiquetteFragile
        {
            get
            {
                return _etiquetteFragile;
            }              
        }
        #endregion

        #region Méthodes publiques
        /// <summary>
        /// Etiquetage avec un destinatire
        /// </summary>
        /// <param name="destinataire">destinataire de l'étiquette</param>
        public void Etiqueter(string destinataire)
        {
            _etiquetteDest = new Etiquette {
            Couleur=Couleurs.blanc,
            Format=Formats.L,
            Texte =destinataire
            };
            //throw new NotImplementedException();

        }
        /// <summary>
        /// Etiquetage avec un destinatire et un booléen
        /// </summary>
        /// <param name="destinataire">destinataire de l'étiquette</param>
        /// <param name="fragile">Etat de fragilité</param>
        public void Etiqueter(string destinataire, bool fragile)// : this(destinataire) C'est uniquement pour les constructeurs
        {
            Etiqueter(destinataire);//Car permet d'étiqueter fragile et destinataire
            //throw new NotImplementedException();
            if (fragile)
                _etiquetteFragile = new Etiquette
             {
                Couleur = Couleurs.rouge,
            Format = Formats.S,
            Texte = "Fragile"
            };
        }

        public void Etiqueter(Etiquette etqDest, Etiquette etqFragile)
        {
            _etiquetteDest = etqDest;
            _etiquetteFragile = etqFragile;

        }

        public bool Compare(Boite autreBoite)
        {
            return (this.Hauteur == autreBoite.Hauteur && this.Largeur == autreBoite.Largeur &&
                this.Longueur == autreBoite.Longueur && this.Matière == autreBoite.Matière);
                    }
        #endregion

    }
}
