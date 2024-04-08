using POS_DePrisa.entidades;
using POS_DePrisa.formularios.UsuarioForm;
using POS_DePrisa.negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace POS_DePrisa.formularios
{
    public partial class FrmUsuario : Form
    {
        private Usuario userSistema;
        public FrmUsuario(Usuario userSistema)
        {
            InitializeComponent();
            this.userSistema = userSistema;
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
        private void cambiarVisibilidadBotones(int estado)
        {
            if (estado == 1)
            {
                btnOcultar.Visible = false;
                btnNuevo.Visible = false;
                tsMenu.Visible = true;
            }
            else
            {
                btnNuevo.Visible = true;
                btnOcultar.Visible = true;
                tsMenu.Visible = false;
            }

        }
        private void btnOcultar_Click(object sender, EventArgs e)
        {
            cambiarVisibilidadBotones(1);
            tableLayoutBackGround.RowStyles[1].Height = tsMenu.Height;
        }

        private void tsbMostrar_Click(object sender, EventArgs e)
        {
            tableLayoutBackGround.RowStyles[1].SizeType = SizeType.Absolute;
            tableLayoutBackGround.RowStyles[1].Height = 46;
            cambiarVisibilidadBotones(0);
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            showForm(new FrmCrudUsuario(userSistema));
        }

        private void tsbNuevoUsuario_Click(object sender, EventArgs e)
        {
            showForm(new FrmCrudUsuario(userSistema));
        }
    }
}
