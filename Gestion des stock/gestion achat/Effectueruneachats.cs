using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace Gestion_des_stock.gestion_achat
{
    public partial class Effectueruneachats : Form
    {
        public static int idfournissuer = 0;
        int idfacture = 0;
        public static String nomfournissuer = "Random Random";
        public static double prixvent = 0, prixachat = 0;
        public static int qntachte = 0;
        public static long idproduit = 0;
        public static String nom = "";

        public Effectueruneachats()
        {
            InitializeComponent();
            Random random = new Random();

            idfacture = random.Next(99999999) + random.Next(9999999);
            do
            {
                idfacture = random.Next(99999999);

            } while (Dataachats.verifiercle(idfacture));



            label4.Text = label4.Text + " " + idfacture;



        }



        private void Effectueruneachats_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'dataDataSet2.Produit'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            //  this.produitTableAdapter.Fill(this.dataDataSet2.Produit);

            Gestion_des_produit.Dataproduit.Afficherlesproduit(bunifuDataGridView2, bunifuTextBox4.Text);

            idfournissuer = Getrandom.Getfournisseur();
            bunifuTextBox6.Focus();

        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {




            int k = 0;

            if (verify(bunifuTextBox6.Text, k))
            {
                MessageBox.Show("Ce produit est déja existe dans la list", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (bunifuTextBox1.Text == "" || bunifuTextBox2.Text == "" || bunifuTextBox3.Text == "")
                {
                    MessageBox.Show("Il faut remplire tout les champes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    if (int.Parse(bunifuTextBox1.Text) < int.Parse(bunifuTextBox3.Text))
                    {
                        double prixqnt = double.Parse(bunifuTextBox2.Text) * double.Parse(bunifuTextBox1.Text);
                        bunifuDataGridView1.Rows.Add(bunifuTextBox6.Text, bunifuTextBox5.Text, bunifuTextBox1.Text, bunifuTextBox2.Text, prixqnt.ToString(), bunifuTextBox3.Text);
                        label2.Text = totale().ToString() + " DA";
                        bunifuTextBox8.Text = totale().ToString();
                        bunifuTextBox1.Clear();

                        bunifuTextBox2.Clear();
                        bunifuTextBox3.Clear();
                        bunifuTextBox4.Clear();
                        bunifuTextBox5.Clear();
                        bunifuTextBox6.Clear();

                        bunifuTextBox6.Focus();
                    }
                    else
                    {
                        MessageBox.Show("le prix d'achat est superiere au prix de vent ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


                }
            }




        }
        bool verify(String id, int index)

        {
            bool desc = false;
            for (int i = 0; bunifuDataGridView1.Rows.Count > i; i++)
            {
                if (bunifuDataGridView1.Rows[i].Cells[0].Value.ToString() == id)
                {
                    desc = true;
                    index = i;


                }

            }
            return desc;
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

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String colname = bunifuDataGridView1.Columns[e.ColumnIndex].Name;
            if (colname == "supp")
            {
                bunifuDataGridView1.Rows.RemoveAt(e.RowIndex);
                label2.Text = totale().ToString() + " DA";
                bunifuTextBox8.Text = totale().ToString();
            }

        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            /*Ajouter_produit.Ajouterproduitfromachat ajouterunproduit = new Ajouter_produit.Ajouterproduitfromachat(idproduit);
            ajouterunproduit.ShowDialog();
            bunifuTextBox5.te
            bunifuTextBox1.Text = prixachat.ToString();
            bunifuTextBox3.Text = prixvent.ToString();
            bunifuTextBox2.Text = qntachte.ToString();*/
        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox4_TextChanged(object sender, EventArgs e)
        {
            Gestion_des_produit.Dataproduit.Afficherlesproduit(bunifuDataGridView2, bunifuTextBox4.Text.Replace("'", "''"));
        }

        private void bunifuDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                bunifuTextBox6.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (Getspecifiqueproduct.find(long.Parse(bunifuTextBox6.Text)))
                {
                    Getspecifiqueproduct.Getfromstock(long.Parse(bunifuTextBox6.Text), bunifuTextBox5, bunifuTextBox1, bunifuTextBox3);
                }
                else
                {

                    Getspecifiqueproduct.Getfromproduit(long.Parse(bunifuTextBox6.Text), bunifuTextBox5, bunifuTextBox1, bunifuTextBox3);




                }
                bunifuTextBox2.Focus();
            }
#pragma warning disable CS0168 // La variable 'x' est déclarée, mais jamais utilisée
            catch (Exception x)
#pragma warning restore CS0168 // La variable 'x' est déclarée, mais jamais utilisée
            {

            }




        }

        private void bunifuPanel6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton23_Click(object sender, EventArgs e)
        {
            Gestion_des_produit.Dataproduit.Afficherlesproduit(bunifuDataGridView2, bunifuTextBox4.Text.Replace("'", "''"));

        }

        private void bunifuButton24_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton25_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuDataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {



        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton26_Click(object sender, EventArgs e)
        {

            if (bunifuDataGridView1.Rows.Count != 0)
            {
                if (idfournissuer == 0)
                {
                    MessageBox.Show("Il faut selectioner un fournisseur", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                }
                else
                {
                    if (nomfournissuer == "Random Random" && totale() > double.Parse(bunifuTextBox8.Text))
                    {
                        Selectionerunfournissuer selectionerunfournissuer = new Selectionerunfournissuer();
                        selectionerunfournissuer.ShowDialog();
                    }
                    else
                    {



                        verification.verifiercredit(idfacture, idfournissuer, totale(), double.Parse(bunifuTextBox8.Text));
                        for (int i = 0; bunifuDataGridView1.Rows.Count > i; i++)
                        {
                            long idprod = long.Parse(bunifuDataGridView1.Rows[i].Cells[0].Value.ToString());
                            int qnt = int.Parse(bunifuDataGridView1.Rows[i].Cells[3].Value.ToString());
                            int prixachat = int.Parse(bunifuDataGridView1.Rows[i].Cells[2].Value.ToString());
                            double prixqnt = double.Parse(bunifuDataGridView1.Rows[i].Cells[4].Value.ToString());
                            double prixvent = double.Parse(bunifuDataGridView1.Rows[i].Cells[5].Value.ToString());
                            Dataachats.Produitachate(idprod, prixachat, qnt, prixqnt, idfacture);
                            verification c = new verification();

                            if (c.verifierlesock(idprod))
                            {
                                verification.modifierqnt(qnt, prixachat, prixvent, idprod);
                            }
                            else
                            {
                                Dataachats.Ajouteraustock(idprod, qnt, prixachat, prixvent, "St44");
                            }

                        }
                        MessageBox.Show("Achcat effectué avec succes", "Achte avec success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        List<report> list = new List<report>();
                        list.Clear();
                        int k = 0;
                        foreach (DataGridViewRow row in bunifuDataGridView1.Rows)
                        {


                            list.Add(new report
                            {
                                idproduit = "" + k,
                                nomproduit = row.Cells[1].Value.ToString(),
                                prix = row.Cells[2].Value.ToString(),
                                qnt = row.Cells[3].Value.ToString(),
                                prixqnt = row.Cells[4].Value.ToString(),



                            });
                            k++;




                        }
                        if(bunifuCheckBox1.Checked == true)
                        {
                        facture.Facture imp = new facture.Facture(list, idfacture.ToString(), nomfournissuer, DateTime.Now.ToString("dd/MM/yyyy"), label2.Text, bunifuTextBox8.Text);

                            imp.ShowDialog();
                        }
                       
                        bunifuDataGridView1.Rows.Clear();
                        idfournissuer = Getrandom.Getfournisseur();
                        nomfournissuer = "Random Random";
                        Random rand = new Random();

                        idfacture = rand.Next(99999999);
                        do
                        {
                            idfacture = rand.Next(99999999);

                        } while (Dataachats.verifiercle(idfacture));
                        label4.Text = " facture :" + idfacture;

                        label2.Text = totale().ToString() + " DA";
                        bunifuTextBox8.Text = totale().ToString();

                        bunifuTextBox6.Focus();

                    }
                }
            }
        }

        private void bunifuTextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                bunifuButton21.PerformClick();
            }
        }

        private void Effectueruneachats_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                bunifuTextBox6.Clear();
                bunifuTextBox6.Focus();
            }
        }

        private void Effectueruneachats_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void bunifuButton28_Click(object sender, EventArgs e)
        {
            Generer_code_barre.Genrecodebare genrecodebare = new Generer_code_barre.Genrecodebare();
            genrecodebare.ShowDialog();

        }

        private void bunifuButton22_Click_1(object sender, EventArgs e)
        {
            Selectionerunfournissuer selectionerunfournissuer = new Selectionerunfournissuer();
            selectionerunfournissuer.ShowDialog();
        }

        private void bunifuTextBox6_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyValue == 13)
            {
                try
                {



                    if (Getspecifiqueproduct.find(long.Parse(bunifuTextBox6.Text)))
                    {
                        Getspecifiqueproduct.Getfromstock(long.Parse(bunifuTextBox6.Text), bunifuTextBox5, bunifuTextBox1, bunifuTextBox3);
                        bunifuTextBox2.Clear();
                        bunifuTextBox2.Focus();
                    }
                    else
                    {
                        if (Getspecifiqueproduct.findfromproduit(long.Parse(bunifuTextBox6.Text)))
                        {
                            Getspecifiqueproduct.Getfromproduit(long.Parse(bunifuTextBox6.Text), bunifuTextBox5, bunifuTextBox1, bunifuTextBox3);

                        }
                        else
                        {
                            try
                            {
                                Ajouter_produit.Ajouterproduitfromachat ajouterunproduit = new Ajouter_produit.Ajouterproduitfromachat(long.Parse(bunifuTextBox6.Text));
                                ajouterunproduit.ShowDialog();
                                bunifuTextBox5.Text = nom;
                                bunifuTextBox1.Text = prixachat.ToString();
                                bunifuTextBox3.Text = prixvent.ToString();
                                bunifuTextBox2.Text = qntachte.ToString();
                                bunifuButton21.PerformClick();

                                bunifuTextBox6.Focus();
                            }
                            catch
                            {
                                bunifuTextBox6.Focus();
                            }


                        }


                    }

#pragma warning disable CS0168 // La variable 'x' est déclarée, mais jamais utilisée
                }
                catch (Exception x)
#pragma warning restore CS0168 // La variable 'x' est déclarée, mais jamais utilisée
                {

                }
            }

        }

    }


}
