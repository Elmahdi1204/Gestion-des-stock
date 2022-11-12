using Bunifu.UI.WinForms;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Gestion_des_stock.Gestion_des_vents
{
    class Datavents

    {

        static SqlCommand cm;
        static SqlDataReader dr;
        public static void Loadproduitvent(BunifuDataGridView bunifuDataGridView, String txt)
        {
            try
            {
                int i = 0;
                bunifuDataGridView.Rows.Clear();
                Connexion.conn.Open();
                cm = new SqlCommand("select  dbo.stock.idproduit  ,dbo.Produit.nomproduit ,dbo.stock.qterest   , dbo.stock.prixvent from   dbo.Produit , dbo.stock where dbo.stock.idproduit = dbo.Produit.idproduit AND dbo.Produit.nomproduit LIKE '%" + txt + "%' ;", Connexion.conn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {

                    i++;


                    bunifuDataGridView.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());


                }
                Connexion.conn.Close();


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }




        }
        public static void Vents(int idvents, int idclient, double prixtotale, double versment, double benifice, DateTime date)
        {
            Connexion.conn.Open();
            SqlCommand cm2 = new SqlCommand("SET IDENTITY_INSERT dbo.vents ON  ", Connexion.conn);
            cm2.ExecuteNonQuery();

            cm = new SqlCommand("Insert into dbo.vents (idvants,idclient ,prixtotale,datevent  , versment , benifice  , users)values('" + idvents + "','" + idclient + "','" + prixtotale + "','" + date + "','" + versment + "','" + benifice + "','" + Connexion.id + "')  ;", Connexion.conn);
            cm.ExecuteNonQuery();
            Connexion.conn.Close();
        }
        public static void Produitvendu(int idfacture, long idproduit, double prix, int qnt, double prixqnt)
        {
            Connexion.conn.Open();
            cm = new SqlCommand("Insert into dbo.produitvendu (idfacture,idproduit , prixunit,qnteachte,prixqnte)values('" + idfacture + "','" + idproduit + "','" + prix + "','" + qnt + "', '" + prixqnt + "');", Connexion.conn);
            cm.ExecuteNonQuery();
            Connexion.conn.Close();
        }

        public static void Loadvents(BunifuDataGridView bunifuDataGridView, String txt)
        {
            try
            {
                int i = 0;
                bunifuDataGridView.Rows.Clear();
                Connexion.conn.Open();
                cm = new SqlCommand("select dbo.vents.idvants ,dbo.client.nomclient , dbo.vents.prixtotale ,dbo.vents.versment,dbo.vents.benifice ,  dbo.vents.datevent  , dbo.client.idclient , users , (select Count(produitvendu.id) from produitvendu where produitvendu.idfacture = vents.idvants) from dbo.vents ,dbo.client where dbo.client.idclient = dbo.vents.idclient AND   dbo.vents.idvants   Like '%" + txt + "%' ORDER BY dbo.vents.datevent DESC;", Connexion.conn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {

                    i++;

                    double credit = double.Parse(dr[2].ToString()) - double.Parse(dr[3].ToString());
                    bunifuDataGridView.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), credit, dr[4].ToString(), DateTime.Parse(dr[5].ToString()).ToString("dd-MM |  HH:mm"), dr[6], dr[8], dr[7]);


                }
                Connexion.conn.Close();


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        public static void LoadventsClient(BunifuDataGridView bunifuDataGridView, String txt)
        {
            try
            {
                int i = 0;
                bunifuDataGridView.Rows.Clear();
                Connexion.conn.Open();
                cm = new SqlCommand("select dbo.vents.idvants ,dbo.client.nomclient , dbo.vents.prixtotale ,dbo.vents.versment,dbo.vents.benifice ,  dbo.vents.datevent  , dbo.client.idclient , users , (select Count(produitvendu.id) from produitvendu where produitvendu.idfacture = vents.idvants)from dbo.vents ,dbo.client where dbo.client.idclient = dbo.vents.idclient AND   dbo.client.nomclient  Like '%" + txt + "%' ORDER BY dbo.vents.datevent DESC;", Connexion.conn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {

                    i++;

                    double credit = double.Parse(dr[2].ToString()) - double.Parse(dr[3].ToString());
                    bunifuDataGridView.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), credit, dr[4].ToString(), DateTime.Parse(dr[5].ToString()).ToString("dd-MM | HH:mm"), dr[6], dr[8], dr[7]);


                }
                Connexion.conn.Close();


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }




        }
        public static void Loadproduitvendudansfacture(BunifuDataGridView bunifuDataGridView, int id)
        {
            try
            {
                int i = 0;
                bunifuDataGridView.Rows.Clear();
                Connexion.conn.Open();
                cm = new SqlCommand("select   dbo.produit.idproduit ,  dbo.produit.nomproduit ,  dbo.produitvendu.prixunit, dbo.produitvendu.qnteachte ,  dbo.produitvendu.prixqnte from dbo.produitvendu , dbo.produit where dbo.produit.idproduit = dbo.produitvendu.idproduit AND  dbo.produitvendu.idfacture ='" + id + "';", Connexion.conn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {

                    i++;


                    bunifuDataGridView.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());



                }
                Connexion.conn.Close();


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }





        }
        public static void Loadproduitachtefacture(BunifuDataGridView bunifuDataGridView, int id)
        {
            try
            {
                int i = 0;
                bunifuDataGridView.Rows.Clear();
                Connexion.conn.Open();
                cm = new SqlCommand("select  dbo.produitachte.idproduit ,  dbo.produit.nomproduit ,  dbo.produitachte.prixachat, dbo.produitachte.qntachte ,  dbo.produitachte.prixqnt from dbo.produitachte , dbo.produit where dbo.produit.idproduit = dbo.produitachte.idproduit AND  dbo.produitachte.idachats ='" + id + "';", Connexion.conn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {

                    i++;


                    bunifuDataGridView.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());



                }
                Connexion.conn.Close();


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }





        }
        public static void payecredit(int id, double montant)
        {
            Connexion.conn.Open();


            cm = new SqlCommand("update dbo.vents  set versment =versment+'" + montant + "' where idvants='" + id + "' ", Connexion.conn);
            cm.ExecuteNonQuery();
            Connexion.conn.Close();
        }

    }

}
