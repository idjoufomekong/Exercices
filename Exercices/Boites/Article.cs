using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boites
{
    public class Article: IComparable
    {
        public int Id { get; }
        public string Libellé { get; set; }
        public double Poids { get; set; }

        public Article(int id, string libellé, double poids)
        {
            Id = id;
            Libellé = libellé;
            Poids = poids;
        }
        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}g", Id, Libellé, Poids);
        }

        public int CompareTo(object obj)
        {
            if (obj is Article)
            {
                Article a = (Article)obj;
                return Poids.CompareTo(a.Poids);
            }
            else
                 throw new ArgumentException();
        }
    }
}
