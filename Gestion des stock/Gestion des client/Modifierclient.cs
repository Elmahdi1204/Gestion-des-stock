using System;
using System.Windows.Forms;

namespace Gestion_des_stock.Gestion_des_client
{
    public partial class Modifierclient : Form
    {
#pragma warning disable CS0169 // Le champ 'Modifierclient.credit' n'est jamais utilisé
        int id; String nom, prenom, num, credit;
#pragma warning restore CS0169 // Le champ 'Modifierclient.credit' n'est jamais utilisé

        private void bunifuTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton25_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox1.Text == "" || bunifuTextBox2.Text == "" || bunifuTextBox3.Text == "")
            {
                MessageBox.Show("Esseye de ermplir tout les champs  ", "Erreur");

            }
            else
            {
                Dataclients.ModifierClient(bunifuTextBox1.Text, bunifuTextBox2.Text, bunifuTextBox3.Text, id);
                MessageBox.Show("Ajouter avec success ", "Modifier un client");

                bunifuTextBox1.Clear(); bunifuTextBox2.Clear(); bunifuTextBox3.Clear();

                this.Close();
            }

        }

        public Modifierclient(int id, String nom, String prenom, String num)
        {
            InitializeComponent();
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.num = num;

        }

        private void Modifierclient_Load(object sender, EventArgs e)
        {
            bunifuTextBox1.Text = nom;
            bunifuTextBox2.Text = prenom;
            bunifuTextBox3.Text = num;

        }
    }
}
