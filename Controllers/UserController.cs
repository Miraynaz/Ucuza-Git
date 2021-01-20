using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class UserController : Controller
    {

        
       
        [HttpGet]
    public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        { 
            SqlConnection sqlConn = new SqlConnection(@"Server=.;Initial Catalog=WebDataBase;Integrated Security = True");
            string sqlQuery = "SELECT Kullanici_Lakap,Kullanici_Sifre FROM Kullanici WHERE Kullanici_Lakap=@Kullanici_Lakap AND Kullanici_Sifre=@Kullanici_Sifre";
            sqlConn.Open();
            SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlConn);
            sqlCmd.Parameters.AddWithValue("@Kullanici_Lakap", user.Kullanici_Lakap);
            sqlCmd.Parameters.AddWithValue("@Kullanici_Sifre", user.Kullanici_Sifre);
            SqlDataReader sdr = sqlCmd.ExecuteReader();
            if(sdr.Read())
            {
                ViewData["Success"] = "Giriş Başarılı";
            }
            else
            {
                ViewData["Message"] = "Giriş Başarısız";
            }
            sqlConn.Close();
            return View();
        }




        [HttpGet]
        // GET: User/Create
        public ActionResult Create()
        {
            return View("Create",new User());
        }

        // POST: User/Create
        [HttpPost]
        
        public ActionResult Create(User user)
        {
            using (SqlConnection sqlConn = new SqlConnection(@"Server=DESKTOP-20AUB83;Initial Catalog=WebDataBase;Integrated Security = True"))
            {
                sqlConn.Open();
                string create = "INSERT INTO Kullanici (Kullanici_Lakap,Kullanici_Sifre,Kullanici_Adi,Kullanici_Soyadi,Kullanici_SehirID,kullanici_Resim) VALUES (@Kullanici_Lakap,@Kullanici_Sifre,@Kullanici_Adi,@Kullanici_Soyadi,@Kullanici_SehirID,@kullanici_Resim)";
                SqlCommand sqlCmd = new SqlCommand(create, sqlConn);
                sqlCmd.Parameters.AddWithValue("@Kullanici_Lakap", user.Kullanici_Lakap);
                sqlCmd.Parameters.AddWithValue("@Kullanici_Sifre", user.Kullanici_Sifre);
                sqlCmd.Parameters.AddWithValue("@Kullanici_Adi", user.Kullanici_Adi);
                sqlCmd.Parameters.AddWithValue("@Kullanici_Soyadi", user.Kullanici_Soyadi);
                sqlCmd.Parameters.AddWithValue("@Kullanici_SehirID", user.Kullanici_SehirID);
                sqlCmd.Parameters.AddWithValue("@kullanici_Resim", user.kullanici_Resim);
                sqlCmd.ExecuteNonQuery();
                sqlConn.Close();
            }
           
            return View("Index");
            
        }

        // GET: User/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            DataAccess dataAccess = new DataAccess();
            if (id == null)
            {
                return NotFound();
            }
            User user = dataAccess.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            return View("Edit",user);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] User user)
        {
            DataAccess dataAccess = new DataAccess();
            if (id != user.KullaniciID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                dataAccess.UpdateUser(user);
                return RedirectToAction("Index");
            }
            return View(dataAccess);
        }

        
    }
}