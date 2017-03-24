using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dt = new DateTime(2017, 02, 25);
            CompteBancaire cb = new CompteBancaire(typeCompte.Courant);//instanciation de la classe CompteBancaire
            bool b=cb.ADécouvert;//Pas besoin de parenthèse pour appeler la propriété

            cb.DécouvertAutorisé = -700;
            cb.Créditer(1000);
            Console.WriteLine("Solde courant:{0}", cb.SoldeCourant);

            cb.Débiter(600);
            Console.WriteLine("Solde courant:{0}", cb.SoldeCourant);

            cb.Débiter(2000);
            Console.WriteLine("Solde courant:{0}", cb.SoldeCourant);

            CompteBancaire ce = new CompteBancaire( typeCompte.Epargne);
            CompteBancaire[] tabComptes = new POO.CompteBancaire[3];
            tabComptes[0] = new CompteBancaire(typeCompte.Courant);
            tabComptes[1] = new CompteBancaire(DateTime.Today,500);//Il est possible de mettre 2 constructeurs différents dan sle même tableau
            tabComptes[2] = new CompteBancaire(typeCompte.Courant);

            Console.ReadKey();
        }
    }

    public enum typeCompte { Courant, Epargne, PEA, PEE}//Type enumere, doit être déclaré avant hors d'une classe

    public class CompteBancaire
    {
        #region Champs privés
        private bool _aDécouvert;
        private DateTime _dateCréation;
        private DateTime _dateCloture;
        private decimal  _soldeCourant;
        private decimal _decouvertAutorisé;
        private typeCompte _type;
        #endregion

        /// <summary>
        /// Création d'un compte
        /// </summary>
        public CompteBancaire()//Pas de type de retour
        {
            _dateCréation = DateTime.Today;
        }
        /// <summary>
        /// Création d'un compte avec date de création
        /// </summary>
        /// <param name="dateCréa">Date de création</param>
        public CompteBancaire(typeCompte type)//Surcharge de la méthode
        {
            _dateCréation = DateTime.Today;
            _type = type;
        }

        /// <summary>
        /// Création d'un compte avec date de création et solde
        /// </summary>
        /// <param name="dateCréa">dateCréa</param>
        /// <param name="solde">solde initial</param>
        public CompteBancaire(DateTime dateCréa, decimal solde)
        {
            _dateCréation = dateCréa;
            _soldeCourant = SoldeCourant;
        }
        #region Propriétés
        public bool ADécouvert //Il a généré automatiquement les accesseurs. Groupe de 2 fonctions: get et set
        {
            get { return _aDécouvert; }
        }

        public DateTime DateCloture
        {
            get { return _dateCloture; }
        }

        public DateTime DateCréation
        {
            get { return _dateCréation; }
        }

        public decimal SoldeCourant
        {
            get { return _soldeCourant; }
        }

        public decimal  DécouvertAutorisé
        { get { return _decouvertAutorisé; }
          set { _decouvertAutorisé = value; }//value mot clé permettant de modifier le champ concerné
        }
        #endregion

        #region Méthodes privées
        private int CalculerAncienneté()
        {
            return (DateTime.Today - _dateCréation).Days;
        }

        private decimal CalculerIntérêts()
        {
            return 0;
        }

        private decimal CalculerSolde()
        {
            return _soldeCourant + CalculerIntérêts() ;
        }
        #endregion

        #region Méthodes publiques
        public void Cloturer()// pas cloturerCompte parce que je sais que je suis sur la classe Compte
        {
            _dateCloture = DateTime.Today;
            CalculerSolde();
        }

        public void Créditer(decimal montant)
        {
            _soldeCourant += montant;
        }

        public void Débiter(decimal montant)
        {
            _soldeCourant -= montant;
            if (_soldeCourant < _decouvertAutorisé)
            {
                _soldeCourant -= 5;
            }
            if (-_soldeCourant < 0)
                _aDécouvert = true;//On modifie la variable car on est à l'intérieur de la classe
        }
        #endregion
    }
}
