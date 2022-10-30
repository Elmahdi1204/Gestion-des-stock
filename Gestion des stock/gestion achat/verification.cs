using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;



namespace Gestion_des_stock.gestion_achat
{
    class verification
    {


        static SqlCommand sql;
        static SqlDataReader dr;
        public static void verifiercredit(int idachat, int idfournissuer, double prixachat, double versment)
        {
            Dataachats.AChat(idachat, idfournissuer, prixachat, versment, DateTime.Now);

            if (prixachat > versment)
            {

                MessageBox.Show("Ce fournisseur nous possède un crédit ", "Credit", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        public bool verifierlesock(long idprod)
        {
            List<string> listid = new List<string>();
            listid.Clear();
            bool find = false;
            int i = 0;

            Connexion.conn.Open();



            sql = new SqlCommand("Select idproduit from dbo.stock where idproduit='" + idprod + "'", Connexion.conn);
            dr = sql.ExecuteReader();
            while (dr.Read())
            {

                i++;


                listid.Add(dr[0].ToString());


            }
            Connexion.conn.Close();

            if (listid.Count == 0)
            {
                find = false;

            }
            else
            {
                find = true;
            }



            return find;

        }
        public static void modifierqnt(int qntachte, double prixachat, double prixvent, long idproduit)
        {
            Connexion.conn.Open();
            SqlCommand cm2 = new SqlCommand("Update dbo.stock SET qteproduit=qteproduit+'" + qntachte + "'  , prixachat='" + prixachat + "' ,prixvent='" + prixvent + "'  where idproduit='" + idproduit + "'", Connexion.conn);
            cm2.ExecuteNonQuery();
            Connexion.conn.Close();
        }

    }

}
