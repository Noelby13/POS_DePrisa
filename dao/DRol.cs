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
    internal class DRol
    {

        // String de la conexion a la base de datos
        private string connectionString;

        // Constructor de la clase
        public DRol()
        {
            connectionString = ConfigurationManager.ConnectionStrings["POS_DePrisa.Properties.Settings.DBDePrisaConnectionString"].ConnectionString;
        }


        // Metodo para listar los roles
        public DataSet ListarRoles()
        {
            DataSet ds = new DataSet();
            try
            {
                string query = "SELECT * FROM Tbl_Rol";

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
                String Error = $"Eror en DRol()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ds;
        }


        // Metodo para insertar un nuevo rol
        public bool GuardarRol(Rol rol)
        {
            bool resultado = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Tbl_Rol (Nombre) VALUES (@Nombre)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", rol.Nombre);
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
                String Error = $"Eror en GuardarRol()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultado;
        }

        // Metodo para obtener el rol de un usuario
        public int BuscarRol(string nombreUsuario)
        {
            int idRol = -1; // Valor predeterminado en caso de que no se encuentre ningún rol

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT idRol FROM Tbl_Usuario WHERE nombreUsuario = @nombreUsuario";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nombreUsuario", nombreUsuario); // Asigna el valor del parámetro
                        object result = command.ExecuteScalar(); // Utiliza ExecuteScalar para obtener un solo valor
                        if (result != null)
                        {
                            idRol = Convert.ToInt32(result); // Convierte el resultado a entero
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                String Error = $"Eror en BuscarRol()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return idRol;
        }
    }
}
