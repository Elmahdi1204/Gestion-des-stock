using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Gestion_des_stock.Statistique
{
    class State4
    {
        static SqlCommand cm;
        static SqlDataReader dr;
        public static void Countfacture(Label txt, DateTime date1, DateTime date2)
        {
            Connexion.conn.Open();
            cm = new SqlCommand("Select Count(idvants) from vents where datevent between '" + date1 + "' and  '" + date2 + "' ;", Connexion.conn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                txt.Text = dr[0].ToString();
            }
            Connexion.conn.Close();

        }
        public static void totaledesvent(Label txt, DateTime date1, DateTime date2)
        {
            Connexion.conn.Open();
            cm = new SqlCommand("select sum(prixtotale) from vents  where datevent between '" + date1 + "' and  '" + date2 + "' ;", Connexion.conn);
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
        public static void Caisse(Label txt, DateTime date1, DateTime date2)
        {
            Connexion.conn.Open();
            cm = new SqlCommand("select sum(versment) from vents  where datevent between '" + date1 + "' and  '" + date2 + "' ;", Connexion.conn);
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
            cm = new SqlCommand("select count(idvants)  ,(select sum(prixtotale - versment) from vents  where   datevent between '" + date1 + "' and  '" + date2 + "'   ) from vents where datevent between '" + date1 + "' and  '" + date2 + "' and versment<prixtotale  ;", Connexion.conn);
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
        public static void benifice(Label txt, DateTime date1, DateTime date2)
        {
            Connexion.conn.Open();
            cm = new SqlCommand("select sum(benifice) from vents  where datevent between '" + date1 + "' and  '" + date2 + "' ;", Connexion.conn);
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
        public static void chart1(Chart chart, DateTime date1, DateTime date2)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand countmatier = new SqlCommand("SELECT DISTINCT cast(datevent as date), (SELECT sum(vents.benifice) from vents WHERE cast(datevent as date) = cast(v.datevent as date)) from  vents as V where datevent between '" + date1 + "' and  '" + date2 + "' ;", Connexion.conn);

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
        public static void chart2(Chart chart, DateTime date1, DateTime date2)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand countmatier = new SqlCommand("SELECT Top 20 nomclient , prixtotale -versment from  vents  , client  where prixtotale -versment>0 and vents.idclient = client.idclient and  datevent between '" + date1 + "' and  '" + date2 + "' ;", Connexion.conn);

                SqlDataReader dr = countmatier.ExecuteReader();


                chart.Series["Series1"].Points.Clear();


                while (dr.Read())
                {
                    if (dr[1].ToString() != "")
                    {
                        chart.Series["Series1"].Points.AddXY("" + dr[0].ToString(), dr[1]);
                    }



                }

                Connexion.conn.Close();


            }
            catch
            {

            }
        }


    }
}
