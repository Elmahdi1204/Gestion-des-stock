using System;
using System.Windows.Forms;

namespace Gestion_des_stock
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dashboard1.Show();
            dashboard1.BringToFront();

        }

        private void bunifuPanel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            listdesproduit1.BringToFront();
            listdesproduit1.Show();
        }

        private void bunifuButton23_Click(object sender, EventArgs e)
        {
            listdesclient1.Show();
            listdesclient1.BringToFront();

        }

        private void bunifuButton24_Click(object sender, EventArgs e)
        {
            listdesfournissuer1.Show();
            listdesfournissuer1.BringToFront();

        }

        private void bunifuButton25_Click(object sender, EventArgs e)
        {
            achats1.Show();
            achats1.BringToFront();
        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            stock1.Show();
            stock1.BringToFront();
        }

        private void bunifuButton26_Click(object sender, EventArgs e)
        {
            vents1.Show();
            vents1.BringToFront();

        }

        private void bunifuButton27_Click(object sender, EventArgs e)
        {
            dashboard1.Show();
            dashboard1.BringToFront();
        }

        private void bunifuButton28_Click(object sender, EventArgs e)
        {
            charges1.Show();
            charges1.BringToFront();

        }

        private void bunifuButton29_Click(object sender, EventArgs e)
        {
            users1.Show();
            users1.BringToFront();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Auth auth = new Auth();
            auth.Show();
        }

        private void bunifuButton210_Click(object sender, EventArgs e)
        {
            home1.Show();
            home1.BringToFront();
        }
    }
}
