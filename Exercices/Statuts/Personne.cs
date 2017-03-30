using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statuts
{
    [Flags]
    public enum Statuts
    {
        Aucun=0,
        CDI = 1,
        CDD = 2,
        DP = 4,
        CHSCT = 8,
        SYND = 16
    }
    class Personne
    {
        public string Nom { get;  }
        public string Prénom { get; }
        //public List<Statuts> Statut { get; set; }
        public Statuts Statut { get; set; }

        #region Constructeur
        public Personne(string nom, string prenom, Statuts statut)
        {
            Nom = nom;
            Prénom = prenom;
            Statut = statut;
        }
        #endregion

        #region Méthodes publiques
        public override string ToString()
        {
            //string s = string.Empty; ;
            //for (int i = 0; i < Statut.Count; i++)
            //    s = s + " " + Statut.ElementAt(i);
            return string.Format("Nom: {0}, Prénom: {1}, Statut: {2}", Nom, Prénom, Statut);
        }
        #endregion
    }
}
