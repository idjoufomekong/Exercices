using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    public class Lancé
    {
        #region Propriétés
        public int? Numéro { get; }
        public Combinaisons Combinaison { get; }
        #endregion

        #region Constructeur
        public Lancé(int? num, Combinaisons combi)
        {
            Numéro = num;
            Combinaison = combi;
        }
        #endregion

        #region Méthodes publiques

        //Vétifie si ce qui est lancé correspond à ca qui a été annoncé
        public bool CorrespondA(Lancé lance)
        {
            if (lance.Combinaison == Combinaisons.Précis)
            {
                if (lance.Numéro == Numéro)
                    return true;
                else
                    return false;
            }
            else
            {
                if ((lance.Combinaison & Combinaison) == lance.Combinaison)
                    return true;
                else
                    return false;
                //switch (lance.Combinaison)
                //{
                //    case Combinaisons.Derniers24:
                //        List<int> listeDerniers24 = new List<int>();
                //        for (int i = 13; i <= 36; i++)
                //        {
                //            listeDerniers24.Add(i);
                //        }
                //        if (listeDerniers24.Contains((int)lance.Numéro))
                //            return true;
                //        else
                //            return false;
                //    case Combinaisons.Premiers24:
                //        List<int> listePremiers24 = new List<int>();
                //        for (int i = 1; i <= 24; i++)
                //        {
                //            listePremiers24.Add(i);
                //        }
                //        if (listePremiers24.Contains((int)lance.Numéro))
                //            return true;
                //        else
                //            return false;
                //    case Combinaisons.Noir:
                //        int[] listeNoir = { 2,4,6,8,10,11,13,15,17,20,22,24,26,28,29,31,33,35};
                       
                //        if (Array.BinarySearch(listeNoir,lance.Numéro) < 0)
                //            return true;
                //        else
                //            return false;
                //    case Combinaisons.Rouge:
                //        int[] listeRouge = { 1,3,5,7,9,12,14,16,18,19,21,23,25,27,30,32,34,36 };

                //        if (Array.BinarySearch(listeRouge, lance.Numéro) < 0)
                //            return true;
                //        else
                //            return false;
                //    case Combinaisons.Impair:
                //        if (lance.Numéro % 2 != 0)
                //            return true;
                //        else return false;
                //    case Combinaisons.Pair:
                //        if (lance.Numéro % 2 == 0)
                //            return true;
                //        else return false;
                //}

            }
            
        }
        #endregion

        #region Méthodes publiques
        public string GetResultatTexte()
        {
            if(Roulette.EstRouge((int)Numéro))
            {
                if(Numéro%2 == 0)
                    return string.Format("La bille est tombée sur le N° {0}, qui est rouge et pair.", Numéro);
                else
                    return string.Format("La bille est tombée sur le N° {0}, qui est rouge et impair.", Numéro);

            }
            else
            {
                if (Numéro % 2 == 0)
                    return string.Format("La bille est tombée sur le N° {0}, qui est noir et pair.", Numéro);
                else
                    return string.Format("La bille est tombée sur le N° {0}, qui est noir et impair.", Numéro);
            }
            
        }
        #endregion
    }
}
