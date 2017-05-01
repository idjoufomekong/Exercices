using System;
using System.Collections.Generic;
using System.Globalization;
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
            //Voiture v1 = new Voiture("Merco", Energies.Gazole);
            //Console.WriteLine(v1.Description);

            //Véhicule v2 = new Moto("Cross", Energies.Essence);
            //Véhicule v3 = new Voiture("Renault", Energies.Essence);
            //Console.WriteLine(v2.Description);
            //Console.WriteLine(v3.Description);

            //Console.WriteLine(v2.PRK);
            //Console.WriteLine(v3.PRK);

            //Console.WriteLine("Résultat v2 par rapport à v1 = {0}", v2.CompareTo(v1));
            //Console.WriteLine(v2.ComparerVéhicules(v3));

            //Véhicule[] tabVehicule =
            //{new Voiture("Peugeot", Energies.Electrique),
            // new Moto("Honda",Energies.GPL),
            // new Voiture("Audi", Energies.Essence),
            // new Moto("Yamaha",Energies.Aucune)
            //};

            //for(int i=0; i < 4; i++)
            //{
            //    if(tabVehicule[i] is Voiture)
            //    {
            //        Console.WriteLine(((Voiture)tabVehicule[i]).RefaireParallélisme());
            //    }
            //}

            Véhicule v1 = new Voiture("Mégane", 19000);
            Véhicule v2 = new Moto("Intruder", 13000);
            Véhicule v3 = new Voiture("Enzo", 380000);
            Véhicule v4 = new Moto("Yamaha XJR1300", 11000);

            //Gestion délégués
            /* Dictionary<string, Véhicule> Véhicules = new Dictionary<string, Véhicule>();
             Véhicules.Add(v1.Nom, v1);
             Véhicules.Add(v2.Nom, v2);
             Véhicules.Add(v3.Nom, v3);
             Véhicules.Add(v4.Nom, v4);

             Console.OutputEncoding = Encoding.Unicode;// pour mettre le symbole €
             foreach(var a in Véhicules)
             {
                 Console.WriteLine("Nom: {0} prix: {1}€", a.Key, a.Value.Prix);
             }

             SortedList<string, Véhicule> ListVéhicule = new SortedList<string, Véhicule>();
             foreach(var a in Véhicules)
             {
                 ListVéhicule.Add(a.Key, a.Value);
             }
             //Véhicules.Clear();
             Console.WriteLine("liste");
             foreach(var a in ListVéhicule)
             {
                 Console.WriteLine("Nom: {0} prix: {1}€", a.Key, a.Value.Prix);
             }

             SortedList<Véhicule, string> ListVéhicule1 = new SortedList<Véhicule, string>();
             foreach (var a in Véhicules)
             {
                 ListVéhicule1.Add(a.Value, a.Key);
             }
             //Véhicules.Clear();

             Console.WriteLine("liste1");
             foreach (var a in ListVéhicule1)
             {
                 Console.WriteLine("Nom: {0} prix: {1}€", a.Key.Nom, a.Key.Prix);
             }

             Console.WriteLine("Résultat recherche");
             string[] tabChaine = {"Clio","Mégane", "Golf", "Enzo", "Polo" };(1)*/

            /*for(int i=0; i<tabChaine.Length; i++)
            {
                string v = tabChaine[i];
                foreach(var a in Véhicules)
                {
                    if (v.CompareTo(a.Key) == 0)
                        Console.WriteLine("Nom: {0} prix: {1}€", a.Key, a.Value.Prix);
                }
            }*/
            /*foreach(var s in tabChaine)
            {
                Véhicule v;
                if(Véhicules.TryGetValue(s,out v))
                    Console.WriteLine("Nom: {0} Prix: {1}",v.Nom, v.Prix);
            }(1)*/

            DelegueEntretien entretien = null;
            entretien += ChangerPneus;
            entretien += Vidanger;
            entretien += RetoucherPeinture;

            v1.Entretenir(new DateTime(2008,10,05), entretien);
            AfficherCarnetEntretien(v1);

            Console.ReadKey();
        }

        public static void ChangerPneus(Véhicule v)
        {
            DateTime d = v.CarnetEntretien.Keys.Last();
            v.CarnetEntretien[d] += "\n- Pneus changés";


        }

        public static void Vidanger(Véhicule v)
        {
            DateTime d = v.CarnetEntretien.Keys.Last();
            v.CarnetEntretien[d] += "\n- Vidange effectuée";
        }

        public static void RetoucherPeinture(Véhicule v)
        {
            DateTime d = v.CarnetEntretien.Keys.Last();
            v.CarnetEntretien[d] += "\n- Peinture retouchée"; 
        }

        public static void AfficherCarnetEntretien(Véhicule v)
        {
            foreach( var a in v.CarnetEntretien)
            {
                /*Console.Write("Entretien du véhicule " + v.Nom + " du " + a.Key.ToString("d", DateTimeFormatInfo.InvariantInfo) + ":");
                Console.Write(a.Value);*/

                Console.WriteLine("Entretien du véhicule {0} du {1:d} {2}",v.Nom,a.Key, a.Value);
            }
        }
    }
}
