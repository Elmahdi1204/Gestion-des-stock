using System;
using System.Drawing;
using System.Windows.Forms;

namespace Gestion_des_stock.Gestion_de_stock
{
    public partial class Stock : UserControl
    {
        public Stock()
        {
            InitializeComponent();
            bunifuDropdown1.Text = "Numéro de séries";


        }

        private void Stock_Load(object sender, EventArgs e)
        {
            Datastock.LoadStocks(bunifuDataGridView1, bunifuTextBox1.Text);
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {
            String k = bunifuDropdown1.Text;


            switch (k)
            {
                case "Numéro de séries":

                    Datastock.LoadStocks(bunifuDataGridView1, bunifuTextBox1.Text.Replace("'" ,"''"));

                    break;
                case "Désignation":
                    Datastock.LoadStocksNOM(bunifuDataGridView1, bunifuTextBox1.Text.Replace("'", "''"));

                    break;
                case "Catégorie":
                    Datastock.LoadStocksCategorie(bunifuDataGridView1, bunifuTextBox1.Text.Replace("'", "''"));
                    break;
                case "Marque":
                    Datastock.LoadStocksmarque(bunifuDataGridView1, bunifuTextBox1.Text.Replace("'", "''"));
                    break;
            }




        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            bunifuTextBox1.Clear();
            String k = bunifuDropdown1.Text;


            switch (k)
            {
                case "Numéro de séries":

                    Datastock.LoadStocks(bunifuDataGridView1, bunifuTextBox1.Text);

                    break;
                case "Désignation":
                    Datastock.LoadStocksNOM(bunifuDataGridView1, bunifuTextBox1.Text);

                    break;
                case "Catégorie":
                    Datastock.LoadStocksCategorie(bunifuDataGridView1, bunifuTextBox1.Text);
                    break;
                case "Marque":
                    Datastock.LoadStocksmarque(bunifuDataGridView1, bunifuTextBox1.Text);
                    break;
            }

        }

        private void bunifuDataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in bunifuDataGridView1.Rows)
            {

                int qnt = Convert.ToInt32(row.Cells[2].Value);



                if (qnt < 3 && bunifuToggleSwitch1.Checked == true)
                {

                    row.DefaultCellStyle.BackColor = Color.Red;
                }


                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }

            }
        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuDropdown1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
