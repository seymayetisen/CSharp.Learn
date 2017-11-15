namespace KafeYonetim.Lib
{
    public class Urun
    {
        public Urun(string ad, double fiyat, bool stoktaVarMi)
        {
            Ad = ad;
            Fiyat = fiyat;
            StoktaVarmi = stoktaVarMi;
        }

        public string Ad { get; private set; }
        public double Fiyat { get; private set; }
        public bool StoktaVarmi { get; set; }
    }
}