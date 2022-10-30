using System;
using System.Windows.Forms;

namespace Gestion_des_stock.Statistique
{
    public partial class Statistiquefinancier : UserControl
    {
        public Statistiquefinancier()
        {
            InitializeComponent();
        }

        private void Statistiquefinancier_Load(object sender, EventArgs e)
        {

            State1.countproduct(nomberP);
            State1.Totalestock(ValeurS);
            State1.Totalestock2(label2);

            State1.chart1(chart1);
            State1.chart2(chart2);
            ////////////////////////
            ///
            State2.Countclient(nbrClient);
            State2.countfournisseur(nbrfournissuer);
            State2.creditclient(bunifuDataGridView1);
            State2.Creditfournissuer(bunifuDataGridView2);
            /////////////
            ///
            Stat3.chart1(chart5, chart6);
            Stat3.Plusproduitbenife(bunifuDataGridView3);

        }

        private void bunifuPanel2_Click(object sender, EventArgs e)
        {

        }
    }
}
