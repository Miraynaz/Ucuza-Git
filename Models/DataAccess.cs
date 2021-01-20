using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using static WebApplication3.Models.User;

namespace WebApplication3.Models
{
    public class DataAccess
    {
        public void UpdateUser(User user)
        {
            using (SqlConnection sqlConn = new SqlConnection(@"Server=.;Initial Catalog=WebDataBase;Integrated Security = True"))
            {
                sqlConn.Open();
                SqlCommand sqlCmd = new SqlCommand("updateUser", sqlConn);
                sqlCmd.Parameters.AddWithValue("@Kullanici_Lakap", user.Kullanici_Lakap);
                sqlCmd.Parameters.AddWithValue("@Kullanici_Sifre", user.Kullanici_Sifre);
                sqlCmd.Parameters.AddWithValue("@Kullanici_Adi", user.Kullanici_Adi);
                sqlCmd.Parameters.AddWithValue("@Kullanici_Soyadi", user.Kullanici_Soyadi);
                sqlCmd.Parameters.AddWithValue("@Kullanici_SehirID", user.Kullanici_SehirID);
                sqlCmd.Parameters.AddWithValue("@kullanici_Resim", user.kullanici_Resim);
                sqlCmd.ExecuteNonQuery();
                sqlConn.Close();
            }
        }
        public User GetUser(int ? id)
        {
            User user = new User();
            using (SqlConnection sqlConn = new SqlConnection(@"Server=DESKTOP-20AUB83;Initial Catalog=WebDataBase;Integrated Security = True"))
            {
                sqlConn.Open();
                SqlCommand sqlCmd = new SqlCommand("GetUserByID", sqlConn);
                SqlDataReader sdr = sqlCmd.ExecuteReader();
                while (sdr.Read())
                {
                    user.KullaniciID = Convert.ToInt32(sdr["Kullanici_ID"]);
                    user.Kullanici_Adi = Convert.ToString(sdr["Kullanici_Adi"]);
                    user.Kullanici_Soyadi = Convert.ToString(sdr["Kullanici_Soyadi"]);
                    user.Kullanici_Lakap = Convert.ToString(sdr["Kullanici_Lakap"]);
                    user.Kullanici_Sifre = Convert.ToString(sdr["Kullanici_Sifre"]);
                    user.kullanici_Resim = Convert.ToString(sdr["kullanici_Resim"]);
                    user.Kullanici_SehirID = Convert.ToInt32(sdr["Kullanici_SehirID"]);
                }
            }

                return user;
        }
    }
}
