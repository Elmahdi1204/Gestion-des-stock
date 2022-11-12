using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_des_stock.gestion_achat
{
    public partial class Toutlesproduitachte : Form
    {
        public Toutlesproduitachte()
        {
            InitializeComponent();
            bunifuDropdown1.Text = "Numéro de série";
        }

        private void Toutlesproduitachte_Load(object sender, EventArgs e)
        {
            Dataproduitachte.loadproduitachteid(bunifuDataGridView1, bunifuTextBox1.Text);
        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            String k = bunifuDropdown1.Text;


            switch (k)
            {
                case "Numéro de série":

                    Dataproduitachte.loadproduitachteid(bunifuDataGridView1, bunifuTextBox1.Text);

                    break;
                case "Nom de Fournisseur":
                    Dataproduitachte.loadproduitachtenomfournissuer(bunifuDataGridView1, bunifuTextBox1.Text);

                    break;
            }
        }

        private void bunifuTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {

                String k = bunifuDropdown1.Text;


                switch (k)
                {
                    case "Numéro de série":

                        Dataproduitachte.loadproduitachteid(bunifuDataGridView1, bunifuTextBox1.Text);

                        break;
                    case "Nom de Fournisseur":
                        Dataproduitachte.loadproduitachtenomfournissuer(bunifuDataGridView1, bunifuTextBox1.Text);

                        break;
                }
            }
        }

        private void bunifuDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = bunifuDataGridView1.Rows[e.RowIndex].Index;


                int id = int.Parse(bunifuDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                String Fournisseur = bunifuDataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                String totale = bunifuDataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();

                String versment = bunifuDataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                String date = bunifuDataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

                Facture se = new Facture(id, Fournisseur, totale, versment, date);
                se.ShowDialog();

                bunifuButton22.PerformClick();
                bunifuDataGridView1.Rows[index].Selected = true;
            }
            catch
            {

            }
        }
    }
}
