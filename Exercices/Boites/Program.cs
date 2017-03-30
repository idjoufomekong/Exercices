using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boites
{
    class Program
    {
        static void Main(string[] args)
        {
            Boite b1 = new Boite(2,3.2,2.2);
            Boite b2 = new Boites.Boite(4,4.2,4.3, Matières.plastique);
            Console.WriteLine("La boîte 1 est de volume {0} cm3, de couleur {1} et en {2}", b1.Volume, b1.Couleur, b1.Matière);
            Console.WriteLine("La boîte 2 est de volume {0} cm3, de couleur {1} et en {2}", b2.Volume, b2.Couleur, b2.Matière);
            Console.WriteLine("{0} instances de boîtes ont été créées", Boite.Compteur);

            Etiquette e1 = new Etiquette
            {
                Texte = "étiquette1",
                Couleur = Couleurs.blanc,
                Format = Formats.S
            };
            Console.WriteLine("L'{0} a une couleur {1} et un format {2}", e1.Texte, e1.Couleur, e1.Format);

            b1.Etiqueter("FMI");
            b2.Etiqueter("Ministère de l'intérieur", true);
            Console.WriteLine("La boîte 1 est adressée à {0}", b1.EtiquetteDest.Texte);
            Console.WriteLine("La boîte 2 est {0}", b2.EtiquetteFragile.Texte);

            Boite b3 = new Boite(30, 40, 50,Matières.plastique);
            Etiquette etq1 = new Etiquette
            {
                Couleur = Couleurs.blanc,
                Format= Formats.L,   
                Texte="Isagri"        
            };
            Etiquette etq2 = new Etiquette
            {
                Couleur = Couleurs.rouge,
                Format = Formats.S,
                Texte = "Fragile"
            };

            b3.Etiqueter(etq1, etq2);
           // Console.WriteLine("La boîte b3 est adressée à {0} et est {1}", b3.EtiquetteDest.Texte, b3.EtiquetteFragile.Texte);

            var a1 = new Article(1, "Article1", 540);
            var a2 = new Article(2, "Article2", 200);
            var a3 = new Article(3, "Article3", 600);

            b1.Articles.Add(a3.Libellé,a3);
            b1.Articles.Add(a2.Libellé,a2);
            b1.Articles.Add(a1.Libellé,a1);

            b1.Articles["Article2"].Poids = 2154;

            //for(int i=0; i < b1.Articles.Count; i++)
            //{
            //    Console.WriteLine(b1.Articles[i]);//Le compilateur appelle automatiquement Tostring car elle est redéfinie dans la classe
            //}

            //for(int i=0; i< b1.Articles.Count; i++)
            //{
            //    if (b1.Articles[i] is Article)
            //    {
            //       // Article a = (Article)b1.Articles[i];
            //     b1.Articles[i].Libellé = "djshd";
            //    }
            //    else
            //        throw new ArgumentException();
                
            //}
           // b1.Articles.Sort();
            // Autre façon de parcourir la collection en lecture seule
            foreach(var a in b1.Articles)
            {
                Console.WriteLine("{0},{1}",a.Key, a.Value);
            }
            //foreach(var k in b1.Articles.Keys)
            //{
            //    Console.WriteLine("{0}", k);
            //}
            //foreach (var v in b1.Articles.Values)
            //{
            //    Console.WriteLine("{0}", v);
            //}

            Console.ReadKey();
        }
    }
           
}
