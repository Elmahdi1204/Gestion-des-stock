using System;
using System.Windows.Forms;

namespace Gestion_des_stock.Gestion_des_vents
{
    public partial class Selectionerunclient : Form
    {
        public Selectionerunclient()
        {
            InitializeComponent();
        }

        private void bunifuDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Effectuerunevents.idclient = int.Parse(bunifuDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            Effectuerunevents.nomcleint = bunifuDataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            MessageBox.Show("Client " + Effectuerunevents.nomcleint.ToUpper() + " selectioner avec success ", "selectioner avec success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.Close();
        }

        private void Selectionerunclient_Load(object sender, EventArgs e)
        {

            Gestion_des_client.Dataclients.Listdeclient(bunifuDataGridView1, bunifuTextBox1.Text);
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            Gestion_des_client.Ajouterunclient ajouter = new Gestion_des_client.Ajouterunclient();
            ajouter.ShowDialog();
            Gestion_des_client.Dataclients.Listdeclient(bunifuDataGridView1, bunifuTextBox1.Text);
        }
    }
}
