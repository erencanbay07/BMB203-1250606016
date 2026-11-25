using System;

namespace BMB203_1250606016
{
    public class GeceTarifesi : IZamanTarifesi
    {
        public string TarifeAdi => "Gece Tarifesi (%30 Indirimli)";

        public decimal CarpanHesapla(DateTime islemZamani)
        {
            if (islemZamani.Hour >= 22 || islemZamani.Hour < 6)
                return 0.70m;

            return 1.0m;
        }
    }
}