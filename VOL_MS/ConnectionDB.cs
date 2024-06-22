using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VOL_MS
{
    internal class ConnectionDB
    {
        public static string GetConnectionString()
        {
            //string con = @"Data Source=AL-MAHIL;Initial Catalog=Events;Integrated Security=True";
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";

            return con;
        }
    }
}
