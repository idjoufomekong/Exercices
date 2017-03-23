using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comptage_Voyelles_Consonnes
{
    class Program
    {
        static void Main(string[] args)
        {
            string motsaisi;
            int voy, cons;

            Console.WriteLine("Saisir un mot: ");
            motsaisi = Console.ReadLine();

            Comptage_Voyelles_Consonnes(motsaisi, out voy, out cons);
            //Console.WriteLine(motsaisi + "comprend" + cons + "consonnes et " +voy +"voyelles");
            Console.WriteLine("{0} comprend {1} voyelles et {2} consonnes.",motsaisi,voy,cons);
            Console.ReadKey();

        }

        static void Comptage_Voyelles_Consonnes(string mot, out int v, out int c)
        {
           // string chaine = mot;
            int nbCar = mot.Length;
            char car;
            v = 0;

            //Console.WriteLine("char:"+ chaine.ElementAt(0));
            //Console.WriteLine("char:" + chaine.ElementAt(mot.Length -1));
            for(int i=0; i<mot.Length;i++)
            {
                //car = mot.ElementAt(i);
                car = mot[i];
                //if ((car == 'a') || (car == 'e') || (car == 'i') || (car == 'o') || (car == 'u') || (car == 'y'))
                //    v++;
                switch (car)
                {
                    case 'a': case 'e': case 'i': case 'o': case 'u': case 'y':
                        v++;
                break;
                
            }

        }
            c = nbCar-v;
            

           
        }
    }
}
