using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace AnalyseurLINQ
{
    public class AnalyseurLINQ
    {
    	private List<DonnéesMois> _data;
    	public List<DonnéesMois> Data {
    		get { return _data; }
    	}

        public AnalyseurLINQ()
        {
            _data = new List<DonnéesMois>();
        }

        public void ChargerDonnées()
        {
            string chemin = @"..\..\DonnéesMétéoParis.txt";

            int cpt = 0;
            using (StreamReader str = new StreamReader(chemin))
            {
                string ligne;
                
                while ((ligne = str.ReadLine()) != null)
                {
                    cpt++;
                    if (cpt == 1) continue; // On n'analyse pas la première ligne car elle contient les en-têtes

                    var tab = ligne.Split('\t');
                    try
                    {
                        var donnéesMois = new DonnéesMois
                        {
                            Mois = DateTime.Parse(tab[0]),
                            TMin = double.Parse(tab[1]),
                            TMax = double.Parse(tab[2]),
                            Précipitations = double.Parse(tab[3]),
                            Ensoleillement = double.Parse(tab[4])
                        };

                        // Ajout des données du mois à la liste
                        Data.Add(donnéesMois);
                    }
                    catch (FormatException)
                    {
                        // On ignore simplement la ligne
                        Console.WriteLine("Erreur de format à la ligne suivante :\r\n{0}", ligne);
                    }
                }
            }
        }

        public void AfficherStats()
        {
            // mois de la température min la plus basse
            var res1 = Data.Min(t => t.TMin);
           
            var res2 = Data.Where(m => m.TMin == res1).First();// Je filtre ma liste de données. Il pêut y avoir plusieurs
            Console.WriteLine("Mois le plus froid: {0}, avec {1}°C", res2.Mois.ToString("mmmm yyyy"), res2.TMin);

            //Data.OrderBy(m => m.TMin).First(); // En utilisant le tri

            // Sommes des précipitations de l'année 2016
            //var year2016 = Data.Where(a => a.Mois.Year
            var pre = (Data.Where(a => a.Mois.Year == 2016)).Sum(a => a.Précipitations);
            Console.WriteLine("La somme des précipitations de l'année 2016: {0}mm", pre);

            // Durée d'ensoleillement moyenne du mois de Juillet sur toutes les années
            //var ens = Data.Average(a => a.Ensoleillement);
            //Console.WriteLine("La moyenne de l'ensoleillement est {0}", ens);
            var s3 = Data.Where(m => m.Mois.Month == 7).Average(d => d.Ensoleillement);
            Console.WriteLine("La somme des précipitations de Juillet {0}mm", pre);

            // Précipitations moyennes par année
            var années = Data.Select(d => d.Mois.Year).Distinct();
            foreach(var an in années)
            {

            var s5 = Data.Where(a => a.Mois.Year == an).Average(d => d.Précipitations);
                Console.WriteLine("La précipitation moyenne de l'année {0}: {1}mm", an, pre);

            }


        }
    }

    /// <summary>
    /// Classe contenant les données d'un mois de relevé météo
    /// </summary>
    public class DonnéesMois
    {
        public DateTime Mois { get; set; }
        public double TMin { get; set; }
        public double TMax { get; set; }
        public double Précipitations { get; set; }
        public double Ensoleillement { get; set; }
    }
}
