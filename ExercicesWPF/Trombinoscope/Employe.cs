using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Trombinoscope
{
    public class Employe
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string NomComplet
        {
            get
            {
                return Nom + " " + Prenom;
            }
        }
        public List<Territoire> Territoires { get; set; }
        public int IdManager { get; set; }
        public string NomManager { get; set; }
        public string PrenomManager { get; set; }
        public ImageSource Photo { get; set; }
    }
    }
