using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KafeYönetim.Data;

namespace KafeYönetim.Sunum.AnaUygulama
{
    class Program
    {
        static void Main(string[] args)
        {
            // DataManager a = new DataManager();
            //a.KafeBilgisiniYazdir();
            //a.UrunListesiniYazdir();
            //a.kafeIsminiGetir();
            //a.urunFiyatiniGetir();
            //a.yuksek();
            // a.urunEkleme();

            //a.urunSilme();
            //DataManager.urunSilme();
            DataManager.urunIsmiGuncelleme();
        }
    }
}
