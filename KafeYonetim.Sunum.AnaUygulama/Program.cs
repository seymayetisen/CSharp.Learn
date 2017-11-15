using KafeYonetim.Data;
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

            DataManager.KafeBilgisiniYazdir();

            //dataManager.UrunListesiniYazdir();

            //dataManager.KafeAdiniGetir();

            DataManager.UrunFiyatiniGetir();

            //dataManager.DegerdenYuksekFiyatliUrunleriGetir();

            //dataManager.UrunGir();

           // dataManager.KapatilmamimsBaglanti();

            //dataManager.SecilenUrunleriSil();

        }
    }
}
