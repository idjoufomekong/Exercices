using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyseurLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var al = new AnalyseurLINQ();
            al.ChargerDonnées();
            al.RAfficherStats();
            Console.ReadKey();
        }
    }
}
