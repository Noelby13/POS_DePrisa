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
    internal class DArqueoCaja
    {
        // String de la conexion a la base de datos
        private string connectionString;

        // Constructor de la clase
        public DArqueoCaja()
        {
            connectionString = ConfigurationManager.ConnectionStrings["POS_DePrisa.Properties.Settings.DBDePrisaConnectionString"].ConnectionString;
        }


        // Metodo para listar los arqueos de caja
        //Para qué rayos Henry hizo esta función? será para algún reporte?
        public DataSet ListarArqueoCaja()
        {
            DataSet ds = new DataSet();
            try
            {
                string query = "Select * from vwArqueoCaja";

                //Se utiliza using para que el objeto se destruya al salir del bloque
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    //Se abre la conexion
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
                String Error = $"Eror en DArqueoCaja()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ds;
        }


        // Metodo para insertar un nuevo arqueo de caja
        //Este arqueo todavia no lo usa, creo que esto se podria cambiar y en lugar de hacerlo con un insert puede ser un update 
        public bool GuardarArqueoCaja(ArqueoCaja arqueoCaja)
        {
            bool resultado = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "usp_CerrarArqueoDeCaja"; // Nombre del procedimiento almacenado
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Agregar parámetros
                        command.Parameters.AddWithValue("@idArqueo", arqueoCaja.IdArqueoCaja);
                        command.Parameters.AddWithValue("@MontoFinal", arqueoCaja.MontoFinal);
                        command.Parameters.AddWithValue("@fechaCierre", DateTime.Now);

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
                String Error = $"Error en ActualizarMontoFinal\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultado;
        }

        //Inicia el arqueo de caja usando un procedimiento almacenado
        //1 = Abierto, 2 = Cerrado,
        public bool ActualizarMontoFinal(ArqueoCaja arqueoCaja)
        {
            bool resultado = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "usp_ActulizarMontoFinal"; // Nombre del procedimiento almacenado
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Agregar parámetros
                        command.Parameters.AddWithValue("@idArqueo", arqueoCaja.IdArqueoCaja);
                        command.Parameters.AddWithValue("@MontoFinal", arqueoCaja.MontoFinal);

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
                String Error = $"Error en ActualizarMontoFinal\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultado;
        }

        public bool IniciarArqueoCaja(ArqueoCaja arqueoCaja)
        {
            bool resultado = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "usp_InsertarArqueoCaja"; // Nombre del procedimiento almacenado
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Agregar parámetros
                        command.Parameters.AddWithValue("@MontoInicial", arqueoCaja.MontoInicial);
                        command.Parameters.AddWithValue("@MontoFinal", arqueoCaja.MontoFinal);
                        command.Parameters.AddWithValue("@FechaApertura", arqueoCaja.FechaApertura);
                        command.Parameters.AddWithValue("@Estado", arqueoCaja.Estado);
                        command.Parameters.AddWithValue("@IdUsuario", arqueoCaja.IdUsuario);

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
                String Error = $"Error en IniciarArqueoCaja()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultado;
        }

        //validar si existe un arqueo de caja abierto 
        /*
        public bool ExisteArqueoCajaAbierto()
        {
            bool resultado = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Tbl_ArqueoCaja WHERE estado = 1";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
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
                String Error = $"Eror en ExisteArqueoCajaAbierto()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultado;
        }
        */

        //obtener el arqueo de caja abierto
        //Estado Arqueo de Caja
        //1 = abierto
        //0 = cerrado
        public ArqueoCaja ObtenerArqueoCajaAbierto()
        {
            ArqueoCaja arqueoCaja = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("usp_ObtenerArqueosActivos", connection))
                    {
                        // Configurar el comando como un procedimiento almacenado
                        command.CommandType = CommandType.StoredProcedure;

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            arqueoCaja = new ArqueoCaja(); // Crear objeto si hay datos
                            while (reader.Read())
                            {
                                arqueoCaja.IdArqueoCaja = reader.GetInt32(0);
                                arqueoCaja.MontoInicial = reader.GetDecimal(1);
                                arqueoCaja.MontoFinal = reader.GetDecimal(2); // Si deseas leer MontoFinal, descomenta esta línea
                                arqueoCaja.FechaApertura = reader.GetDateTime(3);
                                //arqueoCaja.FechaCierre = reader.GetDateTime(4); // Si deseas leer FechaCierre, descomenta esta línea
                                arqueoCaja.Estado = reader.GetBoolean(5);
                                arqueoCaja.IdUsuario = reader.GetInt32(6);
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                String Error = $"Error en ObtenerArqueoCajaAbierto()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return arqueoCaja;
        }
    }
}
