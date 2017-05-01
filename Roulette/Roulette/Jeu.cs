using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    public class Jeu
    {
        #region Champs privés
        private int _nbJetons;
        private Roulette _roulette;
        private  static int _nbMise = 1;
        private static int _nbJetonInit, _nbJetonFinal;
        private static int _nbGagnant = 0;
        private static int _nbPerdant = 0;
        #endregion

        #region Propriétés 
        public Roulette Roulette { get {return _roulette; } }
        public int NbJetons { get { return _nbJetons; }
                              set { _nbJetons = value; } }
        public int MyProperty { get; set; }

        #endregion

        #region Constructeur
        public Jeu()
        {
            _roulette = new Roulette();
        }
        #endregion

        #region Méthodes publiques
        public void Jouer()
        {
            SaisirNbJetonsInit();
            _nbJetonInit = _nbJetons;
            do
            {
                Mise mise;
                SaisirMise(out mise);
                Lancé lancé = _roulette.LancerBille();
                AfficherRésultat(lancé, mise);
                _nbJetonFinal = _nbJetons;
                if (!SaisirContinuation())
                    break;
            }
            while (_nbJetons != 0);

            //Console.WriteLine("La partie est terminée. \nMerci d’avoir joué.");
            AfficherStats();
            
        }
        #endregion

        #region Méthodes privées
        private void SaisirNbJetonsInit()
        {
            do
            {
                Console.WriteLine("Combien de jetons avez-vous achetés?");
                _nbJetons = int.Parse(Console.ReadLine());
            }
            while (_nbJetons == 0);      
        }

        private void SaisirMise(out Mise mise)
        {
            string saisie;
            Combinaisons combi = Combinaisons.Aucun;
            int nombre = 0;
            int jeton;

            Console.Write("Mise " + _nbMise + " - ");
            Console.WriteLine("Quelle combinaison choisissez vous?");
            Console.WriteLine("24p/24d : 24 premiers ou derniers numéros");
            Console.WriteLine("r/n : Couleur rouge ou noire");
            Console.WriteLine("i/p : Numéro impair ou pair");
            Console.WriteLine("x : Un numéro précis");
            do
            {
                saisie = Console.ReadLine();    
            }
            while ((saisie.CompareTo("24p") !=0) && (saisie.ToUpper() != "24D") && (saisie.ToUpper() != "R") && (saisie.ToUpper() != "N") && 
                    (saisie.ToUpper() != "I") && (saisie.ToUpper() != "P") && (saisie.ToUpper() != "X"));
            if (saisie.ToUpper() == "X")
            {

                Console.WriteLine("Choisissez un numéro compris entre 1 et 36 :");
                do
                {
                    nombre = int.Parse(Console.ReadLine()); 
                }
                while (nombre == 0);
                
                
            }

            do
            {
                Console.WriteLine("Combien de jetons misez-vous (max : " + NbJetons + ") ?");
                do
                {
                    jeton = int.Parse(Console.ReadLine());

                }
                while (jeton > NbJetons);
            }
            while (jeton == 0);
            //Retour du choix

            if (saisie.ToUpper() == "X") { combi = Combinaisons.Précis; mise = new Mise(nombre, combi, jeton); }
            else if (saisie.ToUpper() == "24P") combi = Combinaisons.Premiers24;
            else if (saisie.ToUpper() == "24D") combi = Combinaisons.Derniers24;
            else if (saisie.ToUpper() == "R") combi = Combinaisons.Rouge;
            else if (saisie.ToUpper() == "N") combi = Combinaisons.Noir;
            else if (saisie.ToUpper() == "I") combi = Combinaisons.Impair;
            else if (saisie.ToUpper() == "P") combi = Combinaisons.Pair;

            mise = new Mise(null, combi, jeton);
            _nbMise++;
        }

        public void AfficherRésultat(Lancé lance, Mise mise)
        {
            if (lance.CorrespondA(mise.Pari))
            {
                mise.Gagnante = true;
                NbJetons += mise.Gain;
                _nbGagnant++;
            }
            else
            {
                NbJetons -= mise.Gain;
                _nbPerdant++;
            }
               
            Console.WriteLine(lance.GetResultatTexte());
            Console.Write(mise.GetResultatTexte());
            if(NbJetons > 0)
                Console.Write(string.Format("Vous possédez désormais {0} jetons.\n", NbJetons));
            else
                Console.Write("Il ne vous reste plus aucun jeton.\n");
            
        }

        public bool SaisirContinuation()
        {
            string cont;
            if (_nbJetons <= 0)
                return false;
            do
            {
                Console.WriteLine("Voulez-vous continuer (O/N)?");
                cont = Console.ReadLine();
            }
            while (cont.ToUpper() != "O" && cont.ToUpper() != "N");
            if (cont.ToUpper() == "O")
                return true;
            else
                return false;
            
        }

        public void AfficherStats()
        {
            int gain = _nbJetonFinal - _nbJetonInit;
            if (_nbJetonFinal < 0) _nbJetonFinal = 0;
            if (gain < 0) gain = 0;
            Console.WriteLine(string.Format("{0} mises réalisées, dont {1} gagnante(s) et {2} perdante(s)." +
                "\nNombre de jetons initial : {3}" +
                "\nNombre de jetons final : {4} (+{5})" +
                "\nMerci d’avoir joué.",
                _nbMise-1, _nbGagnant, _nbPerdant, _nbJetonInit, _nbJetonFinal,gain));
        }
        #endregion

    }
}
   
