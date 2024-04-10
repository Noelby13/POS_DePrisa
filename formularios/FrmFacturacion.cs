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
    public partial class FrmFacturacion : Form
    {
        //define una lista de productos accediento a traves del namespace entidades
        private List<entidades.Producto> listaProductos;
        
        public FrmFacturacion()
        {
            InitializeComponent();
            listaProductos = new List<entidades.Producto>();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            //agregale borde al panel
            ControlPaint.DrawBorder(e.Graphics, panel2.ClientRectangle, Color.FromArgb(144, 148, 165), ButtonBorderStyle.Solid);
        }

        private void FrmFacturacion_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dBDePrisaDataSet.Tbl_Producto' Puede moverla o quitarla según sea necesario.

            cargarDataGrid();
        }

        private void configurarData()
        {
            DataGridViewColumn columnaPrecio = dgvListaProducto.Columns["Precio"];

            if (columnaPrecio != null)
            {
                // Configurar color de fondo y formato de la columna "Precio"
                columnaPrecio.DefaultCellStyle.BackColor = Color.LightGreen;
                columnaPrecio.DefaultCellStyle.Format = "C"; // Formato de moneda
            }
            else
            {
                MessageBox.Show("La columna 'Precio' no existe.");
            }


        }
        private void ConfigurarEstiloDataGridView()
        {
            MessageBox.Show("Configurando estilo del DataGridView...");
            // Configurar estilo de las celdas
            DataGridViewCellStyle estiloCeldas = new DataGridViewCellStyle();
            estiloCeldas.BackColor = Color.White;
            estiloCeldas.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            estiloCeldas.ForeColor = Color.Black;
            estiloCeldas.SelectionBackColor = Color.FromArgb(0, 81, 161);
            estiloCeldas.SelectionForeColor = Color.White;
            dgvListaProducto.RowsDefaultCellStyle = estiloCeldas;

            // Configurar estilo de las cabeceras de columna
            DataGridViewCellStyle estiloCabeceras = new DataGridViewCellStyle();
            estiloCabeceras.BackColor = Color.Transparent;
            estiloCabeceras.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            estiloCabeceras.ForeColor = Color.Black;
            estiloCabeceras.SelectionBackColor = Color.FromArgb(0, 81, 161);
            estiloCabeceras.SelectionForeColor = Color.White;
            dgvListaProducto.ColumnHeadersDefaultCellStyle = estiloCabeceras;

            // Obtener la columna "Precio" por nombre
            DataGridViewColumn columnaPrecio = dgvListaProducto.Columns["precio"];

            if (columnaPrecio != null)
            {
                // Configurar color de fondo y formato de la columna "Precio"
                columnaPrecio.DefaultCellStyle.ForeColor = Color.LightGreen;
                MessageBox.Show("Configurando estilo de la columna 'Precio'...");
                columnaPrecio.DefaultCellStyle.Format = "C"; // Formato de moneda
                dgvListaProducto.Refresh();
            }
            else
            {
                MessageBox.Show("La columna 'Precio' no existe.");
            }
        }

        private void cargarDataGrid()
        {
            //limpia estructura del datagrid
            ////agrega columnas al datagrid
            //ProductoServices productoServices = new ProductoServices();
            //dgvListaProducto.DataSource = productoServices.listarProductos().Tables[0];
            //dgvListaProducto.Refresh();
            dgvListaProducto .DataSource = null;
            if (listaProductos != null && listaProductos.Count > 0)
            {
                dgvListaProducto.DataSource = listaProductos;
                //dgvListaProducto.Columns["Precio"].DefaultCellStyle.BackColor = Color.Red;
                //dgvListaProducto.Columns["Precio"].DefaultCellStyle.Format = "C";
                ConfigurarEstiloDataGridView();
            }
            dgvListaProducto.Refresh();
       

        }

        private void addFakeDataToListaProductos()
        {
            entidades.Producto producto = new entidades.Producto();
            producto.IdProducto = 1;
            producto.Nombre = "Producto 1";
            producto.Precio = 1000;
            listaProductos.Add(producto);
            entidades.Producto producto2 = new entidades.Producto();
            producto2.IdProducto = 2;
            producto2.Nombre = "Producto 2";
            producto2.Precio = 2000;
            listaProductos.Add(producto2);
            entidades.Producto producto3 = new entidades.Producto();
            producto3.IdProducto = 3;
            producto3.Nombre = "Producto 3";
            producto3.Precio = 3000;
            listaProductos.Add(producto3);
            entidades.Producto producto4 = new entidades.Producto();
            producto4.IdProducto = 4;
            producto4.Nombre = "Producto 4";
            producto4.Precio = 4000;
            listaProductos.Add(producto4);
            entidades.Producto producto5 = new entidades.Producto();
            producto5.IdProducto = 5;
            producto5.Nombre = "Producto 5";
            producto5.Precio = 5000;
            listaProductos.Add(producto5);
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            addFakeDataToListaProductos();
            cargarDataGrid();
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            FrmBuscarProducto frmBuscarProducto = new FrmBuscarProducto(dgvListaProducto, listaProductos);
            frmBuscarProducto.ShowDialog();
        }
    }
}
