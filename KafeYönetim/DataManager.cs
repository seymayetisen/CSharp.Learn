using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace KafeYönetim.Data
{
    public class DataManager
    {
        public void KafeBilgisiniYazdir()
        {
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-S3O5AOR;Initial Catalog=kafeYönetim;Integrated Security=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select top 1* from Kafe", baglanti);
            SqlDataReader result = komut.ExecuteReader();

            result.Read();
         

            Console.WriteLine($"Kafe adi:{result["Ad"]}" +
                $"\n durum:{result["durum"]}");
            baglanti.Close();


        }
        public void UrunListesiniYazdir()
        {
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-S3O5AOR;Initial Catalog=kafeYönetim;Integrated Security=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from urunler", baglanti);
            SqlDataReader result = komut.ExecuteReader();
            while (result.Read())
            {
                Console.WriteLine($"urun adi:{result["ad"]}" +
                 $"\n fiyat:{result["fiyat"]}");
               
            }
            baglanti.Close();

        }
        public void kafeIsminiGetir()
        {
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-S3O5AOR;Initial Catalog=kafeYönetim;Integrated Security=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select ad from Kafe", baglanti);
           
            object result = komut.ExecuteScalar();
            Console.WriteLine(result);

        }
        public void urunFiyatiniGetir()
        {
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-S3O5AOR;Initial Catalog=kafeYönetim;Integrated Security=True");
            baglanti.Open();
            Console.WriteLine("urunadi giriniz:");
            string urunAdi = Console.ReadLine();
            SqlCommand komut = new SqlCommand("select fiyat from urunler where ad=@ad", baglanti);
            komut.Parameters.AddWithValue("@ad", urunAdi);
            object result = (double)komut.ExecuteScalar();
            Console.WriteLine($"{urunAdi} fiyat:{result}");
            baglanti.Close();


        }
        public void yuksek()
        {
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-S3O5AOR;Initial Catalog=kafeYönetim;Integrated Security=True");
            baglanti.Open();

            Console.WriteLine("esik fiyet giriniz:");
            int esik =int.Parse( Console.ReadLine());
            SqlCommand komut = new SqlCommand("select ad from urunler where fiyat>@esik", baglanti);
            komut.Parameters.AddWithValue("@esik", esik);
            SqlDataReader result = komut.ExecuteReader();
            Console.WriteLine($"fiyati {esik} degerinin uzerinde olan urunler");
            while (result.Read())
            {
                Console.WriteLine($" adi:{result["ad"]}");
            }
            
            baglanti.Close();
        }
        public void urunEkleme()
        {
            Console.Clear();
            Console.WriteLine("urun adi giriniz:");
            string ad = Console.ReadLine();
            Console.WriteLine("urun fiyati giriniz");
            double fiyat = double.Parse(Console.ReadLine());
            Console.WriteLine("stok var mı (0 veya 1):");
            int stok = int.Parse(Console.ReadLine());

            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-S3O5AOR;Initial Catalog=kafeYönetim;Integrated Security=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into urunler values(@ad,@fiyat,@stok)", baglanti);
            komut.Parameters.AddWithValue("@ad", ad);
            komut.Parameters.AddWithValue("@fiyat", fiyat);

            komut.Parameters.AddWithValue("@stok", stok);
            komut.ExecuteNonQuery();
            Console.WriteLine("urun eklendi...");
            //SqlDataReader oku = komut.ExecuteReader();
            //while (oku.Read())
            //{
            //    Console.WriteLine($" urun adi:{oku["ad"]}");
            //}
            baglanti.Close();



        }
    }
}
