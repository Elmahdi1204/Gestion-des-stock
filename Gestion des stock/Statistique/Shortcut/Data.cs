using Bunifu.UI.WinForms;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Gestion_des_stock.Statistique.Shortcut
{
    class Data
    {
        public static void Loadvents(BunifuDataGridView bunifuDataGridView, String txt)
        {
            try
            {
                int i = 0;
                bunifuDataGridView.Rows.Clear();
                Connexion.conn.Open();
                SqlCommand cm = new SqlCommand("select dbo.vents.idvants ,dbo.client.nomclient , dbo.vents.prixtotale ,dbo.vents.versment,dbo.vents.benifice ,  dbo.vents.datevent  , dbo.client.idclient , users from dbo.vents ,dbo.client where dbo.client.idclient = dbo.vents.idclient and dbo.vents.prixtotale > dbo.vents.versment AND   dbo.vents.idvants   Like '%" + txt + "%' ORDER BY dbo.vents.datevent DESC;", Connexion.conn);
                SqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {

                    i++;

                    double credit = double.Parse(dr[2].ToString()) - double.Parse(dr[3].ToString());
                    bunifuDataGridView.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), credit, dr[4].ToString(), DateTime.Parse(dr[5].ToString()).ToString("dd-MM-yyyy"), dr[6], dr[7]);


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
