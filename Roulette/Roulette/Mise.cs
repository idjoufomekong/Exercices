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
    class Mise
    {
    }
}
