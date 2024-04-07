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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            showForm(new FrmCrudUsuario(userSistema));
        }

        
    }
}
