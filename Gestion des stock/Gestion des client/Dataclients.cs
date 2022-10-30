using Bunifu.UI.WinForms;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Gestion_des_stock.Gestion_des_client
{

    class Dataclients
    {

        static SqlCommand sql;
        static SqlDataReader dr;
        public static void Listdeclient(BunifuDataGridView bunifuDataGridView, String txt)
        {
            try
            {
#pragma warning disable CS0219 // La variable 'i' est assignée, mais sa valeur n'est jamais utilisée
                int i = 0;
#pragma warning restore CS0219 // La variable 'i' est assignée, mais sa valeur n'est jamais utilisée
                bunifuDataGridView.Rows.Clear();
                Connexion.conn.Open();
                sql = new SqlCommand("select idclient , concat( nomclient  ,' ', prenomclient ) ,numtelephone ,(select sum(prixtotale - versment) from vents where vents.idclient = client.idclient) ,(select count(idvants) from vents where vents.idclient = client.idclient) from client where nomclient LIKE '%" + txt + "%' order by dateajout desc;", Connexion.conn);
                dr = sql.ExecuteReader();
                double credit = 0;
                double nb = 0;
                while (dr.Read())
                {


                    if (dr[3].ToString() == "")
                    {
                        credit = 0;
                    }
                    else
                    {
                        credit = double.Parse(dr[3].ToString());
                    }
                    if (dr[4].ToString() == "")
                    {
                        nb = 0;
                    }
                    else
                    {
                        nb = double.Parse(dr[4].ToString());
                    }


                    bunifuDataGridView.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), credit, nb);


                }
                Connexion.conn.Close();


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }




        }
        public static void Ajouterclient(String nom, String prenom, String num, DateTime date)
        {
            Connexion.conn.Open();
            sql = new SqlCommand("INSERT INTO dbo.client (nomclient , prenomclient , numtelephone  , dateajout )VALUES ('" + nom + "', '" + prenom + "','" + num + "','" + date.ToString("dd-MM-yyyy") + "')", Connexion.conn);
            sql.ExecuteNonQuery();
            Connexion.conn.Close();

        }
        public static void ModifierClient(String nom, String prenom, String num, int id)
        {
            Connexion.conn.Open();
            sql = new SqlCommand("Update dbo.client SET nomclient='" + nom + "' , prenomclient= '" + prenom + "' , numtelephone='" + num + "'  where idclient='" + id + "' ;", Connexion.conn);
            sql.ExecuteNonQuery();
            Connexion.conn.Close();

        }
        public static void Supprimerclient(int id)
        {
            Connexion.conn.Open();
            sql = new SqlCommand("DELETE FROM dbo.client WHERE idclient='" + id + "' ", Connexion.conn);
            sql.ExecuteNonQuery();
            Connexion.conn.Close();

        }
    }
}
