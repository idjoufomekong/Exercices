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
                    resultLogin = VerifierLogin(login);
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
                    resultMdp=VerifierMdp(mdp);
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
                throw new FormatException("Taille insuffisante du login");
            }
            return result;

        }

        static bool VerifierMdp(string mdp)
        {
            bool result = true;
            if ((mdp.Length < 6) || (mdp.Length > 12) || (mdp[0] == ' ') || (mdp[mdp.Length - 1] == ' '))
            {
                result = false;
                throw new FormatException("Le mot de passe ne respecte pas les conditions");
            }
            return result;
        }

    }
}
