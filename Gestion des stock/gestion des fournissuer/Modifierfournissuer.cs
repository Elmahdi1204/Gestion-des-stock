using System;
using System.Windows.Forms;

namespace Gestion_des_stock.gestion_des_fournissuer
{
    public partial class Modifierfournissuer : Form
    {
        int id; String nom, prenom, num, entrp;

        private void bunifuButton25_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox1.Text == "" || bunifuTextBox2.Text == "" || bunifuTextBox3.Text == "" || bunifuTextBox5.Text == "")
            {
                MessageBox.Show("Esseye de ermplir tout les champs  ", "Erreur");

            }
            else
            {
                Datafournisseur.Modifierfournisseur(bunifuTextBox1.Text, bunifuTextBox2.Text, bunifuTextBox3.Text, bunifuTextBox5.Text, id);
                MessageBox.Show("Modifier avec success ", "Modifier un Fournissuer");

                bunifuTextBox1.Clear(); bunifuTextBox2.Clear(); bunifuTextBox5.Clear(); bunifuTextBox3.Clear();

                this.Close();
            }
        }

        public Modifierfournissuer(int id, String nom, String prenom, String num, String entrp)
        {
            InitializeComponent();
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.num = num;

            this.entrp = entrp;
        }

        private void Modifierfournissuer_Load(object sender, EventArgs e)
        {
            bunifuTextBox1.Text = nom;
            bunifuTextBox2.Text = prenom;
            bunifuTextBox3.Text = num;
            bunifuTextBox5.Text = entrp;


        }
    }
}
