using POS_DePrisa.dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_DePrisa.formularios
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }


        private void txtUser_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "Usuario")
            {
                txtUser.Text = "";
            }
        }

        private void txtContra_Click(object sender, EventArgs e)
        {
            if (txtContra.Text == "Contraseña")
            {
                txtContra.Text = "";
                txtContra.PasswordChar = '*';
            }
        }

       
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DRol loginRol = new DRol();
            DUsuario loginUsuario = new DUsuario();
            



            if (txtUser.Text.Trim() == "Usuario" && txtContra.Text.Trim() == "Contraseña")
            {
                // Mostrar un cuadro de diálogo de error
                MessageBox.Show("Ingresa tus datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (loginUsuario.validarCredenciales(txtUser.Text.Trim(), txtContra.Text.Trim())) {
                    int idRol = loginRol.BuscarRol(txtUser.Text.Trim());
                    string nombre = loginUsuario.ObtenerNombrePorNombreUsuario(txtUser.Text.Trim());
                    var frm = new FrmPrincipal(nombre,txtUser.Text.Trim(), idRol);
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Nombre de usuario o clave invalidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUser.Text = "Usuario";
                    txtContra.Text = "Contraseña";


                }
            }
            
            
            
           
        }
    }
}
