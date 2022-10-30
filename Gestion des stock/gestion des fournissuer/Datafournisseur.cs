using Bunifu.UI.WinForms;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Gestion_des_stock.gestion_des_fournissuer
{
    class Datafournisseur
    {

        static SqlCommand sql;
        static SqlDataReader dr;
        public static void Loadfournissuer(BunifuDataGridView bunifuDataGridView, String txt)
        {
            try
            {
#pragma warning disable CS0219 // La variable 'i' est assignée, mais sa valeur n'est jamais utilisée
                int i = 0;
#pragma warning restore CS0219 // La variable 'i' est assignée, mais sa valeur n'est jamais utilisée
                bunifuDataGridView.Rows.Clear();
                Connexion.conn.Open();
                sql = new SqlCommand("select idfournisseur , concat( nomfornissuer  ,' ', prenomfournissuer ), entrprise ,telephone ,(select sum(prixachat - versment) from achats where achats.idfournissuer = fournissuer.idfournisseur) ,(select count(idachat) from achats where achats.idfournissuer = fournissuer.idfournisseur) from fournissuer where nomfornissuer LIKE '%" + txt + "%' order by dateajout desc", Connexion.conn);
                dr = sql.ExecuteReader();
                double credit = 0;
                double nb = 0;
                while (dr.Read())
                {

                    if (dr[4].ToString() == "")
                    {
                        credit = 0;
                    }
                    else
                    {
                        credit = double.Parse(dr[4].ToString());
                    }
                    if (dr[5].ToString() == "")
                    {
                        nb = 0;
                    }
                    else
                    {
                        nb = double.Parse(dr[5].ToString());
                    }



                    bunifuDataGridView.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), credit, nb);


                }
                Connexion.conn.Close();


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }




        }

        public static void Ajouterfournissuer(String nom, String prenom, String tele, String entrp, DateTime date)
        {
            Connexion.conn.Open();
            sql = new SqlCommand("INSERT INTO dbo.fournissuer (nomfornissuer , prenomfournissuer , telephone , entrprise ,dateajout   )VALUES ('" + nom + "', '" + prenom + "','" + tele + "','" + entrp + "','" + date.ToString("dd-MM-yyyy") + "')", Connexion.conn);
            sql.ExecuteNonQuery();
            Connexion.conn.Close();


        }
        public static void Modifierfournisseur(String nom, String prenom, String tele, String entrp, int id)
        {
            Connexion.conn.Open();
            sql = new SqlCommand("Update dbo.fournissuer SET nomfornissuer='" + nom + "' , prenomfournissuer= '" + prenom + "' , telephone='" + tele + "', entrprise='" + entrp + "' where idfournisseur='" + id + "' ;", Connexion.conn);
            sql.ExecuteNonQuery();
            Connexion.conn.Close();

        }
        public static void Supprimerfournisseur(int id)
        {
            Connexion.conn.Open();
            sql = new SqlCommand("DELETE FROM dbo.fournissuer WHERE idfournisseur='" + id + "' ", Connexion.conn);
            sql.ExecuteNonQuery();
            Connexion.conn.Close();

        }
    }
}
