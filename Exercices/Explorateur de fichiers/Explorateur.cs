﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorateur_de_fichiers
{
    public delegate void DelegueExplorateur(FileInfo f);
    public class Explorateur
    {
        #region Propriétés
        public string Chemin { get; }
        public List<FileInfo> ListeFichiers { get; }

        #endregion

        //#region Constructeur
        //public Explorateur()
        //{
        //    Chemin = chemin;
        //    ListeFichiers = new List<FileInfo>();
        //}
        //#endregion

        #region Métodes publiques
        public static void Explorer(string chemin, DelegueExplorateur analyserFichier)
        {
            if ((new DirectoryInfo(chemin)).Exists)
            { 
                DirectoryInfo repertoire = new DirectoryInfo(chemin);
                foreach (var a in repertoire.EnumerateFiles("*", SearchOption.AllDirectories))
                {
                    analyserFichier(a);
                }
            }

        }
        #endregion
    }

}
