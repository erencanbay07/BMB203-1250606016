using System;

namespace BMB203_1250606016
{
    public class OnlineKurs : Kurs
    {
        public string PlatformAdi { get; }
        private const decimal DijitalIndirimOrani = 0.85m; // %15 indirim

        public override string KursTuru => "Online Kurs";

        public OnlineKurs(string kursKodu, string kursAdi, int kapasite, int dersSaati, decimal tabanSaatlikUcret, string platformAdi)
            : base(kursKodu, kursAdi, kapasite, dersSaati, tabanSaatlikUcret)
        {
            if (string.IsNullOrWhiteSpace(platformAdi))
                throw new ArgumentException("Platform adı boş olamaz.", nameof(platformAdi));

            PlatformAdi = platformAdi;
        }

        public override decimal UcretHesapla(IZamanTarifesi tarife, DateTime islemZamani)
        {
            if (tarife == null) throw new ArgumentNullException(nameof(tarife));

            decimal temelTutar = DersSaati * TabanSaatlikUcret * tarife.CarpanHesapla(islemZamani);
            return temelTutar * DijitalIndirimOrani;
        }

        public override string ToString()
        {
            return $"{base.ToString()} | Platform: {PlatformAdi}";
        }
    }
}