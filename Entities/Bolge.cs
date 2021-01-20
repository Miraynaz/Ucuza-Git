using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Bolge
    {
       
        
            public int bolge_ID { get; set; }
            public string bolge_Adi { get; set; }

            public Bolge(int ID)
            {
                SqlConnection bag = new SqlConnection(@"Server=.;Initial Catalog=WebDataBase;Integrated Security = True");
                bag.Open();
                SqlCommand sqlcommand = new SqlCommand("SELECT * FROM Bolge WHERE Bolge_ID=" + ID.ToString(), bag);
                SqlDataReader sqldataReader = sqlcommand.ExecuteReader();
                while (sqldataReader.Read())
                {
                    bolge_ID = sqldataReader.GetInt32(0);
                    bolge_Adi = sqldataReader.GetString(1);
                }
                sqldataReader.Close();
                bag.Dispose();
                bag.Close();

            }
        
    }
}
