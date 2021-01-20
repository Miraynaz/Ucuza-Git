using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class User
    {
        public int KullaniciID { get; set; }
        [Required(ErrorMessage = "Lütfen Kullanıcı Nickname kısmını boş geçmeyiniz...")]
        
        public string Kullanici_Lakap { get; set; }
        [Required(ErrorMessage = "Lütfen Şifre kısmını boş geçmeyiniz...")]
        [DataType(DataType.Password, ErrorMessage = "Lütfen şifreyi tüm kuralları göz önüne alarak giriniz...")]
        public string Kullanici_Sifre { get; set; }
        [Required(ErrorMessage = "Lütfen Kullanıcı Adı kısmını boş geçmeyiniz...")]
        public string Kullanici_Adi { get; set; }
        [Required(ErrorMessage = "Lütfen Kullanıcı Soyad kısmını boş geçmeyiniz...")]
        public string Kullanici_Soyadi { get; set; }
        [Required(ErrorMessage = "Lütfen Kullanıcı Plaka kısmını boş geçmeyiniz...")]
        public int Kullanici_SehirID { get; set; }
        public string kullanici_Resim { get; set; }

    }
}
