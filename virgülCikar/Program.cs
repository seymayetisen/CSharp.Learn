using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace virgülCikar
{
    class Program
    {
        static void Main(string[] args)
        {
            string metin = Console.ReadLine();
            var ayir = metin.Split(new[] { '.', ',', ';', ' ', '?', '!' });
            int max = 0;

            for (int i = 0; i < ayir.Length; i++)
            {
                if (max<ayir[i].Length)
                {
                    max = ayir[i].Length;
                }
                
            }
            Console.WriteLine(max);

        }
    }
}
