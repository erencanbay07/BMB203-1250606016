using System;

namespace BMB203_1250606016
{
    public class Kayit
    {
        public Ogrenci Ogrenci { get; }
        public Kurs Kurs { get; }
        public DateTime KayitTarihi { get; }
        public string UygulananTarife { get; }
        public decimal OdenenUcret { get; }

        public Kayit(Ogrenci ogrenci, Kurs kurs, DateTime kayitTarihi, IZamanTarifesi tarife)
        {
            Ogrenci = ogrenci ?? throw new ArgumentNullException(nameof(ogrenci));
            Kurs = kurs ?? throw new ArgumentNullException(nameof(kurs));
            if (tarife == null) throw new ArgumentNullException(nameof(tarife));

            KayitTarihi = kayitTarihi;
            UygulananTarife = tarife.TarifeAdi;
            OdenenUcret = kurs.UcretHesapla(tarife, kayitTarihi);
        }

        public override string ToString()
        {
            return $"{Ogrenci.AdSoyad} -> {Kurs.KursAdi} | Tarih: {KayitTarihi:dd.MM.yyyy HH:mm} | Tarife: {UygulananTarife} | Ücret: {OdenenUcret:C2}";
        }
    }
}