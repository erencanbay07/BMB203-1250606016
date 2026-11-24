using System;

namespace BMB203_1250606016
{
    public class CiftKayitException : Exception
    {
        public string OgrenciAd { get; }
        public string KursKodu { get; }

        public CiftKayitException(string ogrenciAd, string kursKodu)
            : base($"'{ogrenciAd}' isimli öğrenci '{kursKodu}' kodlu kursa zaten kayıtlıdır.")
        {
            OgrenciAd = ogrenciAd;
            KursKodu = kursKodu;
        }
    }
}