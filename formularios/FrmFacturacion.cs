using Microsoft.ReportingServices.RdlExpressions.ExpressionHostObjectModel;
using POS_DePrisa.helpers;
using POS_DePrisa.negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_DePrisa.formularios
{
    public partial class FrmFacturacion : Form
    {

        //define una lista de productos accediento a traves del namespace entidades
        //private List<entidades.Producto> listaProductos;
        //private BindingList<helpers.RowData> bs;
        //private List<helpers.RowData> listaProductosFactura;

        private BindingList<helpers.RowData> listaProductoFactura;
        private bool permitirEventosDGV = false;  // Bandera para controlar la activación de eventos

        public FrmFacturacion()
        {
            InitializeComponent();
            listaProductoFactura = new BindingList<helpers.RowData>();

            //listaProductos = new List<entidades.Producto>();
            //bs = new BindingList<helpers.RowData>();
            //listaProductosFactura = new List<helpers.RowData>();
            //initialConfigDataGrid();

            //bs.ListChanged += Bs_ListChanged;

        }

        private void initialConfigDataGrid()
        {
            try
            {
                dgvListaProducto.DataSource = listaProductoFactura;
                dgvListaProducto.Columns["idproducto"].Visible = false;
                dgvListaProducto.Columns["codigobarra"].HeaderText = "Código de barra";
                dgvListaProducto.Columns["nombre"].HeaderText = "Nombre";
                dgvListaProducto.Columns["descripcion"].HeaderText = "Descripción";
                dgvListaProducto.Columns["precio"].HeaderText = "Precio venta";
                dgvListaProducto.Columns["cantidad"].HeaderText = "Cantidad";
                dgvListaProducto.Columns["importe"].HeaderText = "Importe";
                dgvListaProducto.Columns["tieneiva"].Visible = false;
                dgvListaProducto.Columns["tienekit"].Visible = false;
                dgvListaProducto.Columns["descuentomaximo"].Visible = false;
                dgvListaProducto.Columns["estado"].Visible = false;
                dgvListaProducto.Columns["idcategoria"].Visible = false;
                dgvListaProducto.Columns["descuentoAplicado"].Visible = false;


                foreach (DataGridViewColumn column in dgvListaProducto.Columns)
                {
                    if (column.Name != "Cantidad")
                    {
                        column.ReadOnly = true;
                    }
                }
                ActivarDeteccionCambios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void actualizarDgvLista()
        {
            try
            {
                DesactivarDeteccionCambios();
                    dgvListaProducto.DataSource = listaProductoFactura  ;
                dgvListaProducto.Refresh();
                if (listaProductoFactura.Count > 0)
                {
                    //calcula el total de la compra utilizando el importe
                    double total = 0;
                    foreach (helpers.RowData item in listaProductoFactura)
                    {
                        total += item.Importe;
                    }
                    lblTotal.Text = "C$ " + total.ToString();
                    lblCantidad.Text = listaProductoFactura.Count + " Productos en la venta actual";
                }
                else
                {
                    lblTotal.Text = "C$ 0";
                }

                ActivarDeteccionCambios();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }


        //private void initialConfigDataGrid()
        //{
        //    dgvListaProducto.AutoGenerateColumns=true;
        //    dgvListaProducto.DataSource= bs;
        //    dgvListaProducto.Columns["IdProducto"].Visible = false;
        //    dgvListaProducto.Columns["CodigoBarra"].HeaderText = "Código de Barra";
        //    dgvListaProducto.Columns["Nombre"].HeaderText = "Nombre";
        //    dgvListaProducto.Columns["Descripcion"].HeaderText = "Descripción";
        //    dgvListaProducto.Columns["Precio"].HeaderText = "Precio Venta";
        //    dgvListaProducto.Columns["Cantidad"].HeaderText = "Cantidad";
        //    dgvListaProducto.Columns["Importe"].HeaderText = "Importe";
        //    dgvListaProducto.Columns["TieneIva"].Visible = false;
        //    dgvListaProducto.Columns["TieneKit"].Visible = false;
        //    dgvListaProducto.Columns["DescuentoMaximo"].Visible = false;
        //    dgvListaProducto.Columns["estado"].Visible = false;
        //    dgvListaProducto.Columns["idcategoria"].Visible = false;
        //    dgvListaProducto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        //    //haz editable la columna de cantidad
        //    foreach (DataGridViewColumn column in dgvListaProducto.Columns)
        //    {
        //        if (column.Name != "Cantidad" )
        //        {
        //            column.ReadOnly = true;
        //        }
        //    }
        //}

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            //agregale borde al panel
            ControlPaint.DrawBorder(e.Graphics, panel2.ClientRectangle, Color.FromArgb(144, 148, 165), ButtonBorderStyle.Solid);
        }

        private void FrmFacturacion_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dBDePrisaDataSet.Tbl_Producto' Puede moverla o quitarla según sea necesario.
            //initialConfigDataGrid();
            //cargarDataGrid();
            initialConfigDataGrid();

        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            FrmBuscarProducto frmBuscarProducto = new FrmBuscarProducto(dgvListaProducto,listaProductoFactura);
            frmBuscarProducto.refreshDg= actualizarDgvLista;
            frmBuscarProducto.ShowDialog();
        }

        

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            actualizarDgvLista();
        }


        //private void ConfigurarEstiloDataGridView()
        //{
        //    // Configurar estilo de las celdas
        //    DataGridViewCellStyle estiloCeldas = new DataGridViewCellStyle();
        //    estiloCeldas.BackColor = Color.White;
        //    estiloCeldas.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
        //    estiloCeldas.ForeColor = Color.Black;
        //    estiloCeldas.SelectionBackColor = Color.FromArgb(0, 81, 161);
        //    estiloCeldas.SelectionForeColor = Color.White;
        //    dgvListaProducto.RowsDefaultCellStyle = estiloCeldas;

        //    // Configurar estilo de las cabeceras de columna
        //    DataGridViewCellStyle estiloCabeceras = new DataGridViewCellStyle();
        //    estiloCabeceras.BackColor = Color.Transparent;
        //    estiloCabeceras.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
        //    estiloCabeceras.ForeColor = Color.Black;
        //    estiloCabeceras.SelectionBackColor = Color.FromArgb(0, 81, 161);
        //    estiloCabeceras.SelectionForeColor = Color.White;
        //    dgvListaProducto.ColumnHeadersDefaultCellStyle = estiloCabeceras;

        //    // Obtener la columna "Precio" por nombre
        //    DataGridViewColumn columnaPrecio = dgvListaProducto.Columns["precio"];

        //    if (columnaPrecio != null)
        //    {
        //        // Configurar color de fondo y formato de la columna "Precio"
        //        columnaPrecio.DefaultCellStyle.ForeColor = Color.LightGreen;
        //        columnaPrecio.DefaultCellStyle.Format = "C"; // Formato de moneda
        //        dgvListaProducto.Refresh();
        //    }
        //    else
        //    {
        //        MessageBox.Show("La columna 'Precio' no existe.");
        //    }
        //}

        //private void addNewRow()
        //{

        //}
        //private void addDataToBs()
        //{
        //                helpers.RowData rowData = new helpers.RowData();
        //    rowData.IdProducto = 1;
        //    rowData.CodigoBarra = "123456";
        //    rowData.Nombre = "Producto 1";
        //    rowData.Descripcion = "Descripcion del producto 1";
        //    rowData.Precio = 1000;
        //    rowData.Cantidad = 1;
        //    rowData.TieneIva = false;
        //    rowData.TieneKit = false;
        //    rowData.DescuentoMaximo = 0;
        //    rowData.estado = true;
        //    rowData.idcategoria = 1;
        //    bs.Add(rowData);
        //    helpers.RowData rowData1 = new helpers.RowData();
        //    rowData1.IdProducto = 1;
        //    rowData1.CodigoBarra = "12";
        //    rowData1.Nombre = "Producto 2";
        //    rowData1.Descripcion = "Descripcion del producto 2";
        //    rowData1.Precio = 1231;
        //    rowData1.Cantidad = 1;
        //    rowData1.TieneIva = false;
        //    rowData1.TieneKit = false;
        //    rowData1.DescuentoMaximo = 0.2m;
        //    rowData1.estado = true;
        //    rowData1.idcategoria = 1;
        //    bs.Add(rowData1);
        //}

        //private void cargarDataGrid()
        //{
        //    //limpia estructura del datagrid
        //    ////agrega columnas al datagrid
        //    //ProductoServices productoServices = new ProductoServices();
        //    //dgvListaProducto.DataSource = productoServices.listarProductos().Tables[0];
        //    //dgvListaProducto.Refresh();
        //    dgvListaProducto .DataSource = null;
        //    if (listaProductos != null && listaProductos.Count > 0)
        //    {
        //        dgvListaProducto.DataSource = listaProductos;
        //        //dgvListaProducto.Columns["Precio"].DefaultCellStyle.BackColor = Color.Red;
        //        //dgvListaProducto.Columns["Precio"].DefaultCellStyle.Format = "C";
        //    }
        //    dgvListaProducto.Refresh();
        //    ConfigurarEstiloDataGridView();



        //}

        //private void addFakeDataToListaProductos()
        //{
        //    entidades.Producto producto = new entidades.Producto();
        //    producto.IdProducto = 1;
        //    producto.Nombre = "Producto 1";
        //    producto.Precio = 1000;
        //    listaProductos.Add(producto);
        //    entidades.Producto producto2 = new entidades.Producto();
        //    producto2.IdProducto = 2;
        //    producto2.Nombre = "Producto 2";
        //    producto2.Precio = 2000;
        //    listaProductos.Add(producto2);
        //    entidades.Producto producto3 = new entidades.Producto();
        //    producto3.IdProducto = 3;
        //    producto3.Nombre = "Producto 3";
        //    producto3.Precio = 3000;
        //    listaProductos.Add(producto3);
        //    entidades.Producto producto4 = new entidades.Producto();
        //    producto4.IdProducto = 4;
        //    producto4.Nombre = "Producto 4";
        //    producto4.Precio = 4000;
        //    listaProductos.Add(producto4);
        //    entidades.Producto producto5 = new entidades.Producto();
        //    producto5.IdProducto = 5;
        //    producto5.Nombre = "Producto 5";
        //    producto5.Precio = 5000;
        //    listaProductos.Add(producto5);
        //}

        //private void btnAgregarProducto_Click(object sender, EventArgs e)
        //{
        //    //addFakeDataToListaProductos();
        //    //cargarDataGrid();
        //    addDataToBs();
        //}

        //private void btnBuscarProducto_Click(object sender, EventArgs e)
        //{
        //    FrmBuscarProducto frmBuscarProducto = new FrmBuscarProducto(dgvListaProducto, listaProductos);
        //    frmBuscarProducto.ShowDialog();
        //}

        //private void btnEliminarProducto_Click(object sender, EventArgs e)
        //{
        //    addNewRow();
        //}



        private void dgvListaProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //valida que si es la columna precio, calcula si se puede editar en base al porcentaje de descuento
            try
            {
                if (dgvListaProducto.Columns[e.ColumnIndex].Name == "Precio")
                {
                    decimal descuentomaximo = Convert.ToDecimal(dgvListaProducto.Rows[e.RowIndex].Cells["DescuentoMaximo"].Value);
                    //valida si el porcentaje de descuento es mayor a 0
                    if (descuentomaximo > 0)
                    {
                        Rectangle rect = dgvListaProducto.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                        // Calcula la posición en pantalla
                        Point locationOnScreen = dgvListaProducto.PointToScreen(new Point(rect.Right, rect.Top));
                        //obten codigoBarra del producto seleccionado
                        string codigoBarra = dgvListaProducto.Rows[e.RowIndex].Cells["CodigoBarra"].Value.ToString();
                        // Crea e inicializa el formulario frmDescuento
                        FrmDescuento descuentoForm = new FrmDescuento(codigoBarra, listaProductoFactura, locationOnScreen.X, locationOnScreen.Y);
                        descuentoForm.refreshPrincipalDg = actualizarDgvLista;
                        descuentoForm.StartPosition = FormStartPosition.Manual;
                        descuentoForm.Location = locationOnScreen; // Coloca el formulario en la posición calculada
                                                                   // Muestra el formulario
                        descuentoForm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show($"El producto {dgvListaProducto.Rows[e.RowIndex].Cells["Nombre"].Value} no tiene descuento", "Error al intentar aplicar descuento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dgvListaProducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //valida que si la columna es cantidad , calcula si se puede editar en base al stock
            //    actualizarDgvLista();
            //if (dgvListaProducto.Columns[e.ColumnIndex].Name == "Cantidad")
            //{
            //    MessageBox.Show("Cantidad");
            //    //obten stock del producto seleccionado
            ////    int stock = Convert.ToInt32(dgvListaProducto.Rows[e.RowIndex].Cells["Stock"].Value);
            ////    //valida si el stock es mayor a 0
            ////    if (stock > 0)
            ////    {
            ////        Rectangle rect = dgvListaProducto.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            ////        // Calcula la posición en pantalla
            //        Point locationOnScreen = dgvListaProducto.PointToScreen(new Point(rect.Right, rect.Top));
            //        //obten codigoBarra del producto seleccionado
            //        string codigoBarra = dgvListaProducto.Rows[e.RowIndex].Cells["CodigoBarra"].Value.ToString();
            //        // Crea e inicializa el formulario frmCantidad
            //        FrmCantidad cantidadForm = new FrmCantidad(codigoBarra, listaProductoFactura, locationOnScreen.X, locationOnScreen.Y);
            //        cantidadForm.refreshPrincipalDg = actualizarDgvLista;
            //        cantidadForm.StartPosition = FormStartPosition.Manual;
            //        cantidadForm.Location = locationOnScreen; // Coloca el formulario en la posición calculada
            //        // Muestra el formulario
            //        cantidadForm.ShowDialog();
            //    }
            //}
        }

        private void dgvListaProducto_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            //valida que si la columna es cantidad
         
        }

        private void dgvListaProducto_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!permitirEventosDGV) return;  // No ejecutar si la bandera está desactivada


            if (dgvListaProducto.Columns[e.ColumnIndex].Name == "Cantidad")
            {
                //obten el codigo de barra del producto seleccionado
                string codigoBarra = dgvListaProducto.Rows[e.RowIndex].Cells["CodigoBarra"].Value.ToString();

                //obten stock del producto seleccionado
                ProductoServices productoServices = new ProductoServices();
                var producto = productoServices.obtenerProducto(codigoBarra);

                //valida que la cantidad ingresada no sea mayor al stock

                if (Convert.ToInt32(dgvListaProducto.Rows[e.RowIndex].Cells["Cantidad"].Value) > producto.Stock)
                {
                    MessageBox.Show($"La cantidad ingresada es mayor al stock del producto {producto.Nombre}", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvListaProducto.Rows[e.RowIndex].Cells["Cantidad"].Value = 1;
                    return;
                }
     
                
                actualizarDgvLista();

            }
        }

        // Método para activar la detección de cambios
        public void ActivarDeteccionCambios()
        {
            permitirEventosDGV = true;
        }

        // Método para desactivar la detección de cambios
        public void DesactivarDeteccionCambios()
        {
            permitirEventosDGV = false;
        }

        private void dgvListaProducto_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //cambia el color de la celda de las columnas importe a verde
            if (dgvListaProducto.Columns[e.ColumnIndex].Name == "Importe")
            {
                e.CellStyle.BackColor = Color.LightGreen;
            }
        }

        private void txtCodigoProducto_TextChanged(object sender, EventArgs e)
        {

        }

        private helpers.RowData ProductoToRowData(entidades.Producto producto)
        {
            helpers.RowData rowData = new helpers.RowData();
            rowData.IdProducto = producto.IdProducto;
            rowData.CodigoBarra = producto.CodigoBarra;
            rowData.Nombre = producto.Nombre;
            rowData.Precio = (double)producto.Precio;
            rowData.Cantidad = 1;
            rowData.TieneIva = producto.TieneIva;
            rowData.TieneKit = producto.TieneKit;
            rowData.DescuentoMaximo = (double)producto.DescuentoMaximo;
            rowData.estado = true;
            rowData.idcategoria = producto.idcategoria;


            if (producto.TieneIva)
            {
                rowData.Nombre = producto.Nombre + "*";
            }


            return rowData;
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (txtCodigoProducto.Text == "")
            {
                return;
            }

            ProductoServices productoServices = new ProductoServices();
            entidades.Producto producto = productoServices.obtenerProducto(txtCodigoProducto.Text);

            //se valora si el producto existe en la base de datos. La razon del cero es el valor por defecto que se le asigna cuando viene nullo por parte de la BD
            if (producto.IdProducto != 0)
            {
                if(producto.Stock == 0)
                {
                    MessageBox.Show("Producto sin stock");
                    return;
                }

                var rowData = ProductoToRowData(producto);
                listaProductoFactura.Add(rowData);
                actualizarDgvLista();
                txtCodigoProducto.Text = "";
            }
            else
            {
                MessageBox.Show("Producto no encontrado");
            }
            

            //obten el producto seleccionado

        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            

            if (listaProductoFactura.Count == 0)
            {
                MessageBox.Show("No hay productos en la lista");
                return;
            }

            //valida que 

            FrmCobrar cobrarForm = new FrmCobrar(listaProductoFactura);
            cobrarForm.refreshPrincipalDg = actualizarDgvLista;
            cobrarForm.ShowDialog();
        }


        //private void Bs_ListChanged(object sender, ListChangedEventArgs e)
        //{
        //    // Actualizar el Label aquí
        //    MessageBox.Show("DataBindingComplete");
        //    changeInferiorLabel();

        //    // Puedes poner más lógica de actualización aquí dependiendo de tus necesidades
        //}

        //private void changeInferiorLabel()
        //{
        //    if (bs.Count > 0)
        //    {
        //        //calcula el total de la compra utilizando el importe
        //        decimal total = 0;
        //        foreach (helpers.RowData item in bs)
        //        {
        //            total += item.Precio;
        //        }
        //        lblTotal.Text = "C$ " + total.ToString();
        //        lblCantidad.Text = bs.Count +" Productos en la venta actual";
        //    }
        //    else
        //    {
        //        lblTotal.Text = "C$ 0";
        //    }




        //}
    }





        //private void dgvListaProducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    // Comprueba si el click fue en la columna de 'Precio'
        //    if (dgvListaProducto.Columns[e.ColumnIndex].Name == "Precio")
        //    {
        //        // Obtiene el descuento máximo permitido de la celda correspondiente
        //        decimal descuentoMaximo = Convert.ToDecimal(dgvListaProducto.Rows[e.RowIndex].Cells["DescuentoMaximo"].Value);

        //        // Verifica si existe un descuento máximo y es mayor que 0
        //        if (descuentoMaximo > 0)
        //        {
        //            // Permite que la celda de precio sea editable
        //            dgvListaProducto.Rows[e.RowIndex].Cells["Precio"].ReadOnly = false;

        //            // Solicita al usuario ingresar el porcentaje de descuento que desea aplicar
        //            string inputDescuento = M("Ingrese el porcentaje de descuento a aplicar, máximo " + descuentoMaximo.ToString() + "%:", "Descuento", "0");
        //            decimal descuentoIngresado;
        //            if (decimal.TryParse(inputDescuento, out descuentoIngresado))
        //            {
        //                if (descuentoIngresado <= descuentoMaximo)
        //                {
        //                    // Calcula el nuevo precio con el descuento aplicado si es válido
        //                    decimal precioOriginal = Convert.ToDecimal(dgvListaProducto.Rows[e.RowIndex].Cells["Precio"].Value);
        //                    decimal precioConDescuento = precioOriginal * (1 - (descuentoIngresado / 100));
        //                    dgvListaProducto.Rows[e.RowIndex].Cells["Precio"].Value = precioConDescuento;
        //                }
        //                else
        //                {
        //                    // Informa al usuario que el descuento ingresado supera el máximo permitido
        //                    MessageBox.Show("El descuento ingresado supera el máximo permitido. El descuento máximo que puede aplicar es del " + descuentoMaximo.ToString() + "%.");
        //                }
        //            }
        //            else
        //            {
        //                // Informa al usuario que el valor ingresado no es un número válido
        //                MessageBox.Show("Por favor, ingrese un número válido para el descuento.");
        //            }
        //        }
        //        else
        //        {
        //            // Indica que no se puede aplicar descuento a este producto
        //            MessageBox.Show("No se puede aplicar descuento a este producto.");
        //        }
        //    }
        //}

}


