using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicules
{
    public enum Energies { Aucune, Essence, Gazole, GPL, Electrique}
    class Program
    {
        static void Main(string[] args)
        {
            Voiture v1 = new Voiture("Merco", Energies.Gazole);
            Console.WriteLine(v1.Description);

            Véhicule v2 = new Moto("Cross", Energies.Essence);
            Véhicule v3 = new Voiture("Renault", Energies.Essence);
            Console.WriteLine(v2.Description);
            Console.WriteLine(v3.Description);

            Console.ReadKey();
        }
    }
}
