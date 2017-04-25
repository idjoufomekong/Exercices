using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorateur_de_fichiers
{
    public class Analyseur
    {
        #region Champs privés

        #endregion

         #region Propriétés
        public int NbFichiers { get; private set; }
        public int NbFichiersCs { get; private set; }
        public string Extension { get; private set; }
        public string Nom { get; private set; }
        public List<string> ListeFichierprojet { get; }
        public string PlusLongFichier { get; private set; }
        #endregion

        #region Constructeur
        public Analyseur()
        {
            ListeFichierprojet = new List<string>();
        }
        #endregion

        #region Méthodes publiques
        public void CompterFichiers(FileInfo fichier)
        {
            NbFichiers++;
            if (fichier.Extension.ToLower() == ".cs")
                NbFichiersCs++;   
        }

        public void TrouverFichierLong(FileInfo fichier)
        {
            long taille = PlusLongFichier.Length;
            if (taille < fichier.Length)
                PlusLongFichier = fichier.Name;
        }

        public void TrouverFichierProjetCSharp(FileInfo fichier)
        {
            if (fichier.Extension.ToLower() == ".csproj")
                ListeFichierprojet.Add(Path.GetFileNameWithoutExtension(fichier.Name));
        }

        public void AnalyserFichier(string chemin)
        {

            PlusLongFichier = "";
            NbFichiers = 0;
            NbFichiersCs = 0;

            DelegueExplorateur analize = null;
            analize += CompterFichiers;
            analize += TrouverFichierLong;
            analize += TrouverFichierProjetCSharp;

            Explorateur.Explorer(chemin, analize);
        }
        #endregion
    }
}
