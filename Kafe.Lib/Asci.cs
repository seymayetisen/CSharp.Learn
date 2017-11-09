using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafeYonetim.Lib
{
    public class Asci: Calisan
    {
        public Asci(string i, DateTime g): base(i, g)
        {

        }

        public void SiparisiHazirla()
        {
            Console.WriteLine("Sipariş Hazırlandı.");
        }
    }
}
