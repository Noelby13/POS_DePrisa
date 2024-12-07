using POS_DePrisa.dao;
using POS_DePrisa.entidades;
using POS_DePrisa.formularios;
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

namespace POS_DePrisa
{
    public partial class FrmPrincipal : Form
    {

        private Usuario userSistema;
        private ArqueoCaja arqueoActual = GlobalData.arqueoCaja;
        public void desactivarBotones()
        {
            btnFacturas.Enabled = false;
            btnUsuarios.Enabled = false;
            btnReportes.Enabled = false;
            btnProductos.Enabled = false;
        }

        public void activarBotones()
        {
            btnFacturas.Enabled = true;
            btnUsuarios.Enabled = true;
            btnReportes.Enabled = true;
            btnProductos.Enabled = true;
        }

        public void activarBotonesCajero()
        {
            btnFacturas.Enabled = true;
        }

        public FrmPrincipal(Usuario userSistema)
        {
            InitializeComponent();
            this.userSistema = userSistema;
            //Activar botones deacuerdo al rol de los usuarios
            desactivarBotones();
            if ( userSistema.IdRol == 1 )
            {
                activarBotones();
            }
            else
            {
                activarBotonesCajero();
            }
            lblNombreCompleto.Text = userSistema.Nombre;

            //pon en lblNombre, si idRol 1 = Administrador, si idRol 2 = Cajero
            if (userSistema.IdRol == 1)
            {
                lblNombre.Text = "Administrador";
            }
            else
            {
                lblNombre.Text = "Cajero";
            }
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

        private void btnFacturas_Click(object sender, EventArgs e)
        {
            //utiliza el panelshowData para cargarFrmProducto
            showForm(new FrmFacturacion());

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
            showForm(new FrmProducto());
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            showForm(new FrmUsuario(userSistema));
        }

        private void verificarExito(bool guardarArqueo)
        {
            if (guardarArqueo)
            {
                MessageBox.Show("Arqueo de caja guardado con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ocurrio un error al guardar el arqueo de caja", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void arqueoDeCajaAbierto()
        {
            try
            {
                DArqueoCaja dArqueoCaja = new DArqueoCaja();
                if (arqueoActual.Estado)
                {
                    DialogResult dialogResult = MessageBox.Show("¿Desea cerrar el arqueo de caja actual?", "Información arqueo de caja", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //Acá se guarda el arqueo de caja y se verifica que se haya realizado con éxito
                        verificarExito(dArqueoCaja.GuardarArqueoCaja(arqueoActual));
                    }
                    else
                    {
                        //En caso de que no se cierre el arqueo de caja unicamente se actualiza el monto final
                        dArqueoCaja.ActualizarMontoFinal(arqueoActual);
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                String Error = $"Eror en DArqueoCaja()\nTipo: {ex.GetType()}\nDescripción: {ex.Message}";
                MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnSalir_Click_2(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro de que desea salir de la aplicación?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                  arqueoDeCajaAbierto();
                  Application.Exit();
                }
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            showForm(new FrmReportes());
        }

        private void panelExitButton_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
