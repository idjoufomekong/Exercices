using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    public abstract class DecorateurDistributeur : Distributeur
    {
        public Distributeur Distrib { get; }

        public override decimal MontantMax { get { return Distrib.MontantMax; } }
        public DecorateurDistributeur(DistributeurBoisson distrib)
        {
            Distrib = distrib;
        }
    }

    public class Controlable : DecorateurDistributeur
    {
        public Controlable(DistributeurBoisson  distrib, decimal seuilBas, decimal seuilHaut) : base(distrib)
        {
            SeuilBas = seuilBas;
            SeuilHaut = seuilHaut;

        }

        public decimal SeuilBas { get; }
        public decimal SeuilHaut { get; }

        public string EtatPaiement
        {
            get
            {
                if (Distrib.MontantMax < SeuilBas)
                    return string.Format("La somme entrée est très basse : {0}", Distrib.MontantMax);
                else if (Distrib.MontantMax > SeuilHaut)
                    return string.Format("La somme entrée est très élevée: {0}", Distrib.MontantMax);

                return string.Format("Veuillez patienter svp");
            }
        }

    }
}
