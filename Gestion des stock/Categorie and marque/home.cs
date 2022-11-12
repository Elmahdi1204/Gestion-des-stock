using System;
using System.Windows.Forms;

namespace Gestion_des_stock.Categorie_and_marque
{
    public partial class home : UserControl
    {
        public home()
        {
            InitializeComponent();

            listdescategorie1.Show();
            listdescategorie1.BringToFront();
        }

        private void bunifuButton23_Click(object sender, EventArgs e)
        {
            Ajoutercategorie ajoutercategorie = new Ajoutercategorie();
            ajoutercategorie.ShowDialog();

        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            listdescategorie1.Show();
            listdescategorie1.BringToFront();
        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            listdesmarque1.Show();
            listdesmarque1.BringToFront();
        }

        private void home_Load(object sender, EventArgs e)
        {

        }
    }
}
