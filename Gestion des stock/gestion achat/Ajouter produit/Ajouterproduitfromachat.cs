using System;
using System.Windows.Forms;

namespace Gestion_des_stock.gestion_achat.Ajouter_produit
{
    public partial class Ajouterproduitfromachat : Form
    {
        public Ajouterproduitfromachat(long id)
        {
            InitializeComponent();
            bunifuTextBox2.Text = id.ToString();
        }

        private void Ajouterproduitfromachat_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'dataDataSet1.marque'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.marqueTableAdapter.Fill(this.dataDataSet1.marque);
            // TODO: cette ligne de code charge les données dans la table 'dataDataSet.category'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.categoryTableAdapter.Fill(this.dataDataSet.category);

            bunifuDropdown1.Text = "Selectioner la catagerie ";
            bunifuDropdown2.Text = "Selectioner la marque";
        }

        private void bunifuButton25_Click(object sender, EventArgs e)
        {
            if (bunifuDropdown1.Text == "Selectioner la catagerie " || bunifuDropdown2.Text == "Selectioner la marque" || bunifuTextBox1.Text == "" || bunifuTextBox3.Text == "" || bunifuTextBox2.Text == "" || bunifuTextBox4.Text == "" || bunifuTextBox5.Text == "")
            {
                MessageBox.Show("Esseye de reùplir tout les champs", "Message Erreur");
            }
            else
            {



                Gestion_des_produit.Dataproduit.Ajouterproduit(bunifuTextBox1.Text, int.Parse(bunifuDropdown2.SelectedValue.ToString()), int.Parse(bunifuDropdown1.SelectedValue.ToString()), long.Parse(bunifuTextBox2.Text));
                MessageBox.Show("Produit ajoute ave success", "Success");
                bunifuDropdown1.Text = "Selectioner la catagerie ";
                bunifuDropdown2.Text = "Selectioner la marque";

                Effectueruneachats.prixachat = double.Parse(bunifuTextBox3.Text);
                Effectueruneachats.prixvent = double.Parse(bunifuTextBox4.Text);
                Effectueruneachats.qntachte = int.Parse(bunifuTextBox5.Text);
                Effectueruneachats.nom = bunifuTextBox1.Text;

                this.Close();


            }
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            Categorie_and_marque.Ajoutercategorie ajoutercategorie = new Categorie_and_marque.Ajoutercategorie();
            ajoutercategorie.ShowDialog();
            // TODO: cette ligne de code charge les données dans la table 'dataDataSet1.marque'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.marqueTableAdapter.Fill(this.dataDataSet1.marque);
            // TODO: cette ligne de code charge les données dans la table 'dataDataSet.category'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.categoryTableAdapter.Fill(this.dataDataSet.category);


        }

        private void bunifuButton24_Click(object sender, EventArgs e)
        {
            Categorie_and_marque.Ajoutercategorie ajoutercategorie = new Categorie_and_marque.Ajoutercategorie();
            ajoutercategorie.ShowDialog();
            // TODO: cette ligne de code charge les données dans la table 'dataDataSet1.marque'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.marqueTableAdapter.Fill(this.dataDataSet1.marque);
            // TODO: cette ligne de code charge les données dans la table 'dataDataSet.category'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.categoryTableAdapter.Fill(this.dataDataSet.category);

        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.categoryTableAdapter.FillBy(this.dataDataSet.category);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
