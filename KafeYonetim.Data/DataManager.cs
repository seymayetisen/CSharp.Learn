using KafeYonetim.Lib;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace KafeYonetim.Data
{
    public class DataManager
    {
        private static string connStr = "Data Source=DESKTOP-S3O5AOR;Initial Catalog=KafeYonetim;Integrated Security=True";

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
            using (var connection = CreateConnection())
            {
                var command = new SqlCommand("SELECT * FROM Urunler", connection);

                using (var result = command.ExecuteReader())
                {
                    var urunler = new List<Urun>();

                    while (result.Read())
                    {
                        var urun = new Urun((int)result["Id"],result["ad"].ToString(), (double)result["fiyat"], (bool)result["stoktaVarMi"]);

                        urunler.Add(urun);
                    }

                    return urunler;
                }
            }

        }

        public static List<Urun> DegerdenYuksekFiyatliUrunleriGetir(double esikDeger)
        {
            using (var connection = CreateConnection())
            {
                var command = new SqlCommand("SELECT * FROM Urunler WHERE fiyat > @deger", connection);
                command.Parameters.AddWithValue("@deger", esikDeger);

                var urunListesi = new List<Urun>();

                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {

                        var urun = new Urun((int)result["Id"],result["ad"].ToString()
                                            , (double)result["Fiyat"]
                                            , (bool)result["StoktaVarMi"]);


                        urunListesi.Add(urun);
                    }

                }

                return urunListesi;


            }
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

        public static void SecilenUrunleriSil()
        {
            //UrunListesiniYazdir();

            Console.WriteLine("Silmek istediğiniz ürünlerin Id'lerini yazınız: ");

            var idList = Console.ReadLine();

            using (var connection = CreateConnection())
            {

                var command = new SqlCommand($"DELETE FROM Urunler WHERE ID IN ({idList}) ", connection);

                command.ExecuteNonQuery();

            }

           // UrunListesiniYazdir();

        }
    }
}
