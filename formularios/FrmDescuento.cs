using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Drawing.Drawing2D;
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


        public FrmDescuento(string codigoBarra, BindingList<helpers.RowData> bs, int x, int y)
        {
            InitializeComponent();
            this.codigoBarra = codigoBarra;
            this.bs = bs;
            this.x = x;
            this.y = y;

            defineLocation();

        }



        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool validarDescuento()
        {
            bool resultado = false;
            helpers.RowData row = bs.FirstOrDefault(x => x.CodigoBarra == codigoBarra);
            var descuento = Convert.ToDecimal(txtDescuento.Text);
            descuento = descuento / 100;
            if (descuento > row.DescuentoMaximo)
            {
                MessageBox.Show("El descuento no puede ser mayor al " + (row.DescuentoMaximo*100) + "%");
                txtDescuento.Text = 0.ToString();
            }
            else
            {
                resultado = true;
            }

            return resultado;
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {

            if (txtPrecio.Text == "")
            {
                MessageBox.Show("Debe ingresar un precio");
                return;
            }

            if (validarDescuento())
            {
                helpers.RowData row = bs.FirstOrDefault(x => x.CodigoBarra == codigoBarra);
                row.Precio = Convert.ToDecimal(txtPrecio.Text);
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
            helpers.RowData row = bs.FirstOrDefault(x => x.CodigoBarra == codigoBarra);
            //si lo encuentra
            if (row != null)
            {
                //asigna los valores a los controles
                lblPrecioNormal.Text = "C$ "+row.Precio.ToString();
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
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            if(txtDescuento.Text == "")
            {
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtDescuento.Text, "^[0-9]*$"))
            {
                //elimina el ultimo caracter ingresado
                txtDescuento.Text = txtDescuento.Text.Remove(txtPrecio.Text.Length - 1);
                return;
        
            }

            if (validarDescuento())
            {
                helpers.RowData row = bs.FirstOrDefault(x => x.CodigoBarra == codigoBarra);
                var newPrecio = row.Precio - (row.Precio * Convert.ToDecimal(txtDescuento.Text) / 100);
                //limita a dos decimales
                newPrecio = Math.Round(newPrecio, 2);
                txtPrecio.Text =newPrecio.ToString();
           
            }

        }
    }
}
