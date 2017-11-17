using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tupple
{
    class Program
    {
        static void Main(string[] args)
        {
            var tuple1 = new Tuple<int>(10);
            Console.WriteLine($"Tuple1 değeri: {tuple1.Item1}");

            var tuple2 = new Tuple<string>("A10");
            Console.WriteLine($"Tuple2 değeri: {tuple2.Item1}");

            var tuple3 = new Tuple<string, bool, int>("A10", true, 5);
            Console.WriteLine($"Tuple3 değerleri => string {tuple3.Item1}, bool: {tuple3.Item2}, int: {tuple3.Item3}");

var tuple4 = new Tuple<Tuple<int,string>, Tuple<int, bool>>(new Tuple<int, string>(0,"Tuple içerdeki 1"), new Tuple<int, bool>(1, false));
            Console.WriteLine($"Tuple4 değerleri => Tuple1 {tuple4.Item1.Item1},{tuple4.Item1.Item2} ; Tuple2 {tuple4.Item2.Item1},{tuple4.Item2.Item2}");

            Console.ReadLine();
        }
    }
}
