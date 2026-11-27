using System;

namespace BMB203_1250606016
{
    public class HibritKurs : Kurs
    {
        public string SinifKodu { get; }
        public string PlatformAdi { get; }
        private const decimal HibritAltyapiPayi = 100m;

        public override string KursTuru => "Hibrit Kurs";

        public HibritKurs(string kursKodu, string kursAdi, int kapasite, int dersSaati, decimal tabanSaatlikUcret, string sinifKodu, string platformAdi)
            : base(kursKodu, kursAdi, kapasite, dersSaati, tabanSaatlikUcret)
        {
            if (string.IsNullOrWhiteSpace(sinifKodu))
                throw new ArgumentException("Sınıf kodu boş olamaz.", nameof(sinifKodu));
            if (string.IsNullOrWhiteSpace(platformAdi))
                throw new ArgumentException("Platform adı boş olamaz.", nameof(platformAdi));

            SinifKodu = sinifKodu;
            PlatformAdi = platformAdi;
        }

        public override decimal UcretHesapla(IZamanTarifesi tarife, DateTime islemZamani)
        {
            if (tarife == null) throw new ArgumentNullException(nameof(tarife));

            decimal temelTutar = DersSaati * TabanSaatlikUcret * tarife.CarpanHesapla(islemZamani);
            return temelTutar + HibritAltyapiPayi;
        }

        public override string ToString()
        {
            return $"{base.ToString()} | Sınıf: {SinifKodu} & Platform: {PlatformAdi}";
        }
    }
}