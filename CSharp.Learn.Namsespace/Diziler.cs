using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Learn.Namsespace
{
    public class Diziler
    {

        public void Dizi()
        {
            //Dizi tanımlanırken tip belirtilmesi zorunluıdur
            //Tip belirlendikten sonra diziye sadece o tipte elemanlar atanabilir
            //Dizi oluşturulurken kaç eleman alacağı belirtilmek zorundadır
            //Dizinin eleman sayısı belirlendikten sonra değiştirilemez
            int[] dizi = new int[5];

            var dizi2 = new bool[10];

            var dizi3 = new bool[] { true, true, false };

            var dizi4 = dizi3;

            dizi[0] = 0;
            dizi[1] = 1;
            dizi[2] = 4;
            dizi[3] = 9;
            dizi[4] = 16;

            int a = dizi[0];

            int[,] cokBoyutluDizi = new int[3, 5];


        }
    }
}
