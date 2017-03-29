using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicules
{
    public abstract class Véhicule: IComparable
    {
        #region Propriétés             
        public string Nom { get; set; }
        public int NbRoues { get; set; }
        public Energies Energie { get; set; }
        public abstract int PRK { get;  }
        public virtual string Description
        {
            get
            {
                return string.Format("Véhicule {0} roule sur {1} roues et à l'énergie {2}.", Nom, NbRoues, Energie);
            }
        }
        #endregion

        #region Constructeurs
        public Véhicule(string nom, int nbRoues,Energies energie)
        {
            Nom = nom;
            this.NbRoues = nbRoues;
            Energie = energie;
        }
        #endregion

        #region Méthodes publiques
        public override string ToString()
        {
            return string.Format("Je suis un véhicule {0}. ", Energie );
        }

        public abstract void CalculerConso();

        public int CompareTo(object obj)
        {
            if (obj is Véhicule)//Car si l'objet n'est pas un véhicule le programme va crasher
            {
                Véhicule comparaison = (Véhicule)obj;
                if (this.PRK < comparaison.PRK)
                    return -1;
                else if (this.PRK > comparaison.PRK)
                    return 1;
                else
                    return 0;
            }
            else
                throw new ArgumentException();
        }

        public string ComparerVéhicules(Véhicule v)
        {
            try
            {
                if (CompareTo(v) < 0)
                    return string.Format("La {0} est plus économique que la {1}", Nom, v.Nom);
                else if (this.CompareTo(v) > 0)
                    return string.Format("La {0} est plus économique que la {1}", v.Nom, this.Nom);
                else
                    return string.Format("Les 2 véhicules ont le même PRK");
            }
            catch (ArgumentException) { 
            return "Argument n'est pas un Véhicule";
            }
        }
        #endregion
    }

    public class Voiture : Véhicule
    {
        private const int NB_ROUES_VOITURE = 4;

        #region Propriétés
        public override string Description
        {
            get
            {
                return "Je suis une voiture.\r\n" + base.Description;
            }
        }

        public override int PRK
        {
            get
            {
                return NB_ROUES_VOITURE;
            }
        }
        #endregion
        public Voiture(string nom, Energies energie): base(nom, NB_ROUES_VOITURE, energie)
        {

        }

        #region Méthodes publiques
        public override string ToString()
        {
            return base.ToString() + string.Format("Je suis une voiture car j'ai {0} roues.",NbRoues);
        }

        public override void CalculerConso()
        {
            throw new NotImplementedException();
        }

        public string RefaireParallélisme()
        {
            return "Parallélisme refait";
        }
        #endregion
    }

    public class Moto : Véhicule
    {
        private const int NB_ROUES_MOTO = 2;

        #region Propriétés
        public override string Description
        {
            get
            {
                return "Je suis une moto.\r\n" + base.Description;
            }
        }

        public override int PRK
        {
            get
            {
                return NB_ROUES_MOTO;
            }
        }
        #endregion
        public Moto(string nom, Energies energie) : base(nom, NB_ROUES_MOTO, energie)
        {

        }

        public override void CalculerConso()
        {
            throw new NotImplementedException();
        }
    }
}
