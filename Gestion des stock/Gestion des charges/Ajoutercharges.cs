using System;
using System.Windows.Forms;

namespace Gestion_des_stock.Gestion_des_charges
{
    public partial class Ajoutercharges : Form
    {
        public Ajoutercharges()
        {
            InitializeComponent();
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox1.Text == "" || bunifuTextBox2.Text == "")
            {
                MessageBox.Show("Esseyé de remplire tout les champs", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Datacharges.Ajouterunecharges(bunifuTextBox1.Text, double.Parse(bunifuTextBox2.Text), bunifuDatePicker1.Value);
                MessageBox.Show("Charges ajouter avec success", "Ajouter avec success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bunifuTextBox1.Clear();

                bunifuTextBox2.Clear();
                this.Close();


            }
        }
    }
}
