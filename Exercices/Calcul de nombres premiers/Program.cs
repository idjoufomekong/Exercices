using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcul_de_nombres_premiers
{
    class Program
    {
        static void Main(string[] args)
        {

            int n;

            Console.WriteLine("Combien de nombres premiers: ");
            string valeur = Console.ReadLine();
            n = int.Parse(valeur);
            while (n != 0)
            {
                /*if (n == 0) Console.WriteLine("Pas de nombres premiers");
                if (n == 1) Console.WriteLine('\n' + 1);
                else*/
                CalculerNbPremiers(n);
                //CalculerNbPremiers(6);
                //CalculerNbPremiers(18);
                Console.WriteLine("Combien de nombres premiers: ");
                valeur = Console.ReadLine();
                n = int.Parse(valeur);
            }

           Console.ReadKey();
        }

        static void CalculerNbPremiers(int nbpremiers)
        {
            int compt, divis, nbr;
            Boolean estPremier;
            Console.WriteLine(2);
            compt = 0;
            nbr = 3;
            while (compt < nbpremiers - 1)
            {
                divis = 2;
                estPremier = true;

                do
                {
                    if (nbr % divis == 0) estPremier = false;
                    else divis += 1;
                }
                //while ((divis > nbr / 2) || (estPremier == false));// Condition pas bonne, "estpremier" est tjrs = false
                while ((divis <= nbr / 2) && (estPremier == true));

                if (estPremier)
                {
                    compt++;
                    Console.WriteLine(nbr);
                }
                nbr ++;
            }

        }
    }
}
