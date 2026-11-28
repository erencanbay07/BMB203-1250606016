using System;
using System.Collections.Generic;
using System.Linq;

namespace BMB203_1250606016
{
    public class KursMerkezi
    {
        private readonly List<Kurs> _kurslar = new List<Kurs>();
        private readonly List<Ogrenci> _ogrenciler = new List<Ogrenci>();
        private readonly List<Kayit> _kayitlar = new List<Kayit>();

        public string MerkezAdi { get; }
        public IZamanTarifesi AktifTarife { get; private set; }

        public IReadOnlyList<Kurs> Kurslar => _kurslar.AsReadOnly();
        public IReadOnlyList<Ogrenci> Ogrenciler => _ogrenciler.AsReadOnly();
        public IReadOnlyList<Kayit> Kayitlar => _kayitlar.AsReadOnly();

        public KursMerkezi(string merkezAdi, IZamanTarifesi baslangicTarifesi = null)
        {
            if (string.IsNullOrWhiteSpace(merkezAdi))
                throw new ArgumentException("Kurs merkezi adı boş olamaz.", nameof(merkezAdi));

            MerkezAdi = merkezAdi;
            AktifTarife = baslangicTarifesi ?? new NormalTarife();
        }

        public void TarifeDegistir(IZamanTarifesi yeniTarife)
        {
            AktifTarife = yeniTarife ?? throw new ArgumentNullException(nameof(yeniTarife));
        }

        public void KursEkle(Kurs kurs)
        {
            if (kurs == null)
                throw new ArgumentNullException(nameof(kurs));

            if (_kurslar.Any(k => k.KursKodu.Equals(kurs.KursKodu, StringComparison.OrdinalIgnoreCase)))
                throw new InvalidOperationException($"'{kurs.KursKodu}' kodlu kurs sistemde zaten mevcut.");

            _kurslar.Add(kurs);
        }

        public void OgrenciEkle(Ogrenci ogrenci)
        {
            if (ogrenci == null)
                throw new ArgumentNullException(nameof(ogrenci));

            if (_ogrenciler.Any(o => o.OgrenciNo.Equals(ogrenci.OgrenciNo, StringComparison.OrdinalIgnoreCase)))
                throw new InvalidOperationException($"'{ogrenci.OgrenciNo}' numaralı öğrenci sistemde zaten kayıtlı.");

            _ogrenciler.Add(ogrenci);
        }

        public Kayit KayitOlustur(string ogrenciNo, string kursKodu, DateTime? islemZamani = null)
        {
            var ogrenci = _ogrenciler.FirstOrDefault(o => o.OgrenciNo.Equals(ogrenciNo, StringComparison.OrdinalIgnoreCase))
                ?? throw new KeyNotFoundException($"'{ogrenciNo}' numaralı öğrenci bulunamadı.");

            var kurs = _kurslar.FirstOrDefault(k => k.KursKodu.Equals(kursKodu, StringComparison.OrdinalIgnoreCase))
                ?? throw new KeyNotFoundException($"'{kursKodu}' kodlu kurs bulunamadı.");

            DateTime zaman = islemZamani ?? DateTime.Now;

            // Kurs sınıfındaki iş kurallarını (kapasite, çift kayıt, başlama durumu) doğrular
            kurs.OgrenciKaydet(ogrenci);

            // Aktif stratejiye göre ücreti hesaplayıp kayıt fişini oluşturur
            var yeniKayit = new Kayit(ogrenci, kurs, zaman, AktifTarife);
            _kayitlar.Add(yeniKayit);

            return yeniKayit;
        }

        public decimal ToplamGelirHesapla()
        {
            return _kayitlar.Sum(k => k.OdenenUcret);
        }

        public decimal KursaGoreGelirHesapla(string kursKodu)
        {
            return _kayitlar
                .Where(k => k.Kurs.KursKodu.Equals(kursKodu, StringComparison.OrdinalIgnoreCase))
                .Sum(k => k.OdenenUcret);
        }

        public List<Kurs> MusaitKurslariListele()
        {
            return _kurslar
                .Where(k => k.Durum == KursDurumu.Planlandi && k.MevcutOgrenciSayisi < k.Kapasite)
                .ToList();
        }
    }
}