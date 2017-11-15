using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Örnek 1");
            var statikOlmayanClass = new StatikOlmayanClass();
            statikOlmayanClass.MerhabaDe();
            Console.WriteLine(statikOlmayanClass.iDegiskeniniDegeriniGetir());
            Console.WriteLine(statikOlmayanClass.jDegiskeniniDegeriniGetir());
            statikOlmayanClass.jDegiskeniniDegeriniArttir();

            statikOlmayanClass.iDegiskeniniDegeriniArttir();
            Console.WriteLine(statikOlmayanClass.jDegiskeniniDegeriniGetir());

            Console.WriteLine("Örnek 2");
            var statikOlmayanClass2 = new StatikOlmayanClass();
            statikOlmayanClass2.MerhabaDe();
            Console.WriteLine(statikOlmayanClass2.iDegiskeniniDegeriniGetir());
            Console.WriteLine(statikOlmayanClass2.jDegiskeniniDegeriniGetir());

            statikOlmayanClass2.iDegiskeniniDegeriniArttir();

            Console.WriteLine("Örnek 3");
            var statikOlmayanClass3 = new StatikOlmayanClass();
            statikOlmayanClass3.MerhabaDe();
            Console.WriteLine(statikOlmayanClass3.iDegiskeniniDegeriniGetir());
            Console.WriteLine(statikOlmayanClass3.jDegiskeniniDegeriniGetir());

            int a = 0;


            Console.ReadLine();
        }
    }
}
