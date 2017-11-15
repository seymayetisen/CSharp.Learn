﻿using KafeYonetim.Lib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafeYonetim.Data
{
    public class DataManager
    {
        private static string connStr = "Data Source=DESKTOP-SON6OA8;Initial Catalog=kafeYönetim;Integrated Security=True";

        private static SqlConnection CreateConnection()
        {
            var connection = new SqlConnection(connStr);
            connection.Open();

            return connection;
        }

        public static void KafeBilgisiniYazdir()
        {

            using (var connection = CreateConnection())
            {
                var command = new SqlCommand("SELECT TOP 1 * FROM KAfe ", connection);

                using (var result = command.ExecuteReader())
                {
                    result.Read();
                    Console.WriteLine($"Kafe Adı: {result["Ad"]}");
                    Console.WriteLine($"Kafe Durumu: {result["Durum"]}");
                }
            }

            Console.ReadLine();
        }

        public static void KafeAdiniGetir()
        {
            using (var connection = CreateConnection())
            {

                var command = new SqlCommand("SELECT TOP 1 Ad FROM KAfe ", connection);
                var result = (string)command.ExecuteScalar();

                Console.WriteLine($"Kafe Adı: {result}");

            }

            Console.ReadLine();

        }

        public static void UrunFiyatiniGetir()
        {
            using (var connection = CreateConnection())
            {

                Console.WriteLine("Ürün adı yazınız: ");
                string urunAdi = Console.ReadLine();

                //var command = new SqlCommand($"SELECT Fiyat FROM Urunler WHERE Ad = '{urunAdi}' ", connection);

                var command = new SqlCommand($"SELECT Fiyat FROM Urunler WHERE Ad = @Ad", connection);

                command.Parameters.AddWithValue("@Ad", urunAdi);

                var result = (double)command.ExecuteScalar();

                Console.WriteLine($"{urunAdi} ürününün fiyatı: {result}");

            }

            Console.ReadLine();

        }

        public static List<Urun> UrunListesiniGetir()
        {
            Console.Clear();

            using (var connection = CreateConnection())
            {

                var command = new SqlCommand("SELECT * FROM Urunler", connection);

                return UrunListesiHazirla(command.ExecuteReader());
            }
        }

        public static List<Urun> DegerdenYuksekFiyatliUrunleriGetir(double esikDeger)
        {
            using (var connection = CreateConnection())
            {
                var command = new SqlCommand("SELECT * FROM Urunler WHERE fiyat > @deger", connection);
                command.Parameters.AddWithValue("@deger", esikDeger);


                return UrunListesiHazirla(command.ExecuteReader());
            }
        }

        public static int masaSayisiniGetir()
        {
            using (SqlConnection connection=CreateConnection())
            {
                int i = 0;
                SqlCommand command = new SqlCommand("select * from Masa", connection);
                using (SqlDataReader result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        i++;
                    }
                }
                return i;
            }

        }

        public static List<Calisann> CalisanlarListesiniGetir()
        {
            using (SqlConnection connection=CreateConnection())
            {
                List<Calisann> calisanlar = new List<Calisann>();
                SqlCommand command = new SqlCommand("select * from Calisan", connection);
                using (SqlDataReader result=command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        Calisann cal = new Calisann(result["Isim"].ToString(), result["Gorev"].ToString());
                        calisanlar.Add(cal);
                    }
                    
                }

                return calisanlar;
            }
        }

        public static bool CalisanEkle(string Isim, DateTime IseGirisTarihi, bool MesaideMi, int KafeId, string Durum,string Gorev)
        {
            using (SqlConnection connection = CreateConnection())
            {
                SqlCommand command = new SqlCommand("INSERT INTO Calisan (Isim, IseGirisTarihi, MesaideMi,KafeId,Durum,Gorev) VALUES (@Isim, @IseGirisTarihi, @MesaideMi,@KafeId,@Durum,@Gorev)", connection);
                command.Parameters.AddWithValue("@Isim", Isim);
                command.Parameters.AddWithValue("@IseGirisTarihi", IseGirisTarihi);
                command.Parameters.AddWithValue("@MesaideMi", MesaideMi);
                command.Parameters.AddWithValue("@KafeId", KafeId);
                command.Parameters.AddWithValue("@Durum", Durum);
                command.Parameters.AddWithValue("@Gorev", Gorev);

                var result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    return true;
                }

                return false;
            }
        }

        public static bool MasaEkle(int masaNo, int kafeId, string masaDurum)
        {
            using (SqlConnection connection =CreateConnection())
            {
                SqlCommand command = new SqlCommand("INSERT INTO Masa (MasaNo, KafeId, Durum) VALUES (@MasaNo, @KafeId, @Durum)", connection);
                command.Parameters.AddWithValue("@MasaNo", masaNo);
                command.Parameters.AddWithValue("@KafeId", kafeId);
                command.Parameters.AddWithValue("@Durum", masaDurum);
                var result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    return true;
                }

                return false;
            }
        }

        public static List<Urun> StokDurumuFalseOlanlarinListesiniGetir()
        {
            using (var connection = CreateConnection())
            {
                var command = new SqlCommand("SELECT * FROM Urunler WHERE stokdavarmı='false'", connection);
                

                return UrunListesiHazirla(command.ExecuteReader());
            }
        }
        public static List<Urun> UrunListesiHazirla(SqlDataReader result)
        {
            var urunListesi = new List<Urun>();

            using (result)
            {
                while (result.Read())
                {
                    Urun urun = new Urun((int)result["id"], result["ad"].ToString()
                            , (double)result["fiyat"]
                            , (bool)result["stokdavarmı"]);
                    urunListesi.Add(urun);
                }
            }
            return urunListesi;
        }

        public static void KapatilmamimsBaglanti()
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    Console.Write("Bir değer giriniz: ");

                    var deger = Console.ReadLine();
                    var command = new SqlCommand("SELECT * FROM Urunler WHERE fiyat > @deger", connection);
                    command.Parameters.AddWithValue("@deger", double.Parse(deger));

                    using (var result = command.ExecuteReader())
                    {
                        while (result.Read())
                        {
                            Console.WriteLine($"Ad: {result["Ad"]}");
                        }

                        Console.ReadLine();
                    }


                    var command2 = new SqlCommand("SELECT * FROM Urunler", connection);
                    //command.Parameters.AddWithValue("@deger", double.Parse(deger));

                    using (var result2 = command2.ExecuteReader())
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("HATA!");
                Console.WriteLine($"{ex.Message}");
            }

            Console.ReadLine();
        }

        public static bool UrunGir(string ad, double fiyat, bool stoktaVarMi)
        {
            using (var connection = CreateConnection())
            {
                var command = new SqlCommand("INSERT INTO Urunler (ad, fiyat, stoktavarmi) VALUES (@ad, @fiyat, @stoktaVarMi)", connection);
                command.Parameters.AddWithValue("@ad", ad);
                command.Parameters.AddWithValue("@fiyat", fiyat);
                command.Parameters.AddWithValue("@stoktaVarMi", stoktaVarMi);

                var result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    return true;
                }

                return false;
            }
        }
        

        //public static void UrunGir()
        //{
        //    using (var connection = CreateConnection())
        //    {

        //        Console.Write("Ürün Adını giriniz: ");
        //        var ad = (isWindows)? textBox1.Text : Console.ReadLine();

        //        Console.Write("Ürün fiyatını giriniz: ");
        //        var fiyat = double.Parse(Console.ReadLine());

        //        Console.Write("Ürün stokta var mı? (e/h): ");
        //        var stok = (Console.ReadLine() == "e") ? true : false;

        //        var command = new SqlCommand("INSERT INTO Urunler (ad, fiyat, stoktavarmi) VALUES (@ad, @fiyat, @stoktaVarMi)", connection);
        //        command.Parameters.AddWithValue("@ad", ad);
        //        command.Parameters.AddWithValue("@fiyat", fiyat);
        //        command.Parameters.AddWithValue("@stoktaVarMi", stok);

        //        var result = command.ExecuteNonQuery();

        //        if (result > 0)
        //        {
        //            Console.WriteLine("Kayıt eklendi.");
        //        }

        //    }

        //    Console.ReadLine();
        //}

        public static int SecilenUrunleriSil(string idList)
        {
            using (var connection = CreateConnection())
            {
                var command = new SqlCommand($"DELETE FROM Urunler WHERE id IN ({idList}) ", connection);

               return command.ExecuteNonQuery();
            }
            
        }
    }
    public class Calisann
    {
        public Calisann(string isim, string gorev)
        {
            Isim = isim;
            Gorev = gorev;

        }
        public string Gorev { get; set; }
        public string Isim { get; private set; }
    }
}
