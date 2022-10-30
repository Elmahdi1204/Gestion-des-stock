using System;
using System.Windows.Forms;

namespace Gestion_des_stock.Categorie_and_marque
{
    public partial class Ajoutercategorie : Form
    {
        public Ajoutercategorie()
        {
            InitializeComponent();
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox1.Text == "")
            {
                MessageBox.Show("Essye de remplir tout les champs", "Message Erreur");
            }
            else
            {


                Data.Ajoutercategory(bunifuTextBox1.Text);
                MessageBox.Show("Ajouter Avec success", "Ajouter une categorie");



            }
        }

        private void bunifuButton25_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox2.Text == "")
            {
                MessageBox.Show("Essye de remplir tout les champs", "Message Erreur");
            }
            else
            {

                Data.Ajoutemarque(bunifuTextBox2.Text);
                MessageBox.Show("Ajouter Avec success", "Ajouter une Marque");

            }

        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
