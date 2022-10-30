using System;
using System.Windows.Forms;

namespace Gestion_des_stock.Gestion_des_client
{
    public partial class Ajouterunclient : Form
    {
        public Ajouterunclient()
        {
            InitializeComponent();
        }

        private void bunifuButton25_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox1.Text == "" || bunifuTextBox2.Text == "" || bunifuTextBox3.Text == "")
            {
                MessageBox.Show("Esseye de ermplir tout les champs  ", "Erreur");

            }
            else
            {
                Dataclients.Ajouterclient(bunifuTextBox1.Text, bunifuTextBox2.Text, bunifuTextBox3.Text, DateTime.Now);
                MessageBox.Show("Ajouter avec success ", "Ajouter un client");

                bunifuTextBox1.Clear(); bunifuTextBox2.Clear(); bunifuTextBox3.Clear();

                this.Close();
            }
        }

        private void bunifuTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Ajouterunclient_Load(object sender, EventArgs e)
        {

        }
    }
}
