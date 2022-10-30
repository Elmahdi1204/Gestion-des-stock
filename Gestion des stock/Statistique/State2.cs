using Bunifu.UI.WinForms;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Gestion_des_stock.Statistique
{
    class State2
    {
        static SqlCommand cm;
        static SqlDataReader dr;
        public static void Countclient(Label txt)
        {
            Connexion.conn.Open();
            cm = new SqlCommand("select count(idclient) from dbo.client ", Connexion.conn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                txt.Text = dr[0].ToString();
            }
            Connexion.conn.Close();

        }
        public static void countfournisseur(Label txt)
        {
            Connexion.conn.Open();
            cm = new SqlCommand("select count(idfournisseur) from dbo.fournissuer ", Connexion.conn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                txt.Text = dr[0].ToString();
            }
            Connexion.conn.Close();

        }
        public static void creditclient(BunifuDataGridView bunifuDataGridView)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand countmatier = new SqlCommand("select idclient ,CONCAT( nomclient ,' ',prenomclient) , (select sum(prixtotale - versment ) from vents where vents.idclient = client.idclient)as k , (select count(idvants) from vents   where  vents.idclient = client.idclient and (prixtotale - versment)>0 ) from  client where  (select sum(prixtotale - versment ) from vents where vents.idclient = client.idclient)>0 order by k desc", Connexion.conn);

                SqlDataReader dr = countmatier.ExecuteReader();


                bunifuDataGridView.Rows.Clear();


                while (dr.Read())
                {
                    if (dr[2].ToString() != "0" || dr[2].ToString() != "")
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


        public static void Creditfournissuer(BunifuDataGridView bunifuDataGridView)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand countmatier = new SqlCommand("select idfournisseur ,CONCAT( nomfornissuer ,' ',prenomfournissuer) , (select sum(prixachat - versment ) from achats where achats.idfournissuer = fournissuer.idfournisseur)as k , (select count(idachat) from achats   where  achats.idfournissuer = fournissuer.idfournisseur and (prixachat - versment)>0 ) from  fournissuer where  (select sum(prixachat - versment ) from achats where achats.idfournissuer = fournissuer.idfournisseur)>0 order by k desc", Connexion.conn);

                SqlDataReader dr = countmatier.ExecuteReader();


                bunifuDataGridView.Rows.Clear();


                while (dr.Read())
                {
                    if (dr[2].ToString() != "0" || dr[2].ToString() != "")
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
