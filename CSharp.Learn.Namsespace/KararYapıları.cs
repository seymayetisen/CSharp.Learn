using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Learn.Namsespace
{
    public class KararYapıları
    {
        public void If() {
            int a = 5;
            int b = 3;
            int c = 12;

            //////////////////////////////////
            if(a > c)
            {
                Console.WriteLine("a c'den büyüktür");
            }

            //////////////////////////////////
            if (a > b)
            {
                Console.WriteLine("a b'den büyüktür");
            }
            else
            {
                Console.WriteLine("b a'dan büyüktür");
            }

            //////////////////////////////////
            if (a < b)
            {
                Console.WriteLine("a b'den büyüktür");
            }
            else if (a < c)
            {
                Console.WriteLine("a c'den büyüktür");
            }

            //////////////////////////////////
            if (a < b)
            {
                Console.WriteLine("a b'den büyüktür");
            }
            else if (a > c)
            {
                Console.WriteLine("a c'den büyüktür");
            }
            else if (b < c)
            {
                Console.WriteLine("a c'den büyüktür");
            }
            else
            {
                Console.WriteLine("en büyük benim");
            }
        }

        public void Switch()
        {
            int x = 5;

            switch (x)
            {
                case 1: Console.WriteLine("1");break;//
                case 3: Console.WriteLine("3");break;//
                case 5: Console.WriteLine("5");break;//
                //case "5": Console.WriteLine("5");break;//HATA
                default:
                    break;
            }
        }
    }
}
