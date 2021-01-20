using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller {
    
    public IActionResult Index()
    {
        SqlConnection bag = new SqlConnection(@"Server=.;Initial Catalog=WebDataBase;Integrated Security = True");
        List<Sehir> sehirler = new List<Sehir>();
        bag.Open();
        SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Sehir", bag);
        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
        while (sqlDataReader.Read())
        {
            sehirler.Add(new Sehir(sqlDataReader.GetInt32(0)));
        }
        sqlDataReader.Close();
        sqlCommand.ExecuteNonQuery();
        bag.Dispose();
        bag.Close();
        return View(sehirler);
    }

    public ViewResult Kullanici_AnaSayfa()
    {
        SqlConnection bag = new SqlConnection(@"Server=.;Initial Catalog=WebDataBase;Integrated Security = True");
        //Şehirler için
        List<Sehir> sehirler = new List<Sehir>();
        bag.Open();
        SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Sehir", bag);
        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
        while (sqlDataReader.Read())
        {
            sehirler.Add(new Sehir(sqlDataReader.GetInt32(0)));
        }
        sqlDataReader.Close();
        sqlCommand.ExecuteNonQuery();
        //Kullanıcı İçin
        SqlCommand command = new SqlCommand("SELECT * FROM Kullanici WHERE Kullanici_ID = 1", bag);
        SqlDataReader sqlData = command.ExecuteReader();
        User kullanicii = new User();
        while (sqlData.Read())
        {
            kullanicii.KullaniciID = sqlData.GetInt32(0);
            kullanicii.Kullanici_Lakap = sqlData.GetString(1);
            kullanicii.Kullanici_Sifre = sqlData.GetString(2);
            kullanicii.Kullanici_Adi = sqlData.GetString(3);
            kullanicii.Kullanici_Soyadi = sqlData.GetString(4);
            kullanicii.Kullanici_SehirID = sqlData.GetInt32(5);
            kullanicii.kullanici_Resim = sqlData.GetString(6);
        }
        sqlData.Close();
        command.ExecuteNonQuery();
        bag.Dispose();
        bag.Close();
        //biraderim için
        var model = new Kullanici_Sehir { kullanici = kullanicii, sehirlers = sehirler };
        //zencilerim için
        return View(model);
    }
    //int nereden_ID,int nereye_ID,int kullanici_ID,DateTime tarih,int en_DusukFiyat=0,int en_YuksekFiyat=99999,
    public ViewResult AramaSonuc(int nereden_ID = -1, int nereye_ID = -1, int yuksek = -1, string tur = "-1", string firma = "-1")
    {
        SqlConnection bag = new SqlConnection(@"Server=.;Initial Catalog=WebDataBase;Integrated Security = True");
        string sorgu = "WHERE Rota_ID = Rota_ID ";
        if (nereden_ID != -1)
        {
            sorgu += "AND Rota_BaslangicSehirID = " + nereden_ID.ToString();
        }
        if (nereye_ID != -1)
        {
            sorgu += " AND Rota_VarisSehirID = " + nereye_ID.ToString();
        }
        if (yuksek != -1)
        {
            sorgu += " AND Rota_Ucret < " + yuksek.ToString();
        }

        List<Rota> rota = new List<Rota>();
        bag.Open();
        SqlCommand sqlcommand = new SqlCommand("SELECT * FROM Rota " + sorgu, bag);
        SqlDataReader sqlDataReader = sqlcommand.ExecuteReader();
        while (sqlDataReader.Read())
        {
            rota.Add(new Rota(sqlDataReader.GetInt32(0)));
        }
        sqlDataReader.Close();
        bag.Dispose();
        bag.Close();
        return View(rota);
    }
}
}
