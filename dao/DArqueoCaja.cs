﻿using POS_DePrisa.entidades;
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
        public DataSet ListarArqueoCaja()
        {
            DataSet ds = new DataSet();
            try
            {
                string query = "SELECT * FROM Tbl_ArqueoCaja";

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
        public bool GuardarArqueoCaja(ArqueoCaja arqueoCaja)
        {
            bool resultado = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Tbl_ArqueoCaja (MontoInicial, MontoFinal, FechaApertura, FechaCierre, Estado, IdUsuario) VALUES (@MontoInicial, @MontoFinal, @FechaApertura, @FechaCierre, @Estado, @IdUsuario)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MontoInicial", arqueoCaja.MontoInicial);
                        command.Parameters.AddWithValue("@MontoFinal", arqueoCaja.MontoFinal);
                        command.Parameters.AddWithValue("@FechaApertura", arqueoCaja.FechaApertura);
                        command.Parameters.AddWithValue("@FechaCierre", arqueoCaja.FechaCierre);
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
                String Error = $"Eror en InsertarArqueoCaja()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultado;
        }

        //inicia el arqueo de caja
        //1 = Abierto, 2 = Cerrado,
        public bool IniciarArqueoCaja(ArqueoCaja arqueoCaja)
        {
            bool resultado = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Tbl_ArqueoCaja (MontoInicial, FechaApertura, Estado, IdUsuario) VALUES (@MontoInicial, @FechaApertura, @Estado, @IdUsuario)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MontoInicial", arqueoCaja.MontoInicial);
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
                String Error = $"Eror en IniciarArqueoCaja()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultado;
        }

        //validar si existe un arqueo de caja abierto 
        public bool ExisteArqueoCajaAbierto()
        {
            bool resultado = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Tbl_ArqueoCaja WHERE Estado = 1";
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

        //obtener el arqueo de caja abierto
        public ArqueoCaja ObtenerArqueoCajaAbierto()
        {
            ArqueoCaja arqueoCaja = new ArqueoCaja();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Tbl_ArqueoCaja WHERE Estado = 1";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                arqueoCaja.IdArqueoCaja = reader.GetInt32(0);
                                arqueoCaja.MontoInicial = reader.GetDecimal(1);
                                //arqueoCaja.MontoFinal = reader.GetDecimal(2);
                                arqueoCaja.FechaApertura = reader.GetDateTime(3);
                                //arqueoCaja.FechaCierre = reader.GetDateTime(4);
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
                String Error = $"Eror en ObtenerArqueoCajaAbierto()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return arqueoCaja;
        }
    }
}
