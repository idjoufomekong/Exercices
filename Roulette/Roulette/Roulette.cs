using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    public class Roulette
    {
        #region Champs privés
        private static int _rnd;
        private static Lancé _lancé;
        #endregion

        #region Constructeur
        public Roulette()
        {
            _rnd = new Random().Next(1,36);
        }
        #endregion

        #region Méthodes publiques

        //Détermine si un int est rouge
        public static bool EstRouge(int num)
        {
            int[] listeRouge = { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };

            if (Array.BinarySearch(listeRouge, num) > 0)
                return true;
            else
                return false;
        }

        public Lancé LancerBille()
        {
            if (Roulette.EstRouge(_rnd))
            {
                if (_rnd % 2 == 0)
                {
                    if(_rnd <= 12)
                    {
                        _lancé = new Lancé(_rnd, Combinaisons.Rouge | Combinaisons.Pair | Combinaisons.Premiers24);
                        return _lancé;
                    }
                    else if(_rnd <= 24)
                    {
                        _lancé = new Lancé(_rnd, Combinaisons.Rouge | Combinaisons.Pair | Combinaisons.Premiers24 | Combinaisons.Derniers24);
                        return _lancé;
                    }
                    else
                    {
                        _lancé = new Lancé(_rnd, Combinaisons.Rouge | Combinaisons.Pair | Combinaisons.Derniers24);
                        return _lancé;
                    }
                    
                }
                else
                {
                    if (_rnd <= 12)
                    {
                        _lancé = new Lancé(_rnd, Combinaisons.Rouge | Combinaisons.Impair | Combinaisons.Premiers24);
                        return _lancé;
                    }
                    else if (_rnd <= 24)
                    {
                        _lancé = new Lancé(_rnd, Combinaisons.Rouge | Combinaisons.Impair | Combinaisons.Premiers24 | Combinaisons.Derniers24);
                        return _lancé;
                    }
                    else
                    {
                        _lancé = new Lancé(_rnd, Combinaisons.Rouge | Combinaisons.Impair | Combinaisons.Derniers24);
                        return _lancé;
                    }
                }
            }
            else
            {
                if (_rnd % 2 == 0)
                {
                    if (_rnd <= 12)
                    {
                        _lancé = new Lancé(_rnd, Combinaisons.Noir | Combinaisons.Pair | Combinaisons.Premiers24);
                        return _lancé;
                    }
                    else if (_rnd <= 24)
                    {
                        _lancé = new Lancé(_rnd, Combinaisons.Noir | Combinaisons.Pair | Combinaisons.Premiers24 | Combinaisons.Derniers24);
                        return _lancé;
                    }
                    else
                    {
                        _lancé = new Lancé(_rnd, Combinaisons.Noir | Combinaisons.Pair | Combinaisons.Derniers24);
                        return _lancé;
                    }
                }
                else
                {
                    if (_rnd <= 12)
                    {
                        _lancé = new Lancé(_rnd, Combinaisons.Noir | Combinaisons.Impair | Combinaisons.Premiers24);
                        return _lancé;
                    }
                    else if (_rnd <= 24)
                    {
                        _lancé = new Lancé(_rnd, Combinaisons.Noir | Combinaisons.Impair | Combinaisons.Premiers24 | Combinaisons.Derniers24);
                        return _lancé;
                    }
                    else
                    {
                        _lancé = new Lancé(_rnd, Combinaisons.Noir | Combinaisons.Impair | Combinaisons.Derniers24);
                        return _lancé;
                    }
                }
            }
            
        }
        #endregion
    }
}
