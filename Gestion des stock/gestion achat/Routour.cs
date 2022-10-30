using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Gestion_des_stock.gestion_achat
{
    public partial class Routour : Form
    {
        int qnt;
        public Routour(long idproduit, int idfacture, int qteachte, double prixproduit)
        {
            InitializeComponent();
            bunifuLabel5.Text = idfacture.ToString();
            bunifuLabel6.Text = idproduit.ToString();
            bunifuLabel7.Text = prixproduit.ToString();
            bunifuTextBox1.Text = qteachte.ToString();
            this.qnt = qteachte;

        }

        private void bunifuButton25_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox1.Text == "" || bunifuTextBox2.Text == "")
            {
                MessageBox.Show("Essye de remplir tout les champs", "Message Erreur");

            }
            else
            {
                Roteur.modifierlestock(long.Parse(bunifuLabel6.Text), int.Parse(bunifuTextBox1.Text));
                Roteur.modifierproduitachte(long.Parse(bunifuLabel6.Text), int.Parse(bunifuTextBox1.Text), double.Parse(bunifuLabel7.Text) * int.Parse(bunifuTextBox1.Text), int.Parse(bunifuLabel5.Text));
                double prixtotale;

                List<double> result = Roteur.Getnewdata((int.Parse(bunifuLabel5.Text)));
                prixtotale = result[0];


                Roteur.Setnewdata(prixtotale, int.Parse(bunifuLabel5.Text), double.Parse(bunifuTextBox2.Text));
                if (qnt == int.Parse(bunifuTextBox1.Text))
                {
                    Supprimerfacture.deletefromproduitachte(long.Parse(bunifuLabel6.Text), int.Parse(bunifuLabel5.Text));
                }
                MessageBox.Show("Routourne avec succes", "Produit retourne avec succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }


        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bunifuTextBox2.Text = (int.Parse(bunifuTextBox1.Text) * double.Parse(bunifuLabel7.Text)).ToString();

            }
#pragma warning disable CS0168 // La variable 'x' est déclarée, mais jamais utilisée
            catch (Exception x)
#pragma warning restore CS0168 // La variable 'x' est déclarée, mais jamais utilisée
            {

            }
        }
    }
}
