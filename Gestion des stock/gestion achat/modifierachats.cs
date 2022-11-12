using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_des_stock.gestion_achat
{
    public partial class modifierachats : Form
    {
        int idachats = 0;
        public modifierachats(int idachat )
        {
            InitializeComponent();
            this.idachats = idachat;
        }

        private void modifierachats_Load(object sender, EventArgs e)
        {
            gestion_des_fournissuer.Datafournisseur.Loadfournissuer(bunifuDataGridView1, bunifuTextBox1.Text);


        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            gestion_des_fournissuer.Ajouterunfournissuer ajouterunfournissuer = new gestion_des_fournissuer.Ajouterunfournissuer();
            ajouterunfournissuer.ShowDialog();
            gestion_des_fournissuer.Datafournisseur.Loadfournissuer(bunifuDataGridView1, bunifuTextBox1.Text);
        }

        private void bunifuDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try

            {
                int idfournissuer = int.Parse(bunifuDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                 string nomfournissuer = bunifuDataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                MessageBox.Show("Fournisseur " + Effectueruneachats.nomfournissuer.ToUpper() + " selectioner avec success ", "selectioner avec success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                

                Connexion.conn.Open();
               SqlCommand sql = new SqlCommand("Update achats  SET idfournissuer='" + idfournissuer + "'  where idachat='" + idachats + "' ;", Connexion.conn);
                sql.ExecuteNonQuery();
                Connexion.conn.Close();
                this.Close();
            }
            catch
            {

            }
        }
    }
}
