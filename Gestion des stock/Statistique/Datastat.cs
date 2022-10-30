using System;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Gestion_des_stock.Statistique
{
    class Datastat
    {


        static SqlCommand cm;
        static SqlDataReader dr;



        public static void Profitdejour(DateTime date1, DateTime date2, Label txt)
        {
            Connexion.conn.Open();
            cm = new SqlCommand("select sum(dbo.vents.benifice) from dbo.vents where dbo.vents.datevent between '" + date1.ToString("yyyy-MM-dd") + "' and '" + date2.ToString("yyyy-MM-dd") + "'; ", Connexion.conn);
            dr = cm.ExecuteReader();
            Double k = 0;
            while (dr.Read())
            {
                if (dr[0].ToString() != "")
                {
                    k = double.Parse(dr[0].ToString());
                }


                txt.Text = $"{ k:### ####.##}";
            }
            Connexion.conn.Close();

        }
        public static void totalevents(DateTime date1, DateTime date2, Label txt)
        {
            Connexion.conn.Open();
            cm = new SqlCommand("select sum(dbo.vents.prixtotale) from dbo.vents where dbo.vents.datevent between '" + date1.ToString("yyyy-MM-dd") + "' and '" + date2.ToString("yyyy-MM-dd") + "'; ", Connexion.conn);
            dr = cm.ExecuteReader();
            Double k = 0;
            while (dr.Read())
            {
                if (dr[0].ToString() != "")
                {
                    k = double.Parse(dr[0].ToString());
                }


                txt.Text = $"{ k:### ####.##}";
            }
            Connexion.conn.Close();

        }
        public static void Caisse(DateTime date1, DateTime date2, Label txt)
        {
            Connexion.conn.Open();
            cm = new SqlCommand("select sum(dbo.vents.prixtotale ) -sum(dbo.vents.prixtotale - dbo.vents.versment) from dbo.vents where dbo.vents.datevent  between '" + date1.ToString("yyyy-MM-dd") + "' and '" + date2.ToString("yyyy-MM-dd") + "'; ", Connexion.conn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                txt.Text = dr[0].ToString() + " DA";
            }
            Connexion.conn.Close();

        }
        public static void Countvents(DateTime date1, DateTime date2, Label txt)
        {
            Connexion.conn.Open();
            cm = new SqlCommand("select count(dbo.vents.idvants) from dbo.vents where dbo.vents.datevent between '" + date1.ToString("yyyy-MM-dd") + "' and '" + date2.ToString("yyyy-MM-dd") + "'; ", Connexion.conn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                txt.Text = dr[0].ToString();
            }
            Connexion.conn.Close();

        }
        public static void Countventcredit(DateTime date1, DateTime date2, Label txt)
        {
            Connexion.conn.Open();
            cm = new SqlCommand("select count(dbo.vents.idvants) from dbo.vents where dbo.vents.versment<> dbo.vents.prixtotale and  dbo.vents.datevent between '" + date1.ToString("yyyy-MM-dd") + "' and '" + date2.ToString("yyyy-MM-dd") + "'; ", Connexion.conn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                txt.Text = dr[0].ToString();
            }
            Connexion.conn.Close();

        }
        public static void Credit(DateTime date1, DateTime date2, Label txt)
        {
            Connexion.conn.Open();
            cm = new SqlCommand("select sum(dbo.vents.prixtotale - dbo.vents.versment)  from dbo.vents where dbo.vents.versment<> dbo.vents.prixtotale and  dbo.vents.datevent between '" + date1.ToString("yyyy-MM-dd") + "' and '" + date2.ToString("yyyy-MM-dd") + "'; ", Connexion.conn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                txt.Text = dr[0].ToString();
            }
            Connexion.conn.Close();

        }
        public static void Countfactureachat(DateTime date1, DateTime date2, Label txt)
        {
            Connexion.conn.Open();
            cm = new SqlCommand("select count(dbo.achats.idachat) from dbo.achats where dbo.achats.dateachat between '" + date1.ToString("yyyy-MM-dd") + "' and '" + date2.ToString("yyyy-MM-dd") + "'; ", Connexion.conn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                txt.Text = dr[0].ToString();
            }
            Connexion.conn.Close();

        }
        public static void Coutdachat(DateTime date1, DateTime date2, Label txt)
        {
            Connexion.conn.Open();
            cm = new SqlCommand("select sum(dbo.achats.prixachat) from dbo.achats where dbo.achats.dateachat between '" + date1.ToString("yyyy-MM-dd") + "' and '" + date2.ToString("yyyy-MM-dd") + "'; ", Connexion.conn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                txt.Text = dr[0].ToString() + " DA";
            }
            Connexion.conn.Close();

        }
        public static void COuntachatcredit(DateTime date1, DateTime date2, Label txt)
        {
            Connexion.conn.Open();
            cm = new SqlCommand("select count(dbo.achats.idachat) from dbo.achats where dbo.achats.versment<> dbo.achats.prixachat and  dbo.achats.dateachat between '" + date1.ToString("yyyy-MM-dd") + "' and '" + date2.ToString("yyyy-MM-dd") + "'; ", Connexion.conn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                txt.Text = dr[0].ToString();
            }
            Connexion.conn.Close();

        }
        public static void Creditachats(DateTime date1, DateTime date2, Label txt)
        {
            Connexion.conn.Open();
            cm = new SqlCommand("select sum(dbo.achats.prixachat - dbo.achats.versment)  from dbo.achats where dbo.achats.versment<> dbo.achats.prixachat and  dbo.achats.dateachat between '" + date1.ToString("yyyy-MM-dd") + "' and '" + date2.ToString("yyyy-MM-dd") + "'; ", Connexion.conn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                txt.Text = dr[0].ToString();
            }
            Connexion.conn.Close();

        }



    }
}
