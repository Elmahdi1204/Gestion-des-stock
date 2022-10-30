using System;
using System.Drawing;
using System.Windows.Forms;

namespace Gestion_des_stock.Gestion_des_client
{
    public partial class listdesclient : UserControl
    {
        public listdesclient()
        {
            InitializeComponent();
        }

        private void listdesclient_Load(object sender, EventArgs e)
        {
            Dataclients.Listdeclient(bunifuDataGridView1, bunifuTextBox1.Text);
        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            Dataclients.Listdeclient(bunifuDataGridView1, bunifuTextBox1.Text);

        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            Ajouterunclient ajouterunclient = new Ajouterunclient();
            ajouterunclient.ShowDialog();

        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {
            Dataclients.Listdeclient(bunifuDataGridView1, bunifuTextBox1.Text);
        }

        private void bunifuPanel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                String colname = bunifuDataGridView1.Columns[e.ColumnIndex].Name;

                int id = int.Parse(bunifuDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                double credit = double.Parse(bunifuDataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                String text = bunifuDataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                String nom = text.Substring(0, text.IndexOf(' '));

                String prenom = text.Substring(text.IndexOf(' '), text.Length - text.IndexOf(' '));

                String num = bunifuDataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                if (colname == "mod")
                {
                    Modifierclient modifierclient = new Modifierclient(id, nom, prenom, num);
                    modifierclient.ShowDialog();
                }
                if (colname == "sup")
                {
                    if (credit > 0)
                    {



                    }
                    else
                    {


                        DialogResult dialog = MessageBox.Show("Vous etes sur ?", "Supprimer un client", MessageBoxButtons.YesNo);
                        if (dialog == DialogResult.Yes)
                        {
                            Dataclients.Supprimerclient(id);
                            MessageBox.Show("Supprimer avec success", "Supprimer un client ");
                            Dataclients.Listdeclient(bunifuDataGridView1, bunifuTextBox1.Text);

                        }
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);

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

        private void bunifuPanel2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
