using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boites
{
    class Program
    {
        static void Main(string[] args)
        {
            Boite b1 = new Boite(2,3.2,2.2);
            Boite b2 = new Boites.Boite(4,4.2,4.3, Matières.plastique);
            Console.WriteLine("La boîte 1 est de volume {0} cm3, de couleur {1} et en {2}", b1.Volume, b1.Couleur, b1.Matière);
            Console.WriteLine("La boîte 2 est de volume {0} cm3, de couleur {1} et en {2}", b2.Volume, b2.Couleur, b2.Matière);
            Console.WriteLine("{0} instances de boîtes ont été créées", Boite.Compteur);

            Etiquette e1 = new Etiquette
            {
                Texte = "étiquette1",
                Couleur = Couleurs.blanc,
                Format = Formats.S
            };
            Console.WriteLine("L'{0} a une couleur {1} et un format {2}", e1.Texte, e1.Couleur, e1.Format);

            b1.Etiqueter("FMI");
            b2.Etiqueter("Ministère de l'intérieur", true);
            Console.WriteLine("La boîte 1 est adressée à {0}", b1.EtiquetteDest.Texte);
            Console.WriteLine("La boîte 2 est {0}", b2.EtiquetteFragile.Texte);

            Boite b3 = new Boite(30, 40, 50,Matières.plastique);
            Etiquette etq1 = new Etiquette
            {
                Couleur = Couleurs.blanc,
                Format= Formats.L,   
                Texte="Isagri"        
            };
            Etiquette etq2 = new Etiquette
            {
                Couleur = Couleurs.rouge,
                Format = Formats.S,
                Texte = "Fragile"
            };

            b3.Etiqueter(etq1, etq2);
            Console.WriteLine("La boîte b3 est adressée à {0} et est {1}", b3.EtiquetteDest.Texte, b3.EtiquetteFragile.Texte);
            


            Console.ReadKey();
        }
    }
           
}
