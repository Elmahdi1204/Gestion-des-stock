using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_des_stock.Gestion_de_stock
{
    public partial class ticket : Form
    {
        public ticket(String nom , String prix)
        {
            InitializeComponent();
            ReportParameterCollection parameters = new ReportParameterCollection();
            parameters.Add(new ReportParameter("Nom", nom.ToString()));
            parameters.Add(new ReportParameter("prix", $"{double.Parse(prix.ToString()):### ### ###,##}"));
           
            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.RefreshReport();
        }

        private void ticket_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
           
        }
    }
}
