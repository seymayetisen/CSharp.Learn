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

        public static void UrunListesiniYazdir()
        {
            Console.Clear();

            using (var connection = CreateConnection())
            {

                var command = new SqlCommand("SELECT * FROM Urunler", connection);

                using (var result = command.ExecuteReader())
                {
                    Console.WriteLine($"{"ID".PadRight(4)} {"Isim".PadRight(19)} {"Fiyat".PadRight(19)} Stok Durumu");
                    Console.WriteLine("".PadRight(60, '='));
                    while (result.Read())
                    {
                        Console.Write($"{result["ID"].ToString().PadRight(5)}");
                        Console.Write($"{result["ad"].ToString().PadRight(20)}");
                        Console.Write($"{result["Fiyat"].ToString().PadRight(20)}");
                        Console.Write($"{result["StoktaVarMi"]}");
                        Console.WriteLine();
                    }

                }
            }

            Console.ReadLine();

        }

        public static void DegerdenYuksekFiyatliUrunleriGetir()
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
                        Console.Write($"{result["ad"]}");
                        Console.Write($"{result["Fiyat"]}");
                        Console.WriteLine();
                    }

                }
            }

            Console.ReadLine();

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

        public static void UrunGir()
        {
            using (var connection = CreateConnection())
            {

                Console.Write("Ürün Adını giriniz: ");
                var ad = Console.ReadLine();

                Console.Write("Ürün fiyatını giriniz: ");
                var fiyat = double.Parse(Console.ReadLine());

                Console.Write("Ürün stokta var mı? (e/h): ");
                var stok = (Console.ReadLine() == "e") ? true : false;

                var command = new SqlCommand("INSERT INTO Urunler (ad, fiyat, stoktavarmi) VALUES (@ad, @fiyat, @stoktaVarMi)", connection);
                command.Parameters.AddWithValue("@ad", ad);
                command.Parameters.AddWithValue("@fiyat", fiyat);
                command.Parameters.AddWithValue("@stoktaVarMi", stok);

                var result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    Console.WriteLine("Kayıt eklendi.");
                }

            }

            Console.ReadLine();
        }

        public static void SecilenUrunleriSil()
        {
            UrunListesiniYazdir();

            Console.WriteLine("Silmek istediğiniz ürünlerin Id'lerini yazınız: ");

            var idList = Console.ReadLine();

            using (var connection = CreateConnection())
            {

                var command = new SqlCommand($"DELETE FROM Urunler WHERE ID IN ({idList}) ", connection);

                command.ExecuteNonQuery();

            }

            UrunListesiniYazdir();

        }
    }
}
