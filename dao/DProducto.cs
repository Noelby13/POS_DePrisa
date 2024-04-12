using POS_DePrisa.entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_DePrisa.dao
{
    internal class DProducto
    {
        private string connectionString;

        public DProducto()
        {
            connectionString = ConfigurationManager.ConnectionStrings["POS_DePrisa.Properties.Settings.DBDePrisaConnectionString"].ConnectionString;
        }

        public DataSet ListarProductos()
        {
            DataSet ds = new DataSet();

            try
            {
                string query = "SELECT * FROM Tbl_Producto";


                //Utilizamos using para que el objeto se destruya al salir del bloque
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    //abrimos la conexión
                    connection.Open();


                    using (SqlDataAdapter da = new SqlDataAdapter(query, connection))
                    {
                        if (da!=null)
                        {
                            da.Fill(ds);
                        }
                    }
                    connection.Close();
                }


            }
            catch (Exception ex) 
            {
                String Error = $"Eror en DProducto()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return ds;

        }

        public bool guardarProducto(Producto producto)
        {
            bool resultado = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Tbl_Producto (CodigoBarra, Nombre, Descripcion, Stock, Costo, TieneIva, TieneKit, DescuentoMaximo, estado, idcategoria) VALUES (@CodigoBarra, @Nombre, @Descripcion, @Stock, @Costo, @TieneIva, @TieneKit, @DescuentoMaximo, @estado, @idcategoria)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CodigoBarra", producto.CodigoBarra);
                        command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                        command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                        command.Parameters.AddWithValue("@Stock", producto.Stock);
                        command.Parameters.AddWithValue("@Costo", producto.Precio);
                        command.Parameters.AddWithValue("@TieneIva", producto.TieneIva);
                        command.Parameters.AddWithValue("@TieneKit", producto.TieneKit);
                        command.Parameters.AddWithValue("@DescuentoMaximo", producto.DescuentoMaximo);
                        command.Parameters.AddWithValue("@estado", producto.estado);
                        command.Parameters.AddWithValue("@idcategoria", producto.idcategoria);
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
                String Error = $"Eror en guardarProducto()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultado;   
        }

        public int obtenerIdProducto(string codigoBarra)
        {
            int idProducto = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT IdProducto FROM Tbl_Producto WHERE CodigoBarra = @CodigoBarra";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CodigoBarra", codigoBarra);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                idProducto = reader.GetInt32(0);
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                String Error = $"Eror en obtenerIdProducto()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return idProducto;
        }


        //validar si el codigo de barra ya existe
        public bool validarCodigoBarra(string codigoBarra)
        {
            bool resultado = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Tbl_Producto WHERE CodigoBarra = @CodigoBarra";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CodigoBarra", codigoBarra);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            resultado = true;
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                String Error = $"Eror en validarCodigoBarra()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultado;
        }

        public List<Producto> buscar(String nombre) {
            List<Producto> productos = new List<Producto>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT TOP 5 * FROM Tbl_Producto WHERE Nombre LIKE @Nombre";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", "%" + nombre + "%");
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Producto producto = new Producto();
                                producto.IdProducto = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                                producto.CodigoBarra = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                                producto.Nombre = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                                producto.Descripcion = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                                producto.Stock = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);
                                producto.Precio = reader.IsDBNull(5) ? 0.0 : Convert.ToDouble(reader.GetValue(5));
                                producto.TieneIva = reader.IsDBNull(6) ? false : reader.GetBoolean(6);
                                producto.TieneKit = reader.IsDBNull(7) ? false : reader.GetBoolean(7);
                                producto.DescuentoMaximo = reader.IsDBNull(8) ? 0f : float.Parse(reader.GetValue(8).ToString());
                                producto.estado = reader.IsDBNull(9) ? 0 : reader.GetInt32(9);
                                producto.idcategoria = reader.IsDBNull(10) ? 0 : reader.GetInt32(10);
                                productos.Add(producto);
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                String Error = $"Eror en buscar()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return productos;
        }
    }
}
