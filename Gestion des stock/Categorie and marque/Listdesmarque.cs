using System;
using System.Windows.Forms;

namespace Gestion_des_stock.Categorie_and_marque
{
    public partial class Listdesmarque : UserControl
    {
        public Listdesmarque()
        {
            InitializeComponent();
        }

        private void Listdesmarque_Load(object sender, EventArgs e)
        {
            Data.Loadmarque(bunifuDataGridView1, "");
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                String colname = bunifuDataGridView1.Columns[e.ColumnIndex].Name;

                int id = int.Parse(bunifuDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());


                int nb1 = int.Parse(bunifuDataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                int nb2 = int.Parse(bunifuDataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                if (colname == "supp")
                {
                    if (nb1 == 0 && nb2 == 0)
                    {

                        DialogResult dialog = MessageBox.Show("Vous etes sur ?", "Supprimer un client", MessageBoxButtons.YesNo);
                        if (dialog == DialogResult.Yes)
                        {
                            Data.Supprimerunemarque(id);
                            MessageBox.Show("Supprimer avec success", "Supprimer une marque ");
                            bunifuDataGridView1.Rows.RemoveAt(e.RowIndex);
                        }

                    }

                }
            }
            catch
            {

            }
        }
    }
}
