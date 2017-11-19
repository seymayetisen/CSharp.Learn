using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafeYonetim.Lib
{
    public class Bulasikci:Calisan
    {
        public Bulasikci(string i, DateTime g, Kafe k) : base(i, g, k)
        {

        }
        public float hizi { get; set; }
    }
}
