
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Gestion_des_stock.facture
{
    public partial class Facture : Form
    {
        public Facture(List<gestion_achat.report> list, String idfacure, String nom, String date, String totale, String versment)
        {
            InitializeComponent();
            ReportParameterCollection parameters = new ReportParameterCollection();
            parameters.Add(new ReportParameter("num", idfacure));
            parameters.Add(new ReportParameter("date", date));
            parameters.Add(new ReportParameter("Nom", nom));
            parameters.Add(new ReportParameter("prix", totale));
            parameters.Add(new ReportParameter("versment", versment));

            reportViewer1.LocalReport.SetParameters(parameters);
            ReportDataSource ds = new ReportDataSource();
            ds.Name = "DataSet1";
            ds.Value = list;



            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(ds);




            reportViewer1.RefreshReport();
            


        }

        private void Facture_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();


        }
    }
}
