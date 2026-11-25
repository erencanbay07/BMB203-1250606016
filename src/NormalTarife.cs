using System;

namespace BMB203_1250606016
{
    public class NormalTarife : IZamanTarifesi
    {
        public string TarifeAdi => "Normal Tarife (1.0x)";

        public decimal CarpanHesapla(DateTime islemZamani)
        {
            return 1.0m;
        }
    }
}