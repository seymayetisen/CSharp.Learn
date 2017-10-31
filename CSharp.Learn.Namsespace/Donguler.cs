using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Learn.Namsespace
{
    public class Donguler
    {
        public void For()
        {
            int length = 5;

            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(i.ToString());
            }

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(i.ToString());
            }

            for (int i = 5; i > 0; i--)
            {
                Console.WriteLine(i.ToString());
            }
        }

        public void While()
        {
            bool devamMi = true;

            int i = 0;

            while (devamMi)
            {
                i++;
                devamMi = i < 10;

                Console.WriteLine(i);
            }

            while (i <= 10 && i>0)
            {
                i--;

                Console.WriteLine(i);
            }

            i = 10;
            while (Aradami(i))
            {
                i--;

                Console.WriteLine(i);
            }
        }

        public bool Aradami(int i)
        {
            return i >= 0 && i <= 10;
        }
    }
}
