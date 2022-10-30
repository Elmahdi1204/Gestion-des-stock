using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace Gestion_des_stock.gestion_achat
{
    public partial class Facture : Form
    {
        int id;
        String fournisseur; String totale; String versment; String date;

        public Facture(int id, String fournisseur, String totale, String versment, String date)
        {
            InitializeComponent();
            this.id = id;
            bunifuLabel1.Text = bunifuLabel1.Text + "  " + fournisseur;
            bunifuLabel6.Text = totale + " DA";
            bunifuLabel5.Text = versment + " DA";
            bunifuLabel2.Text = bunifuLabel2.Text + "  " + date;
            this.fournisseur = fournisseur;
            this.totale = totale;
            this.versment = versment; this.date = date;



            if (double.Parse(totale) != int.Parse(versment))
            {
                bunifuLabel3.ForeColor = Color.Red;
                bunifuLabel4.ForeColor = Color.Red;
            }

        }

        private void Facture_Load(object sender, EventArgs e)
        {
            Dataachats.LoadListdesachats(bunifuDataGridView1, id);


        }

        private void bunifuDataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void bunifuButton27_Click(object sender, EventArgs e)
        {
            List<report> list = new List<report>();
            list.Clear();
            int i = 0;
            foreach (DataGridViewRow row in bunifuDataGridView1.Rows)
            {


                list.Add(new report
                {
                    idproduit = "" + i,
                    nomproduit = row.Cells[1].Value.ToString(),
                    prix = row.Cells[2].Value.ToString(),
                    qnt = row.Cells[3].Value.ToString(),
                    prixqnt = row.Cells[4].Value.ToString(),



                });



                i++;

            }

            facture.Facture imp = new facture.Facture(list, id.ToString(), fournisseur, date, totale, versment);
            imp.ShowDialog();



        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String colname = bunifuDataGridView1.Columns[e.ColumnIndex].Name;


            if (colname == "R")
            {
                long idproduit = long.Parse(bunifuDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                double prix = double.Parse(bunifuDataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                int qnt = int.Parse(bunifuDataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());

                Routour retour = new Routour(idproduit, id, qnt, prix);
                retour.ShowDialog();
                Dataachats.LoadListdesachats(bunifuDataGridView1, id);
                List<double> result = Roteur.Getnewdata(id);
                bunifuLabel6.Text = result[0] + " DA";
                bunifuLabel5.Text = result[1] + " DA";
                if (result[0] == 0)
                {
                    foreach (DataGridViewRow row in bunifuDataGridView1.Rows)
                    {
                        Roteur.modifierlestock(long.Parse(row.Cells[0].Value.ToString()), int.Parse(row.Cells[3].Value.ToString()));
                        Supprimerfacture.deletefromproduitachte(long.Parse(row.Cells[0].Value.ToString()), id);

                    }

                    Supprimerfacture.supprimerfacture(id);
                    MessageBox.Show("Facture supprimer avec success", "Supprimer avec success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }

            }
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in bunifuDataGridView1.Rows)
            {
                Roteur.modifierlestock(long.Parse(row.Cells[0].Value.ToString()), int.Parse(row.Cells[3].Value.ToString()));
                Supprimerfacture.deletefromproduitachte(long.Parse(row.Cells[0].Value.ToString()), id);

            }

            Supprimerfacture.supprimerfacture(id);
            MessageBox.Show("Facture supprimer avec success", "Supprimer avec success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
    public class report
    {
        public string idproduit { get; set; }
        public string nomproduit { get; set; }
        public string prix { get; set; }
        public string qnt { get; set; }
        public string prixqnt { get; set; }
    }
}

