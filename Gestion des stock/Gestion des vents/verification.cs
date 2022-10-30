using System;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Gestion_des_stock.Gestion_des_vents
{
    class verification
    {

#pragma warning disable CS0169 // Le champ 'verification.sql' n'est jamais utilisé
        static SqlCommand sql;
#pragma warning restore CS0169 // Le champ 'verification.sql' n'est jamais utilisé
#pragma warning disable CS0169 // Le champ 'verification.dr' n'est jamais utilisé
        static SqlDataReader dr;
#pragma warning restore CS0169 // Le champ 'verification.dr' n'est jamais utilisé
        public static void verifiercredit(int idvent, int idclient, double prixachat, double benifice, double versment)
        {
            Datavents.Vents(idvent, idclient, prixachat, versment, benifice, DateTime.Now);

            if (prixachat > versment)
            {

                MessageBox.Show("Ce client  possède un crédit ", "Credit", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public static void modifierlestock(long idproduit, int qnt)
        {
            Connexion.conn.Open();
            SqlCommand requet = new SqlCommand("update dbo.stock set qteproduit =qteproduit-'" + qnt + "'where idproduit ='" + idproduit + "' ; ", Connexion.conn);
            requet.ExecuteNonQuery();
            Connexion.conn.Close();
        }
    }
}
