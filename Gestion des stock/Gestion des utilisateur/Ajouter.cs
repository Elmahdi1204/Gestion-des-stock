using System;
using System.Windows.Forms;

namespace Gestion_des_stock.Gestion_des_utilisateur
{
    public partial class Ajouter : Form
    {
        public Ajouter()
        {
            InitializeComponent();
        }

        private void bunifuButton23_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox1.Text == "" || bunifuTextBox2.Text == "" || bunifuDropdown2.Text == "")
            {
                MessageBox.Show("Error", "Esseye de remplire tout les champs", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                Datauser.Ajouterusers(bunifuTextBox1.Text, bunifuTextBox2.Text, bunifuDropdown2.Text);
                MessageBox.Show("Ajouter avec success", "Utilisateur ajouter  avec success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bunifuTextBox1.Clear();
                bunifuTextBox2.Clear();
                bunifuDropdown2.Text = "";
                this.Close();


            }
        }
    }
}
