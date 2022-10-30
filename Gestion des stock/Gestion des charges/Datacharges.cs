using Bunifu.UI.WinForms;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Gestion_des_stock.Gestion_des_charges
{
    class Datacharges
    {
        public static void Ajouterunecharges(String description, double totale, DateTime date)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("insert into dbo.Charges (description , totale , date)values('" + description + "' , '" + totale + "', '" + date + "')", Connexion.conn);
                sql.ExecuteNonQuery();
                Connexion.conn.Close();


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
            }
        }
        public static void Deletecharges(int id)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("delete from charges where idcharges ='" + id + "' ;", Connexion.conn);
                sql.ExecuteNonQuery();
                Connexion.conn.Close();


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
            }
        }

        public static void Listedescharges(BunifuDataGridView bunifuDataGridView, String text, DateTime date1, DateTime date2)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("Select * from dbo.Charges  where  date between  '" + date1 + "' and   '" + date2.AddDays(1) + "' and   description Like '%" + text + "%' order by date desc; ", Connexion.conn);
                SqlDataReader dr = sql.ExecuteReader();
                bunifuDataGridView.Rows.Clear();
                while (dr.Read())
                {
                    bunifuDataGridView.Rows.Add(dr[0], dr[1], dr[2], DateTime.Parse(dr[3].ToString()).ToString("dd-MM-yyyy"));
                }
                Connexion.conn.Close();


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
            }
        }
    }
}
