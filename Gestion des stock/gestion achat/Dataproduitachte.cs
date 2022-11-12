using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_des_stock.gestion_achat
{
    class Dataproduitachte
    {
        public static void loadproduitachteid(BunifuDataGridView bunifuDataGridView, String id)
        {
            try
            {
                int i = 0;
                bunifuDataGridView.Rows.Clear();
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("select idachats , produit.idproduit , nomproduit   ,produitachte.prixachat ,qntachte , dateachat , nomfornissuer ,  achats.prixachat , achats.versment   from produitachte , produit , achats , fournissuer    where produitachte.idproduit = produit.idproduit and produitachte.idachats = achats.idachat and fournissuer.idfournisseur = achats.idfournissuer and produit.idproduit LIKE '%" + id + "%'  order by dateachat desc", Connexion.conn);
               SqlDataReader dr = sql.ExecuteReader();
                while (dr.Read())
                {

                    i++;


                    bunifuDataGridView.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString()  , DateTime.Parse(dr[5].ToString()).ToString("dd-MM | HH:mm"), dr[6].ToString(), dr[7].ToString(), dr[8].ToString());


                }
                Connexion.conn.Close();


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }




        }
        public static void loadproduitachtenomfournissuer(BunifuDataGridView bunifuDataGridView, String nomf)
        {
            try
            {
                int i = 0;
                bunifuDataGridView.Rows.Clear();
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("select idachats , produit.idproduit , nomproduit   ,produitachte.prixachat ,qntachte , dateachat , nomfornissuer ,  achats.prixachat , achats.versment  from produitachte , produit , achats , fournissuer     where produitachte.idproduit = produit.idproduit and produitachte.idachats = achats.idachat and fournissuer.idfournisseur = achats.idfournissuer and nomfornissuer LIKE '%" + nomf + "%'  order by dateachat desc", Connexion.conn);
                SqlDataReader dr = sql.ExecuteReader();
                while (dr.Read())
                {

                    i++;


                    bunifuDataGridView.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString() , DateTime.Parse(dr[5].ToString()).ToString("dd-MM | HH:mm"), dr[6].ToString() , dr[7].ToString(), dr[8].ToString());


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
