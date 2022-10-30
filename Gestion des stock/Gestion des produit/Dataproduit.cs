using Bunifu.UI.WinForms;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Gestion_des_stock.Gestion_des_produit
{

    class Dataproduit
    {

        static SqlCommand sql;
        static SqlDataReader dr;



        public static void Ajouterproduit(String nomprod, int idmarque, int idcat, long idproduit)
        {
            try
            {
                Connexion.conn.Open();
                sql = new SqlCommand("insert into dbo.produit (idproduit , nomproduit,idmarque , idcategory)values ('" + idproduit + "' , '" + nomprod.Replace("'", "''") + "' , '" + idmarque + "', '" + idcat + "')", Connexion.conn);
                sql.ExecuteNonQuery();
                Connexion.conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message); Connexion.conn.Close();
            }



        }
        public static void Supprimerproduit(int id)
        {
            try
            {


                Connexion.conn.Open();
                sql = new SqlCommand("DELETE FROM  dbo.Produit where idproduit ='" + id + "'", Connexion.conn);
                sql.ExecuteNonQuery();
                Connexion.conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Connexion.conn.Close();
            }

        }
        public static void Afficherlesproduit(BunifuDataGridView bunifuDataGridView, String txt)
        {
            try
            {
                int i = 0;
                bunifuDataGridView.Rows.Clear();
                Connexion.conn.Open();
                sql = new SqlCommand("select idproduit , nomproduit , nomcategory ,nommarque from dbo.produit , dbo.marque , dbo.category where dbo.produit.idcategory =dbo.category.idcategory AND dbo.produit.idmarque =dbo.marque.idmarque AND nomproduit LIKE '%" + txt + "%' ;", Connexion.conn);
                dr = sql.ExecuteReader();
                while (dr.Read())
                {

                    i++;


                    bunifuDataGridView.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());


                }
                Connexion.conn.Close();


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Connexion.conn.Close();
            }




        }
        public static void Modifierproduit(String nom, int idcategory, int idmarque, long id)
        {
            try
            {
                Connexion.conn.Open();
                sql = new SqlCommand("Update dbo.produit SET nomproduit='" + nom.Replace("'", "''") + "' , idcategory= '" + idcategory + "' , idmarque='" + idmarque + "'  where idproduit='" + id + "' ;", Connexion.conn);
                sql.ExecuteNonQuery();
                Connexion.conn.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Connexion.conn.Close();
            }

        }

    }

}
