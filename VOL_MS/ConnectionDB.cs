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
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\EventsDatabase.mdf;Integrated Security=True";
            return con;
        }

        public static string GetShitsConnectionString()
        {
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ShiftsDB.mdf;Integrated Security=True";
            return con;
        }
    }
}
