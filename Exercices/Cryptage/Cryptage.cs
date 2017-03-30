using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptage
{
    public static class Cryptage
    {
        public static Dictionary<char,char> _dico = new Dictionary<char, char>();
        

        public static bool ChargerClé(string s)
        {
            string[] lignes = null;
            try
            {
               // string s = @"../../cle.txt";
                lignes = File.ReadAllLines(s);
                char car1= '0';
                char car2 = '0';
                

                for (int i= 0; i< lignes.Length; i++)
                    {
                        AnalyserFichier(lignes[i], out  car1, out car2);
                        _dico.Add(car1,car2);
                    }
                Console.WriteLine("1: {0} 2: {1}", _dico.ElementAt(0).Key, _dico.ElementAt(0).Value);
                return true;

            }
            catch (FileNotFoundException)
            {

                Console.WriteLine("Fichier non trouvé: {0}", s);
                return false;
            }
            catch (Exception)
            {

                Console.WriteLine("Erreur avec le fichier: {0}", s);
                return false;
            }
            
        }

        public static void AnalyserFichier(string ligne, out char car1, out char car2)
        {
            string[] valeur = ligne.Split( ' ' );
            car1 = char.Parse(valeur[0]);
            car2 = char.Parse(valeur[1]);


        }

        public static string Crypter(string b)
            {
            char c;
            string s=b;
                for(int i=0; i<s.Length;i++)
                {
                if( _dico.TryGetValue(s[i],out c))
                    s[i] = c;
                }
                return s;
            }
    }
}

