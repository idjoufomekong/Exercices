using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statuts
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<Statuts> l = new List<Statuts> { Statuts.CDD, Statuts.CDI,Statuts.CHSCT };
            //Personne p = new Personne("Porc", "Cochon", l);
            //Console.WriteLine(p.ToString());

            //liste des personnes
            List<Personne> ListePersonnes = new List<Personne>() {
            new Personne("TURPIN", "Abel", Statuts.CDI),
            new Personne("BONNEAU", "Achille", Statuts.CDI|Statuts.DP),
            new Personne("BLONDEL", "Adelphe", Statuts.CDI|Statuts.DP|Statuts.CHSCT),
            new Personne("BLACK", "Aimé", Statuts.CDI),
            new Personne("PERRIER", "Aimée", Statuts.CDI),
            new Personne("JORDAN", "Alain", Statuts.CDD|Statuts.CHSCT),
            new Personne("BAUDRY", "Alban", Statuts.CDD),
            new Personne("ORLEANS", "Albert", Statuts.CDI|Statuts.DP|Statuts.SYND),
            new Personne("VALOIS", "Alexandra", Statuts.CDI|Statuts.SYND),
            new Personne("WEST", "Alexandre", Statuts.CDI|Statuts.DP|Statuts.CHSCT)
        };

            Statuts CDD_CHSCT = Statuts.CDD | Statuts.CHSCT;//Masque
            Statuts CDI_DP = Statuts.CDI | Statuts.DP;
            List<Personne> Liste_CDI_DP = new List<Personne>();
            //List<Personne> Liste_CDI_DP = new List<Personne>();

            foreach (var a in ListePersonnes)
            {
                if ((a.Statut & CDI_DP) == CDI_DP)
                    a.Statut = a.Statut | Statuts.CHSCT; //a.Statut |= Statuts.CHSCT
                //a.Statut &= ~Statuts.DP; //Retire un statut
                Liste_CDI_DP.Add(a);

            }

            foreach (var a in Liste_CDI_DP)
            {
               Console.WriteLine(a);
                a.Statut &= ~Statuts.DP;
                Console.WriteLine(a);
            }
           

            Console.ReadKey();
        }
    }
}
