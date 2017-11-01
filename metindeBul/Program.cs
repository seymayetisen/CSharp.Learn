using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metindeBul
{
    class Program
    {
       
        static void Main(string[] args)
        {
            string metin = Console.ReadLine();
            var ayir = metin.Split(new[] { '.', ',', ';', ' ','?','!' });
            int say=0;
            
            for (int i = 0; i < ayir.Length; i++)
            {

                for (int j = 0; j < ayir.Length; j++)
                {
                    if (ayir[i]==ayir[j])
                    {
                        say++;
                        
                    }
                    
                }
                
                    Console.WriteLine("{0} kelimesi {1} tane var", ayir[i], say);
                    say = 0;
                
                
                
            }
        }
    }
}
