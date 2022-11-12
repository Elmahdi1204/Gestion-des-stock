using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_des_stock.Gestion_des_vents
{
    class dataproduitvendu

    {
        public static void loadproduitvenduid(BunifuDataGridView bunifuDataGridView, String id)
        {
            try
            {
                int i = 0;
                bunifuDataGridView.Rows.Clear();
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("select idvants , produit.idproduit , nomproduit   ,produitvendu.prixunit ,qnteachte , datevent , nomclient  , vents.prixtotale , vents.versment   from produitvendu , produit , vents , client  where produitvendu.idproduit = produit.idproduit and produitvendu.idfacture = vents.idvants and client.idclient = vents.idclient and produit.idproduit  LIKE '%" + id + "%'  order by datevent desc", Connexion.conn);
                SqlDataReader dr = sql.ExecuteReader();
                while (dr.Read())
                {

                    i++;


                    bunifuDataGridView.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), DateTime.Parse(dr[5].ToString()).ToString("dd-MM | HH:mm"), dr[6].ToString(), dr[7].ToString(), dr[8].ToString());


                }
                Connexion.conn.Close();


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }




        }
        public static void loadproduitvenduclient(BunifuDataGridView bunifuDataGridView, String nomf)
        {
            try
            {
                int i = 0;
                bunifuDataGridView.Rows.Clear();
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand(" select idvants , produit.idproduit , nomproduit   ,produitvendu.prixunit ,qnteachte , datevent , nomclient  , vents.prixtotale , vents.versment   from produitvendu , produit , vents , client  where produitvendu.idproduit = produit.idproduit and produitvendu.idfacture = vents.idvants and client.idclient = vents.idclient and nomclient  LIKE '%" + nomf + "%'  order by datevent desc ", Connexion.conn);
                SqlDataReader dr = sql.ExecuteReader();
                while (dr.Read())
                {

                    i++;


                    bunifuDataGridView.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), DateTime.Parse(dr[5].ToString()).ToString("dd-MM | HH:mm"), dr[6].ToString(), dr[7].ToString(), dr[8].ToString());


                }
                Connexion.conn.Close();


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }




        }
    }
}
