using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcul_du_PGCD
{
    class Program
    {
        static void Main(string[] args)
        {
            int p,m;
            int q,n;
            int pgcd;
            string valeur;

            Console.WriteLine("Entrez le premier nombre: ");
            valeur = Console.ReadLine();
            p=m = int.Parse(valeur);

            Console.WriteLine("Entrez le deuxième nombre: ");
            valeur = Console.ReadLine();
            q=n = int.Parse(valeur);

            while(p!=q)
            {
                if (p > q)
                    p = p - q;
                else
                    q = q - p;
            }
            pgcd = p;

            Console.WriteLine("Le PGCD de " + m + " et " +n +" est: " + pgcd);
            Console.ReadKey();
        }
    }
}
