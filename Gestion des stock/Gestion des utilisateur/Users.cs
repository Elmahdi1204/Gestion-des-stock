using System;
using System.Windows.Forms;

namespace Gestion_des_stock.Gestion_des_utilisateur
{
    public partial class Users : UserControl
    {
        public Users()
        {
            InitializeComponent();
            bunifuDatePicker1.Value = new DateTime(bunifuDatePicker1.Value.Year, bunifuDatePicker1.Value.Month, bunifuDatePicker1.Value.Day, 00, 00, 00);
            bunifuDatePicker2.Value = new DateTime(bunifuDatePicker2.Value.Year, bunifuDatePicker2.Value.Month, bunifuDatePicker2.Value.Day, 23, 59, 59);
            Datauser.Listdesutilisateurs(bunifuDataGridView1, bunifuTextBox1.Text, bunifuDatePicker1.Value, bunifuDatePicker2.Value);

        }

        private void bunifuPanel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuDatePicker1_ValueChanged(object sender, EventArgs e)
        {
            bunifuDatePicker1.Value = new DateTime(bunifuDatePicker1.Value.Year, bunifuDatePicker1.Value.Month, bunifuDatePicker1.Value.Day, 00, 00, 00);
        }

        private void bunifuDatePicker2_ValueChanged(object sender, EventArgs e)
        {
            bunifuDatePicker2.Value = new DateTime(bunifuDatePicker2.Value.Year, bunifuDatePicker2.Value.Month, bunifuDatePicker2.Value.Day, 23, 59, 59);
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            Datauser.Listdesutilisateurs(bunifuDataGridView1, bunifuTextBox1.Text, bunifuDatePicker1.Value, bunifuDatePicker2.Value);

        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            Ajouter ajouter = new Ajouter();
            ajouter.ShowDialog();
            Datauser.Listdesutilisateurs(bunifuDataGridView1, bunifuTextBox1.Text, bunifuDatePicker1.Value, bunifuDatePicker2.Value);


        }

        private void bunifuDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                String nometu = bunifuDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                Changemotdepass changemotdepass = new Changemotdepass(nometu);
                changemotdepass.ShowDialog();
            }
            catch
            {

            }
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                String colname = bunifuDataGridView1.Columns[e.ColumnIndex].Name;

                String nomet = bunifuDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

                if (colname == "supp")
                {



                    DialogResult dialog = MessageBox.Show("Vous etes sur ?", "Supprimer un utilisateur", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        Datauser.supprimerutilisateur(nomet);
                        MessageBox.Show("Supprimer avec success", "Supprimer un utilisateur ");
                        Datauser.Listdesutilisateurs(bunifuDataGridView1, bunifuTextBox1.Text, bunifuDatePicker1.Value, bunifuDatePicker2.Value);

                    }
                }
            }


            catch
            {

            }
        }
    }
}
