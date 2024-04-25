using POS_DePrisa.dao;
using POS_DePrisa.entidades;
using POS_DePrisa.negocios;
using POS_DePrisa.store;
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
            Color campoInactivo = Color.FromArgb(144, 148, 165);

            if (txtUser.Text == "Usuario")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.Black;
            }

            if (txtContra.Text == "")
            {
                txtContra.UseSystemPasswordChar = false;
                txtContra.Text = "Contraseña";
                txtContra.ForeColor = Color.FromArgb(144, 148, 165);

            }
        }

        private void txtContra_Click(object sender, EventArgs e)
        {
            if (txtContra.Text == "Contraseña")
            {
                txtContra.Text = "";
                txtContra.UseSystemPasswordChar = true;
                txtContra.ForeColor = Color.Black;
            }

            if (txtUser.Text == "")
            {
                txtUser.Text = "Usuario";
                txtUser.ForeColor = Color.FromArgb(144, 148, 165);
            }
        }

       
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //private void btnLogin_Click(object sender, EventArgs e)
        //{
        //    DRol loginRol = new DRol();
        //    DUsuario loginUsuario = new DUsuario();
        //    Usuario user = new Usuario();


        //    if (txtUser.Text.Trim() == "Usuario" && txtContra.Text.Trim() == "Contraseña")
        //    {
        //            MessageBox.Show("Ingresa tus datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    else
        //    {
        //        if (loginUsuario.validarCredenciales(txtUser.Text.Trim(), txtContra.Text.Trim()))
        //        {
        //            int idRol = loginRol.BuscarRol(txtUser.Text.Trim());
        //            user = loginUsuario.ObtenerUsuarioPorNombreUsuario(txtUser.Text.Trim());

        //            GlobalData.usuario = user;

        //            ArqueoServices arqueoServices = new ArqueoServices();
        //            var resultado = arqueoServices.validarArqueoAbierto();
        //            //En caso que no existe un arqueo abierto
        //            if (!resultado) { 
        //                FrmAperturaCaja frmAperturaCaja = new FrmAperturaCaja();
        //                frmAperturaCaja.ShowDialog();

        //                if (!frmAperturaCaja.arqueoIsOpen)
        //                {
        //                    return;
        //                }
        //            }

        //            //avisa que existe un arqueo de caja abierto
        //            MessageBox.Show("Existe un arqueo de caja abierto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //            var frm = new FrmPrincipal(user);
        //            frm.Show();
        //            this.Hide();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Nombre de usuario o clave invalidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            txtUser.Text = "Usuario";
        //            txtContra.Text = "Contraseña";


        //        }
        //    }

        //}

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Trim() == "Usuario" || txtContra.Text.Trim() == "Contraseña")
            {
                MessageBox.Show("Ingresa tus datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DUsuario loginUsuario = new DUsuario();

            if (!loginUsuario.validarCredenciales(txtUser.Text.Trim(), txtContra.Text.Trim()))
            {
                MessageBox.Show("Nombre de usuario o clave invalidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUser.Text = "Usuario";
                txtContra.Text = "Contraseña";
                return;
            }

            DRol loginRol = new DRol();
            Usuario user = loginUsuario.ObtenerUsuarioPorNombreUsuario(txtUser.Text.Trim());
            GlobalData.usuario = user;

            ArqueoServices arqueoServices = new ArqueoServices();
            bool resultado = arqueoServices.validarArqueoAbierto();

            // Gestión de arqueo de caja
            if (!resultado)
            {
                FrmAperturaCaja frmAperturaCaja = new FrmAperturaCaja();
                frmAperturaCaja.ShowDialog();
                if (!frmAperturaCaja.arqueoIsOpen)
                {
                    MessageBox.Show("No se puede continuar sin abrir un arqueo de caja", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                //avisa que existe un arqueo de caja abierto, que si desea continuar
                DialogResult dialogResult = MessageBox.Show("Existe un arqueo de caja abierto, ¿Desea continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                GlobalData.arqueoCaja = arqueoServices.obtenerArqueoAbierto();
            }
       

            // Si todo es correcto, mostrar el formulario principal
            FrmPrincipal frm = new FrmPrincipal(user);
            frm.Show();
            this.Hide();
        }


        private void chkContraseña_CheckedChanged(object sender, EventArgs e)
        {
            if (chkContraseña.Checked == true)
            {
                txtContra.UseSystemPasswordChar = false;
            }
            else
            {
                txtContra.UseSystemPasswordChar = true;
            }
        }


    }
}
