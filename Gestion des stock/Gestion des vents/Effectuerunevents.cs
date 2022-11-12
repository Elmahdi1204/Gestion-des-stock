using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Gestion_des_stock.Gestion_des_vents
{
    public partial class Effectuerunevents : Form
    {
        int qntdisponible = 0;
        int idfacture = 0;
        public static int idclient = 0;
        public static String nomcleint = "Random Random";
        public Effectuerunevents()
        {
            InitializeComponent();
            Random random = new Random();
            idfacture = random.Next(99999999) + random.Next(9999999);
            label4.Text = label4.Text + " " + idfacture;
            if (Connexion.type == "Employee")
            {
                label6.Hide();
                label5.Hide();
               
                bunifuDataGridView3.Columns[3].Visible = false;
                bunifuDataGridView1.Columns[5].Visible = false;
                bunifuTextBox9.PasswordChar = '*';
                bunifuTextBox3.PasswordChar = '*';
            }
        }

        private void Effectuerunevents_Load(object sender, EventArgs e)
        {
            Gestion_de_stock.Datastock.LoadStocksNOM(bunifuDataGridView3, bunifuTextBox4.Text);
            idclient = Gestion_des_client.Getrandomclient.Getclient();
            bunifuTextBox6.Focus();
        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {


        }

        private void bunifuTextBox4_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void bunifuButton23_Click(object sender, EventArgs e)
        {
            Gestion_de_stock.Datastock.LoadStocksNOM(bunifuDataGridView3, bunifuTextBox4.Text.Replace("'", "''"));
        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox7_TextChanged(object sender, EventArgs e)
        {


        }

        private void bunifuButton24_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton25_Click(object sender, EventArgs e)
        {

        }

        private void bunifuDataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {


                bunifuTextBox6.Text = bunifuDataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();
                try
                {
                    if (gestion_achat.Getspecifiqueproduct.find(long.Parse(bunifuTextBox6.Text)))
                    {
                        gestion_achat.Getspecifiqueproduct.Getfromstock(long.Parse(bunifuTextBox6.Text), bunifuTextBox5, bunifuTextBox9, bunifuTextBox1);
                        qntdisponible = Routour.Getqnt(long.Parse(bunifuTextBox6.Text));
                        bunifuTextBox2.Focus();
                        bunifuTextBox2.Text = "1";
                        bunifuTextBox2.SelectionLength = bunifuTextBox2.TextLength;
                    }
                    else
                    {
                        MessageBox.Show("Produit nexiste pas dans le stock");
                        bunifuTextBox6.Clear();
                        bunifuTextBox6.Focus();
                    }

                }

#pragma warning disable CS0168 // La variable 'x' est déclarée, mais jamais utilisée
                catch (Exception x)
#pragma warning restore CS0168 // La variable 'x' est déclarée, mais jamais utilisée
                {

                }




            }
#pragma warning disable CS0168 // La variable 'x' est déclarée, mais jamais utilisée
            catch (Exception x)
#pragma warning restore CS0168 // La variable 'x' est déclarée, mais jamais utilisée
            {

            }

        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double benifice = double.Parse(bunifuTextBox1.Text) * int.Parse(bunifuTextBox2.Text) - double.Parse(bunifuTextBox9.Text) * int.Parse(bunifuTextBox2.Text);
                bunifuTextBox3.Text = benifice.ToString();

            }
#pragma warning disable CS0168 // La variable 'x' est déclarée, mais jamais utilisée
            catch (Exception x)
#pragma warning restore CS0168 // La variable 'x' est déclarée, mais jamais utilisée
            {

            }

        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {


            if (verify(bunifuTextBox6.Text))
            {
                int q = int.Parse(bunifuDataGridView1.Rows[getindex(bunifuTextBox6.Text)].Cells[3].Value.ToString());

                if (bunifuTextBox2.Text == "0" || (double.Parse(bunifuTextBox2.Text) + q) > qntdisponible)
                {
                    MessageBox.Show("Quantite undiponible", "Alert de quantite ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bunifuTextBox2.Text = qntdisponible.ToString();
                    bunifuTextBox6.Clear();
                    bunifuTextBox6.Focus();
                }
                else
                {





                    bunifuDataGridView1.Rows.RemoveAt(getindex(bunifuTextBox6.Text));
                    double benifice = double.Parse(bunifuTextBox1.Text) * (double.Parse(bunifuTextBox2.Text) + q) - double.Parse(bunifuTextBox9.Text) * (double.Parse(bunifuTextBox2.Text) + q);
                    bunifuTextBox3.Text = benifice.ToString();

                    double prixqnt = (double.Parse(bunifuTextBox2.Text) + q) * double.Parse(bunifuTextBox1.Text);
                    bunifuDataGridView1.Rows.Add(bunifuTextBox6.Text, bunifuTextBox5.Text, bunifuTextBox1.Text, (double.Parse(bunifuTextBox2.Text) + q), prixqnt.ToString(), bunifuTextBox3.Text);
                    label2.Text = $"{ totale():### ####.##}  DA";
                    label5.Text = $"{ totalebenifice():### ####.##}  DA";
                    bunifuTextBox8.Text = totale().ToString();
                    bunifuTextBox1.Text = "0";

                    bunifuTextBox2.Text = "1";
                    bunifuTextBox9.Text = "0";


                    bunifuTextBox3.Clear();
                    bunifuTextBox4.Clear();
                    bunifuTextBox5.Clear();
                    bunifuTextBox6.Clear();
                    bunifuTextBox6.Focus();


                }

            }
            else
            {
                if (bunifuTextBox1.Text == "" || bunifuTextBox2.Text == "" || bunifuTextBox3.Text == "")
                {
                    MessageBox.Show("Il faut remplire tout les champes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    if (int.Parse(bunifuTextBox1.Text) < int.Parse(bunifuTextBox9.Text))
                    {
                        MessageBox.Show("le prix d'achat est superiere au prix de vent ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                   
                    if (bunifuTextBox2.Text == "0" || int.Parse(bunifuTextBox2.Text) > qntdisponible)
                    {
                        MessageBox.Show("Quantite undiponible", "Alert de quantite ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        bunifuTextBox2.Text = qntdisponible.ToString();
                        bunifuTextBox6.Clear();
                        bunifuTextBox6.Focus();
                    }
                    else
                    {
                        double prixqnt = double.Parse(bunifuTextBox2.Text) * double.Parse(bunifuTextBox1.Text);
                        bunifuDataGridView1.Rows.Add(bunifuTextBox6.Text, bunifuTextBox5.Text, bunifuTextBox1.Text, bunifuTextBox2.Text, prixqnt.ToString(), bunifuTextBox3.Text);
                        label2.Text = $"{ totale():### ####.##}  DA";
                        label5.Text = $"{ totalebenifice():### ####.##}  DA";
                        bunifuTextBox8.Text = totale().ToString();
                        bunifuTextBox1.Text = "0";

                        bunifuTextBox2.Text = "1";
                        bunifuTextBox9.Text = "0";


                        bunifuTextBox3.Clear();
                        bunifuTextBox4.Clear();
                        bunifuTextBox5.Clear();
                        bunifuTextBox6.Clear();
                        bunifuTextBox6.Focus();
                    }


                }
            }

        }
        bool verify(String id)

        {
            bool desc = false;

            for (int i = 0; bunifuDataGridView1.Rows.Count > i; i++)
            {
                if (bunifuDataGridView1.Rows[i].Cells[0].Value.ToString() == id)
                {
                    desc = true;

                }

            }

            return desc;
        }
        int getindex(String id)
        {
            int index = 0;

            for (int i = 0; bunifuDataGridView1.Rows.Count > i; i++)
            {
                if (bunifuDataGridView1.Rows[i].Cells[0].Value.ToString() == id)
                {
                    index = i;

                }

            }

            return index;
        }
        double totale()
        {
            double s = 0;
            for (int i = 0; bunifuDataGridView1.Rows.Count > i; i++)
            {
                s = s + double.Parse(bunifuDataGridView1.Rows[i].Cells[4].Value.ToString());

            }
            return s;
        }
        double totalebenifice()
        {
            double s = 0;
            for (int i = 0; bunifuDataGridView1.Rows.Count > i; i++)
            {
                s = s + double.Parse(bunifuDataGridView1.Rows[i].Cells[5].Value.ToString());

            }
            return s;
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String colname = bunifuDataGridView1.Columns[e.ColumnIndex].Name;
            if (colname == "supp")
            {
                bunifuDataGridView1.Rows.RemoveAt(e.RowIndex);
                label2.Text = $"{ totale():### ####.##}  DA";
                label5.Text = $"{ totalebenifice():### ####.##}  DA";
                bunifuTextBox8.Text = totale().ToString();
            }
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {

                double benifice = double.Parse(bunifuTextBox1.Text) * int.Parse(bunifuTextBox2.Text) - double.Parse(bunifuTextBox9.Text) * int.Parse(bunifuTextBox2.Text);
                bunifuTextBox3.Text = benifice.ToString();
            }

#pragma warning disable CS0168 // La variable 'x' est déclarée, mais jamais utilisée
            catch (Exception x)
#pragma warning restore CS0168 // La variable 'x' est déclarée, mais jamais utilisée

            {

            }

        }

        private void bunifuButton26_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridView1.Rows.Count != 0)
            {
                if (idclient == 0)
                {
                    MessageBox.Show("Il faut selectioner un Client", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                }
                else
                {
                    if (nomcleint == "Random Random" && totale() > double.Parse(bunifuTextBox8.Text))
                    {
                        Selectionerunclient selectionerunclient = new Selectionerunclient();
                        selectionerunclient.ShowDialog();
                    }
                    else
                    {


                        verification.verifiercredit(idfacture, idclient, totale(), totalebenifice(), double.Parse(bunifuTextBox8.Text));
                        for (int i = 0; bunifuDataGridView1.Rows.Count > i; i++)
                        {
                            long idprod = long.Parse(bunifuDataGridView1.Rows[i].Cells[0].Value.ToString());
                            int qnt = int.Parse(bunifuDataGridView1.Rows[i].Cells[3].Value.ToString());
                            int benifice = int.Parse(bunifuDataGridView1.Rows[i].Cells[5].Value.ToString());
                            double prixqnt = double.Parse(bunifuDataGridView1.Rows[i].Cells[4].Value.ToString());
                            double prixvent = double.Parse(bunifuDataGridView1.Rows[i].Cells[2].Value.ToString());
                            Datavents.Produitvendu(idfacture, idprod, prixvent, qnt, prixqnt);


                            verification.modifierlestock(idprod, qnt);


                        }
                        MessageBox.Show("Vents effectué avec succes", "Vent avec success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        List<gestion_achat.report> list = new List<gestion_achat.report>();
                        list.Clear();
                      
                        foreach (DataGridViewRow row in bunifuDataGridView1.Rows)
                        {


                            list.Add(new gestion_achat.report
                            {
                                idproduit = "" + row.Cells[0].Value.ToString(),
                                nomproduit = row.Cells[1].Value.ToString(),
                                prix = row.Cells[2].Value.ToString(),
                                qnt = row.Cells[3].Value.ToString(),
                                prixqnt = row.Cells[4].Value.ToString(),



                            });


                         


                        }
                        if (bunifuCheckBox1.Checked==true)
                        {
                            facture.Facture imp = new facture.Facture(list, idfacture.ToString(), nomcleint, DateTime.Now.ToString("dd/MM/yyyy"), totale().ToString(), bunifuTextBox8.Text);
                            imp.ShowDialog();
                        }
                       
                       
                        bunifuDataGridView1.Rows.Clear();
                        idclient = Gestion_des_client.Getrandomclient.Getclient();
                        nomcleint = "Random Random";
                        Random rand = new Random();
                        idfacture = rand.Next(99999999) + rand.Next(999999);
                        label4.Text = " facture :" + idfacture;
                        label5.Text = $"{ totalebenifice():### ####.##}  DA";
                        label2.Text = $"{ totale():### ####.##}  DA";
                        bunifuTextBox8.Text = totale().ToString();

                        Gestion_de_stock.Datastock.LoadStocksNOM(bunifuDataGridView3, bunifuTextBox4.Text);
                        bunifuTextBox6.Focus();

                    }
                }
            }
        }

        private void bunifuDataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuTextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuPanel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                try
                {
                    if (gestion_achat.Getspecifiqueproduct.find(long.Parse(bunifuTextBox6.Text)))
                    {
                        gestion_achat.Getspecifiqueproduct.Getfromstock(long.Parse(bunifuTextBox6.Text), bunifuTextBox5, bunifuTextBox9, bunifuTextBox1);
                        qntdisponible = Routour.Getqnt(long.Parse(bunifuTextBox6.Text));
                        bunifuTextBox2.Focus();
                        bunifuTextBox2.Text = "1";
                        bunifuButton21.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("Produit nexiste pas dans le stock");
                        bunifuTextBox6.Clear();
                        bunifuTextBox6.Focus();
                    }

                }

#pragma warning disable CS0168 // La variable 'x' est déclarée, mais jamais utilisée
                catch (Exception x)
#pragma warning restore CS0168 // La variable 'x' est déclarée, mais jamais utilisée
                {

                }
            }
        }

        private void bunifuTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                bunifuButton21.PerformClick();
            }
        }

        private void Effectuerunevents_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                bunifuTextBox6.Clear();
                bunifuTextBox6.Focus();
            }
        }

        private void bunifuDataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuDataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuPanel10_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuButton22_Click_1(object sender, EventArgs e)
        {
            Selectionerunclient selectionerunclient = new Selectionerunclient();
            selectionerunclient.ShowDialog();
        }

        private void bunifuTextBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue==13) {
                Gestion_de_stock.Datastock.LoadStocksNOM(bunifuDataGridView3, bunifuTextBox4.Text.Replace("'", "''"));

            }
        }
    }
}
