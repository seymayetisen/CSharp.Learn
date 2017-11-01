using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hesapMak
{
    class Program
    {
        static void Main(string[] args)
        {
            
            char devamMi = 'e';
            do
            {
                Console.WriteLine("islem yaziniz...");
                string islem = Console.ReadLine();
                var sonuc = islem.Split(new[] { '/', '+', '*', '-' });
                char isaret = '-';

                for (int i = 0; i < islem.Length; i++)
                {
                    if (islem[i] == '/' || islem[i] == '+' || islem[i] == '-' || islem[i] == '*')
                    {
                        isaret = islem[i];
                    }
                }
                if (isaret=='+')
                {
                    Console.WriteLine(int.Parse(sonuc[0]) + int.Parse(sonuc[1]));
                }
                else if(isaret == '-')
                {
                    Console.WriteLine(int.Parse(sonuc[0])-int.Parse(sonuc[1]));
                }
                else if (isaret == '/')
                {
                    Console.WriteLine(int.Parse(sonuc[0]) / int.Parse(sonuc[1]));
                }
                else if (isaret == '*')
                {
                    Console.WriteLine(int.Parse(sonuc[0]) * int.Parse(sonuc[1]));
                }


                Console.WriteLine("devam etmek istiyormusunuz:");
                devamMi = char.Parse(Console.ReadLine());
            } while (devamMi=='e'||devamMi=='E');
            
        }
    }
}
