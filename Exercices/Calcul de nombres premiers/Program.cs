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
            int compt, divis,nbr;
            Boolean estPremier;

            Console.WriteLine("Combien de nombres premiers: ");
            string valeur = Console.ReadLine();
            n = int.Parse(valeur);

            /*if (n == 0) Console.WriteLine("Pas de nombres premiers");
            if (n == 1) Console.WriteLine('\n' + 1);
            else*/
            {
                Console.WriteLine(2);
                compt = 1;
                nbr = 3;
                while (compt < n)
                {
                divis = 2;
                estPremier = true;

                    do
                    {
                        if (nbr % divis == 0) estPremier = false;
                        else divis += 2;
                    }
                    while ((divis > nbr / 2) || (estPremier == false));

                    if (estPremier)
                    {
                        Console.WriteLine(nbr);
                        compt++;
                    }
                    nbr += 2;
                }

            }

            Console.ReadKey();
        }
    }
}
