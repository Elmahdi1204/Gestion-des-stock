using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace Gestion_des_stock.Generer_code_barre
{
    public partial class Imprimerbarecode : Form
    {
        public Imprimerbarecode(long id, string com, string prix)
        {
            InitializeComponent();
            ReportParameterCollection parameters = new ReportParameterCollection();
            parameters.Add(new ReportParameter("id", id.ToString()));
            parameters.Add(new ReportParameter("prix", prix.ToString()));
            parameters.Add(new ReportParameter("com", com.ToString()));
            parameters.Add(new ReportParameter("url", new Uri(@"C:\logs\br.png").AbsoluteUri));
            this.reportViewer1.LocalReport.EnableExternalImages = true;
            reportViewer1.LocalReport.SetParameters(parameters);
        reportViewer1.RefreshReport();
        }

        private void Imprimerbarecode_Load(object sender, System.EventArgs e)
        {

            this.reportViewer1.RefreshReport();
          
        }
    }
}
