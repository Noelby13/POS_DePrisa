using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using POS_DePrisa.dao;
using POS_DePrisa.entidades;
using POS_DePrisa.negocios;
using POS_DePrisa.store;
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
    public partial class FrmAperturaCaja : Form
    {

        public bool arqueoIsOpen = false;
        

        public FrmAperturaCaja()
        {
            InitializeComponent();
        }

  

        private void FrmAperturaCaja_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblHoraApertura.Text = DateTime.Now.ToString("hh:mm:ss tt");
            lblNombreUsuario.Text = GlobalData.usuario.NombreUsuario;
        }

        private void txtMontoInicial_TextChanged(object sender, EventArgs e)
        {
            //valida que no se ingresen letras
            if (System.Text.RegularExpressions.Regex.IsMatch(txtMontoInicial.Text, "[^0-9]"))
            {
                txtMontoInicial.Text = txtMontoInicial.Text.Remove(txtMontoInicial.Text.Length - 1);
                return;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtMontoInicial.Text == "")
            {
                MessageBox.Show("Ingrese el monto inicial", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Convert.ToDouble(txtMontoInicial.Text) <= 0)
            {
                MessageBox.Show("El monto inicial debe ser mayor a 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ArqueoServices arqueoServices = new ArqueoServices();
            ArqueoCaja arqueo = new ArqueoCaja();
            arqueo.FechaApertura = DateTime.Now;
            arqueo.MontoInicial = Convert.ToDecimal(txtMontoInicial.Text);
            arqueo.MontoFinal = Convert.ToDecimal(txtMontoInicial.Text);
            arqueo.IdUsuario = GlobalData.usuario.IdUsuario;
            arqueo.Estado = true;
            var resultado = arqueoServices.iniciarArqueo(arqueo);

            if (!resultado)
            {
                MessageBox.Show("Error al abrir la caja", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Obtenemos el arqueo abierto recien creado con su id generado por la base de datos
            GlobalData.arqueoCaja = arqueoServices.obtenerArqueoAbierto();
            MessageBox.Show("Caja abierta correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            arqueoIsOpen = true;


            this.Close();

            



        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
