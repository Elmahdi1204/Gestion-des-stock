using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Gestion_des_stock.Statistique
{
    class State5
    {
        static SqlCommand cm;
        static SqlDataReader dr;
        public static void Countfacture(Label txt, DateTime date1, DateTime date2)
        {
            Connexion.conn.Open();
            cm = new SqlCommand("Select Count(idachat)  from achats where dateachat between '" + date1 + "' and  '" + date2 + "' ;", Connexion.conn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                txt.Text = dr[0].ToString();
            }
            Connexion.conn.Close();

        }
        public static void totaleachats(Label txt, DateTime date1, DateTime date2)
        {
            Connexion.conn.Open();
            cm = new SqlCommand("Select SUM(prixachat)   from achats where dateachat between '" + date1 + "' and  '" + date2 + "' ;", Connexion.conn);
            dr = cm.ExecuteReader();

            while (dr.Read())
            {
                if (dr[0].ToString() == "")
                {
                    txt.Text = "0";
                }
                else
                {
                    txt.Text = dr[0].ToString();
                }


            }
            Connexion.conn.Close();

        }

        public static void Credit(Label txt, Label txt2, DateTime date1, DateTime date2)
        {
            Connexion.conn.Open();
            cm = new SqlCommand("select count(idachat)  ,(select sum(prixachat - versment) from achats  where   dateachat between '" + date1 + "' and  '" + date2 + "'   ) from achats where dateachat between '" + date1 + "' and  '" + date2 + "' and versment<prixachat  ;", Connexion.conn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (dr[1].ToString() == "")
                {
                    txt2.Text = "0";
                }
                else
                {
                    txt2.Text = dr[1].ToString();
                }
                txt.Text = dr[0].ToString();

            }
            Connexion.conn.Close();

        }

        public static void chart1(Chart chart, DateTime date1, DateTime date2)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand countmatier = new SqlCommand("SELECT DISTINCT cast(dateachat as date), (SELECT sum(achats.prixachat) from achats WHERE cast(dateachat as date) =cast(a.dateachat as date)) from  achats as A where dateachat between '" + date1 + "' and  '" + date2 + "' ;", Connexion.conn);

                SqlDataReader dr = countmatier.ExecuteReader();


                chart.Series["Series1"].Points.Clear();


                while (dr.Read())
                {
                    if (dr[1].ToString() != "")
                    {
                        chart.Series["Series1"].Points.AddXY("" + DateTime.Parse(dr[0].ToString()).ToString("dd-MM"), dr[1]);
                    }



                }

                Connexion.conn.Close();


            }
            catch
            {

            }
        }
        public static void totaledescharges(Label txt, DateTime date1, DateTime date2)
        {
            Connexion.conn.Open();
            cm = new SqlCommand("Select SUM(totale)   from charges where date between '" + date1 + "' and  '" + date2 + "' ;", Connexion.conn);
            dr = cm.ExecuteReader();

            while (dr.Read())
            {
                if (dr[0].ToString() == "")
                {
                    txt.Text = "0";
                }
                else
                {
                    txt.Text = dr[0].ToString();
                }


            }
            Connexion.conn.Close();

        }

    }
}
