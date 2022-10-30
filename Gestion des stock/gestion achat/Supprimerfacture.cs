using System.Data.SqlClient;

namespace Gestion_des_stock.gestion_achat
{
    class Supprimerfacture
    {
#pragma warning disable CS0169 // Le champ 'Supprimerfacture.cm' n'est jamais utilisé
        static SqlCommand cm;
#pragma warning restore CS0169 // Le champ 'Supprimerfacture.cm' n'est jamais utilisé
#pragma warning disable CS0169 // Le champ 'Supprimerfacture.dr' n'est jamais utilisé
        static SqlDataReader dr;
#pragma warning restore CS0169 // Le champ 'Supprimerfacture.dr' n'est jamais utilisé


        public static void supprimerfacture(int idvants)
        {
            Connexion.conn.Open();
            SqlCommand requet = new SqlCommand("delete from achats where idachat ='" + idvants + "' ", Connexion.conn);
            requet.ExecuteNonQuery();
            Connexion.conn.Close();
        }

        public static void deletefromproduitachte(long idproduit, int idfacture)
        {
            Connexion.conn.Open();
            SqlCommand requet = new SqlCommand("delete from produitachte where idproduit ='" + idproduit + "' and idachats  ='" + idfacture + "' ", Connexion.conn);
            requet.ExecuteNonQuery();
            Connexion.conn.Close();
        }
    }
}
