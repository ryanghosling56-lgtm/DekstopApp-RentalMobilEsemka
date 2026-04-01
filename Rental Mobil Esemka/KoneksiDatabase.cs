using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Mobil_Esemka
{
    public static class KoneksiDatabase
    {
        public static string connectionString = @"Data Source=TKJSTEWA-1\SQLEXPRESS;Initial Catalog=Rental_Mobil_Esemka;Integrated Security=True";
        public static string NamaEmail;
        public static string Level;
        
        

        public static  SqlConnection GetConn()
        {
            return new SqlConnection(connectionString);
        }
    }
}
