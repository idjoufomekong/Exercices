using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tri_d_un_tableau
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tab = { "seize", "trois", "douze", "un" };//{ "vert","bleu", "rouge", "jaune"}; //;
            AffichTab(tab);

            TrieTableau(tab);
            AffichTab(tab);

            Console.ReadKey();


        }

        static void AffichTab(string[] tab)
        {
            for (int i = 0; i < tab.Length; i++)
                Console.Write(tab[i] + "; ");
        }

        static void TrieTableau(string[] tab)
        {
            string perm;
            bool auMoinsUnePermut = true;

            //while (auMoinsUnePermut)
            //{
            //    auMoinsUnePermut = false;
            //    for (int i = 0; i < tab.Length - 1; i++)
            //    {

            //        if (tab[i].CompareTo(tab[i + 1]) > 0)
            //        {
            //            perm = tab[i];
            //            tab[i] = tab[i + 1];
            //            tab[i + 1] = perm;
            //            auMoinsUnePermut = true;
            //        }


            //    }

            //}

            for (int i = 0; i < tab.Length - 1; i++)
            {
                for (int j = i; j < tab.Length - 1; j++)
                {
                    if (tab[j].CompareTo(tab[j + 1]) > 0)
                    {
                        perm = tab[j];
                        tab[j] = tab[j + 1];
                        tab[j + 1] = perm;
                        //auMoinsUnePermut = true;
                    }
                }

            }
        }
    }
}
