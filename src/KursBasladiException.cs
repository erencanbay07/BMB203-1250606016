using System;

namespace BMB203_1250606016
{
    public class KursBasladiException : Exception
    {
        public string KursKodu { get; }

        public KursBasladiException(string kursKodu)
            : base($"'{kursKodu}' kodlu kurs halihazırda başladığı için yeni kayıt veya işlem yapılamaz.")
        {
            KursKodu = kursKodu;
        }
    }
}