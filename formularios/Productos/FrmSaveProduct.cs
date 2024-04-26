using POS_DePrisa.negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_DePrisa.formularios.Productos
{
    public partial class FrmSaveProduct : Form
    {

        private entidades.Producto productoSelected;
        public FrmSaveProduct()
        {
            InitializeComponent();
            productoSelected = new entidades.Producto();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }

        private void rbKitSi_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbKitNo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardarProducto_Click(object sender, EventArgs e)
        {

        }

        private async void FrmSaveProduct_Load(object sender, EventArgs e)
        {
            await CargarComboAsync();
            await CargarListaProductoAsync(dgvListaProductoPrincipal);

        }

        private async Task CargarComboAsync()
        {
            await Task.Run(() =>
            {
                ProductoServices productoServices = new ProductoServices();
                var categorias = productoServices.listarCategorias();

                // Actualizar el ComboBox en el hilo de la interfaz de usuario
                this.Invoke((MethodInvoker)delegate
                {
                    cbxCategoria.DataSource = categorias.Tables[0];
                    cbxCategoria.DisplayMember = "Nombre";
                    cbxCategoria.ValueMember = "IdCategoria";
                    cbxCategoria.SelectedIndex = -1;
                });
            });
        }

        private async Task CargarListaProductoAsync(DataGridView dg)
        {
            await Task.Run(() =>
            {
                ProductoServices services = new ProductoServices();
                var productos = services.listarProductos();

                this.Invoke((MethodInvoker)delegate
                {
                    dg.DataSource = productos.Tables[0];
                    OcultarMostrarColumnas(dg);
                    CambiarNombresColumnas(dg);
                });
            });
        }

        private void OcultarMostrarColumnas(DataGridView dg)
        {
            dg.Columns["IdProducto"].Visible = false;
            dg.Columns["IdCategoria"].Visible = false;
            dg.Columns["TieneKit"].Visible = false;
            dg.Columns["TieneIva"].Visible = false;
            dg.Columns["DescuentoMaximo"].Visible = false;
            dg.Columns["Costo"].Visible = true;
            dg.Columns["Stock"].Visible = true;
            dg.Columns["Descripcion"].Visible = true;
            dg.Columns["CodigoBarra"].Visible = false;
            dg.Columns["Nombre"].Visible = true;
            dg.Columns["estado"].Visible = false;
        }

        private void CambiarNombresColumnas(DataGridView dg)
        {
            dg.Columns["Nombre"].HeaderText = "Nombre";
            dg.Columns["CodigoBarra"].HeaderText = "Codigo de Barra";
            dg.Columns["Descripcion"].HeaderText = "Descripcion";
            dg.Columns["Stock"].HeaderText = "Stock";
            dg.Columns["Costo"].HeaderText = "Precio";
            dg.Columns["DescuentoMaximo"].HeaderText = "Descuento Maximo";
            dg.Columns["TieneKit"].HeaderText = "Tiene Kit";
            dg.Columns["TieneIva"].HeaderText = "Tiene Iva";
        }



        private void cargarDataGrid()
        {
            // Cargar datos en el datagrid

            ProductoServices productoServices = new ProductoServices();
            var datos = productoServices.listarProductos();
            dgvListaProductoPrincipal.DataSource = datos;
            dgvListaProductoPrincipal.Columns[0].Visible = false;
        }

        private void limpiarCampos()
        {
            txtNombre.Text = "";
            txtCodigoBarra.Text = "";
            txtDescripcion.Text = "";
            txtCantidad.Text = "";
            txtPrecio.Text = "";
            txtDescuento.Text = "";

            cbxCategoria.SelectedIndex = -1;

            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;

            btnGuardar.Enabled = true;


        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            limpiarCampos();
        }
        private bool validarCampos()
        {

            if (txtCodigoBarra.Text == "")
            {
                MessageBox.Show("El campo Codigo de Barra es obligatorio");
                return false;
            }
            if (txtNombre.Text == "")
            {
                MessageBox.Show("El campo Nombre es obligatorio");
                return false;
            }
            if (txtCantidad.Text == "")
            {
                MessageBox.Show("El campo Stock es obligatorio");
                return false;
            }
            if (txtPrecio.Text == "")
            {
                MessageBox.Show("El campo Precio es obligatorio");
                return false;
            }
            if (txtDescuento.Text == "")
            {
                MessageBox.Show("El campo Descuento Maximo es obligatorio");
                return false;
            }

            if (cbxCategoria.SelectedIndex == -1)
            {
                MessageBox.Show("El campo Categoria es obligatorio");
                return false;
            }
            return true;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!validarCampos())
            {
                return;
            }

            ProductoServices productoServices = new ProductoServices();

            entidades.Producto producto = new entidades.Producto();

            producto.CodigoBarra = txtCodigoBarra.Text;
            producto.Nombre = txtNombre.Text;
            producto.Descripcion = txtDescripcion.Text;
            producto.Stock = Convert.ToInt32(txtCantidad.Text);
            producto.Precio = Convert.ToDouble(txtPrecio.Text);
            producto.DescuentoMaximo = (float)Convert.ToDouble(txtDescuento.Text);
            producto.idcategoria = Convert.ToInt32(cbxCategoria.SelectedValue);

            producto.TieneIva = rbIvaSi.Checked;

            var resultado = productoServices.Guardar(producto);

            if (!resultado.IsExitoso)
            {
                MessageBox.Show(resultado.Mensaje);
                return;

            }
            

            MessageBox.Show("Producto guardado con exito");
            limpiarCampos();
            await CargarListaProductoAsync(dgvListaProductoPrincipal);

        }

        private async void btnActualizar_Click_1(object sender, EventArgs e)
        {
            //crea un producto
            entidades.Producto producto = new entidades.Producto();
            producto.IdProducto = productoSelected.IdProducto;
            producto.CodigoBarra = txtCodigoBarra.Text;
            producto.Nombre = txtNombre.Text;
            producto.Descripcion = txtDescripcion.Text;
            producto.Stock = Convert.ToInt32(txtCantidad.Text);
            producto.Precio = Convert.ToDouble(txtPrecio.Text);
            producto.DescuentoMaximo = (float)Convert.ToDouble(txtDescuento.Text);
            producto.idcategoria = Convert.ToInt32(cbxCategoria.SelectedValue);
            producto.TieneIva = rbIvaSi.Checked;

            ProductoServices productoServices = new ProductoServices();
            var resultado = productoServices.actualizar(producto);

            if (!resultado.IsExitoso)
            {
                MessageBox.Show(resultado.Mensaje);
                return;
            }

            MessageBox.Show("Producto actualizado con exito");
            limpiarCampos();
            await CargarListaProductoAsync(dgvListaProductoPrincipal);


        }


        private  void dgvListaProductoPrincipal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }



        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            //pregunta al usuario que si desea eliminar el producto
            DialogResult dialogResult = MessageBox.Show($"¿Desea eliminar el producto {productoSelected.Nombre}?", "Eliminar", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                ProductoServices productoServices = new ProductoServices();
                var resultado = productoServices.borrar(productoSelected);
                if (!resultado.IsExitoso)
                {
                    MessageBox.Show(resultado.Mensaje);
                    return;
                }
                MessageBox.Show("Producto eliminado con exito");
                limpiarCampos();
                await CargarListaProductoAsync(dgvListaProductoPrincipal);
            }

        }

        private void dgvListaProductoPrincipal_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //valida que sea en filas validas
            if (e.RowIndex < 0)
            {
                return;
            }
            limpiarCampos();

            //carga los datos del producto seleccionado pero utiliza el nombre de la columna
            productoSelected.IdProducto = Convert.ToInt32(dgvListaProductoPrincipal.CurrentRow.Cells["IdProducto"].Value);
            txtNombre.Text = dgvListaProductoPrincipal.CurrentRow.Cells["Nombre"].Value.ToString();
            txtCodigoBarra.Text = dgvListaProductoPrincipal.CurrentRow.Cells["CodigoBarra"].Value.ToString();
            txtDescripcion.Text = dgvListaProductoPrincipal.CurrentRow.Cells["Descripcion"].Value.ToString();
            txtCantidad.Text = dgvListaProductoPrincipal.CurrentRow.Cells["Stock"].Value.ToString();
            txtPrecio.Text = dgvListaProductoPrincipal.CurrentRow.Cells["Costo"].Value.ToString();
            txtDescuento.Text = dgvListaProductoPrincipal.CurrentRow.Cells["DescuentoMaximo"].Value.ToString();
            cbxCategoria.SelectedValue = dgvListaProductoPrincipal.CurrentRow.Cells["IdCategoria"].Value;

            //convierte la fila a un producto
            productoSelected.Nombre = dgvListaProductoPrincipal.CurrentRow.Cells["Nombre"].Value.ToString();

            if (Convert.ToBoolean(dgvListaProductoPrincipal.CurrentRow.Cells["tieneIva"].Value) == true)
            {
                rbIvaSi.Checked = true;
            }
            else
            {
                rbIvaNo.Checked = true;
            }

            btnGuardar.Enabled = false;
            btnEliminar.Enabled = true;
            btnActualizar.Enabled = true;
        }
    }
}
