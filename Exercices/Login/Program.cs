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
            bool resultLogin;

            Console.WriteLine("Saisir login: ");
            login = Console.ReadLine();

            try
            {
             do resultLogin=VerifierLogin(login);
                while (resultLogin == false) ; 
            }
            catch (FormatException e)
            {
               Console.WriteLine(e.Message);
            }
           
                   
            Console.WriteLine("Saisir le mot de passe: ");
            mdp = Console.ReadLine();
            
            try
            {
                VerifierMdp(mdp);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
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

        static void VerifierMdp(string mdp)
        {
            if((mdp.Length<6)|| (mdp.Length >12)|| (mdp[0]==' ') || (mdp[mdp.Length-1] == ' '))
                throw new FormatException("Le mot de passe ne respecte pas les conditions");
        }

    }
}
