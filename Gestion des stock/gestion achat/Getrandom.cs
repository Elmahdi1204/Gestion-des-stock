﻿using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Gestion_des_stock.gestion_achat
{
    class Getrandom
    {
        static SqlCommand sql;
        static SqlDataReader dr;
        public static int Getfournisseur()
        {

            try
            {


                Connexion.conn.Open();
                sql = new SqlCommand(" select * from fournissuer where nomfornissuer='Random' ;", Connexion.conn);
                dr = sql.ExecuteReader();
                int id = 0;
                while (dr.Read())
                {
                    if (dr[0].ToString() != "")
                    {
                        id = int.Parse(dr[0].ToString());
                    }
                }

                Connexion.conn.Close();
                return id;




            }
            catch (Exception e)
            {

                Connexion.conn.Close();
                MessageBox.Show(e.Message);
                return 0;

            }




        }
    }
}
