using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Sehir
    {
        public Sehir(int ID)
        {
            SqlConnection bag = new SqlConnection(@"Server=.;Initial Catalog=WebDataBase;Integrated Security = True");
            bag.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Sehir WHERE sehir_ID=" + ID.ToString(), bag);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                sehir_ID = sqlDataReader.GetInt32(0);
                sehir_Adi = sqlDataReader.GetString(1);
                sehir_BolgeID = sqlDataReader.GetInt32(2);
                bolge = new Bolge(sehir_BolgeID);
            }
            sqlDataReader.Close();
            bag.Dispose();
            bag.Close();
        }

        public Bolge bolge { get; set; }
        public int sehir_ID { get; set; }
        public int sehir_BolgeID { get; set; }
        public string sehir_Adi { get; set; }
    }
}
