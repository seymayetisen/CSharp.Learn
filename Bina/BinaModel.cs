using Bina.Kapi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bina
{
    //BEST PRACTICE
    public class BinaModel
    {
        public BinaModel()
        {

        }

        public BinaModel(string ad)
        {
            _ad = ad;
        }

        private string _ad;

        public string Ad {
            get {
                if (_ad.Length < 20)
                {
                    return Renk;
                }

                return _ad;
            }

            set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Ad bilgisi boş olamaz.");
                }

                _ad = value;
            }
        }


        public string Renk;
        public BinaKapisi[] BinaKapsi;
        public Pencere[] Pencereler;
        private Daire[] Daireler;

        public string AdSoyle()
        {
            return Ad;
        }

    }
}
