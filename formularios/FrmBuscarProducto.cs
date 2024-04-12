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
        public FrmBuscarProducto(DataGridView dg, List<entidades.Producto> listaProductos)
        {
            InitializeComponent();
            this.dg = dg;
            ListaProductos = listaProductos;
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

        private void addFakeData()
        {
            //crea lo productos primeros y luego los agrega a la lista
            entidades.Producto p1 = new entidades.Producto();
            p1.IdProducto = 1;
            p1.Nombre = "Producto 1";
            p1.Precio = 1000;
            p1.Stock = 10;
            p1.CodigoBarra = "1234";
            p1.Descripcion = "Descripcion del producto 1";
            ListaProductos.Add(p1);


           
    
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            addFakeData();
            dg.DataSource = null; // Limpia el origen de datos actual
            dg.DataSource = ListaProductos; // Asigna la lista actualizada como origen de datos
            dg.Refresh(); // Refresca el DataGridView para mostrar los cambios
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

    }
}
