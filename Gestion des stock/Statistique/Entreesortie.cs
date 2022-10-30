using System;
using System.Drawing;
using System.Windows.Forms;

namespace Gestion_des_stock.Statistique
{
    public partial class Entreesortie : UserControl
    {
        public Entreesortie()
        {
            InitializeComponent();
            outils.autodate2(bunifuDatePicker1, bunifuDatePicker2);
        }

        private void Entreesortie_Load(object sender, EventArgs e)
        {
            State4.Countfacture(NbfacuterV, bunifuDatePicker1.Value, bunifuDatePicker2.Value);
            State4.Caisse(Caisse, bunifuDatePicker1.Value, bunifuDatePicker2.Value);
            State4.totaledesvent(totalev, bunifuDatePicker1.Value, bunifuDatePicker2.Value);
            State4.benifice(benifice, bunifuDatePicker1.Value, bunifuDatePicker2.Value);
            State4.chart1(chart1, bunifuDatePicker1.Value, bunifuDatePicker2.Value);
            State4.Credit(nbfacturecredit, totalecredit, bunifuDatePicker1.Value, bunifuDatePicker2.Value);
            State4.chart2(chart2, bunifuDatePicker1.Value, bunifuDatePicker2.Value);
            State5.Countfacture(label13, bunifuDatePicker1.Value, bunifuDatePicker2.Value);
            State5.totaleachats(label2, bunifuDatePicker1.Value, bunifuDatePicker2.Value);
            State5.Credit(label5, label10, bunifuDatePicker1.Value, bunifuDatePicker2.Value);
            State5.chart1(chart3, bunifuDatePicker1.Value, bunifuDatePicker2.Value);
            label26.Text = benifice.Text;
            State5.totaledescharges(label23, bunifuDatePicker1.Value, bunifuDatePicker2.Value);
            label20.Text = (double.Parse(label26.Text) - double.Parse(label23.Text)).ToString();


            if (double.Parse(label20.Text) < 0)
            {
                label20.ForeColor = Color.Red;
                pictureBox13.Image = Properties.Resources.money__1_1;
            }
            else
            {

                label20.ForeColor = Color.Green;
                pictureBox13.Image = Properties.Resources.financial_profit;
            }





        }

        private void bunifuButton24_Click(object sender, EventArgs e)
        {
            try
            {

                bunifuDatePicker1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 00, 00, 00);
                bunifuDatePicker2.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

                bunifuButton25.PerformClick();

            }
            catch
            {

            }
        }

        private void bunifuButton23_Click(object sender, EventArgs e)
        {
            try
            {
                bunifuDatePicker1.Value = DateTime.Now.AddDays(-7);
                bunifuDatePicker2.Value = DateTime.Now;

                bunifuButton25.PerformClick();

            }
            catch
            {

            }
        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            try
            {
                bunifuDatePicker1.Value = DateTime.Now.AddDays(-30);
                bunifuDatePicker2.Value = DateTime.Now;

                bunifuButton25.PerformClick();

            }
            catch
            {

            }
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            outils.autodate2(bunifuDatePicker1, bunifuDatePicker2);
            bunifuButton25.PerformClick();
        }

        private void bunifuDatePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuDatePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt = bunifuDatePicker2.Value;
            bunifuDatePicker2.Value = new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59);
        }

        private void bunifuShadowPanel10_DoubleClick(object sender, EventArgs e)
        {
            Shortcut.FacturCredit facturCredit = new Shortcut.FacturCredit();
            facturCredit.ShowDialog();
        }
    }
}
