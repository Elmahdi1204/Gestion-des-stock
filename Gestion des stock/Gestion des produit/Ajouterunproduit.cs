using System;
using System.Windows.Forms;

namespace Gestion_des_stock.Gestion_des_produit
{
    public partial class Ajouterunproduit : Form
    {
        public Ajouterunproduit()
        {
            InitializeComponent();
            bunifuDropdown1.Text = "Selectioner la catagerie ";
            bunifuDropdown2.Text = "Selectioner la marque";


        }




        private void Ajouterunproduit_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'dataDataSet1.marque'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.marqueTableAdapter.Fill(this.dataDataSet1.marque);
            // TODO: cette ligne de code charge les données dans la table 'dataDataSet.category'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.categoryTableAdapter.Fill(this.dataDataSet.category);


        }

        private void bunifuButton25_Click(object sender, EventArgs e)
        {
            if (bunifuDropdown1.Text == "Selectioner la catagerie " || bunifuDropdown2.Text == "Selectioner la marque" || bunifuTextBox1.Text == "")
            {
                MessageBox.Show("Esseye de reùplir tout les champs", "Message Erreur");
            }
            else
            {



                Dataproduit.Ajouterproduit(bunifuTextBox1.Text, int.Parse(bunifuDropdown2.SelectedValue.ToString()), int.Parse(bunifuDropdown1.SelectedValue.ToString()), long.Parse(bunifuTextBox2.Text));
                MessageBox.Show("Produit ajoute ave success", "Success");
                bunifuDropdown1.Text = "Selectioner la catagerie ";
                bunifuDropdown2.Text = "Selectioner la marque";
                bunifuTextBox1.Clear();


            }
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {

            Categorie_and_marque.Ajoutercategorie ajoutercategorie = new Categorie_and_marque.Ajoutercategorie();
            ajoutercategorie.ShowDialog();
            this.categoryTableAdapter.Fill(this.dataDataSet.category);


        }

        private void bunifuButton24_Click(object sender, EventArgs e)
        {

            Categorie_and_marque.Ajoutercategorie ajoutercategorie = new Categorie_and_marque.Ajoutercategorie();
            ajoutercategorie.ShowDialog();
            this.marqueTableAdapter.Fill(this.dataDataSet1.marque);
        }
    }
}
