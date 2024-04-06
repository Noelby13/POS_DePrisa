﻿using POS_DePrisa.dao;
using POS_DePrisa.entidades;
using POS_DePrisa.formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_DePrisa
{
    public partial class FrmPrincipal : Form
    {
        
        public Usuario _usuarioSistema = new Usuario();
        public void desactivarBotones()
        {
            btnConfiguracion.Enabled = false;
            btnFacturas.Enabled = false;
            btnUsuarios.Enabled = false;
            btnReportes.Enabled = false;
            btnProductos.Enabled = false;
        }

        public void activarBotones()
        {
            btnConfiguracion.Enabled = true;
            btnFacturas.Enabled = true;
            btnUsuarios.Enabled = true;
            btnReportes.Enabled = true;
            btnProductos.Enabled = true;
        }

        public void activarBotonesCajero()
        {
            btnFacturas.Enabled = true;
            btnReportes.Enabled = true;
            btnProductos.Enabled = true;
        }

        public FrmPrincipal(string nombreCompleto, string nombreUsuario, int idRol)
        {
            InitializeComponent(); 
            //Activar botones deacuerdo al rol de los usuarios
            desactivarBotones();
            if ( idRol == 1 )
            {
                activarBotones();
            }
            else
            {
                activarBotonesCajero();
            }
            lblNombreCompleto.Text = nombreCompleto;
            lblNombre.Text = nombreUsuario;
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            MaxFormSize();
            cargarDataGrid();
        }

        private void cargarDataGrid()
        {
       
        }

        private void MaxFormSize()
        {
            Left = Top = 0;
            Width = Screen.PrimaryScreen.WorkingArea.Width;
            Height = Screen.PrimaryScreen.WorkingArea.Height;
        }

        private void tableLayoutBackGround_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnFacturas_Click(object sender, EventArgs e)
        {
            //utiliza el panelshowData para cargarFrmProducto
            showForm(new FrmProducto());

        }

        private void showForm(Form form)
        {
            panelShowData.Controls.Clear();
            form.FormBorderStyle = FormBorderStyle.None;
            form.TopLevel = false;
            form.WindowState = FormWindowState.Maximized;
            panelShowData.Controls.Add(form);
            form.Show();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            showForm(new FrmPlantilla());
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            showForm(new FrmUsuario());
        }

        private void btnSalir_Click_2(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
