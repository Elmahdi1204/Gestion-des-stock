using System;
using System.Windows.Forms;

namespace Gestion_des_stock.gestion_des_fournissuer
{
    public partial class Ajouterunfournissuer : Form
    {
        public Ajouterunfournissuer()
        {
            InitializeComponent();
        }

        private void bunifuButton25_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox1.Text == "" || bunifuTextBox2.Text == "" || bunifuTextBox5.Text == "")
            {
                MessageBox.Show("Esseye de ermplir tout les champs  ", "Erreur");

            }
            else
            {
                Datafournisseur.Ajouterfournissuer(bunifuTextBox1.Text, bunifuTextBox2.Text, bunifuTextBox3.Text, bunifuTextBox5.Text, DateTime.Now);
                MessageBox.Show("Ajouter avec success ", "Ajouter un client");

                bunifuTextBox1.Clear(); bunifuTextBox2.Clear(); bunifuTextBox5.Clear(); bunifuTextBox3.Clear();

                this.Close();
            }
        }
    }
}
