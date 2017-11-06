using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bina;

namespace BinaYönetimi
{
    public class Program
    {
        static void Main(string[] args)
        {
            BinaModel binamodel = new BinaModel();
            binamodel.ad = "bem kurs binasi";
            binamodel.renk = "yesil";

            Console.WriteLine($"bina adi:{binamodel.ad}");

            
        }
    }
}
