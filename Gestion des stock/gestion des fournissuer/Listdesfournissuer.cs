using System;
using System.Drawing;
using System.Windows.Forms;

namespace Gestion_des_stock.gestion_des_fournissuer
{
    public partial class Listdesfournissuer : UserControl
    {
        public Listdesfournissuer()
        {
            InitializeComponent();
        }

        private void Listdesfournissuer_Load(object sender, EventArgs e)
        {
            Datafournisseur.Loadfournissuer(bunifuDataGridView1, bunifuTextBox1.Text);
        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            Datafournisseur.Loadfournissuer(bunifuDataGridView1, bunifuTextBox1.Text);
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {
            Datafournisseur.Loadfournissuer(bunifuDataGridView1, bunifuTextBox1.Text);
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            Ajouterunfournissuer ajouterunfournissuer = new Ajouterunfournissuer();
            ajouterunfournissuer.ShowDialog();

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

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                String colname = bunifuDataGridView1.Columns[e.ColumnIndex].Name;

                int id = int.Parse(bunifuDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                double credit = double.Parse(bunifuDataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                String text = bunifuDataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                String nom = text.Substring(0, text.IndexOf(' '));

                String prenom = text.Substring(text.IndexOf(' '), text.Length - text.IndexOf(' '));

                String num = bunifuDataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                String entrp = bunifuDataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                if (colname == "mod")
                {
                    Modifierfournissuer modifierfournissuer = new Modifierfournissuer(id, nom, prenom, num, entrp);
                    modifierfournissuer.ShowDialog();
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
                            Datafournisseur.Supprimerfournisseur(id);
                            MessageBox.Show("Supprimer avec success", "Supprimer un Fournisseur ");
                            Datafournisseur.Loadfournissuer(bunifuDataGridView1, bunifuTextBox1.Text);

                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }
    }
}
