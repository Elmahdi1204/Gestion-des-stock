using System.Collections.Generic;
using System.Data.SqlClient;

namespace Gestion_des_stock.gestion_achat
{
    class Roteur
    {
        static SqlDataReader dr;

        public static void modifierlestock(long idproduit, int qnt)
        {
            Connexion.conn.Open();
            SqlCommand requet = new SqlCommand("update dbo.stock set qteproduit =qteproduit-'" + qnt + "'where idproduit ='" + idproduit + "' ; ", Connexion.conn);
            requet.ExecuteNonQuery();
            Connexion.conn.Close();
        }


        public static void modifierproduitachte(long idproduit, int qnt, double prixqnt, int idfacture)
        {
            Connexion.conn.Open();
            SqlCommand requet = new SqlCommand("update dbo.produitachte set qntachte =qntachte-'" + qnt + "' ,prixqnt =prixqnt-'" + prixqnt + "'   where idproduit ='" + idproduit + "' and idachats ='" + idfacture + "' ; ", Connexion.conn);
            requet.ExecuteNonQuery();

            Connexion.conn.Close();
        }
        public static List<double> Getnewdata(int idachat)
        {
            Connexion.conn.Open();
            SqlCommand requet = new SqlCommand("select (select sum(prixqnt)from produitachte where idachats = idachat) , versment  from achats where idachat ='" + idachat + "'", Connexion.conn);
            dr = requet.ExecuteReader();
            List<double> result = new List<double>();
            result.Clear();
            while (dr.Read())
            {
                if (dr[0].ToString() != "")
                {
                    result.Add(double.Parse(dr[0].ToString()));
                    result.Add(double.Parse(dr[1].ToString()));

                }

                result.Add(0);
                result.Add(0);




            }

            Connexion.conn.Close();
            return result;
        }
        public static void Setnewdata(double prixtotal, int idvant, double versment)
        {
            Connexion.conn.Open();
            SqlCommand sqlCommand = new SqlCommand("update achats set  prixachat = '" + prixtotal + "'  , versment = versment -'" + versment + "' where idachat ='" + idvant + "' ", Connexion.conn);
            sqlCommand.ExecuteNonQuery();

            Connexion.conn.Close();
        }


    }
}
