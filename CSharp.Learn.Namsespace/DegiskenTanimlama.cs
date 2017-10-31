using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Learn.Namsespace
{
    public class DegiskenTanimlama
    {
        public void Tanimlamalar()
        {
            //Değişkenler tanımlandıkları satırdan önce kullanılamazlar
            //x++;//HATA

            //Değişken tanımlama.
            //Variable declaration
            //Açıktan (explicit) değişken tanımlama
            // Değişken tipi değişkenin tanımlanması sırasında belirlenir;
            int x;

            //Değişken tanımlanmış olsa bile bir değer atamadan hiç bir şekilde kullanılamaz
            //x++;//HATA
            //int y = x;//HATA
            //Console.WriteLine(x)//HATA

            //Değer atama
            //Value assign
            x = 5;

            //Değer atama işlemi yapıldıktan sonra istediğimiz gibi değişkeni kullanabiliyoruz.
            x++;

            //Değişken tanımlama ve değer atama işlemleri aynı anda yapılabilir.
            int b = 5;

            //Değişken tanımlanırken daha önceden tanımlanmış ve içinde bir değer olan değişkeni atama işleminde kullanabiliyoruz.
            int c = b;

            //değişken tipi belirlendikten sonra o değişkenin tipi değiştirilemez
            // başka bir tipte bir değer alamaz
            //c = "a";//HATA
            //c = false;//HATA


            //var keyword ü ile değişken tanımlama
            // Değişkenin tipi atanan değer ile belirlenir
            //Bu örnekte d değişkenine atanan değer int olduğu için d artık int tipinde bir değişkendir.
            var d = 5;

            //var ile tanımlana bir değişken tanımlama sırasında mutlaka bir değer almalı
            //var e;//HATA


            //var ile tanımlanmış değişkenler tipleri atama sırasında belirlendikten sonra bir daha değiştirilemez ve farklı bir tipte değer alamaz

            //d = "g";//HATA
            //d = true;//HATA

            //var ile tanımlamada değer yerine bir değişken de kullanılabilir.
            var g = d;
        }


    }
}
