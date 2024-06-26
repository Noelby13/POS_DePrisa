﻿using POS_DePrisa.entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Text;
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
                string query = "SELECT * FROM Tbl_Producto where estado = 1";


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
                        command.Parameters.AddWithValue("@estado", 1);
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
                    string query = "SELECT TOP 5 * FROM Tbl_Producto WHERE Nombre LIKE @Nombre and estado = 1";
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

        public entidades.Producto obtenerProductoByCodigoBarra(string codigoBarra)
        {
            entidades.Producto producto = new entidades.Producto();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Tbl_Producto WHERE CodigoBarra = @codigoBarra";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@codigoBarra", codigoBarra);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
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
                            }
                        }
                    }
                    connection.Close();
                }
                return producto;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener producto por codigo de barra: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return producto;
        }

        //disminuye la cantidad de un producto en el inventario
        public bool disminuirStock(int idProducto, int cantidad)
        {
            bool resutado = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Tbl_Producto SET Stock = Stock - @cantidad WHERE IdProducto = @idProducto";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@cantidad", cantidad);
                        command.Parameters.AddWithValue("@idProducto", idProducto);
                        if (command.ExecuteNonQuery() > 0)
                        {
                            resutado = true;
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                String Error = $"Eror en disminuirStock()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resutado;
        }

        //eliminar un producto mediante borrado logico
        public bool eliminarProducto(int idProducto)
        {
            bool resutado = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Tbl_Producto SET Estado = 0 WHERE IdProducto = @idProducto";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idProducto", idProducto);
                        if (command.ExecuteNonQuery() > 0)
                        {
                            resutado = true;
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                String Error = $"Error en eliminarProducto()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resutado;
        }

        //actualizar un producto
        public bool actualizarProducto(entidades.Producto producto)
        {
            bool resutado = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Tbl_Producto SET CodigoBarra = @CodigoBarra, Nombre = @Nombre, Descripcion = @Descripcion, Stock = @Stock, Costo = @Precio, TieneIva = @TieneIva, TieneKit = @TieneKit, DescuentoMaximo = @DescuentoMaximo, IdCategoria = @IdCategoria WHERE IdProducto = @IdProducto";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IdProducto", producto.IdProducto);
                        command.Parameters.AddWithValue("@CodigoBarra", producto.CodigoBarra);
                        command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                        command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                        command.Parameters.AddWithValue("@Stock", producto.Stock);
                        command.Parameters.AddWithValue("@Precio", producto.Precio);
                        command.Parameters.AddWithValue("@TieneIva", producto.TieneIva);
                        command.Parameters.AddWithValue("@TieneKit", producto.TieneKit);
                        command.Parameters.AddWithValue("@DescuentoMaximo", producto.DescuentoMaximo);
                        command.Parameters.AddWithValue("@IdCategoria", producto.idcategoria);
                        if (command.ExecuteNonQuery() > 0)
                        {
                            resutado = true;
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                String Error = $"Error en actualizarProducto()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resutado;
        }
    }
}
