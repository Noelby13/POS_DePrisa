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

namespace POS_DePrisa.formularios
{
    public partial class FrmBuscarProducto : Form
    {
        private DataGridView dg;
        private List<entidades.Producto> ListaProductos;
        private BindingList<helpers.RowData> listaFactura;
        //declara una propiedad funcion que se le pasara una funcion que no retorna nada y no recibe parametros
        public Action refreshDg { get; set; }
        public FrmBuscarProducto(DataGridView dg, BindingList<helpers.RowData> listaProductosFactura)
        {
            InitializeComponent();
            this.dg = dg;
            ListaProductos = new List<entidades.Producto>();
           listaFactura = listaProductosFactura;
        }

        private void FrmBuscarProducto_Load(object sender, EventArgs e)
        {
            initialDataGridConfig();
        }

        private void initialDataGridConfig()
        {
            dgvListaProducto.DataSource = ListaProductos;
            dgvListaProducto.Columns["IdProducto"].Visible = false;
            dgvListaProducto.Columns["Nombre"].HeaderText = "Nombre";
            dgvListaProducto.Columns["Precio"].HeaderText = "Precio";
            dgvListaProducto.Columns["Stock"].HeaderText = "Inventario";
            dgvListaProducto.Columns["CodigoBarra"].HeaderText = "Código de Barra";
            dgvListaProducto.Columns["Descripcion"].HeaderText = "Descripción";
            dgvListaProducto.Columns["TieneIva"].Visible=false;
            dgvListaProducto.Columns["TieneKit"].Visible=false;
            dgvListaProducto.Columns["DescuentoMaximo"].Visible=false;
            dgvListaProducto.Columns["estado"].Visible=false;
            dgvListaProducto.Columns["idcategoria"].Visible=false;
            dgvListaProducto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListaProducto.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvListaProducto_CellFormatting);

            OrderColumns();

        }


        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            //valida que haya un producto seleccionado
            if (dgvListaProducto.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //obten el producto seleccionado
            entidades.Producto producto = (entidades.Producto)dgvListaProducto.CurrentRow.DataBoundItem;

            if ( producto== null)
            {
                //crea un objeto tipo rowData
                return;
      
            }
            if (producto.Stock <= 0)
            {
                MessageBox.Show("No hay existencias de este producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //valida que si el producto ya esta en la lista de productos, le sume uno a la cantidad
            foreach (helpers.RowData item in listaFactura)
            {
                if (item.IdProducto == producto.IdProducto)
                {
                    item.Cantidad++;
                    refreshDg();
                    return;
                }
            }

            //crea un objeto tipo rowData
            helpers.RowData rowData = ProductoToRowData(producto);
            //agrega el objeto a la lista de productos
            listaFactura.Add(rowData);
            refreshDg();
            //actualiza el datagridview
            //dg.AutoGenerateColumns = false;
            //dg.DataSource = listaProductoFactura;
            //dg.Refresh();
            //cierra el formulario
            this.Close();
        }

        //genera una funcion que acepte un objeto tipo producto y lo convierta en un objeto tipo rowData
        private helpers.RowData ProductoToRowData(entidades.Producto producto)
        {
            helpers.RowData rowData = new helpers.RowData();
            rowData.IdProducto = producto.IdProducto;
            rowData.CodigoBarra = producto.CodigoBarra;
            rowData.Nombre = producto.Nombre;
            rowData.Precio = (double)producto.Precio;
            rowData.Descripcion = producto.Descripcion;
            rowData.Cantidad = 1;
            rowData.TieneIva = producto.TieneIva;
            rowData.TieneKit = producto.TieneKit;
            rowData.DescuentoMaximo = (double)producto.DescuentoMaximo;
            rowData.estado = true;
            rowData.idcategoria = producto.idcategoria;

            //valida que si tiene iva agregar asterisco al final del nombre
            if (producto.TieneIva)
            {
                rowData.Nombre = producto.Nombre + "*";
            }


            return rowData;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Length > 0)
            {
                ProductoServices productoServices = new ProductoServices();
                dgvListaProducto.AutoGenerateColumns = false;
                dgvListaProducto.DataSource = productoServices.buscar(txtBuscar.Text);
                dgvListaProducto.Refresh();

            }
            else
            {
                dgvListaProducto.DataSource= null;
                initialDataGridConfig();
            }
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OrderColumns()
        {
            // Asegúrate de que las columnas existan antes de intentar reordenarlas
            if (dgvListaProducto.Columns["CodigoBarra"] != null) dgvListaProducto.Columns["CodigoBarra"].DisplayIndex = 0;
            if (dgvListaProducto.Columns["Nombre"] != null) dgvListaProducto.Columns["Nombre"].DisplayIndex = 1;
            if (dgvListaProducto.Columns["Descripcion"] != null) dgvListaProducto.Columns["Descripcion"].DisplayIndex = 2;
            if (dgvListaProducto.Columns["Precio"] != null) dgvListaProducto.Columns["Precio"].DisplayIndex = 3;
            if (dgvListaProducto.Columns["Stock"] != null) dgvListaProducto.Columns["Stock"].DisplayIndex = 4;
        }

        private void dgvListaProducto_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verifica que se esté formateando la columna de 'Stock'
            if (dgvListaProducto.Columns[e.ColumnIndex].Name == "Stock")
            {
                int stockValue = 0;
                if (e.Value != null && int.TryParse(e.Value.ToString(), out stockValue))
                {
                    // Si el stock es 0, cambia el color de fondo a rojo
                    if (stockValue == 0)
                    {
                        e.CellStyle.BackColor = Color.Red;
                        e.CellStyle.ForeColor = Color.White; // Cambia el texto a blanco para mejor contraste
                    }
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvListaProducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
