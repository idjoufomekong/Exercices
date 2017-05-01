using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorateur_de_fichiers
{
    public class Program
    {
        static void Main(string[] args)
        {
            string chemin = "";
            while (chemin == "")
            {
                Console.WriteLine("Veuillez entrer le nom du fichier à explorer:");
                chemin = Console.ReadLine();

                Analyseur ana = new Analyseur();

               
                Console.WriteLine(ana.Extension);
                Console.WriteLine("Nombre de fichiers total: {0}\n Nombre de fichiers Csharp: {1}",
                    ana.NbFichiers, ana.NbFichiersCs);
                Console.WriteLine("Nom du fichier le plus long: {0}", ana.PlusLongFichier);
                Console.WriteLine("Liste des fichiers projet:");
                foreach (var a in ana.ListeFichierprojet)
                {
                    Console.WriteLine(a);
                }

                Console.ReadKey();
                chemin = "";
                Console.Clear();
            }
        }
    }
}
