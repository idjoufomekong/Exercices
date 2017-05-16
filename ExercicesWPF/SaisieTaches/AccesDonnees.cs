using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SaisieTaches
{
    public static class AccesDonnees
    {
        public static List<Tache> ChargerTaches()
        {
            List<Tache> listTache = null;
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Tache>),
      new XmlRootAttribute("Taches"));

            using (var sr = new StreamReader(@"..\..\Taches.xml"))
            {
                // Deserialize renvoie un type object, qu'il faut transtyper 
                listTache = (List<Tache>)deserializer.Deserialize(sr);
            }

            return listTache;
        }
    }
}
