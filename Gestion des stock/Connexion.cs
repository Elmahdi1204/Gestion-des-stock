using System;
using System.Data.SqlClient;

namespace Gestion_des_stock
{
    class Connexion
    {
        public static string id;
        public static String mdps;
        public static String type;
        public static SqlConnection conn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=data;Integrated Security=True");
    }
}
