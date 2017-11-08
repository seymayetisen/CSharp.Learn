using KafeYonetim.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafeYonetim.Sunum.ConsoleApp
{
    class Program
    {
        private static Kafe kafe;

        static void Main(string[] args)
        {
            kafe = KafeInstanceOlustur();
            KafeyeUrunEkle(kafe);
            KafeyeCalisanEkle(kafe);
            KafeyeMasaEkle(kafe);

            ConsoleKeyInfo secim;
            do
            {
                MenuYazdir();

                secim = Console.ReadKey();

                switch (secim.KeyChar)
                {
                    case '1': MasayaGarsonCagir();break;
                    default:
                        break;
                }

            } while (secim.KeyChar != '0');

            Console.ReadKey();
        }

        public static void MasayaGarsonCagir()
        {
            Console.Write("Masa numarasını belirtin: ");
            int masaNo = int.Parse(Console.ReadLine());

            //kafe.Masalar[masaNo].GarsonCagir();
        }

        public static void MenuYazdir()
        {


            Console.WriteLine("Menü");
            Console.WriteLine("1. Masaya Garson Çağır.");
            Console.WriteLine("2. MAsadanGarsonaSiparisVer");
            Console.WriteLine("0. Uygulamayaı kapat");
            Console.WriteLine();
            Console.Write("Bir seçim yapınız: ");
        }

        public static Kafe KafeInstanceOlustur()
        {
            var kafe = new Kafe("Bizim Kafe", "09:00", "22:00");

            Console.WriteLine("Kafe");
            Console.WriteLine($"\tAd: {kafe.Ad}");
            Console.WriteLine($"\tDurum: {kafe.Durum}");

            return kafe;
        }
       
        public static void KafeyeUrunEkle(Kafe kafe)
        {
            kafe.Urunler[0] = new Urun("Çay", 9.00f, true);
            kafe.Urunler[1] = new Urun("Kahve", 12.00f, true);
            kafe.Urunler[2] = new Urun("Gazoz", 12.00f, true);
            kafe.Urunler[3] = new Urun("Tonbalıklı Sandviç", 16.00f, true);
            kafe.Urunler[4] = new Urun("Pekin Usulü Portakallı Ördek", 150.00f, true);
        }

        public static void KafeyeCalisanEkle(Kafe kafe)
        {

            kafe.Calisanlar[0] = new Garson("Ahmet", new DateTime(2017, 11, 8));
            kafe.Calisanlar[1] = new Garson("Mehmet", new DateTime(2017, 11, 8));
            kafe.Calisanlar[2] = new Asci("Berk", new DateTime(2017, 11, 8));
        }

        public static void KafeyeMasaEkle(Kafe kafe)
        {
            kafe.Masalar[0] = new Masa(1);
            kafe.Masalar[1] = new Masa(2);
            kafe.Masalar[2] = new Masa(3);
            kafe.Masalar[3] = new Masa(4);
        }
    }
}
