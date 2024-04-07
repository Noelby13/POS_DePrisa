using POS_DePrisa.dao;
using POS_DePrisa.entidades;
using POS_DePrisa.negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_DePrisa.formularios.UsuarioForm
{
    public partial class FrmCrudUsuario : Form
    {
        private UsuarioServices usuarioServices;
        private Usuario usuarioSelected = new Usuario();
        private Usuario userSistema; //Usuario que esta usando el sistema 


        public FrmCrudUsuario(Usuario userSistema)
        {
            InitializeComponent();
            this.userSistema = userSistema;
            usuarioServices = new UsuarioServices();

        }

        private void enableBotones()
        {
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            btnGuardarUsuario.Enabled = true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtUserName.Clear();
            txtContrasena.Clear();
            cbxRol.SelectedIndex = -1;
            enableBotones();

        }

        private void FrmCrudUsuario_Load(object sender, EventArgs e)
        {
            cargarDgvListaUsuario();
            cargarCbxRol();
        }

        private void cargarCbxRol()
        {
            cbxRol.DataSource = usuarioServices.obtenerRoles().Tables[0];
            cbxRol.DisplayMember = "nombre";
            cbxRol.ValueMember = "idRol";

        }

        private void cargarDgvListaUsuario()
        {
            dgvListaUsuario.DataSource = usuarioServices.listarUsuarios().Tables[0];
            dgvListaUsuario.Columns["idUsuario"].Visible = false;
            dgvListaUsuario.Columns["idRol"].Visible = false;
            dgvListaUsuario.Columns["pw"].Visible = false;
            dgvListaUsuario.Columns["fechaCreacion"].Visible = false;
            dgvListaUsuario.Columns["estado"].Visible = false;
            dgvListaUsuario.Columns["Rol"].Visible = true;

            //cambia el nombre de la columna
            dgvListaUsuario.Columns["nombre"].HeaderText = "Nombre";
            dgvListaUsuario.Columns["nombreUsuario"].HeaderText = "Usuario";
            dgvListaUsuario.Columns["Rol"].HeaderText = "Rol";


        }

        private bool validarCampos()
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("El campo nombre es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtUserName.Text == "")
            {
                MessageBox.Show("El campo nombre de usuario es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtContrasena.Text == "")
            {
                MessageBox.Show("El campo contraseña es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cbxRol.SelectedIndex == -1)
            {
                MessageBox.Show("El campo rol es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnGuardarUsuario_Click(object sender, EventArgs e)
        {
            if (!validarCampos())
            {
                return;
            }

            var usuario = new entidades.Usuario();

            usuario.Nombre = txtNombre.Text;
            usuario.NombreUsuario = txtUserName.Text;
            usuario.Pw = txtContrasena.Text;
            usuario.IdRol = Convert.ToInt32(cbxRol.SelectedValue);
            usuario.FechaCreacion = DateTime.Now;
            usuario.Estado = 1;


            var resultado = usuarioServices.guardar(usuario);

            if (!resultado.IsExitoso)
            {
                MessageBox.Show(resultado.Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(resultado.Mensaje, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cargarDgvListaUsuario();
            btnLimpiar.PerformClick();

        }

        private void dgvListaUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //valida que sea una fila seleccionada valida
            if (e.RowIndex < 0)
            {
                return;
            }

            txtNombre.Text = dgvListaUsuario.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
            txtUserName.Text = dgvListaUsuario.Rows[e.RowIndex].Cells["nombreUsuario"].Value.ToString();
            txtContrasena.Text = dgvListaUsuario.Rows[e.RowIndex].Cells["pw"].Value.ToString();


            // Obtiene el valor de la celda "idRol" de la fila seleccionada y lo asigna al ComboBox cbxRol
            cbxRol.SelectedValue = Convert.ToInt32(dgvListaUsuario.Rows[e.RowIndex].Cells["idRol"].Value);

            //crear usuario
            usuarioSelected.IdUsuario = (int)dgvListaUsuario.Rows[e.RowIndex].Cells["idUsuario"].Value;
            usuarioSelected.Nombre = txtNombre.Text.Trim();
            usuarioSelected.NombreUsuario = txtUserName.Text.Trim();
            usuarioSelected.Pw = txtContrasena.Text.Trim();
            usuarioSelected.IdRol = Convert.ToInt32(dgvListaUsuario.Rows[e.RowIndex].Cells["idRol"].Value);
            usuarioSelected.Estado = 1;
            usuarioSelected.FechaCreacion = (DateTime)dgvListaUsuario.Rows[e.RowIndex].Cells["fechaCreacion"].Value;

            //Actualizar estado de los botones
            
            btnGuardarUsuario.Enabled = false;
            btnActualizar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Length > 0)
            {
                var ds = usuarioServices.buscar(txtUsuario.Text);
                dgvListaUsuario.DataSource = ds.Tables[0];
                dgvListaUsuario.Columns["idUsuario"].Visible = false;
                dgvListaUsuario.Columns["idRol"].Visible = false;
                dgvListaUsuario.Columns["pw"].Visible = false;
                dgvListaUsuario.Columns["fechaCreacion"].Visible = false;
                dgvListaUsuario.Columns["estado"].Visible = false;
                dgvListaUsuario.Columns["Rol"].Visible = true;

                //Cambiar el nombre de las columnas 
                dgvListaUsuario.Columns["nombre"].HeaderText = "Nombre";
                dgvListaUsuario.Columns["nombreUsuario"].HeaderText = "Usuario";
                dgvListaUsuario.Columns["Rol"].HeaderText = "Rol";
            }
            else
            {
                cargarDgvListaUsuario()
 ;
            }
        }
        //Función para editar un usuario
        private void btnActualizar_Click(object sender, EventArgs e)
        {   
            if (!validarCampos()) return;

            usuarioSelected.Nombre = txtNombre.Text.Trim();
            usuarioSelected.NombreUsuario = txtUserName.Text.Trim();
            usuarioSelected.Pw = txtContrasena.Text.Trim();
            usuarioSelected.IdRol = Convert.ToInt32(cbxRol.SelectedValue);

            var resultado = usuarioServices.editar(usuarioSelected);
 
            if (!resultado.IsExitoso)
            {
                MessageBox.Show(resultado.Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnLimpiar.PerformClick();
                return;
            }

            MessageBox.Show(resultado.Mensaje, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cargarDgvListaUsuario();
            btnLimpiar.PerformClick();

        }

        //Botón para eliminar un usuario
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //valida si desea eliminar la categoria
            if (usuarioSelected.IdUsuario == userSistema.IdUsuario)
            {
                MessageBox.Show("No puede eliminar el usuario que está usando el programa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnLimpiar.PerformClick();
                return;
            }
            if (MessageBox.Show($"¿Estas seguro de eliminar el usuario: {usuarioSelected.Nombre}?", "Eliminar Usuario", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var resultado = usuarioServices.borrarUsuario(usuarioSelected);
                if (!resultado.IsExitoso)
                {
                    MessageBox.Show(resultado.Mensaje);
                    btnLimpiar.PerformClick();
                    return;
                }
                MessageBox.Show("Usuario eliminado con éxito", "Eliminación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnLimpiar.PerformClick();
                cargarDgvListaUsuario();
            }
        }

    }
}
