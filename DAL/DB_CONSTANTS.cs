using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace DAL
{
    public class DB_CONSTANTS
    {
        private static string connString_PfWell = ConfigurationManager.AppSettings["connection_pf"].ToString();
    

        public static string ConnectionString_PfWell
        {
            get { return connString_PfWell; }
        }

      
    }
}
