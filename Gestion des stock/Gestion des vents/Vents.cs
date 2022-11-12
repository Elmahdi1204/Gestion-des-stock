using System;
using System.Drawing;
using System.Windows.Forms;

namespace Gestion_des_stock.Gestion_des_vents
{
    public partial class Vents : UserControl
    {
        public Vents()
        {
            InitializeComponent();
            bunifuDropdown1.Text = "Numéro de Facture";
            if (Connexion.type == "Employee")
            {
                bunifuDataGridView1.Columns[5].Visible = false;
                bunifuButton23.Visible = true;
                
            }
        }

        private void Vents_Load(object sender, EventArgs e)
        {
            Datavents.Loadvents(bunifuDataGridView1, bunifuTextBox1.Text);
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            Effectuerunevents f = new Effectuerunevents();
            f.Show();


        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            String k = bunifuDropdown1.Text;


            switch (k)
            {
                case "Numéro de Facture":

                    Datavents.Loadvents(bunifuDataGridView1, bunifuTextBox1.Text);

                    break;
                case "nom client":
                    Datavents.LoadventsClient(bunifuDataGridView1, bunifuTextBox1.Text);

                    break;
            }
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {
          
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
                String date = bunifuDataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();

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

          
            String colname = bunifuDataGridView1.Columns[e.ColumnIndex].Name;
            if (e.RowIndex < 0)
            {

            }
            else

            {
                if (colname == "Column8")
                {
                    int index = bunifuDataGridView1.Rows[e.RowIndex].Index;

                    int id = int.Parse(bunifuDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    int idclient = int.Parse(bunifuDataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString());
                    String totale = bunifuDataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

                    String versment = bunifuDataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    double paye = double.Parse(totale) - double.Parse(versment);
                    payercredit p = new payercredit(id, paye, idclient);
                    p.ShowDialog();
                    bunifuButton22.PerformClick();
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

        private void bunifuPanel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuToggleSwitch2_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuToggleSwitch.CheckedChangedEventArgs e)
        {
            if (bunifuToggleSwitch2.Checked == true)
            {
                bunifuDataGridView1.Columns[9].Visible = true;
            }
            else
            {
                bunifuDataGridView1.Columns[9].Visible = false;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuToggleSwitch1_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuToggleSwitch.CheckedChangedEventArgs e)
        {

        }

        private void bunifuButton23_Click(object sender, EventArgs e)
        {
            Gestion_des_charges.Ajoutercharges ajoutercharges = new Gestion_des_charges.Ajoutercharges();
            ajoutercharges.ShowDialog();
        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue==13)
            {
                String k = bunifuDropdown1.Text;


                switch (k)
                {
                    case "Numéro de Facture":

                        Datavents.Loadvents(bunifuDataGridView1, bunifuTextBox1.Text);

                        break;
                    case "nom client":
                        Datavents.LoadventsClient(bunifuDataGridView1, bunifuTextBox1.Text);

                        break;
                }

            }
        }

        private void bunifuButton24_Click(object sender, EventArgs e)
        {
            Toutlesproduitvendu toutlesproduitvendu = new Toutlesproduitvendu();
            toutlesproduitvendu.Show();
        }
    }
}
