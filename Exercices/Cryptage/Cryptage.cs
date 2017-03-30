using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptage
{
    public static class Cryptage
    {
        public static bool ChargerClé()
        {
            StreamReader inputFile = null;
            try
            {
                inputFile = new StreamReader(@"D:\Exercices\Exercices\Cryptage\cle.txt",true);

            }
            catch (Exception)
            {

                throw;
            }
            return true;
        }
    }
}
