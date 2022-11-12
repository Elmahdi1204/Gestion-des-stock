using Bunifu.UI.WinForms;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Gestion_des_stock.gestion_achat
{
    class Dataachats
    {

        static SqlCommand sql;
        static SqlDataReader dr;
        public static void AChat(int idachat, int idfourn, double prixachat, double versment, DateTime dateachat)
        {
            Connexion.conn.Open();
            sql = new SqlCommand("Insert into dbo.achats (idachat,idfournissuer ,prixachat,dateachat  , versment)values('" + idachat + "','" + idfourn + "','" + prixachat + "','" + dateachat + "','" + versment + "')  ;", Connexion.conn);
            sql.ExecuteNonQuery();
            Connexion.conn.Close();
        }
        public static void Produitachate(long idprod, double prixachat, int qnt, double prixqnt, int idachat)
        {
            Connexion.conn.Open();
            sql = new SqlCommand("Insert into dbo.produitachte (idproduit,prixachat , qntachte,prixqnt,idachats)values('" + idprod + "','" + prixachat + "','" + qnt + "','" + prixqnt + "', '" + idachat + "');", Connexion.conn);
            sql.ExecuteNonQuery();
            Connexion.conn.Close();
        }
        public static void Ajouteraustock(long idproduit, int qnteproduit, double prixachat, double prixvent, String place)
        {

            Connexion.conn.Open();


            sql = new SqlCommand("Insert into dbo.stock (idproduit,qteproduit ,prixachat,prixvent,place)values('" + idproduit + "','" + qnteproduit + "','" + prixachat + "', '" + prixvent + "', '" + place + "');", Connexion.conn);
            sql.ExecuteNonQuery();
            Connexion.conn.Close();
        }
        public static void Loadfacture(BunifuDataGridView bunifuDataGridView, String txt)
        {
            try
            {
                int i = 0;
                bunifuDataGridView.Rows.Clear();
                Connexion.conn.Open();
                sql = new SqlCommand(" select dbo.achats.idachat , dbo.fournissuer.nomfornissuer , dbo.achats.prixachat , dbo.achats.versment ,dbo.achats.dateachat , dbo.fournissuer.idfournisseur , (select Count(produitachte.id) from produitachte , produit where produitachte.idachats = achats.idachat  and produitachte.idproduit = produit.idproduit)   from dbo.achats , dbo.fournissuer where dbo.fournissuer.idfournisseur= dbo.achats.idfournissuer and dbo.achats.idachat  LIKE '%" + txt + "%'      ORDER BY  dbo.achats.dateachat DESC ;", Connexion.conn);
                dr = sql.ExecuteReader();
                while (dr.Read())
                {

                    i++;
                    double credit = double.Parse(dr[2].ToString()) - double.Parse(dr[3].ToString());

                    bunifuDataGridView.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), credit, DateTime.Parse(dr[4].ToString()).ToString("dd-MM | HH:mm"), dr[5], dr[6]);


                }
                Connexion.conn.Close();


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }




        }
        public static void LoadfactureFournisseur(BunifuDataGridView bunifuDataGridView, String txt)
        {
            try
            {
                int i = 0;
                bunifuDataGridView.Rows.Clear();
                Connexion.conn.Open();
                sql = new SqlCommand(" select dbo.achats.idachat , dbo.fournissuer.nomfornissuer , dbo.achats.prixachat , dbo.achats.versment ,dbo.achats.dateachat , dbo.fournissuer.idfournisseur  ,(select Count(produitachte.id) from produitachte , produit where produitachte.idachats = achats.idachat  and produitachte.idproduit = produit.idproduit)  from dbo.achats , dbo.fournissuer where dbo.fournissuer.idfournisseur= dbo.achats.idfournissuer and dbo.fournissuer.nomfornissuer  LIKE '%" + txt + "%'      ORDER BY  dbo.achats.dateachat DESC ;", Connexion.conn);
                dr = sql.ExecuteReader();
                while (dr.Read())
                {

                    i++;
                    double credit = double.Parse(dr[2].ToString()) - double.Parse(dr[3].ToString());

                    bunifuDataGridView.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), credit, DateTime.Parse(dr[4].ToString()).ToString("dd-MM | HH:mm"), dr[5], dr[6]);


                }
                Connexion.conn.Close();


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }




        }
        public static void LoadListdesachats(BunifuDataGridView bunifuDataGridView, int id)
        {
            try
            {
                int i = 0;
                bunifuDataGridView.Rows.Clear();
                Connexion.conn.Open();
                sql = new SqlCommand("select  dbo.Produit.idproduit  ,dbo.Produit.nomproduit , dbo.produitachte.prixachat , dbo.produitachte.qntachte , dbo.produitachte.prixqnt from dbo.produitachte , dbo.Produit , dbo.achats where dbo.achats.idachat = dbo.produitachte.idachats and dbo.produitachte.idproduit= dbo.Produit.idproduit and  dbo.produitachte.idachats='" + id + "' ;", Connexion.conn);
                dr = sql.ExecuteReader();
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


            sql = new SqlCommand("update dbo.achats  set versment =versment+'" + montant + "' where idachat='" + id + "' ", Connexion.conn);
            sql.ExecuteNonQuery();
            Connexion.conn.Close();
        }
        public static bool verifiercle(int id)
        {
            try
            {


                Connexion.conn.Open();
                sql = new SqlCommand("select * from  dbo.achats where idachat='" + id + "' ;", Connexion.conn);
                dr = sql.ExecuteReader();
                bool find = false;
                if (dr.HasRows)
                {
                    find = true;
                }
                Connexion.conn.Close();
                return find;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }




        }
    }
}
