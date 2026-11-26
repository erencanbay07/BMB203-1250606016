using System;

namespace BMB203_1250606016
{
    public class Ogrenci
    {
        public string OgrenciNo { get; }
        public string AdSoyad { get; }
        public string Eposta { get; }

        public Ogrenci(string ogrenciNo, string adSoyad, string eposta)
        {
            if (string.IsNullOrWhiteSpace(ogrenciNo))
                throw new ArgumentException("Öğrenci numarası boş olamaz.", nameof(ogrenciNo));
            if (string.IsNullOrWhiteSpace(adSoyad))
                throw new ArgumentException("Öğrenci adı soyadı boş olamaz.", nameof(adSoyad));

            OgrenciNo = ogrenciNo;
            AdSoyad = adSoyad;
            Eposta = eposta ?? string.Empty;
        }

        public override string ToString()
        {
            return $"{OgrenciNo} - {AdSoyad}";
        }
    }
}