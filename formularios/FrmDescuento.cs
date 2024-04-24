using Microsoft.ReportingServices.RdlExpressions.ExpressionHostObjectModel;
using POS_DePrisa.negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_DePrisa.formularios
{
    public partial class FrmDescuento : Form
    {
        private string codigoBarra;
        private BindingList<helpers.RowData> bs;
        private int x;
        private int y;
        private entidades.Producto producto { get; set; }
        private entidades.Producto productoSelected { get; set; }
        public Action refreshPrincipalDg { get; set; }


        public FrmDescuento(string codigoBarra, BindingList<helpers.RowData> bs, int x, int y)
        {
            InitializeComponent();
            this.codigoBarra = codigoBarra;
            this.bs = bs;
            this.x = x;
            this.y = y;

            defineLocation();

        }
        private void obtenerInfoBD()
        {
            ProductoServices productoServices = new ProductoServices();
            producto = productoServices.obtenerProducto(codigoBarra);
        }



        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool validarDescuento()
        {
            bool resultado = false;




            //helpers.RowData row = bs.FirstOrDefault(x => x.CodigoBarra == codigoBarra);
            //var descuento = Convert.ToDecimal(txtDescuento.Text);
            //descuento = descuento / 100;
            //if (descuento > row.DescuentoMaximo)
            //{
            //    MessageBox.Show("El descuento no puede ser mayor al " + (row.DescuentoMaximo*100) + "%");
            //    txtDescuento.Text = 0.ToString();
            //}
            //else
            //{
            //    resultado = true;
            //}
            var maximaCantidadDescuento = producto.Precio * (producto.DescuentoMaximo / 100);
            var precioMinimo = producto.Precio - maximaCantidadDescuento;

            var descuento = Convert.ToDouble(txtDescuento.Text);
            helpers.RowData row = bs.FirstOrDefault(x => x.CodigoBarra == codigoBarra);
            var precioActualProducto = row.Precio;

            if (precioActualProducto >= precioMinimo)
            {
                resultado = true;
                return resultado;
            }
            
       


            return resultado;
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {

            if (txtPrecio.Text == "")
            {
                MessageBox.Show("Elige el porcentaje de descuento");
                return;
            }

            if (validarDescuento())
            {
                helpers.RowData row = bs.FirstOrDefault(x => x.CodigoBarra == codigoBarra);
                row.Precio = Convert.ToDouble(txtPrecio.Text);
                refreshPrincipalDg();
                this.Close();
            }

        }

        private void defineLocation()
        {
          //utiliza x y y para definir la ubicacion del formulario
            this.Location = new Point(x, y);

        }

        private void definirInformacion()
        {
            //busca en Bs el producto con el codigo de barra
            //helpers.RowData row = bs.FirstOrDefault(x => x.CodigoBarra == codigoBarra);
            ////si lo encuentra
            //if (row != null)
            //{
            //    //asigna los valores a los controles
            //    lblPrecioNormal.Text = "C$ "+row.Precio.ToString();
            //    lblDescuento.Text = $"Descuento Max({row.DescuentoMaximo}%):";

            //}

            ProductoServices productoServices = new ProductoServices();
            productoSelected = productoServices.obtenerProducto(codigoBarra);
            lblPrecioNormal.Text = "C$ " + productoSelected.Precio.ToString();
            lblDescuento.Text = $"Descuento Max({productoSelected.DescuentoMaximo}%):";

            
        }

        private bool hasDiscount()
        {
            //bool resultado = false;
            //helpers.RowData row = bs.FirstOrDefault(x => x.CodigoBarra == codigoBarra);
            //if (row.DescuentoMaximo > 0)
            //{
            //    resultado = true;
            //}

            //return resultado;

            bool resultado = false;
            if (productoSelected.DescuentoMaximo > 0)
            {
                resultado = true;
            }   

            return resultado;
        }

        private void actualizarControles()
        {
            //si tiene descuento
            if (hasDiscount())
            {
                
            }
            else
            {
                //oculta los controles
                //lblPrecioNormal.Text = "Este producto no tiene descuento";
                //txtDescuento.ReadOnly = true;
                //btnAgregarProducto.Enabled = false;
                lblNuevoPrecio.Text = "Este producto no tiene descuento";
                lblPrecioNormal.Visible = false;
                lblDescuento.Visible = false;
                txtDescuento.Visible = false;
                txtPrecio.Visible = false;
                btnAgregarProducto.Visible = false;

            }
        }

        //private void txtPrecio_TextChanged(object sender, EventArgs e)
        //{
        //    //valida que solo se puedan ingresar numeros, no lo dejes ingresar letras
        //    if (!System.Text.RegularExpressions.Regex.IsMatch(txtPrecio.Text, "^[0-9]*$"))
        //    {
        //        //elimina el ultimo caracter ingresado
        //        txtPrecio.Text = txtPrecio.Text.Remove(txtPrecio.Text.Length - 1);

        //    }
           
        //}

        private void FrmDescuento_Load(object sender, EventArgs e)
        {
            definirInformacion();
            actualizarControles();
            obtenerInfoBD();
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtDescuento.Text == "")
                {
                    return;
                }


                //valida que solo se puedan ingresar numeros, no lo dejes ingresar letras

                if (!System.Text.RegularExpressions.Regex.IsMatch(txtDescuento.Text, "^[0-9]*$"))
                {
                    //elimina el ultimo caracter ingresado
                    txtDescuento.Text = txtDescuento.Text.Remove(txtDescuento.Text.Length - 1);
                    return;

                }

                //valida que no sea un numero negativo
                if (Convert.ToDecimal(txtDescuento.Text) < 0)
                {
                    MessageBox.Show("El descuento no puede ser negativo");
                    txtDescuento.Text = 0.ToString();
                }

                //valida que no sea mayor a descuento maximo

                var descuentoIngresado = Convert.ToDecimal(txtDescuento.Text);
                var descuentoProducto = Decimal.Parse(productoSelected.DescuentoMaximo.ToString());

                if (descuentoIngresado > descuentoProducto)
                {
                    MessageBox.Show("El descuento no puede ser mayor al " + producto.DescuentoMaximo + "%");
                    txtDescuento.Text = 0.ToString();
                    return;
                }

                //calcula el precio con descuento
                var precio = Decimal.Parse(productoSelected.Precio.ToString());
                var descuento = Decimal.Parse(txtDescuento.Text);
                var descuentoCalculado = precio * (descuento / 100);
                var precioConDescuento = precio - descuentoCalculado;
                txtPrecio.Text = precioConDescuento.ToString();

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

     

        }
    }
}
