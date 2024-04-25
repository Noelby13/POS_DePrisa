using POS_DePrisa.entidades;
using POS_DePrisa.formularios.Producto;
using POS_DePrisa.negocios;
using POS_DePrisa.store;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        private void btnEfectivo_Click(object sender, EventArgs e)
        {
            //pon de color azul el boton efectivo
            btnEfectivo.BackColor = Color.Blue;
            

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


        private void updateButton()
        {
     
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

                //realiza una resta del total de la factura menos el pago con
                double cambio = Convert.ToDouble(txtPagoCon.Text) - totalFactura;
                txtCambio.Text = cambio.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar el monto a pagar", ex.Message);
            }

                
           
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            //valida que si quiere cerrar el formulario
            if (MessageBox.Show("¿Desea cancelar el cobro?", "Cerrar Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (txtPagoCon.Text == "")
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
            if (isEfectivoSelected || isTarjetaSelected || isMixtoSelected)
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
            factura.IdFactura = facturaServices.obtenerIdUltimaFactura();

            var listaDetallesFactura = convertirListaProductoFactura(factura.IdFactura);

            var resultado = facturaServices.guardarFactura(factura, listaDetallesFactura); 

            if (!resultado.IsExitoso){
                MessageBox.Show("Error al guardar la factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Cobro realizado con éxito", "Cobro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //borra todos los datos de la lista de productos
            listaProductoFactura.Clear();
            refreshPrincipalDg();

            this.Close();
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
    }
}
