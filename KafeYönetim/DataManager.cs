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
       
        private static SqlConnection createConnection()
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-S3O5AOR;Initial Catalog=kafeYönetim;Integrated Security=True");
            connection.Open();
            return connection;
        }
        public static void KafeBilgisiniYazdir()// with using
        {
            
            using (SqlConnection baglant = createConnection())
            {
                SqlCommand komut = new SqlCommand("select top 1* from Kafe", baglant);
                using (SqlDataReader result = komut.ExecuteReader())
                {
                    
                    result.Read();
                    
                    Console.WriteLine($"Kafe adi:{result["Ad"]}" +
                        $"\n durum:{result["durum"]}");
                }
            }
        }
        public static void UrunListesiniYazdir()
        {
            using (SqlConnection baglanti = createConnection())
            {
                SqlCommand komut = new SqlCommand("select * from urunler", baglanti);
                using (SqlDataReader oku = komut.ExecuteReader())
                {
                    while (oku.Read())
                    {
                        Console.Write($"{oku["id"].ToString().PadRight(20)}");
                        Console.Write($"{oku["ad"].ToString().PadRight(20)}");
                        Console.Write($"{oku["fiyat"].ToString().PadRight(20)}");
                        Console.Write($"{oku["stokdavarmı"]}");
                        Console.WriteLine();
                    }
                }
            }
        }
        public static void kafeIsminiGetir()
        {
            using (SqlConnection baglanti = createConnection())
            {
                SqlCommand komut = new SqlCommand("select ad from Kafe", baglanti);
                object result = komut.ExecuteScalar();
                    Console.WriteLine(result);
                
            }

        }
        public static void urunFiyatiniGetir()
        {
            using (SqlConnection baglanti = createConnection())
            {
                Console.WriteLine("urunadi giriniz:");
                string urunAdi = Console.ReadLine();
                SqlCommand komut = new SqlCommand("select fiyat from urunler where ad=@ad", baglanti);
                komut.Parameters.AddWithValue("@ad", urunAdi);
                object result = (double)komut.ExecuteScalar();
                Console.WriteLine($"{urunAdi} fiyat:{result}");
            }


        }
        public static void yuksek()
        {
            using (SqlConnection baglanti = createConnection())
            {
                Console.WriteLine("esik fiyet giriniz:");
                int esik = int.Parse(Console.ReadLine());
                SqlCommand komut = new SqlCommand("select ad from urunler where fiyat>@esik", baglanti);
                komut.Parameters.AddWithValue("@esik", esik);
                using (SqlDataReader result = komut.ExecuteReader())
                {
                    Console.WriteLine($"fiyati {esik} degerinin uzerinde olan urunler");
                    while (result.Read())
                    {
                        Console.WriteLine($" adi:{result["ad"]}");
                    }
                }
            }
        }
        public static void urunEkleme()
        {
            Console.Clear();
            Console.WriteLine("urun adi giriniz:");
            string ad = Console.ReadLine();
            Console.WriteLine("urun fiyati giriniz");
            double fiyat = double.Parse(Console.ReadLine());
            Console.WriteLine("stok var mı (0 veya 1):");
            int stok = int.Parse(Console.ReadLine());

            using (SqlConnection baglanti = createConnection())
            {


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
            }



        }
        public static void urunSilme()
        {
            UrunListesiniYazdir();
            Console.WriteLine("silmek istediğiniz id leri giriniz");
            string silinecekler = Console.ReadLine();
            //string[] id = silinecekler.Split(',');
            //baglanti.Open();
            //for (int i = 0; i < id.Length; i++)
            //{
            //    SqlCommand deleteCom = new SqlCommand("delete from urunler where id=@id",baglanti);
            //    deleteCom.Parameters.AddWithValue("@id", int.Parse(id[i]));
            //    deleteCom.ExecuteNonQuery();
            //}
            using (SqlConnection baglanti=createConnection())
            {
                SqlCommand deleteCom = new SqlCommand($"delete from urunler where id in ({silinecekler})", baglanti);

                deleteCom.ExecuteNonQuery();
            }
            UrunListesiniYazdir();
        }
        

    }
}
