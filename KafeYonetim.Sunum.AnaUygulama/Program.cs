using KafeYonetim.Data;
using KafeYonetim.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafeYonetim.Sunum.AnaUygulama
{
    class Program
    {
        static void Main(string[] args)
        {

            //DataManager.KafeBilgisiniYazdir();

            //UrunListesiniYazdir();

            //dataManager.KafeAdiniGetir();

            //DataManager.UrunFiyatiniGetir();

            //dataManager.DegerdenYuksekFiyatliUrunleriGetir();


            // dataManager.KapatilmamimsBaglanti();

            //dataManager.SecilenUrunleriSil();

            //UrunGir();

            //DegerdenYuksekFiyatliUrunleriGetir();

            do
            {
                Console.Clear();

                Console.WriteLine("1. Ürün Listesini Getir");
                Console.WriteLine("2. Eşik Değerden Yüksek Fiyatlı Ürünlerin Listesini Getir");
                Console.WriteLine("3. Ürün Ekle");
                Console.WriteLine();
                Console.Write("Bir seçim yapınız (çıkmak için H harfine basınız): ");
                var secim = Console.ReadLine();

                switch (secim)
                {
                    case "1": ButunUrunlerListesiniYazdir(); break;
                    case "2": DegerdenYuksekFiyatliUrunleriGetir(); break;
                    case "3": UrunGir(); break;
                    case "h": return;
                    default:
                        break;
                }

            } while (true);

        }

        private static void UrunListesiYazdir(List<Urun> urunler, string baslik, bool ekranTemizlensinMi)
        {

            if (ekranTemizlensinMi)
            {
                Console.Clear();
            }

            if (!string.IsNullOrWhiteSpace(baslik))
            {
                Console.WriteLine(baslik);
            }

            Console.WriteLine($"{"ID".PadRight(4)} {"Isim".PadRight(19)} {"Fiyat".PadRight(19)} Stok Durumu");
            Console.WriteLine("".PadRight(60, '='));

            foreach (var urun in urunler)
            {
                Console.WriteLine();
                Console.Write($"{urun.Id.ToString().PadRight(5)}");
                Console.Write($"{urun.Ad.PadRight(20)}");
                Console.Write($"{urun.Fiyat.ToString().PadRight(20)}");
                Console.Write($"{urun.StoktaVarmi}");
            }
        }

        private static void ButunUrunlerListesiniYazdir()
        {
            var urunler = DataManager.UrunListesiniGetir();
            UrunListesiYazdir(urunler, "Tüm Ürünler", true);
            Console.ReadLine();
        }

        private static void DegerdenYuksekFiyatliUrunleriGetir()
        {
            Console.Clear();
            Console.Write("Eşik Değeri giriniz: ");

            var doubleEsikDeger = double.Parse(Console.ReadLine());
            var liste = DataManager.DegerdenYuksekFiyatliUrunleriGetir(doubleEsikDeger);
            string baslik = $"Fiyatı {doubleEsikDeger} TL'den Yüksek Ürünler";

            UrunListesiYazdir(liste, baslik, true);
            Console.ReadLine();
        }

        private static void UrunGir()
        {
            Console.Clear();

            Console.Write("Ürün Adı:");
            string urunAdi = Console.ReadLine();

            Console.Write("Fiyat:");
            double fiyat = double.Parse(Console.ReadLine());

            Console.Write("Stokta Var mı (E/H):");
            bool stokDurumu = Console.ReadLine().ToUpper() == "E";

            if (DataManager.UrunGir(urunAdi, fiyat, stokDurumu))
            {
                Console.WriteLine("Ürün başarıyla eklendi.");
            }
            else
            {
                Console.WriteLine("Ürün eklenirken bir hata oluştu...");
            }

            Console.ReadLine();
        }
    }
}
