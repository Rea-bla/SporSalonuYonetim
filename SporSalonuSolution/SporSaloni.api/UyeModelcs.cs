using System;

namespace SporSalonu.API
{
    public class UyeModel
    {
        public string TCNo { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Telefon { get; set; }
        public string KanGrubu { get; set; } 
        public string Cinsiyet { get; set; }
        public int Boy { get; set; }         //  (cm)(bilerek koydum inadına)
        public double Kilo { get; set; }     // (kg)(bunuda : Yusuftan selams)
        public DateTime DogumTarihi { get; set; }
        public DateTime? BitisTarihi { get; set; } 
        public int SecilenUyelikID { get; set; }  
    }
}