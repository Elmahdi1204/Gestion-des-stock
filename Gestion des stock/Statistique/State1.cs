using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Gestion_des_stock.Statistique
{
    class State1
    {
        static SqlCommand cm;
        static SqlDataReader dr;
        public static void countproduct(Label txt)
        {
            Connexion.conn.Open();
            cm = new SqlCommand("select count(idproduit) from dbo.stock   where qteproduit > 0", Connexion.conn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                txt.Text = dr[0].ToString();
            }
            Connexion.conn.Close();

        }
        public static void Totalestock(Label txt)
        {
            Connexion.conn.Open();
            cm = new SqlCommand("select sum(dbo.stock.prixvent * dbo.stock.qteproduit )  from dbo.stock ", Connexion.conn);
            dr = cm.ExecuteReader();
            Double k = 0;
            while (dr.Read())
            {
                if (dr[0].ToString() != "")
                {
                    k = double.Parse(dr[0].ToString());
                }


                txt.Text = $"{ k:### ### ###.##}       DA";
            }
            Connexion.conn.Close();

        }
        public static void Totalestock2(Label txt)
        {
            Connexion.conn.Open();
            cm = new SqlCommand("select sum(dbo.stock.prixachat * dbo.stock.qteproduit )  from dbo.stock ", Connexion.conn);
            dr = cm.ExecuteReader();
            Double k = 0;
            while (dr.Read())
            {
                if (dr[0].ToString() != "")
                {
                    k = double.Parse(dr[0].ToString());
                }


                txt.Text = $"{ k:### ### ###.##}      DA";
            }
            Connexion.conn.Close();

        }


        public static void chart1(Chart chart)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand countmatier = new SqlCommand("select top 10 nomproduit , (select sum(qnteachte) from produitvendu where produitvendu.idproduit = produit.idproduit) as k from   produit order by k asc", Connexion.conn);

                SqlDataReader dr = countmatier.ExecuteReader();


                chart.Series["Series1"].Points.Clear();


                while (dr.Read())
                {
                    if (dr[1].ToString() != "")
                    {
                        chart.Series["Series1"].Points.AddXY("" + dr[0], dr[1]);
                    }



                }

                Connexion.conn.Close();


            }
            catch (Exception e)
            {
                Connexion.conn.Close();
                MessageBox.Show(e.Message);


            }
        }
        public static void chart2(Chart chart)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand countmatier = new SqlCommand("select top 10 nomproduit , (prixvent - prixachat) as k  from   stock , produit where stock.idproduit = produit.idproduit order by k ASC ", Connexion.conn);

                SqlDataReader dr = countmatier.ExecuteReader();


                chart.Series["Series1"].Points.Clear();


                while (dr.Read())
                {


                    chart.Series["Series1"].Points.AddXY("" + dr[0], dr[1]);

                }

                Connexion.conn.Close();


            }
            catch (Exception e)
            {
                Connexion.conn.Close();
                MessageBox.Show(e.Message);


            }
        }



























    }
}
