﻿using POS_DePrisa.dao;
using POS_DePrisa.entidades;
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //    DRol loginRol = new DRol();
            //    DUsuario loginUsuario = new DUsuario();
            //    Usuario user = new Usuario();


            //    if (txtUser.Text.Trim() == "Usuario" && txtContra.Text.Trim() == "Contraseña")
            //    {
            //        Mostrar un cuadro de diálogo de error
            //        MessageBox.Show("Ingresa tus datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //    else
            //    {
            //        if (loginUsuario.validarCredenciales(txtUser.Text.Trim(), txtContra.Text.Trim()))
            //        {
            //            int idRol = loginRol.BuscarRol(txtUser.Text.Trim());
            //            user = loginUsuario.ObtenerUsuarioPorNombreUsuario(txtUser.Text.Trim());
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

            //crea un usuario temporal
            Usuario user = new Usuario();
            user.IdRol = 1;
            user.Nombre = "Administrador";
            user.NombreUsuario = "admin";
            user.Pw = "admin";
            var frm = new FrmPrincipal(user);
            frm.Show();




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
