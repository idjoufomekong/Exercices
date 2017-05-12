using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
    }
