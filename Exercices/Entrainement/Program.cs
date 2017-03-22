using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entrainement
{
    class Program
    {
        static void Main(string[] args)
        {
            Demo();
            Console.ReadKey();
        }
        static void Demo()
        {
            //Console.WriteLine("Hello");
            string texte;
            string phrase;
            int nbPhrase, nbMots, nbCaractères; // Plusieurs déclarations

            const double PI = 3.1414926;
            const string DEB_LISTE = "-";

            phrase = "Le C# est un langage moderne et puissant!";
            texte = phrase;
            texte = texte + "Il est utilisé pour toutes sortes d'application\n";
            texte += DEB_LISTE + "Application console\n";
            texte += DEB_LISTE + "Application fenêtrée Winforms et WPF\n";

            Console.WriteLine(texte);
            //Console.Write(texte);
            char lettre;
            lettre = phrase[3];
            Console.WriteLine("Lettre:"+lettre);

            short s = 2;
            s++;
            Console.WriteLine("La valeur de s est:" + s);

            /*int[] tabPos = new int[3]; //Tableau de 3 entiers
            tabPos[0] = 2;
            tabPos[1] = 3;
            tabPos[2] = 4;*/

            int[] tabPos = new int[3] { 3, 4, 40 };
            Console.WriteLine(tabPos.Length);// Nbre d'éléments du tableau

            //Les boucles
            for (int i=0; i<tabPos.Length;i++)
            {
                Console.WriteLine(tabPos[i]);
            }
            int j = 0;
            while(j<tabPos.Length)
            {
                Console.WriteLine(tabPos[j]);
                j++;
            }

            Console.Clear();
            Console.WriteLine(texte);

            //Compter le nombre de lignes dans le texte
            nbPhrase = 0;
            for(int i=0; i<texte.Length;i++)
            {
                if (texte[i] == '\n')
                 {
                nbPhrase++;
                 }
            }
            Console.WriteLine("Il y a " + nbPhrase + " lignes dans le texte");

            //Compter le nbre de mots dans une phrase
            nbMots = 0;
            for (int i = 0; i < phrase.Length; i++)
            {
                if (phrase[i] == ' ' || phrase[i]=='\'' || phrase[i]=='\n')
                {
                    nbMots++;
                }
            }
            Console.WriteLine("Il y a " + nbMots + " mots dans la phrase");

            Console.WriteLine("Entrer un nombre:");
            string valeur = Console.ReadLine();
            int x = int.Parse(valeur);
        }
    }
}
