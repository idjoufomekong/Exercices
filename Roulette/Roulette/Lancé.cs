﻿using System;
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
        public bool CorrespondA(Lancé lance)
        {
            return true;
        }
        #endregion
    }
}
