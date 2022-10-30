using Bunifu.UI.WinForms;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Gestion_des_stock.Gestion_des_utilisateur
{
    class Datauser
    {
        public static bool Login(String nomutilisateur, String motdepass)
        {
            try
            {

                Connexion.conn.Open();
                SqlCommand countmatier = new SqlCommand("Select * from Users where Nomutilisateur='" + nomutilisateur + "' and password ='" + motdepass + "' ", Connexion.conn);

                SqlDataReader dr = countmatier.ExecuteReader();

                bool find = false;
                if (dr.HasRows)
                {
                    find = true;
                    while (dr.Read())
                    {

                        Connexion.id = dr[0].ToString();
                        Connexion.mdps = dr[1].ToString();
                        Connexion.type = dr[2].ToString();
                    }

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

        public static void Ajouterusers(String nomutilisateur, String password, String type)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("insert into Users values('" + nomutilisateur + "' ,'" + password + "' ,'" + type + "')", Connexion.conn);
                sql.ExecuteNonQuery();
                Connexion.conn.Close();


            }
            catch (Exception e)
            {
                MessageBox.Show("Error", e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
            }
        }


        public static void changermotdepass(String nomutilisateur, String password)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("update Users set password ='" + password + "' where Nomutilisateur ='" + nomutilisateur + "'", Connexion.conn);
                sql.ExecuteNonQuery();
                Connexion.conn.Close();


            }
            catch (Exception e)
            {
                MessageBox.Show("Error", e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
            }
        }
        public static void supprimerutilisateur(String nomutilisateur)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("delete from users where Nomutilisateur ='" + nomutilisateur + "' ", Connexion.conn);
                sql.ExecuteNonQuery();
                Connexion.conn.Close();


            }
            catch (Exception e)
            {
                MessageBox.Show("Error", e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
            }
        }

        public static void Listdesutilisateurs(BunifuDataGridView bunifuDataGridView, String text, DateTime date1, DateTime date2)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("Select  Nomutilisateur , password  , type ,(select  count(idvants)from vents where users = Nomutilisateur and datevent between '" + date1 + "' and '" + date2 + "')  , (select  sum(prixtotale)from vents where users = Nomutilisateur and  datevent between '" + date1 + "' and '" + date2 + "') , (select  sum(qnteachte)from vents , produitvendu where produitvendu.idfacture = vents.idvants and  users = Nomutilisateur and  datevent between '" + date1 + "' and '" + date2 + "') from users ", Connexion.conn);
                SqlDataReader dr = sql.ExecuteReader();
                bunifuDataGridView.Rows.Clear();
                while (dr.Read())
                {
                    bunifuDataGridView.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[5], dr[4]);
                }
                Connexion.conn.Close();


            }
            catch (Exception e)
            {
                Connexion.conn.Close();
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
