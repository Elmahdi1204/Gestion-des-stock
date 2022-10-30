using System;
using System.Windows.Forms;

namespace Gestion_des_stock.Statistique
{
    public partial class Dashboard : UserControl
    {
        public Dashboard()
        {
            InitializeComponent();
            entreesortie1.Show();
            entreesortie1.BringToFront();

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {



        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuDatePicker1_ValueChanged(object sender, EventArgs e)
        {


        }


        private void bunifuDatePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuDatePicker4_ValueChanged(object sender, EventArgs e)
        {


        }

        private void bunifuDatePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            entreesortie1.Show();
            entreesortie1.BringToFront();

        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            statistiquefinancier1.Show();
            statistiquefinancier1.BringToFront();
        }
    }
}
