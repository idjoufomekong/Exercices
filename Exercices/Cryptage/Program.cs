using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptage
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = @"../../cle.txt";
            if(Cryptage.ChargerClé(s))
                Console.WriteLine("Fichier ouvert");
                
            string v = "valeur";
            Console.WriteLine(Cryptage.Crypter(v));
            Console.WriteLine("noveau mot; {0}", v);
            Console.ReadKey();
        }
    }
}
