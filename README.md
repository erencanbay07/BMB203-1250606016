# BMB203 - Nesneye Yönelik Programlama Dönem Projesi
**Öğrenci No:** 1250606016  
**Proje Konusu:** Dinamik Zaman Tarifeli Eğitim ve Kurs Merkezi Yönetim Sistemi  

## 1. Proje Özeti
Bu proje, C# ve .NET kullanılarak Nesneye Yönelik Programlama (NYP) prensipleri (Soyutlama, Kapsülleme, Kalıtım, Çok Biçimlilik) ve **Strategy Tasarım Deseni** temel alınarak geliştirilmiş bir kurs merkezi yönetim simülasyonudur. Sistem; Yüz Yüze, Online ve Hibrit kurs türlerini desteklemekte, kayıt işlemlerini durum makinesi (`KursDurumu`) kurallarına göre denetlemekte ve çalışma zamanında dinamik fiyatlandırma tarifeleri (`Normal`, `Gece`, `Hafta Sonu`) uygulayabilmektedir.

## 2. Klasör Yapısı
* `src/` : C# kaynak kodları, arayüzler, soyut sınıflar, alt sınıflar ve özel istisna (exception) sınıfları.
* `docs/` : UML sınıf diyagramı (`uml-diagram.png`) ve konsol uygulama çıktı ekran görüntüleri (`konsol-cikti.png`).
* `README.md` : Proje dokümantasyonu, kurulum adımları, mimari tasarım kararları ve yapay zeka kullanım beyanı.

## 3. Kurulum ve Çalıştırma Adımları
Projeyi yerel bilgisayarınızda derlemek ve çalıştırmak için .NET SDK (6.0 veya üzeri) yüklü olmalıdır.

1. Depoyu bilgisayarınıza klonlayın:
   ```bash
   git clone [https://github.com/erencanbay07/BMB203-1250606016.git](https://github.com/erencanbay07/BMB203-1250606016.git)
   cd BMB203-1250606016
