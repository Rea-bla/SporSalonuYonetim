using System.ComponentModel.DataAnnotations;

namespace SporSalonu.Web.Models
{
    public class UyeModel
    {
        [Required(ErrorMessage = "TC Kimlik Numarası zorunludur")]
        public string TCNo { get; set; }

        [Required(ErrorMessage = "Ad zorunludur")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Soyad zorunludur")]
        public string Soyad { get; set; }

        public string? Telefon { get; set; }

        public string? Cinsiyet { get; set; }

        public string? KanGrubu { get; set; }

        [Required(ErrorMessage = "Doğum tarihi zorunludur")]
        public string DogumTarihi { get; set; }

        public int Boy { get; set; }

        public int Kilo { get; set; }

        [Required(ErrorMessage = "Üyelik seçimi zorunludur")]
        public int SecilenUyelikID { get; set; }

        public string? Odeme { get; set; }

        public string? BitisTarihi { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur")]
        public string Sifre { get; set; }

        [Required(ErrorMessage = "KVKK onayı zorunludur")]
        public bool KvkkOnay { get; set; }
    }
}