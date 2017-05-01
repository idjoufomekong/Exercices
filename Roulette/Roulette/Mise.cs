using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    [Flags]
    public enum Combinaisons {
    Aucun = 0,
    Premiers24 = 1,
    Derniers24 = 2,
    Rouge = 4,
    Noir = 8,
    Impair = 32,
    Pair = 64,
    Précis = 128
    }
    public class Mise
    {
        #region Champs privés
        private int _jetons;
        #endregion

        #region Propriétés
        public int Gain { get; }
        public Lancé Pari { get; }
        public int NbJetons {
            get
            {
                return _jetons;
            }
            set
            {
                _jetons = value;
            }
        }
        public bool Gagnante { get; set; }
        #endregion

        #region Constructeur
        public Mise(int? num, Combinaisons combi, int jetons)
        {
            //Instanciation d'un pari
            Pari = new Lancé(num, combi);
            _jetons = jetons;

            //Calcul du gain potentiel
            if(combi == Combinaisons.Précis)
            {
                Gain = 35 * jetons;
            }
            else if(combi == Combinaisons.Premiers24 || combi == Combinaisons.Derniers24)
            {
                Gain = (int)Math.Floor(0.5 * jetons);
            }
            else
            {
                Gain = jetons;
            }
              

        }
        #endregion

        #region Méthodes publiques
        //Retourne le gain ou la perte
        public string GetResultatTexte()
        {
            if (Gagnante)
            {
             return string.Format("Vous gagnez {0} jetons. ", Gain);
            }
              
            else
            {
                return string.Format("Vous perdez {0} jetons. ", Gain);
            }
                
        }

        
        #endregion
    }
}
