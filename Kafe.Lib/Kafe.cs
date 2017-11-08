using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafeYonetim.Lib
{
    public class Kafe
    {
        //Constructor - İnşa edici metod / Yapılandırıcı Metod

        public Kafe(string ad, string acilisSaati, string kapanisSaati)
        {
            Ad = ad;
            AcilisSaati = acilisSaati;
            KapanisSaati = kapanisSaati;

            Durum = KafeDurum.Kapali;

            Urunler = new Urun[500];
            Calisanlar = new Calisan[500];
            Masalar = new Masa[500];
            Siparisler = new Siparis[500];
        }

        public string Ad { get; private set; }
        public string AcilisSaati { get; private set; }
        public string KapanisSaati { get; private set; }
        public KafeDurum Durum { get; private set; }
        public Calisan[] Calisanlar { get; set; }
        public Urun[] Urunler { get; set; }
        public Masa[] Masalar { get; set; }
        public Siparis[] Siparisler { get; set; }

        public void Ac()
        {
            Durum = KafeDurum.Acik;
        }

        public void Kapat()
        {
            Durum = KafeDurum.Kapali;
        }
    }
}
