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
            StaticOlmayanClass a = new StaticOlmayanClass();
            Console.WriteLine(a.getir());
            StaticOlmayanClass b = new StaticOlmayanClass();
            Console.WriteLine(b.getir());

        }
    }
}
