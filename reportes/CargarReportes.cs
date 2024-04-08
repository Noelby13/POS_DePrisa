using Microsoft.Reporting.WinForms;
using POS_DePrisa.formularios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_DePrisa.reportes
{
    public static class CargarReportes
    {
        public static void VerReporte(DataTable t, string nombreDS, string nombreRpt)
        {
            try
            {
                ReportDataSource rpt = new ReportDataSource(nombreDS, t);
                FrmReporteVistaPrevia frmVistaPrevia = new FrmReporteVistaPrevia();
                frmVistaPrevia.reportViewer1.LocalReport.DataSources.Clear();
                frmVistaPrevia.reportViewer1.LocalReport.DataSources.Add(rpt);
                frmVistaPrevia.reportViewer1.LocalReport.ReportPath = nombreRpt;
                frmVistaPrevia.reportViewer1.RefreshReport();
                frmVistaPrevia.Show();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
