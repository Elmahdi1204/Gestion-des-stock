using System;
using System.Windows.Forms;

namespace Gestion_des_stock.Gestion_des_charges
{
    public partial class Charges : UserControl
    {
        public Charges()
        {

            InitializeComponent();
            outils.autodate2(bunifuDatePicker1, bunifuDatePicker2);
            Datacharges.Listedescharges(bunifuDataGridView1, bunifuTextBox1.Text, bunifuDatePicker1.Value, bunifuDatePicker2.Value);
        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            Ajoutercharges ajouter = new Ajoutercharges();
            ajouter.ShowDialog();
            Datacharges.Listedescharges(bunifuDataGridView1, bunifuTextBox1.Text, bunifuDatePicker1.Value, bunifuDatePicker2.Value);
        }

        private void bunifuDatePicker1_ValueChanged(object sender, EventArgs e)
        {
            outils.autodate(bunifuDatePicker1, bunifuDatePicker2);
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {
            Datacharges.Listedescharges(bunifuDataGridView1, bunifuTextBox1.Text, bunifuDatePicker1.Value, bunifuDatePicker2.Value);
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                String colname = bunifuDataGridView1.Columns[e.ColumnIndex].Name;
                int idcharges = int.Parse(bunifuDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

                if (colname == "supp")
                {

                    DialogResult dialogResult = MessageBox.Show("Vous etes sur ?", "Supprimer un Charge", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        Datacharges.Deletecharges(idcharges);
                        Datacharges.Listedescharges(bunifuDataGridView1, bunifuTextBox1.Text, bunifuDatePicker1.Value, bunifuDatePicker2.Value);
                    }


                }
            }
#pragma warning disable CS0168 // La variable 'x' est déclarée, mais jamais utilisée
            catch (Exception x)
#pragma warning restore CS0168 // La variable 'x' est déclarée, mais jamais utilisée
            {

            }

        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            Datacharges.Listedescharges(bunifuDataGridView1, bunifuTextBox1.Text, bunifuDatePicker1.Value, bunifuDatePicker2.Value);
        }
    }
}
