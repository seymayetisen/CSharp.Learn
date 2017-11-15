using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static
{
    public class StatikOlmayanClass
    {
        static int i = 0;
        int j = 0;

        public StatikOlmayanClass()
        {
            i++;
            j++;
        }

        public void MerhabaDe()
        {
            Console.WriteLine("Merhaba");
        }

        public int iDegiskeniniDegeriniGetir()
        {
            return i;
        }

        public int iDegiskeniniDegeriniArttir()
        {
            return ++i;
        }

        public int jDegiskeniniDegeriniGetir()
        {          
            return j;
        }         
        public int jDegiskeniniDegeriniArttir()
        {
            return ++j;
        }
    }
}
