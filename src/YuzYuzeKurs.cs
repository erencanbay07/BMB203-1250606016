using System;

namespace BMB203_1250606016
{
    public class YuzYuzeKurs : Kurs
    {
        public string SinifKodu { get; }
        private const decimal MateryalUcreti = 250m;

        public override string KursTuru => "Yüz Yüze Kurs";

        public YuzYuzeKurs(string kursKodu, string kursAdi, int kapasite, int dersSaati, decimal tabanSaatlikUcret, string sinifKodu)
            : base(kursKodu, kursAdi, kapasite, dersSaati, tabanSaatlikUcret)
        {
            if (string.IsNullOrWhiteSpace(sinifKodu))
                throw new ArgumentException("Sınıf kodu boş olamaz.", nameof(sinifKodu));

            SinifKodu = sinifKodu;
        }

        public override decimal UcretHesapla(IZamanTarifesi tarife, DateTime islemZamani)
        {
            if (tarife == null) throw new ArgumentNullException(nameof(tarife));

            decimal temelTutar = DersSaati * TabanSaatlikUcret * tarife.CarpanHesapla(islemZamani);
            return temelTutar + MateryalUcreti;
        }

        public override string ToString()
        {
            return $"{base.ToString()} | Sınıf: {SinifKodu}";
        }
    }
}