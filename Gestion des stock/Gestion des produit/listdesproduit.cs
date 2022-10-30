using System;
using System.Windows.Forms;

namespace Gestion_des_stock.Gestion_des_produit
{
    public partial class listdesproduit : UserControl
    {
        public listdesproduit()
        {
            InitializeComponent();
        }

        private void listdesproduit_Load(object sender, EventArgs e)
        {
            Dataproduit.Afficherlesproduit(bunifuDataGridView1, bunifuTextBox1.Text.Replace("'", "''"));
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {
            Dataproduit.Afficherlesproduit(bunifuDataGridView1, bunifuTextBox1.Text.Replace("'","''"));

        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            Dataproduit.Afficherlesproduit(bunifuDataGridView1, bunifuTextBox1.Text.Replace("'", "''"));

        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            Ajouterunproduit ajouterunproduit = new Ajouterunproduit();
            ajouterunproduit.ShowDialog();

        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
            DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ", "Supprimer un Produit", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                MessageBox.Show("Supprimer avec succes");
                Dataproduit.Afficherlesproduit(bunifuDataGridView1, bunifuTextBox1.Text);
               

            }
        }

        private void bunifuDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = bunifuDataGridView1.Rows[e.RowIndex].Index;
                long id = long.Parse(bunifuDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                String nom = bunifuDataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                Modifierproduit modifierproduit = new Modifierproduit(id, nom);
                modifierproduit.ShowDialog();
                Dataproduit.Afficherlesproduit(bunifuDataGridView1, bunifuTextBox1.Text.Replace("'", "''"));
                bunifuDataGridView1.Rows[index].Selected = true;

            }
            catch
            {

            }
        }

        private void bunifuDataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
