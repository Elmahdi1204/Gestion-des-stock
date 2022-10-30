using System.Collections.Generic;
using System.Data.SqlClient;

namespace Gestion_des_stock.Gestion_des_vents
{
    class Routour
    {

#pragma warning disable CS0169 // Le champ 'Routour.cm' n'est jamais utilisé
        static SqlCommand cm;
#pragma warning restore CS0169 // Le champ 'Routour.cm' n'est jamais utilisé
        static SqlDataReader dr;


        public static void modifierlestock(long idproduit, int qnt)
        {
            Connexion.conn.Open();
            SqlCommand requet = new SqlCommand("update dbo.stock set qteproduit =qteproduit+'" + qnt + "'where idproduit ='" + idproduit + "' ; ", Connexion.conn);
            requet.ExecuteNonQuery();
            Connexion.conn.Close();
        }


        public static void modifierproduitvendu(long idproduit, int qnt, double prixqnt, int idfacture)
        {
            Connexion.conn.Open();
            SqlCommand requet = new SqlCommand("update dbo.produitvendu set qnteachte =qnteachte-'" + qnt + "' ,prixqnte =prixqnte-'" + prixqnt + "'   where idproduit ='" + idproduit + "' and idfacture ='" + idfacture + "' ; ", Connexion.conn);
            requet.ExecuteNonQuery();

            Connexion.conn.Close();
        }
        public static List<double> Getnewdata(int idvant)
        {
            Connexion.conn.Open();
            SqlCommand requet = new SqlCommand("select (select sum(prixqnte)from produitvendu where idfacture = idvants) , (select sum((produitvendu.prixunit)*produitvendu.qnteachte)- sum((stock.prixachat)*produitvendu.qnteachte)  from stock , produitvendu  where stock.idproduit= produitvendu.idproduit and idfacture =idvants) , versment  from vents where idvants ='" + idvant + "'", Connexion.conn);
            dr = requet.ExecuteReader();
            List<double> result = new List<double>();
            result.Clear();
            while (dr.Read())
            {
                if (dr[0].ToString() != "")
                {
                    result.Add(double.Parse(dr[0].ToString()));
                    result.Add(double.Parse(dr[1].ToString()));
                    result.Add(double.Parse(dr[2].ToString()));
                }

                result.Add(0);
                result.Add(0);
                result.Add(0);



            }

            Connexion.conn.Close();
            return result;
        }
        public static void Setnewdata(double prixtotal, double benifice, int idvant, double versment)
        {
            Connexion.conn.Open();
            SqlCommand sqlCommand = new SqlCommand("update vents set benifice = '" + benifice + "' , prixtotale = '" + prixtotal + "'  , versment = versment -'" + versment + "' where idvants ='" + idvant + "' ", Connexion.conn);
            sqlCommand.ExecuteNonQuery();

            Connexion.conn.Close();
        }



        public static int Getqnt(long idproduit)
        {
            Connexion.conn.Open();
            SqlCommand requet = new SqlCommand("select  qteproduit  from stock where idproduit ='" + idproduit + "' ; ", Connexion.conn);
            dr = requet.ExecuteReader();
            int qnt = 0;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    qnt = int.Parse(dr[0].ToString());
                }

            }
            else
            {
                qnt = 0;

            }

            Connexion.conn.Close();
            return qnt;

        }
    }
}
