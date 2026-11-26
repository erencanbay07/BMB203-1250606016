using System;
using System.Collections.Generic;
using System.Linq;

namespace BMB203_1250606016
{
    public abstract class Kurs
    {
        private readonly List<Ogrenci> _kayitliOgrenciler = new List<Ogrenci>();

        public string KursKodu { get; }
        public string KursAdi { get; }
        public int Kapasite { get; }
        public int DersSaati { get; }
        public decimal TabanSaatlikUcret { get; }
        public KursDurumu Durum { get; private set; }

        public IReadOnlyList<Ogrenci> KayitliOgrenciler => _kayitliOgrenciler.AsReadOnly();
        public int MevcutOgrenciSayisi => _kayitliOgrenciler.Count;

        protected Kurs(string kursKodu, string kursAdi, int kapasite, int dersSaati, decimal tabanSaatlikUcret)
        {
            if (string.IsNullOrWhiteSpace(kursKodu))
                throw new ArgumentException("Kurs kodu boş olamaz.", nameof(kursKodu));
            if (string.IsNullOrWhiteSpace(kursAdi))
                throw new ArgumentException("Kurs adı boş olamaz.", nameof(kursAdi));
            if (kapasite <= 0 || kapasite > 50)
                throw new ArgumentOutOfRangeException(nameof(kapasite), "Kurs kapasitesi 1 ile 50 arasında olmalıdır.");
            if (dersSaati < 7)
                throw new ArgumentOutOfRangeException(nameof(dersSaati), "Kurs süresi en az 7 saat olmalıdır.");
            if (tabanSaatlikUcret < 0)
                throw new ArgumentOutOfRangeException(nameof(tabanSaatlikUcret), "Saatlik ücret negatif olamaz.");

            KursKodu = kursKodu;
            KursAdi = kursAdi;
            Kapasite = kapasite;
            DersSaati = dersSaati;
            TabanSaatlikUcret = tabanSaatlikUcret;
            Durum = KursDurumu.Planlandi;
        }

        public void OgrenciKaydet(Ogrenci ogrenci)
        {
            if (ogrenci == null)
                throw new ArgumentNullException(nameof(ogrenci));

            if (Durum != KursDurumu.Planlandi)
                throw new KursBasladiException(KursKodu);

            if (_kayitliOgrenciler.Any(o => o.OgrenciNo == ogrenci.OgrenciNo))
                throw new CiftKayitException(ogrenci.OgrenciNo, KursKodu);

            if (_kayitliOgrenciler.Count >= Kapasite)
                throw new InvalidOperationException($"'{KursKodu}' kodlu kursun kontenjanı ({Kapasite}) dolmuştur.");

            _kayitliOgrenciler.Add(ogrenci);
        }

        public void KursuBaslat()
        {
            if (Durum == KursDurumu.Basladi)
                throw new KursBasladiException(KursKodu);

            Durum = KursDurumu.Basladi;
        }

        public void KursuTamamla()
        {
            Durum = KursDurumu.Tamamlandi;
        }

        public abstract string KursTuru { get; }
        public abstract decimal UcretHesapla(IZamanTarifesi tarife, DateTime islemZamani);

        public override string ToString()
        {
            return $"[{KursKodu}] {KursAdi} ({KursTuru}) - Durum: {Durum} | Kontenjan: {MevcutOgrenciSayisi}/{Kapasite}";
        }
    }
}