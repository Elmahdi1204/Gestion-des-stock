using Bunifu.UI.WinForms;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Gestion_des_stock.gestion_achat
{
    class Getspecifiqueproduct

    {

        static SqlCommand sql;
        static SqlDataReader dr;
        public static void Getfromstock(long idprduit, BunifuTextBox nomproduit, BunifuTextBox prixachat, BunifuTextBox prixvent)
        {

            try
            {


                Connexion.conn.Open();
                sql = new SqlCommand(" select  dbo.stock.idproduit  ,dbo.Produit.nomproduit   , dbo.stock.prixachat , dbo.stock.prixvent  from   dbo.Produit , dbo.stock where dbo.stock.idproduit = dbo.Produit.idproduit and stock.idproduit  ='" + idprduit + "' ;", Connexion.conn);
                dr = sql.ExecuteReader();




                while (dr.Read())
                {
                    nomproduit.Text = dr[1].ToString();

                    prixachat.Text = dr[2].ToString();
                    prixvent.Text = dr[3].ToString();

                }

                Connexion.conn.Close();




            }
            catch (Exception e)
            {

                Connexion.conn.Close();
                MessageBox.Show(e.Message);

            }




        }

        public static bool find(long idprduit)
        {

            try
            {
                Connexion.conn.Open();
                sql = new SqlCommand(" select  dbo.stock.idproduit  ,dbo.Produit.nomproduit   , dbo.stock.prixachat , dbo.stock.prixvent  from   dbo.Produit , dbo.stock where dbo.stock.idproduit = dbo.Produit.idproduit and stock.idproduit ='" + idprduit + "' ;", Connexion.conn);
                dr = sql.ExecuteReader();
                bool find = false;

                if (dr.HasRows)
                {
                    find = true;

                }
                else
                {
                    find = false;


                }

                Connexion.conn.Close();
                return find;


            }
#pragma warning disable CS0168 // La variable 'e' est déclarée, mais jamais utilisée
            catch (Exception e)
#pragma warning restore CS0168 // La variable 'e' est déclarée, mais jamais utilisée
            {

                Connexion.conn.Close();
                return false;

            }

        }

        public static void Getfromproduit(long idprduit, BunifuTextBox nomproduit, BunifuTextBox prixachat, BunifuTextBox prixvent)
        {

            try
            {


                Connexion.conn.Open();
                sql = new SqlCommand(" select  *  from   dbo.Produit  where idproduit  ='" + idprduit + "' ;", Connexion.conn);
                dr = sql.ExecuteReader();


                if (dr.HasRows)
                {




                    while (dr.Read())
                    {
                        nomproduit.Text = dr[1].ToString();

                        prixachat.Text = "";
                        prixvent.Text = "";

                    }
                }
                else
                {

                    nomproduit.Text = "";

                    prixachat.Text = "";
                    prixvent.Text = "";
                }

                Connexion.conn.Close();




            }
            catch (Exception e)
            {

                Connexion.conn.Close();
                MessageBox.Show(e.Message);

            }




        }
        public static bool findfromproduit(long idprduit)
        {

            try
            {
                Connexion.conn.Open();
                sql = new SqlCommand(" select * from   dbo.Produit  where idproduit ='" + idprduit + "' ;", Connexion.conn);
                dr = sql.ExecuteReader();
                bool find = false;

                if (dr.HasRows)
                {
                    find = true;

                }
                else
                {
                    find = false;


                }

                Connexion.conn.Close();
                return find;


            }
#pragma warning disable CS0168 // La variable 'e' est déclarée, mais jamais utilisée
            catch (Exception e)
#pragma warning restore CS0168 // La variable 'e' est déclarée, mais jamais utilisée
            {

                Connexion.conn.Close();
                return false;

            }

        }
    }
}
