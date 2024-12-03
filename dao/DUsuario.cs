using POS_DePrisa.entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_DePrisa.dao
{
    internal class DUsuario
    {

        // String de la conexion a la base de datos
        private string connectionString;

        // Constructor de la clase
        public DUsuario()
        {
            connectionString = ConfigurationManager.ConnectionStrings["POS_DePrisa.Properties.Settings.DBDePrisaConnectionString"].ConnectionString;
        }


        // Metodo para listar los usuarios
        public DataSet ListarUsuarios()
        {
            DataSet ds = new DataSet();
            try
            {
                string query = "select * from vwListarUsuarios";

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
                String Error = $"Eror en DUsuario()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ds;
        }


        // Metodo para insertar un nuevo usuario
        public bool GuardarUsuario(Usuario usuario)
        {
            bool resultado = false;
            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "Exec createUser @Nombre, @NombreUsuario, @Pw, @FechaCreacion, @Estado, @IdRol";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        command.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                        command.Parameters.AddWithValue("@Pw", usuario.Pw);
                        command.Parameters.AddWithValue("@FechaCreacion", usuario.FechaCreacion);
                        command.Parameters.AddWithValue("@Estado", 1);
                        command.Parameters.AddWithValue("@IdRol", usuario.IdRol);
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
                String Error = $"Eror en GuardarUsuario()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultado;
        }

       

        public bool validarCredenciales(string nombreUsuario, string contraseña)
        {
            bool resultado = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("validarCredenciales", connection))
                    {
                        // Configurar como procedimiento almacenado
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        // Agregar parámetros de entrada
                        command.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                        command.Parameters.AddWithValue("@Pw", contraseña);
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
                String Error = $"Eror en validarCredenciales()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultado;
        }

        public Usuario ObtenerUsuarioPorNombreUsuario(string nombreUsuario)
        {
            Usuario usuario = null; // Inicializamos el usuario como null
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("ObtenerUsuarioPorNombreUsuario", connection))
                    {
                        // Configurar como procedimiento almacenado
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        // Agregar parámetros de entrada
                        command.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read()) // Si hay filas en el resultado
                        {
                            // Crear un nuevo objeto Usuario y establecer sus propiedades
                            usuario = new Usuario
                            {
                                IdUsuario = Convert.ToInt32(reader["idUsuario"]),
                                Nombre = reader["nombre"].ToString(),
                                NombreUsuario = reader["nombreUsuario"].ToString(),
                                Pw = reader["pw"].ToString(),
                                FechaCreacion = Convert.ToDateTime(reader["fechaCreacion"]),
                                Estado = Convert.ToInt32(reader["estado"]),
                                IdRol = Convert.ToInt32(reader["idRol"])
                            };
                        }

                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                String Error = $"Eror en validarCredenciales()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return usuario; // Devolvemos el usuario encontrado o null si no se encuentra coincidencia
        }

        public DataSet buscarUsuario(String nombre) //usp_BuscarUsuario
        {
            DataSet ds = new DataSet();
            try
            {
               
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("usp_BuscarUsuario", connection))
                    {
                        // Configurar como procedimiento almacenado
                        command.CommandType = CommandType.StoredProcedure;

                        // Agregar parámetros de entrada
                        command.Parameters.AddWithValue("@nombre", "%" + nombre + "%");

                        using (SqlDataAdapter da = new SqlDataAdapter(command))
                        {
                                da.Fill(ds);
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                String Error = $"Error en buscarUsuario()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ds;
        }

        // Método para editar un usuario existente
        public bool actualizarUsuario(Usuario usuario)
        {
            bool resultado = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "Exec usp_ActualizarUsuario @Nombre, @NombreUsuario, @Pw, @IdRol, @idUsuario";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        command.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                        command.Parameters.AddWithValue("@Pw", usuario.Pw);
                        command.Parameters.AddWithValue("@IdRol", usuario.IdRol);
                        command.Parameters.AddWithValue("@idUsuario", usuario.IdUsuario);
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
                String Error = $"Error en actualizarUsuario()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultado;
        }

        public bool validarUsuarioUnico(Usuario usuario)
        {
            bool resultado = true; // Cambiado a true para que sea verdadero si el usuario es único

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Tbl_Usuario WHERE nombreUsuario = @nombreUsuario";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            resultado = false; // Cambiado a false si se encuentra una fila con el mismo nombre de usuario
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                String Error = $"Eror en validarUsuarioUnico()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return resultado;
        }

        //Método para validar si un usario existe más de una vez
public bool ValidarUserNameUnico(Usuario usuario)
{
    bool resultado = true; // Inicialmente suponemos que el usuario es único

    try
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            
            // Usar el procedimiento almacenado en lugar de una consulta directa
            using (SqlCommand command = new SqlCommand("usp_ObtenerUsuarioActivo", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                
                // Agregar el parámetro requerido por el procedimiento almacenado
                command.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);

                // Ejecutar el procedimiento almacenado y obtener el resultado
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int idObtenido = reader.GetInt32(0); // Obtener el idUsuario
                        
                        // Si el ID obtenido es diferente al del usuario proporcionado, el nombre de usuario no es único
                        if (idObtenido != usuario.IdUsuario)
                        {
                            resultado = false;
                        }
                    }
                }
            }
            connection.Close();
        }
    }
    catch (Exception ex)
    {
        String Error = $"Error en ValidarUserNameUnico()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
        MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    return resultado;
}

        //Método para eliminar un usuario
        public bool eliminarUsuario(Usuario usuario)
        {
            bool resultado = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Procedimiento almacenado en lugar de query directa
                    string storedProcedure = "usp_DesactivarUsuario";
                    using (SqlCommand command = new SqlCommand(storedProcedure, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Agregar parámetro requerido por el procedimiento almacenado
                        command.Parameters.AddWithValue("@idUsuario", usuario.IdUsuario);

                        int result = command.ExecuteNonQuery();

                        // Verificar si el procedimiento afectó filas
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
                string error = $"Error en eliminarUsuario()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return resultado;
        }


    }
}
