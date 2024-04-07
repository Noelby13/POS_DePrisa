using POS_DePrisa.dao;
using POS_DePrisa.entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_DePrisa.negocios
{
    internal class UsuarioServices
    {

        private DUsuario dUsuario;

        public UsuarioServices()
        {
            dUsuario = new DUsuario();
        }

        public ResultadoOperacion guardar(Usuario usuario)
        {

            ResultadoOperacion resultado = new ResultadoOperacion();


            if (!dUsuario.validarUsuarioUnico(usuario))
            {
                resultado.Mensaje = "El nombre de usuario ya existe";
                resultado.IsExitoso = false;
                return resultado;

            }

            if (!dUsuario.GuardarUsuario(usuario))
            {
                resultado.Mensaje = "Error al guardar el usuario";
                resultado.IsExitoso = false;
                return resultado;
            }

            resultado.Mensaje = "Usuario guardado con éxito";
            resultado.IsExitoso = true;
            return resultado;

        }

        public ResultadoOperacion editar(Usuario usuario)
        {

            ResultadoOperacion resultado = new ResultadoOperacion();


            if (!dUsuario.ValidarUserNameUnico(usuario))
            {
                resultado.Mensaje = "El nombre de usuario ya existe";
                resultado.IsExitoso = false;
                return resultado;

            }

            if (!dUsuario.actualizarUsuario(usuario))
            {
                resultado.Mensaje = "Error al editar el usuario";
                resultado.IsExitoso = false;
                return resultado;
            }

            resultado.Mensaje = "Usuario editado con éxito";
            resultado.IsExitoso = true;
            return resultado;

        }

        public ResultadoOperacion borrarUsuario(Usuario usuario)
        {
            ResultadoOperacion resultado = new ResultadoOperacion();

            if (usuario == null)
            {
                resultado.IsExitoso = false;
                resultado.Mensaje = "El usuario no puede ser nulo";
                return resultado;
            }

            try
            {
                // Suponiendo que dUsuario es un objeto que maneja operaciones relacionadas con usuarios
                if (!dUsuario.eliminarUsuario(usuario))
                {
                    resultado.IsExitoso = false;
                    resultado.Mensaje = "Error al borrar el usuario";
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                resultado.IsExitoso = false;
                resultado.Mensaje = "Error al borrar el usuario: " + ex.Message;
                return resultado;
            }

            resultado.IsExitoso = true;
            resultado.Mensaje = "Usuario borrado con éxito";
            return resultado;
        }
        public DataSet obtenerRoles()
        {
            DRol dRol = new DRol();
            return dRol.ListarRoles();
        }

        public DataSet listarUsuarios()
        {
            return dUsuario.ListarUsuarios();
        }

        public DataSet buscar(String nombre)
        {
            return dUsuario.buscarUsuario(nombre);
        }


    }
}
