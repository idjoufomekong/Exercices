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
            Cryptage.ChargerClé(s);
                                
            string v = "valeur";
            Console.WriteLine("Le mot {0} est transformé en: {1}", v, Cryptage.Crypter(v));

            string c = "vewyfs";
            Console.WriteLine("Le mot {0} est transformé en: {1}", c, Cryptage.Décrypter(c));
            Console.ReadKey();
        }
    }
}
