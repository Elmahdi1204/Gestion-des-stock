using Bunifu.UI.WinForms;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Gestion_des_stock.Categorie_and_marque
{

    class Data
    {

        static SqlCommand sql;
        static SqlDataReader dr;
        public static void Loadmarque(BunifuDataGridView bunifuDataGridView, String txt)
        {
            try
            {
#pragma warning disable CS0219 // La variable 'i' est assignée, mais sa valeur n'est jamais utilisée
                int i = 0;
#pragma warning restore CS0219 // La variable 'i' est assignée, mais sa valeur n'est jamais utilisée
                bunifuDataGridView.Rows.Clear();
                Connexion.conn.Open();
                sql = new SqlCommand("select idmarque , nommarque  , (select sum(stock.qteproduit) from stock , produit where produit.idproduit = stock.idproduit and produit.idmarque = marque.idmarque) , (select sum(produitvendu.qnteachte) from produitvendu , produit where produit.idproduit = produitvendu.idproduit and produit.idmarque = marque.idmarque) from marque  ", Connexion.conn);
                dr = sql.ExecuteReader();
                String nb = "0";
                String nb2 = "0";
                while (dr.Read())
                {

                    if (dr[3].ToString() == "")
                    {
                        nb = "0";
                    }
                    else
                    {
                        nb = dr[3].ToString();
                    }

                    if (dr[2].ToString() == "")
                    {
                        nb2 = "0";
                    }
                    else
                    {
                        nb2 = dr[2].ToString();
                    }

                    bunifuDataGridView.Rows.Add(dr[0].ToString(), dr[1].ToString(), nb2, nb);





                }
                Connexion.conn.Close();


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }




        }

        public static void Ajoutemarque(String nomarque)
        {
            Connexion.conn.Open();
            sql = new SqlCommand("INSERT INTO dbo.marque (nommarque   )VALUES ('" + nomarque + "')", Connexion.conn);
            sql.ExecuteNonQuery();
            Connexion.conn.Close();

        }
        public static void Supprimerunemarque(int id)
        {
            Connexion.conn.Open();
            sql = new SqlCommand("DELETE FROM dbo.marque WHERE idmarque='" + id + "' ", Connexion.conn);
            sql.ExecuteNonQuery();
            Connexion.conn.Close();

        }
        //Category
        public static void Loadcategorie(BunifuDataGridView bunifuDataGridView, String txt)
        {
            try
            {
#pragma warning disable CS0219 // La variable 'i' est assignée, mais sa valeur n'est jamais utilisée
                int i = 0;
#pragma warning restore CS0219 // La variable 'i' est assignée, mais sa valeur n'est jamais utilisée
                bunifuDataGridView.Rows.Clear();
                Connexion.conn.Open();
                sql = new SqlCommand("select idcategory , nomcategory  , (select sum(stock.qteproduit) from stock , produit where produit.idproduit = stock.idproduit and produit.idcategory = category.idcategory) , (select sum(produitvendu.qnteachte) from produitvendu , produit where produit.idproduit = produitvendu.idproduit and produit.idcategory = category.idcategory) from category ", Connexion.conn);
                dr = sql.ExecuteReader();
                String nb = "0";
                String nb2 = "0";
                while (dr.Read())
                {

                    if (dr[3].ToString() == "")
                    {
                        nb = "0";
                    }
                    else
                    {
                        nb = dr[3].ToString();
                    }
                    if (dr[2].ToString() == "")
                    {
                        nb2 = "0";
                    }
                    else
                    {
                        nb2 = dr[2].ToString();
                    }

                    bunifuDataGridView.Rows.Add(dr[0].ToString(), dr[1].ToString(), nb2, nb);





                }
                Connexion.conn.Close();


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }




        }

        public static void Ajoutercategory(String nomcat)
        {
            Connexion.conn.Open();
            sql = new SqlCommand("INSERT INTO dbo.category (nomcategory   )VALUES ('" + nomcat + "')", Connexion.conn);
            sql.ExecuteNonQuery();
            Connexion.conn.Close();

        }
        public static void Supprimercategory(int id)
        {
            Connexion.conn.Open();
            sql = new SqlCommand("DELETE FROM dbo.category WHERE idcategory='" + id + "' ", Connexion.conn);
            sql.ExecuteNonQuery();
            Connexion.conn.Close();

        }
    }
}
