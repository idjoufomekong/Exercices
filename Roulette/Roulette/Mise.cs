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
                return Jeu._nbJetons;
            }
            set
            {
                if (Gagnante) _jetons += Gain;
                else _jetons -= Gain;
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
                Jeu._nbJetons += Gain;
                Jeu._nbGagnant++;
                if (Jeu._nbJetons < 0) Jeu._nbJetons = 0;
                return string.Format("Vous gagnez {0} jetons. Vous possédez désormais {1} jetons.", Gain, Jeu._nbJetons);
            }
              
            else
            {
                Jeu._nbJetons -= Gain;
                Jeu._nbPerdant++;
                if (Jeu._nbJetons < 0) Jeu._nbJetons = 0;
                if (NbJetons == 0)
                    return string.Format("Vous perdez {0} jetons. Il ne vous reste plus aucun jeton.", Gain);
                else
                    return string.Format("Vous perdez {0} jetons. Vous possédez désormais {1} jetons.", Gain, Jeu._nbJetons);
            }
                
        }

        
        #endregion
    }
}
