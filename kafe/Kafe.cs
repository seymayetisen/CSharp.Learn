using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kafeYönetim.lib
{
    public class Kafe
    {
        public string Ad { get; private set; }
        public string AcilisSaati { get; private set; }
        public string KapanisSaati { get; private set; }
        public KafeDurum Durum { get; set; }
        public Urun[] Urunler { get; set; }

        public void Ac()
        {
            Durum = KafeDurum.acik;
        }
        public void Kapat()
        {
            Durum = KafeDurum.kapali;
        }

    }
}
