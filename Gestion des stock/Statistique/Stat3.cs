using Bunifu.UI.WinForms;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Gestion_des_stock.Statistique
{
    class Stat3
    {
        public static void chart1(Chart chart, Chart chart2)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand countmatier = new SqlCommand("select TOP  5 nomcategory , (select sum(qteproduit) from stock , produit  where  produit.idcategory = category.idcategory and stock.idproduit = produit.idproduit) ,  (select sum(prixvent*qteproduit)  from stock , produit  where  produit.idcategory = category.idcategory and stock.idproduit = produit.idproduit) as k from  category where  (select sum(prixvent*qteproduit)  from stock , produit  where  produit.idcategory = category.idcategory and stock.idproduit = produit.idproduit) >0 order by K desc", Connexion.conn);

                SqlDataReader dr = countmatier.ExecuteReader();


                chart.Series["Series1"].Points.Clear();
                chart2.Series["Series1"].Points.Clear();


                while (dr.Read())
                {
                    if (dr[1].ToString() != "")
                    {
                        chart.Series["Series1"].Points.AddXY("" + dr[0], dr[1]);
                        chart2.Series["Series1"].Points.AddXY("" + dr[0], dr[2]);

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
        public static void Plusproduitbenife(BunifuDataGridView bunifuDataGridView)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand countmatier = new SqlCommand("select top 10 nomproduit , ((prixvent - prixachat) * (select sum(qnteachte) from produitvendu where produitvendu.idproduit = produit.idproduit)) as k, (select sum(qnteachte) from produitvendu where produitvendu.idproduit = produit.idproduit) , qteproduit from   stock , produit where stock.idproduit = produit.idproduit order by k DESC", Connexion.conn);

                SqlDataReader dr = countmatier.ExecuteReader();


                bunifuDataGridView.Rows.Clear();


                while (dr.Read())
                {
                    if (dr[1].ToString() != "")
                    {
                        bunifuDataGridView.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
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
    }
}
