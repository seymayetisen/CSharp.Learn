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

            //dataManager.UrunListesiniYazdir();

            //dataManager.KafeAdiniGetir();

            //DataManager.UrunFiyatiniGetir();

            //dataManager.DegerdenYuksekFiyatliUrunleriGetir();

            //dataManager.UrunGir();

            // dataManager.KapatilmamimsBaglanti();

            //dataManager.SecilenUrunleriSil();

            //UrunGir();

            //DegerdenYuksekFiyatliUrunleriGetir();
            do
            {
                Console.Clear();
                Console.WriteLine("DegerdenYuksekFiyatliUrunleriGetir   1");
                Console.WriteLine("UrunListesiniYazdir                  2");
                Console.WriteLine("stokda olmatan ürünleri getir        3");
                Console.WriteLine("urunleri sil                         4");
                Console.WriteLine("urun gir                             5");
                Console.WriteLine("masa ekle                            6");
                Console.WriteLine("masa sayısı                          7");
                Console.WriteLine("garson ekle                          8");
                Console.WriteLine("asci ekle                            9");
                Console.WriteLine("calisanlar listesini getir           10");





                Console.WriteLine();
                Console.WriteLine("cıkmak için                          h");
                //


                string secim = Console.ReadLine();
                switch (secim)
                {
                    case "1":
                        BütünUrunlerListesiniYazdir();
                        break;
                    case "2":
                        DegerdenYuksekFiyatliUrunleriGetir();
                        break;
                    case "3":
                        StokDurumuFalseOlanlarinListesiniGetir();
                        break;
                    case "4":
                        SecilenUrunleriSil();
                        break;
                    case "5":
                        UrunGir();
                        break;
                    case "6":
                        MasaEkle();
                        break;
                    case "7":
                        masaSayisiniGetir();
                        break;
                    case "8":
                        CalisanEkle("garson");
                        break;
                    case "9":
                        CalisanEkle("garson");
                        break;
                    case "10":
                        CalisanlarListesiniGetir();
                        break;
                    case "h":
                        return;
                    default: break;



                }
            } while (true);
            

        }

        private static void CalisanlarListesiniGetir()
        {
            List<Calisann> calisanlar = DataManager.CalisanlarListesiniGetir();
            Console.Clear();
            Console.WriteLine($"{"Isim".PadRight(14)} {"Gorev".PadRight(19)}");
            Console.WriteLine("".PadRight(60, '='));
            foreach (var calisan in calisanlar)
            {
                Console.WriteLine();
                Console.Write($"{calisan.Isim}".PadRight(15));
                Console.Write($"{calisan.Gorev}".PadRight(20));
                
            }
            Console.ReadLine();
        }

        private static void CalisanEkle(string Gorev)
        {
            Console.Clear();
            Console.WriteLine("garsonun ismini giriniz : ");
            string Isim = Console.ReadLine();
            Console.WriteLine("garsonun işe giris tarihi : ");
            DateTime IseGirisTarihi = DateTime.Parse(Console.ReadLine());
            Console.Write("Garson mesaide mi (E/H):");
            bool MesaideMi = Console.ReadLine().ToUpper() == "E";
            int KafeId = 1;
            Console.WriteLine("garson durum (Uygun/Masada/MusaitDegil)");
            string Durum = Console.ReadLine();

            if (DataManager.CalisanEkle(Isim, IseGirisTarihi, MesaideMi, KafeId, Durum, Gorev))
            {
                Console.WriteLine("kayıt eklendi...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("kayıt eklenemedi...");
                Console.ReadKey();
            }
            

            
            


        }

        private static void masaSayisiniGetir()
        {
            Console.Clear();
            int sayisi=DataManager.masaSayisiniGetir();
            Console.WriteLine($"kafede toplam {sayisi} tane masa var...");
            Console.ReadLine();
        }

        private static void MasaEkle()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("masa no giriniz : ");
                int MasaNo = int.Parse(Console.ReadLine());
                Console.WriteLine("Masa durumunu giriniz (Bos/Dolu) : ");
                string MasaDurum = Console.ReadLine();
                int KafeId = 1;
                if (DataManager.MasaEkle(MasaNo,KafeId,MasaDurum))
                {
                    Console.WriteLine("kayıt eklendi...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("kayıt eklenemedi...");
                    Console.ReadKey();
                }
            }
            catch (Exception)
            {
                
                Console.WriteLine("aynı masa no bulunmakta lütfen farklı bir deger giriniz...");
                Console.ReadKey();
            }
            
        }

        private static void SecilenUrunleriSil()
        {
            BütünUrunlerListesiniYazdir();
            Console.WriteLine("Silmek istediğiniz ürünlerin Id'lerini yazınız: ");
            
            string idList = Console.ReadLine();
            int a=DataManager.SecilenUrunleriSil(idList);
            Console.WriteLine($"silinen urun adedi {a}");
            Console.ReadLine();
        }

        private static void BütünUrunlerListesiniYazdir()
        {
            
            List<Lib.Urun> liste = DataManager.UrunListesiniGetir();
           
            UrunListesiYazdir(liste, "bütün ürünler...",true);
            Console.ReadLine();

           
        }

        private static void DegerdenYuksekFiyatliUrunleriGetir()
        {

            Console.Clear();
            Console.Write("Eşik Değeri giriniz: ");
            var doubleEsikDeger = double.Parse(Console.ReadLine());

            var liste = DataManager.DegerdenYuksekFiyatliUrunleriGetir(doubleEsikDeger);
            
            UrunListesiYazdir(liste, $"{doubleEsikDeger} den yüksek urunler...",true);



            Console.ReadLine();

        }
        private static void StokDurumuFalseOlanlarinListesiniGetir()
        {
            List<Urun> liste = DataManager.StokDurumuFalseOlanlarinListesiniGetir();
            UrunListesiYazdir(liste, "stokda olmayan ürünler", true);
            Console.ReadLine();
        }
        private static void UrunListesiYazdir(List<Urun> liste,string baslik,bool ekranTemizlensinMi)
        {
            if (ekranTemizlensinMi)
            {
                Console.Clear();
            }
            if (!(string.IsNullOrWhiteSpace(baslik)))//baslik bos değilse
            {
                Console.WriteLine(baslik);
            }
           
            Console.WriteLine($"{"ID".PadRight(4)} {"Isim".PadRight(19)} {"Fiyat".PadRight(19)} Stok Durumu");
            Console.WriteLine("".PadRight(60, '='));
            foreach (var urun in liste)
            {
                Console.WriteLine();
                Console.Write($"{urun.Id}".PadRight(5));
                Console.Write($"{urun.Ad}".PadRight(20));
                Console.Write($"{urun.Fiyat}".PadRight(20));
                Console.Write($"{urun.StoktaVarmi}".PadRight(7));
            }
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

            if(DataManager.UrunGir(urunAdi, fiyat, stokDurumu))
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
