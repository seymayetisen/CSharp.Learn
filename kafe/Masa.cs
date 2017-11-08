using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kafeYönetim.lib
{
    class Masa
    {
        public int masaNo { get;private set; }
        public Siparis Siparis { get; set; }
        public MasaDurum Durum { get; set; }
    }
}
