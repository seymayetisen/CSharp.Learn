namespace kafeYönetim.lib
{
    public class Siparis
    {
        public int SiparisNo { get; private set; }
        public Kalem[] kalemler { get; set; }
        public Garson SiparisAlanGarson { get; set; }
        public Asci SiparisHazirlayanAsci { get; set; }
        public string Not { get; set; }
    }
}