using Microsoft.Reporting.WinForms;
using POS_DePrisa.DBDePrisaDataSetTableAdapters;
using POS_DePrisa.entidades;
using POS_DePrisa.formularios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
                MessageBox.Show("Error al cargar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //carga el reporte sin parametros
        public static void VerFactura(int idFactura, List<DetalleFactura> detallesFact )
        {
            try
            {
                MessageBox.Show("idFactura: " + idFactura);
                DBDePrisaDataSetTableAdapters.RptDetallesFacturaTableAdapter detallesFacturaTableAdapter  = new RptDetallesFacturaTableAdapter();
                DataTable detalles = detallesFacturaTableAdapter.GetData(idFactura);

                DBDePrisaDataSetTableAdapters.RptFacturaInfoTableAdapter facturaInfoTableAdapter = new RptFacturaInfoTableAdapter();
                DataTable facturaInfo = facturaInfoTableAdapter.GetData(idFactura);


                ReportDataSource rptDetalles = new ReportDataSource("dsDetallesFactura", detalles);
                ReportDataSource rptFacturaInfo = new ReportDataSource("dsFacturaInfo", facturaInfo);

                FrmReporteVistaPrevia frmVistaPrevia = new FrmReporteVistaPrevia();
                frmVistaPrevia.reportViewer1.LocalReport.DataSources.Clear();
                frmVistaPrevia.reportViewer1.LocalReport.DataSources.Add(rptDetalles);
                frmVistaPrevia.reportViewer1.LocalReport.DataSources.Add(rptFacturaInfo);
                frmVistaPrevia.reportViewer1.LocalReport.ReportPath = "reportes/rptFactura.rdlc";
                frmVistaPrevia.reportViewer1.RefreshReport();
                frmVistaPrevia.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





    }
}
