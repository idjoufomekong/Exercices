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

            Console.WriteLine(v2.PRK);
            Console.WriteLine(v3.PRK);

            Console.WriteLine("Résultat v2 par rapport à v1 = {0}", v2.CompareTo(v1));
            Console.WriteLine(v2.ComparerVéhicules(v3));

            Véhicule[] tabVehicule =
            {new Voiture("Peugeot", Energies.Electrique),
             new Moto("Honda",Energies.GPL),
             new Voiture("Audi", Energies.Essence),
             new Moto("Yamaha",Energies.Aucune)
            };

            for(int i=0; i < 4; i++)
            {
                if(tabVehicule[i] is Voiture)
                {
                    Console.WriteLine(((Voiture)tabVehicule[i]).RefaireParallélisme());
                }
            }

            Console.ReadKey();
        }
    }
}
