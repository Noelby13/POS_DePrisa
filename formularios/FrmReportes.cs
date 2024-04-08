using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_DePrisa.formularios
{
    public partial class FrmReportes : Form
    {
        public FrmReportes()
        {
            InitializeComponent();
        }

        private void cambiarVisibilidadBotones(int estado)
        {
            if (estado == 1)
            {
                gbTipoReporte.Visible = false;
                btnGenerarReporte.Visible = false;
                btnOcultar.Visible = false;
                tsMenu.Visible = true;
            }
            else
            {
                gbTipoReporte.Visible = true;
                btnGenerarReporte.Visible = true;
                btnOcultar.Visible = true;
                tsMenu.Visible = false;
            }

        }

        private void btnOcultar_Click(object sender, EventArgs e)
        {
            cambiarVisibilidadBotones(1);
            tableLayoutBackGround.RowStyles[1].Height = tsMenu.Height;
        }

        private void tsbMostrar_Click(object sender, EventArgs e)
        {
            tableLayoutBackGround.RowStyles[1].SizeType = SizeType.Absolute;
            tableLayoutBackGround.RowStyles[1].Height = 46;
            cambiarVisibilidadBotones(0);
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            if (cbxTipoReporte.SelectedIndex == 1)
            {
                MostrarProductosDisponibles();
            }
        }

        private void MostrarProductosDisponibles()
        {
            DBDePrisaDataSetTableAdapters.RptProductosDisponiblesTableAdapter tbl = new DBDePrisaDataSetTableAdapters.RptProductosDisponiblesTableAdapter();
            DataTable datos = tbl.GetData();
            reportes.CargarReportes.VerReporte(datos, "RptProductosDisponibles", "reportes/RptProductosDisponibles.rdlc");
        }
    }
}
