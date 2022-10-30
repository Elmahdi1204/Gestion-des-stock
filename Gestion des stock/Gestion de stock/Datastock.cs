using Bunifu.UI.WinForms;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Gestion_des_stock.Gestion_de_stock
{
    class Datastock
    {

        static SqlCommand sql;
        static SqlDataReader dr;
        public static void LoadStocks(BunifuDataGridView bunifuDataGridView, String txt)
        {
            try
            {

                bunifuDataGridView.Rows.Clear();
                Connexion.conn.Open();
                sql = new SqlCommand("select  dbo.stock.idproduit  ,dbo.Produit.nomproduit  , dbo.stock.qteproduit , dbo.stock.prixachat , dbo.stock.prixvent , dbo.category.nomcategory, dbo.marque.nommarque , (select top 1 nomfornissuer from achats , produitachte , fournissuer where achats.idfournissuer = fournissuer.idfournisseur  and produitachte.idachats =achats.idachat and produitachte.idproduit =produit.idproduit order by achats.dateachat desc ) from  dbo.marque , dbo.category ,  dbo.Produit , dbo.stock where dbo.stock.idproduit = dbo.Produit.idproduit and dbo.produit.idcategory =dbo.category.idcategory AND dbo.produit.idmarque =dbo.marque.idmarque  AND dbo.stock.idproduit LIKE '%" + txt + "%' ;", Connexion.conn);
                dr = sql.ExecuteReader();
                while (dr.Read())
                {




                    bunifuDataGridView.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString() , dr[7]);


                }
                Connexion.conn.Close();


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }




        }
        public static void LoadStocksNOM(BunifuDataGridView bunifuDataGridView, String txt)
        {
            try
            {

                bunifuDataGridView.Rows.Clear();
                Connexion.conn.Open();
                sql = new SqlCommand("select  dbo.stock.idproduit  ,dbo.Produit.nomproduit  , dbo.stock.qteproduit , dbo.stock.prixachat , dbo.stock.prixvent , dbo.category.nomcategory, dbo.marque.nommarque ,(select top 1 nomfornissuer from achats , produitachte , fournissuer where achats.idfournissuer = fournissuer.idfournisseur  and produitachte.idachats =achats.idachat and produitachte.idproduit =produit.idproduit order by achats.dateachat desc )  from  dbo.marque , dbo.category ,  dbo.Produit , dbo.stock where dbo.stock.idproduit = dbo.Produit.idproduit and dbo.produit.idcategory =dbo.category.idcategory AND dbo.produit.idmarque =dbo.marque.idmarque  AND dbo.Produit.nomproduit LIKE '%" + txt + "%' ;", Connexion.conn);
                dr = sql.ExecuteReader();
                while (dr.Read())
                {




                    bunifuDataGridView.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString() , dr[7]);


                }
                Connexion.conn.Close();


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }




        }
        public static void LoadStocksCategorie(BunifuDataGridView bunifuDataGridView, String txt)
        {
            try
            {

                bunifuDataGridView.Rows.Clear();
                Connexion.conn.Open();
                sql = new SqlCommand("select  dbo.stock.idproduit  ,dbo.Produit.nomproduit  , dbo.stock.qteproduit , dbo.stock.prixachat , dbo.stock.prixvent , dbo.category.nomcategory, dbo.marque.nommarque ,(select top 1 nomfornissuer from achats , produitachte , fournissuer where achats.idfournissuer = fournissuer.idfournisseur  and produitachte.idachats =achats.idachat and produitachte.idproduit =produit.idproduit order by achats.dateachat desc )  from  dbo.marque , dbo.category ,  dbo.Produit , dbo.stock where dbo.stock.idproduit = dbo.Produit.idproduit and dbo.produit.idcategory =dbo.category.idcategory AND dbo.produit.idmarque =dbo.marque.idmarque  AND dbo.category.nomcategory LIKE '%" + txt + "%' ;", Connexion.conn);
                dr = sql.ExecuteReader();
                while (dr.Read())
                {




                    bunifuDataGridView.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString() , dr[7]);


                }
                Connexion.conn.Close();


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }




        }
        public static void LoadStocksmarque(BunifuDataGridView bunifuDataGridView, String txt)
        {
            try
            {

                bunifuDataGridView.Rows.Clear();
                Connexion.conn.Open();
                sql = new SqlCommand("select  dbo.stock.idproduit  ,dbo.Produit.nomproduit  , dbo.stock.qteproduit , dbo.stock.prixachat , dbo.stock.prixvent , dbo.category.nomcategory, dbo.marque.nommarque  , (select top 1 nomfornissuer from achats , produitachte , fournissuer where achats.idfournissuer = fournissuer.idfournisseur  and produitachte.idachats =achats.idachat and produitachte.idproduit =produit.idproduit order by achats.dateachat desc ) from  dbo.marque , dbo.category ,  dbo.Produit , dbo.stock where dbo.stock.idproduit = dbo.Produit.idproduit and dbo.produit.idcategory =dbo.category.idcategory AND dbo.produit.idmarque =dbo.marque.idmarque  AND dbo.marque.nommarque LIKE '%" + txt + "%' ;", Connexion.conn);
                dr = sql.ExecuteReader();
                while (dr.Read())
                {




                    bunifuDataGridView.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString() , dr[7]);


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
