using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS_DePrisa.entidades;

namespace POS_DePrisa.dao
{
    internal class DVerificarAcceso
    {
        // String de la conexion a la base de datos
        private string connectionString;

        // Constructor de la clase
        public DVerificarAcceso()
        {
            connectionString = ConfigurationManager.ConnectionStrings["POS_DePrisa.Properties.Settings.DBDePrisaConnectionString"].ConnectionString;
        }

        // Metodo para listar los usuarios
        public int VerificarAcceso(Usuario usuario, DateTime fechaHoraAcceso)
        {
            int resultado = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("verificarAccesoHorario", connection))
                    {
                        // Configurar como procedimiento almacenado
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        // Agregar parámetros de entrada
                        command.Parameters.AddWithValue("@idUsuario", usuario.IdUsuario);
                        command.Parameters.AddWithValue("@idRol", usuario.IdRol);
                        command.Parameters.AddWithValue("@fechaHoraAcceso", fechaHoraAcceso);

                        // Agregar parámetro de retorno
                        SqlParameter returnValue = new SqlParameter();
                        returnValue.Direction = System.Data.ParameterDirection.ReturnValue;
                        command.Parameters.Add(returnValue);

                        // Ejecutar el comando
                        command.ExecuteNonQuery();

                        // Recuperar el valor de retorno
                        resultado = (int)returnValue.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones
                Console.WriteLine($"Error: {ex.Message}");
            }

            return resultado;




        }
    }
}
