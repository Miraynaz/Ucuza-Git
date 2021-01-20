using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Tur
    {
        public Tur(int ID)
        {
            SqlConnection bag = new SqlConnection(@"Server=.;Initial Catalog=WebDataBase;Integrated Security = True");
            bag.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Tur WHERE Tur_ID=" + ID.ToString(), bag);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                tur_ID = sqlDataReader.GetInt32(0);
                tur_Adi = sqlDataReader.GetString(1);
                tur_Logo = sqlDataReader.GetString(2);
            }
            sqlDataReader.Close();
            bag.Dispose();
            bag.Close();
        }
        public int tur_ID { get; set; }
        public string tur_Adi { get; set; }

        public string tur_Logo { get; set; }
    }
}
