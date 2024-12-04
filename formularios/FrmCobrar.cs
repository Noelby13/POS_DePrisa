using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using POS_DePrisa.dao;
using POS_DePrisa.entidades;
using POS_DePrisa.formularios.Producto;
using POS_DePrisa.negocios;
using POS_DePrisa.reportes;
using POS_DePrisa.store;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_DePrisa.formularios
{
    public partial class FrmCobrar : Form
    {
        private bool isEfectivoSelected = false;
        private bool isTarjetaSelected = false;
        private bool isMixtoSelected = false;
        private double totalFactura;
        private double PagoCon;
        private double cambio;
        private ArqueoCaja arqueoActual = GlobalData.arqueoCaja;
        decimal montoTemporal = GlobalData.arqueoCaja.MontoFinal;
        private BindingList<helpers.RowData> listaProductoFactura { get; set; }
        public Action refreshPrincipalDg { get; set; }



        public FrmCobrar(BindingList<helpers.RowData> listaProductoFactura)
        {
            InitializeComponent();
            this.listaProductoFactura = listaProductoFactura;
        }

        private void FrmCobrar_Load(object sender, EventArgs e)
        {
            calcularTotal();
        }

        private void cleanButtons()
        {
            //Change selected values?
            isTarjetaSelected = false;
            isMixtoSelected = false;
            isEfectivoSelected = false;
            //Change background color
            btnTarjeta.BackColor = Color.Silver;
            btnEfectivo.BackColor = Color.Silver;
            btnMixto.BackColor = Color.Silver;
        }

        private void updateButton(Button boton)
        {
            cleanButtons();
            boton.BackColor = Color.Blue;

        }
        private void btnEfectivo_Click(object sender, EventArgs e)
        {
           
            Button clickedButton = sender as Button;
            if (clickedButton != null) { 
              updateButton(clickedButton);
                //Updte selected value
                isEfectivoSelected = true;
            }
        }

        private void btnTarjeta_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            //The sender parameter in the event handler contains a reference to the object that raised the event.
            if (clickedButton != null) {
                updateButton(clickedButton);
                //Update selected value
                isTarjetaSelected = true;
            }
            
        }

        private void btnMixto_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            //The sender parameter in the event handler contains a reference to the object that raised the event.
            if (clickedButton != null)
            {
                updateButton(clickedButton);
                //update selected value
                isMixtoSelected = true;
            }
        }

        private void calcularTotal() {
            //calcular el total de la factura, multiplicar los productos que tengan IVA al 15%

            double totalFactura = 0;
            double totalIVA = 0;

            foreach (helpers.RowData item in listaProductoFactura)
            {
                totalFactura += item.Importe;
                if (item.TieneIva)
                {
                    totalIVA += item.Importe * 0.15;
                }
            }

            lblIvaTotal.Text = "C$ "+totalIVA.ToString();
            lblTotal.Text = "C$ " + (totalFactura + totalIVA).ToString();

            //asigno el total de la factura a la variable totalFactura
            this.totalFactura = totalFactura + totalIVA;
        }

        private bool comprobarEfectivo()
        {
            if ((decimal)cambio > arqueoActual.MontoFinal)
            {
                MessageBox.Show("El cambio es superior al dinero en caja"+ arqueoActual.MontoFinal.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            arqueoActual.MontoFinal += (decimal)this.totalFactura;
            return true;
        }

        private void txtPagoCon_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtPagoCon.Text == "")
                {
                    txtCambio.Text = "0";
                    return;
                }

                //valida que no se pueda ingresar letras
                if (System.Text.RegularExpressions.Regex.IsMatch(txtPagoCon.Text, "[^0-9]"))
                {
                    txtPagoCon.Text = txtPagoCon.Text.Remove(txtPagoCon.Text.Length - 1);
                    return; 
                }

                 PagoCon = Convert.ToDouble(txtPagoCon.Text);

                //realiza una resta del total de la factura menos el pago con
                cambio = PagoCon - totalFactura;
                txtCambio.Text = cambio.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar el monto a pagar", ex.Message);
            }

                
           
        }

        private void btnCancelarCobro_Click(object sender, EventArgs e)
        {
            //valida que si quiere cerrar el formulario
            if (MessageBox.Show("¿Desea cancelar el cobro?", "Cerrar Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                arqueoActual.MontoFinal = montoTemporal;
                this.Close();
            }
        }

        private void mostrarFactura (Factura factura)
        {
            CargarReportes.VerFactura(factura.IdFactura);
        }

        private int realizarPago(int type)
        {
            if (txtPagoCon.Text == "")
            {
                MessageBox.Show("Debe ingresar el monto a pagar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 3;
            }

            //valida que si txtPagoCon menor que el total de la factura, no se puede cobrar
            if (Convert.ToDouble(txtPagoCon.Text) < totalFactura)
            {
                MessageBox.Show("El monto a pagar no puede ser menor al total de la factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 3;
            }
            //valida que si no se ha seleccionado un metodo de pago
            if (!isEfectivoSelected & !isTarjetaSelected & !isMixtoSelected)
            {
                MessageBox.Show("Debe seleccionar un método de pago", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 3;
            }

            if (!comprobarEfectivo())
            {
                return 3;
            }

            FacturaServices facturaServices = new FacturaServices();
            Factura factura = new Factura();
            factura.Fecha = DateTime.Now;
            factura.Estado = 1;
            factura.IdArqueo = GlobalData.arqueoCaja.IdArqueoCaja;
            factura.IdUsuario = GlobalData.usuario.IdUsuario;
            factura.IdFactura = facturaServices.obtenerIdUltimaFactura() + 1;

            var listaDetallesFactura = convertirListaProductoFactura(factura.IdFactura);

            var resultado = facturaServices.guardarFactura(factura, listaDetallesFactura);

            if (!resultado.IsExitoso)
            {
                MessageBox.Show("Error al guardar la factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 3;
            }
            MessageBox.Show("Cobro realizado con éxito", "Cobro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //borra todos los datos de la lista de productos
            listaProductoFactura.Clear();
            refreshPrincipalDg();

            if (type == 1)
            {
                mostrarFactura(factura);
            }

            return 2;
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            /*if (txtPagoCon.Text == "")
            {
                MessageBox.Show("Debe ingresar el monto a pagar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //valida que si txtPagoCon menor que el total de la factura, no se puede cobrar
            if (Convert.ToDouble(txtPagoCon.Text) < totalFactura)
            {
                MessageBox.Show("El monto a pagar no puede ser menor al total de la factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //valida que si no se ha seleccionado un metodo de pago
            if (!isEfectivoSelected & !isTarjetaSelected & !isMixtoSelected)
            {
                MessageBox.Show("Debe seleccionar un método de pago", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FacturaServices facturaServices = new FacturaServices();
            Factura factura = new Factura();
            factura.Fecha = DateTime.Now;
            factura.Estado = 1;
            factura.IdArqueo = GlobalData.arqueoCaja.IdArqueoCaja;
            factura.IdUsuario = GlobalData.usuario.IdUsuario;
            factura.IdFactura = facturaServices.obtenerIdUltimaFactura()+1;

            var listaDetallesFactura = convertirListaProductoFactura(factura.IdFactura);

            var resultado = facturaServices.guardarFactura(factura, listaDetallesFactura); 

            if (!resultado.IsExitoso){
                MessageBox.Show("Error al guardar la factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Cobro realizado con éxito", "Cobro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            */
            //borra todos los datos de la lista de productos
            int op = realizarPago(1);
            if (op == 2)
            {
                this.Close();
            }
            //CargarReportes.VerFactura(factura.IdFactura);
        }

        //genera un metodo que transforme una lista de rowdata a lista de DetallesFactura
        private List<DetalleFactura> convertirListaProductoFactura(int idFactura)
        {
            List<DetalleFactura> listaDetallesFactura = new List<DetalleFactura>();
            foreach (helpers.RowData item in listaProductoFactura)
            {
                DetalleFactura detalle = new DetalleFactura();
                detalle.Cantidad = item.Cantidad;
                detalle.Precio = (float)item.Precio;
                detalle.IdProducto = item.IdProducto;
                detalle.Descuento = (float)item.descuentoAplicado;
                detalle.IdFactura = idFactura;
                listaDetallesFactura.Add(detalle);
            }
            return listaDetallesFactura;
        }


        private void btnCobrarSinImprimir_Click(object sender, EventArgs e)
        {

            int op = realizarPago(2);
            if (op == 2) {
                this.Close();
            }
        }

        private void btnCancelarCobro_Click_1(object sender, EventArgs e)
        {
            //valida que si quiere cerrar el formulario
            if (MessageBox.Show("¿Desea cancelar el cobro?", "Cerrar Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
