using System.Collections.Generic;
using WebApplication3.Models;


namespace WebApplication3.Models
{
    public class Kullanici_Sehir
    {
        public List<Sehir> sehirlers { get; set; }
        public User kullanici { get; set; }
    }
}

