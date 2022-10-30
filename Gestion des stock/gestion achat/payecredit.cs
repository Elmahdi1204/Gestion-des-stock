using System;
using System.Windows.Forms;

namespace Gestion_des_stock.gestion_achat
{


    public partial class payecredit : Form
    {
        int idclient;
        public payecredit(int id, double credit, int idclient)
        {
            InitializeComponent();
            label2.Text = id.ToString();
            bunifuTextBox4.Text = credit.ToString();
            this.idclient = idclient;
        }

        private void payecredit_Load(object sender, EventArgs e)
        {

        }

        private void bunifuButton25_Click(object sender, EventArgs e)
        {
            Dataachats.payecredit(int.Parse(label2.Text), double.Parse(bunifuTextBox4.Text));

            MessageBox.Show("payer avec success", "paye un credit ");
            this.Close();
        }
    }
}
