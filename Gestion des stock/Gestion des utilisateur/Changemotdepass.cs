using System;
using System.Windows.Forms;

namespace Gestion_des_stock.Gestion_des_utilisateur
{
    public partial class Changemotdepass : Form
    {
        public Changemotdepass(string nom)
        {
            InitializeComponent();
            bunifuTextBox1.Text = nom;
        }

        private void bunifuButton23_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox1.Text == "" || bunifuTextBox3.Text == "")
            {
                MessageBox.Show("Error", "Esseye de remplire tout les champs", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                Datauser.changermotdepass(bunifuTextBox1.Text, bunifuTextBox3.Text);
                MessageBox.Show("Changer avec  success", "Mot de pass changer avec  success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();



            }
        }

        private void bunifuPanel4_Click(object sender, EventArgs e)
        {

        }
    }
}
