using System;

namespace BMB203_1250606016
{
    public class HaftaSonuTarifesi : IZamanTarifesi
    {
        public string TarifeAdi => "Hafta Sonu Tarifesi (%30 Zamli)";

        public decimal CarpanHesapla(DateTime islemZamani)
        {
            if (islemZamani.DayOfWeek == DayOfWeek.Saturday || islemZamani.DayOfWeek == DayOfWeek.Sunday)
                return 1.30m;

            return 1.0m;
        }
    }
}