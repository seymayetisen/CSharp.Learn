using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isimgirme
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("isim giriniz");
                string isim = Console.ReadLine();
           
            do
            {

                if (isim == isim.Trim())
                {
                    Console.WriteLine(isim);
                    break;
                }
                else if (isim.Trim().Length != isim.TrimStart().Length || isim.Trim().Length != isim.TrimEnd().Length)
                {
                    Console.WriteLine("yanlis karakter girdiniz tekrar giriniz...");
                    Console.WriteLine("isim giriniz");
                    isim = Console.ReadLine();

                }
            } while (isim != isim.Trim());
            


        }
    }
}
