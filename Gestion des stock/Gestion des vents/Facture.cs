using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Gestion_des_stock.Gestion_des_vents
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
            this.date = date;
            this.totale = totale;
            this.versment = versment;


            if (double.Parse(totale) != int.Parse(versment))
            {
                bunifuLabel6.ForeColor = Color.Red;
                bunifuLabel5.ForeColor = Color.Red;
            }
            if (Connexion.type == "Employee")
            {
                bunifuButton21.Hide();
                bunifuDataGridView1.Columns[5].Visible = false;
            }

        }

        private void Facture_Load(object sender, EventArgs e)
        {
            Datavents.Loadproduitvendudansfacture(bunifuDataGridView1, id);
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String colname = bunifuDataGridView1.Columns[e.ColumnIndex].Name;


            if (colname == "R")
            {
                long idproduit = long.Parse(bunifuDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                double prix = double.Parse(bunifuDataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                int qnt = int.Parse(bunifuDataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());

                Retour retour = new Retour(idproduit, id, qnt, prix);
                retour.ShowDialog();
                Datavents.Loadproduitvendudansfacture(bunifuDataGridView1, id);
                List<double> result = Routour.Getnewdata(id);
                bunifuLabel6.Text = result[0] + " DA";
                bunifuLabel5.Text = result[2] + " DA";
                if (result[0] == 0)
                {
                    foreach (DataGridViewRow row in bunifuDataGridView1.Rows)
                    {
                        Routour.modifierlestock(long.Parse(row.Cells[0].Value.ToString()), int.Parse(row.Cells[3].Value.ToString()));
                        supprimerunefacture.deletefromproduitvendu(long.Parse(row.Cells[0].Value.ToString()), id);

                    }

                    supprimerunefacture.supprimerfacture(id);
                    MessageBox.Show("Facture supprimer avec success", "Supprimer avec success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }

            }
        }

        private void bunifuButton27_Click(object sender, EventArgs e)
        {
            List<gestion_achat.report> list = new List<gestion_achat.report>();
            list.Clear();
            int i = 0;
            foreach (DataGridViewRow row in bunifuDataGridView1.Rows)
            {


                list.Add(new gestion_achat.report
                {
                    idproduit = "" + row.Cells[0].Value.ToString(),
                    nomproduit = row.Cells[1].Value.ToString(),
                    prix = row.Cells[2].Value.ToString()+" DA",
                    qnt = row.Cells[3].Value.ToString(),
                    prixqnt = row.Cells[4].Value.ToString(),



                });



                i++;

            }
            facture.Facture imp = new facture.Facture(list, id.ToString(), fournisseur, DateTime.Now.ToString("dd/MM/yyyy"), totale, versment);
            imp.ShowDialog();
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in bunifuDataGridView1.Rows)
            {
                Routour.modifierlestock(long.Parse(row.Cells[0].Value.ToString()), int.Parse(row.Cells[3].Value.ToString()));
                supprimerunefacture.deletefromproduitvendu(long.Parse(row.Cells[0].Value.ToString()), id);

            }

            supprimerunefacture.supprimerfacture(id);
            MessageBox.Show("Facture supprimer avec success", "Supprimer avec success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }
    }
}
