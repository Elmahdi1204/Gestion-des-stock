using System.Data.SqlClient;

namespace Gestion_des_stock.Gestion_des_vents
{
    class supprimerunefacture
    {

#pragma warning disable CS0169 // Le champ 'supprimerunefacture.cm' n'est jamais utilisé
        static SqlCommand cm;
#pragma warning restore CS0169 // Le champ 'supprimerunefacture.cm' n'est jamais utilisé
#pragma warning disable CS0169 // Le champ 'supprimerunefacture.dr' n'est jamais utilisé
        static SqlDataReader dr;
#pragma warning restore CS0169 // Le champ 'supprimerunefacture.dr' n'est jamais utilisé


        public static void supprimerfacture(int idvants)
        {
            Connexion.conn.Open();
            SqlCommand requet = new SqlCommand("delete from vents where idvants ='" + idvants + "' ", Connexion.conn);
            requet.ExecuteNonQuery();
            Connexion.conn.Close();
        }

        public static void deletefromproduitvendu(long idproduit, int idfacture)
        {
            Connexion.conn.Open();
            SqlCommand requet = new SqlCommand("delete from produitvendu where idproduit ='" + idproduit + "' and idfacture  ='" + idfacture + "' ", Connexion.conn);
            requet.ExecuteNonQuery();
            Connexion.conn.Close();
        }

    }
}
