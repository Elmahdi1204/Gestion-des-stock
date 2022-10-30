using System;
using System.Windows.Forms;

namespace Gestion_des_stock.Statistique.Shortcut
{
    public partial class FacturCredit : Form
    {
        public FacturCredit()
        {
            InitializeComponent();
        }

        private void FacturCredit_Load(object sender, EventArgs e)
        {
            Data.Loadvents(bunifuDataGridView1, bunifuTextBox1.Text);
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String colname = bunifuDataGridView1.Columns[e.ColumnIndex].Name;
            if (e.RowIndex < 0)
            {

            }
            else

            {
                if (colname == "Column8")
                {

                    int id = int.Parse(bunifuDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    int idclient = int.Parse(bunifuDataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString());
                    String totale = bunifuDataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

                    String versment = bunifuDataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    double paye = double.Parse(totale) - double.Parse(versment);
                    Gestion_des_vents.payercredit p = new Gestion_des_vents.payercredit(id, paye, idclient);
                    p.ShowDialog();

                }


            }
        }
    }
}
