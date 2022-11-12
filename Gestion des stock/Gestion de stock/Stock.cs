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

        private void bunifuDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                String nom = bunifuDataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                String prix = bunifuDataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                ticket ticket = new ticket(nom , prix);
                ticket.ShowDialog();



            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void bunifuTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                String k = bunifuDropdown1.Text;


                switch (k)
                {
                    case "Numéro de séries":

                        Datastock.LoadStocks(bunifuDataGridView1, bunifuTextBox1.Text.Replace("'", "''"));

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
        }

        private void bunifuButton28_Click(object sender, EventArgs e)
        {
            Generer_code_barre.Genrecodebare genrecodebare = new Generer_code_barre.Genrecodebare();
            genrecodebare.ShowDialog();
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                String colname = bunifuDataGridView1.Columns[e.ColumnIndex].Name;
                if (e.RowIndex < 0)
                {

                }
                else

                {
                    if (colname == "mod")
                    {
                        int index = bunifuDataGridView1.Rows[e.RowIndex].Index;

                        long id = long.Parse(bunifuDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                        
                        String nomproduit = bunifuDataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

                        String prix = bunifuDataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

                        Modifierprixproduit p = new Modifierprixproduit(id  , nomproduit , prix ) ;
                        p.ShowDialog();
                        bunifuButton22.PerformClick();
                        bunifuDataGridView1.Rows[index].Selected = true;

                    }


                }
            }
            catch
            {

            }


        }
    }
}
