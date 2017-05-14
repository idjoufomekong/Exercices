using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOverview.Entites
{
    public class Logiciel
    {
        public string CodeLogiciel { get; set; }
        public string Nom { get; set; }
        public BindingList<Module> ListeModule { get; set; }
        public BindingList<Version> ListeVersion { get; set; }
    }

    public class Module
    {
        public string CodeModule { get; set; }
        public string Libelle { get; set; }
    }

    public class Version
    {
        public float NumeroVersion { get; set; }
        public short Millesime { get; set; }
        public DateTime DateOuverture { get; set; }
        public DateTime DateSortiePrevue { get; set; }
        public short NumeroRelease { get; set; }
    }
}
