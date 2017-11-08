using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kafeYönetim.lib
{
    public class Calisan
    {
        public string Isim { get; private set; }
        public DateTime MesaideMi { get; private set; }
        public Siparis[] siparisler { get; set; }
    }
}
