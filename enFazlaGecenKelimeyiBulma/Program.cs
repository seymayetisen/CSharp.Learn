using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enFazlaGecenKelimeyiBulma
{
    class Program
    {
        static void Main(string[] args)
        {
            string metin = Console.ReadLine();
            var ayir = metin.Split(new[] { '.', ',', ';', ' ', '?', '!' });
            string[] bulunanlar = new string[metin.Length];
            int say = 0;
            int max = 0;
            int al = 0;

            for (int i = 0; i < ayir.Length; i++)
            {

                for (int h = 0; h < bulunanlar.Length; h++)
                {
                    if (ayir[i] == bulunanlar[h])
                    {
                        break;
                    }

                }
                for (int j = 0; j < ayir.Length; j++)
                {

                    if (ayir[i] == ayir[j])
                    {
                        say++;

                    }

                }


                Console.WriteLine("{0} kelimesi {1} tane var", ayir[i], say);
                al = say;
                say = 0;

                bulunanlar[i] = ayir[i];

            }
            if (max<al)
            {
                max = al;
            }
            Console.WriteLine(max);
        }
        }
    }

