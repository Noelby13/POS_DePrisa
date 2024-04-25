using POS_DePrisa.entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_DePrisa.dao
{
    internal class DFactura
    {

        // String de la conexion a la base de datos
        private string connectionString;

        // Constructor de la clase
        public DFactura()
        {
            connectionString = ConfigurationManager.ConnectionStrings["POS_DePrisa.Properties.Settings.DBDePrisaConnectionString"].ConnectionString;
        }


        // Metodo para listar las facturas
        public DataSet ListarFacturas()
        {
            DataSet ds = new DataSet();
            try
            {
                string query = "SELECT * FROM Tbl_Factura";

                //Se utiliza using para que el objeto se destruya al salir del bloque
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    //Se abre la conexion
                    connection.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter(query, connection))
                    {
                        if (da != null)
                        {
                            da.Fill(ds);
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                String Error = $"Eror en DFactura()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ds;
        }


        // Metodo para insertar una nueva factura
        public bool GuardarFactura(Factura factura)
        {
            bool resultado = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Tbl_Factura (IdUsuario, Fecha, IdArqueo, Estado) VALUES (@IdUsuario, @Fecha, @IdArqueo, @Estado)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IdUsuario", factura.IdUsuario);
                        command.Parameters.AddWithValue("@Fecha", factura.Fecha);
                        command.Parameters.AddWithValue("@IdArqueo", factura.IdArqueo);
                        command.Parameters.AddWithValue("@Estado", factura.Estado);
                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            resultado = true;
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                String Error = $"Eror en GuardarFactura()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultado;
        }

        //obten el id de la ultima factura
        public int ObtenerIdUltimaFactura()
        {
            int id = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT MAX(IdFactura) FROM Tbl_Factura";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        id = Convert.ToInt32(command.ExecuteScalar());
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                String Error = $"Eror en ObtenerIdUltimaFactura()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return id;
        }

        //genera un metodo para guardar los detalles de la factura
        public bool GuardarDetalleFactura(DetalleFactura detalle)
        {
            bool resultado = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Tbl_DetalleFactura (IdFactura, IdProducto, Cantidad, Precio) VALUES (@IdFactura, @IdProducto, @Cantidad, @Precio)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IdFactura", detalle.IdFactura);
                        command.Parameters.AddWithValue("@IdProducto", detalle.IdProducto);
                        command.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                        command.Parameters.AddWithValue("@Precio", detalle.Precio);
                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            resultado = true;
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                String Error = $"Eror en GuardarDetalleFactura()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultado;
        }

        //genera un metodo para guardar multiples detalles de la factura
        public bool GuardarDetallesFactura(List<DetalleFactura> detalles)
        {
            bool resultado = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();
                    try
                    {
                        foreach (DetalleFactura detalle in detalles)
                        {
                            string query = "INSERT INTO Tbl_DetalleFactura (IdFactura, IdProducto, Cantidad, Precio, Descuento) VALUES (@IdFactura, @IdProducto, @Cantidad, @Precio, @Descuento)";
                            using (SqlCommand command = new SqlCommand(query, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@IdFactura", detalle.IdFactura);
                                command.Parameters.AddWithValue("@IdProducto", detalle.IdProducto);
                                command.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                                command.Parameters.AddWithValue("@Precio", detalle.Precio);
                                command.Parameters.AddWithValue("@Descuento", detalle.Descuento);
                                int result = command.ExecuteNonQuery();
                                if (result <= 0)
                                {
                                    transaction.Rollback();
                                    return false;
                                }
                            }
                        }
                        transaction.Commit();
                        resultado = true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        String Error = $"Eror en GuardarDetallesFactura()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                        MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                String Error = $"Eror en GuardarDetallesFactura()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultado;
        }

        //Genera un metodo para guardar la factura y los detalles de la factura utilizando una transaccion
        //public bool GuardarFacturaConDetalle(Factura factura, List<DetalleFactura> detalles)
        //{
        //    bool resultado = false;
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            connection.Open();
        //            SqlTransaction transaction = connection.BeginTransaction();
        //            try
        //            {
        //                string query = "INSERT INTO Tbl_Factura (IdUsuario, Fecha, IdArqueo, Estado) VALUES (@IdUsuario, @Fecha, @IdArqueo, @Estado)";
        //                using (SqlCommand command = new SqlCommand(query, connection, transaction))
        //                {
        //                    command.Parameters.AddWithValue("@IdUsuario", factura.IdUsuario);
        //                    command.Parameters.AddWithValue("@Fecha", factura.Fecha);
        //                    command.Parameters.AddWithValue("@IdArqueo", factura.IdArqueo);
        //                    command.Parameters.AddWithValue("@Estado", factura.Estado);
        //                    int result = command.ExecuteNonQuery();
        //                    if (result > 0)
        //                    {
        //                        resultado = true;
        //                    }
        //                }
        //                if (resultado)
        //                {
        //                    foreach (DetalleFactura detalle in detalles)
        //                    {
        //                        query = "INSERT INTO Tbl_DetalleFactura (IdFactura, IdProducto, Cantidad, Precio) VALUES (@IdFactura, @IdProducto, @Cantidad, @Precio)";
        //                        using (SqlCommand command = new SqlCommand(query, connection, transaction))
        //                        {
        //                            command.Parameters.AddWithValue("@IdFactura", detalle.IdFactura);
        //                            command.Parameters.AddWithValue("@IdProducto", detalle.IdProducto);
        //                            command.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
        //                            command.Parameters.AddWithValue("@Precio", detalle.Precio);
        //                            int resultDetalle = command.ExecuteNonQuery();
        //                            if (resultDetalle <= 0)
        //                            {
        //                                resultado = false;
        //                                break;
        //                            }
        //                        }
        //                    }
        //                }
        //                if (resultado)
        //                {
        //                    transaction.Commit();
        //                }
        //                else
        //                {
        //                    transaction.Rollback();
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                transaction.Rollback();
        //                String Error = $"Eror en GuardarFacturaConDetalle()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
        //                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //            connection.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        String Error = $"Eror en GuardarFacturaConDetalle()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
        //        MessageBox.Show(Error, "Error",)
        //    }
        //}
    }
}
