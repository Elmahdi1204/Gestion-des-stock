using System;
using System.Windows.Forms;

namespace Gestion_des_stock.gestion_achat
{
    public partial class Selectionerunfournissuer : Form
    {
        public Selectionerunfournissuer()
        {
            InitializeComponent();
        }

        private void Selectionerunfournissuer_Load(object sender, EventArgs e)
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
            Effectueruneachats.idfournissuer = int.Parse(bunifuDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            Effectueruneachats.nomfournissuer = bunifuDataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            MessageBox.Show("Fournisseur " + Effectueruneachats.nomfournissuer.ToUpper() + " selectioner avec success ", "selectioner avec success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.Close();

        }
    }
}
