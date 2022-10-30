using System;
using System.Drawing;
using System.Windows.Forms;

namespace Gestion_des_stock.Generer_code_barre
{
    public partial class Genrecodebare : Form
    {
        public Genrecodebare()
        {
            InitializeComponent();
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            try
            {
                BarcodeLib.Barcode b = new BarcodeLib.Barcode();
                pictureBox1.Image = b.Encode(BarcodeLib.TYPE.CODE128, bunifuTextBox1.Text, Color.Black, Color.White, 300, 100);

            }
            catch
            {

            }
           
          

        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.Save(@"C:\logs\br.png");
            Imprimerbarecode imprimerbarecode = new Imprimerbarecode(long.Parse(bunifuTextBox1.Text), bunifuTextBox3.Text, bunifuTextBox2.Text);
            imprimerbarecode.ShowDialog();
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            long k = random.Next(999999999) + random.Next(999999999);
            bunifuTextBox1.Text = k.ToString();
        }
    }
}
