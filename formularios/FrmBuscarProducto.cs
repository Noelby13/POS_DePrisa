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
    }
}
