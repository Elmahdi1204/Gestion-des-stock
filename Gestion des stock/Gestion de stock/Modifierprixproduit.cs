using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_des_stock.Gestion_de_stock
{
    public partial class Modifierprixproduit : Form
    {
        long id;
        public Modifierprixproduit(long id , String nom , String prix)
        {
            InitializeComponent();
            this.id = id;
            bunifuTextBox1.Text = nom;
            bunifuTextBox2.Text = prix.ToString();

            

        }

        private void Modifierprixproduit_Load(object sender, EventArgs e)
        {

        }

        private void bunifuButton25_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox1.Text == "" || bunifuTextBox2.Text == "")
            {
                MessageBox.Show("Esseye de ermplir tout les champs  ", "Erreur");

            }
            else
            {
                Datastock.Modifierprixproduit(double.Parse( bunifuTextBox2.Text), id);
                MessageBox.Show("Modifier avec success ", "Modifier le prix");

                bunifuTextBox1.Clear(); bunifuTextBox2.Clear(); 

                this.Close();
            }
        }
    }
}
