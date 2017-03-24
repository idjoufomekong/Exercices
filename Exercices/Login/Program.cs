using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string login, mdp;
            bool resultLogin, resultMdp;

            Console.WriteLine("Saisir login: ");
            login = Console.ReadLine();

            //resultLogin = false;

            try
            {
                resultLogin = VerifierLogin(login);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                resultLogin = false;
            }

            while (resultLogin == false)
            {
                Console.WriteLine("Saisir à nouveau le login: ");
                login = Console.ReadLine();

                try
                {
                    resultLogin = VerifierLogin(login);//il n'est pas nécessaire que la fonction renvoie quelque chose car l'exception traite déjà s'il y a un retour ou pas
                    //on retourne un paramètre pour l'utiliser et pas pour vérifier s'il y a eu erreur ou pas
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            resultMdp = false;
            while (resultMdp == false)
            {
                Console.WriteLine("Saisir le mot de passe: ");
            mdp = Console.ReadLine();

            try
            {
                    VerifierMdp(mdp);
                    resultMdp = true;
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }


            Console.WriteLine("Votre compte a bien été créé. Un message vient de vous être envoyé");
            Console.ReadKey();

        }

        static bool VerifierLogin(string mot)
        {
            bool result = true;
            if (mot.Length < 5)
            {
                result = false;
                throw new FormatException("Taille insuffisante du login");// Mettre un message le plus précis possible
            }
            return result;

        }

        static void VerifierMdp(string mdp)// il n'est pas nécessaire de renvoyer quelque chose
        {
            bool result = true;
            //if ((mdp.Length < 6) || (mdp.Length > 12) || (mdp[0] == ' ') || (mdp[mdp.Length - 1] == ' '))
            //{
            //    result = false;
            //    throw new FormatException("Le mot de passe ne respecte pas les conditions");
            //}
            //return result;

            if ((mdp.Length < 6) || (mdp.Length > 12))
            {
                result = false;
                throw new FormatException("Le mot de passe doit contenir  entre 6 et 12 caractères");
            }
            //return result;

            if ((mdp[0] == ' ') || (mdp[mdp.Length - 1] == ' '))
            {
                result = false;
                throw new FormatException("Le mot de passe ne doit pas commencer ou finir par un espace");
            }
           // return result;
        }

    }
}
