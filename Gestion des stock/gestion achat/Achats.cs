using System;
using System.Drawing;
using System.Windows.Forms;

namespace Gestion_des_stock.gestion_achat
{
    public partial class Achats : UserControl
    {
        public Achats()
        {
            InitializeComponent();
            bunifuDropdown1.Text = "Numéro de Facture";
        }

        private void Achats_Load(object sender, EventArgs e)
        {
            Dataachats.Loadfacture(bunifuDataGridView1, bunifuTextBox1.Text);
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            Effectueruneachats effectueruneachats = new Effectueruneachats();
            effectueruneachats.Show();

        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            String k = bunifuDropdown1.Text;


            switch (k)
            {
                case "Numéro de Facture":

                    Dataachats.Loadfacture(bunifuDataGridView1, bunifuTextBox1.Text);

                    break;
                case "Nom de Fournisseur":
                    Dataachats.LoadfactureFournisseur(bunifuDataGridView1, bunifuTextBox1.Text);

                    break;
            }

        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {


            String k = bunifuDropdown1.Text;


            switch (k)
            {
                case "Numéro de Facture":

                    Dataachats.Loadfacture(bunifuDataGridView1, bunifuTextBox1.Text);

                    break;
                case "Nom de Fournisseur":
                    Dataachats.LoadfactureFournisseur(bunifuDataGridView1, bunifuTextBox1.Text);

                    break;
            }

        }

        private void bunifuDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = bunifuDataGridView1.Rows[e.RowIndex].Index;


                int id = int.Parse(bunifuDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                String Fournisseur = bunifuDataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                String totale = bunifuDataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

                String versment = bunifuDataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                String date = bunifuDataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

                Facture se = new Facture(id, Fournisseur, totale, versment, date);
                se.ShowDialog();
              
                bunifuButton22.PerformClick();
                bunifuDataGridView1.Rows[index].Selected = true;
            }
            catch
            {

            }
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

          
            int index = bunifuDataGridView1.Rows[e.RowIndex].Index;
           
            String colname = bunifuDataGridView1.Columns[e.ColumnIndex].Name;
            if (e.RowIndex < 0)
            {

            }
            else

            {
                if (colname == "Column7")
                {

                    int id = int.Parse(bunifuDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    int idclient = int.Parse(bunifuDataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
                    String totale = bunifuDataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

                    String versment = bunifuDataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    double paye = double.Parse(totale) - double.Parse(versment);
                    payecredit p = new payecredit(id, paye, idclient);
                    p.ShowDialog();
                    Dataachats.Loadfacture(bunifuDataGridView1, bunifuTextBox1.Text);

                    bunifuDataGridView1.Rows[index].Selected = true;
                }

            }
            }
            catch
            {

            }


        }

        private void bunifuDataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in bunifuDataGridView1.Rows)
            {

                double credit = Convert.ToDouble(row.Cells[4].Value);



                if (credit > 0 && bunifuToggleSwitch1.Checked == true)
                {

                    row.DefaultCellStyle.BackColor = Color.Red;
                }


                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }

            }
        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }
    }
}
