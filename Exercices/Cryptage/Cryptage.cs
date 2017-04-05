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
        //Créer régions
        public static Dictionary<char,char> _cryptage= new Dictionary<char, char>();//Mieux choisir le nom
        public static Dictionary<char,char> _décryptage= new Dictionary<char, char>();
        
        public static Dictionary<char,char> Cryptages 
            { 
                get 
                    { return _cryptage;}
            }
        public static Dictionary<char,char> Décryptage 
            { 
                get 
                    { return _décryptage;}
            }
        
        public static void ChargerClé(string s)
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
                        _cryptage.Add(car1,car2);
                        _décryptage.Add(car2,car1);
                    }
                /*Console.WriteLine("1: {0} 2: {1}", _cryptage.ElementAt(0).Key, _cryptage.ElementAt(0).Value);
                Console.WriteLine("3: {0} 4: {1}", _décryptage.ElementAt(0).Key, _décryptage.ElementAt(0).Value);*/
                
            }
            catch (FileNotFoundException)
            {

                Console.WriteLine("Fichier non trouvé: {0}", s);
                
            }
            catch (Exception)
            {

                Console.WriteLine("Erreur avec le fichier: {0}", s);
                
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
            char[] s= b.ToCharArray();

                for(int i=0; i<s.Length;i++)
                {
                if( _cryptage.TryGetValue(s[i],out c))
                    s[i] = c;
                }
                return new string(s);
            }

            public static string Décrypter(string b)
            {
            char c;
            char[] s= b.ToCharArray();

                for(int i=0; i<s.Length;i++)
                {
                if( _décryptage.TryGetValue(s[i],out c))
                    s[i] = c;
                }
                return new string(s);
            }
    }
}

