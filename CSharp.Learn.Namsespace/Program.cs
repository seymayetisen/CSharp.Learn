﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Learn.Namsespace
{
    class Program
    {
        static void Main(string[] args)
        {
            byte a = 10;
            //a = 256;
            //a = "a";

            int x = a;

            //a = x;

            float y = 5.2f;
            //x =y;
            y = x;

            string s = "abscd";
            //char[] cs = new[] { 'a', 'b', 's', 'c', 'd' };
            
            char c = 'c';

            c = s[0];

            var sa = new[] { 1, 2, 3 };
            foreach (var item in sa)
            {
                
                Console.WriteLine(item);
            }
        }
    }
}
