using System;

namespace BMB203_1250606016
{
    public interface IZamanTarifesi
    {
        string TarifeAdi { get; }
        decimal CarpanHesapla(DateTime islemZamani);
    }
}