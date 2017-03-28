using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicules
{
    public class Véhicule
    {
        #region Propriétés             
        public string Nom { get; set; }
        public int NbRoues { get; set; }
        public Energies Energie { get; set; }
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
        #endregion
        public Voiture(string nom, Energies energie): base(nom, NB_ROUES_VOITURE, energie)
        {

        }

        #region Méthodes publiques
        public override string ToString()
        {
            return base.ToString() + string.Format("Je suis une voiture car j'ai {0} roues.",NbRoues);
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
        #endregion
        public Moto(string nom, Energies energie) : base(nom, NB_ROUES_MOTO, energie)
        {

        }

    }
}
