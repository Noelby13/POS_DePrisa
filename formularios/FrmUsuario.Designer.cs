namespace POS_DePrisa.formularios
{
    partial class FrmUsuario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutBackGround = new System.Windows.Forms.TableLayoutPanel();
            this.panelShowData = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnOcultar = new POS_DePrisa.customControls.RoundedButton();
            this.flowLayoutMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsbNuevoUsuario = new System.Windows.Forms.ToolStripButton();
            this.tsbMostrar = new System.Windows.Forms.ToolStripButton();
            this.btnNuevo = new POS_DePrisa.customControls.RoundedButton();
            this.gradientPanel1 = new POS_DePrisa.customControls.GradientPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutBackGround.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutMenu.SuspendLayout();
            this.tsMenu.SuspendLayout();
            this.gradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutBackGround
            // 
            this.tableLayoutBackGround.BackColor = System.Drawing.Color.Gray;
            this.tableLayoutBackGround.ColumnCount = 1;
            this.tableLayoutBackGround.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1924F));
            this.tableLayoutBackGround.Controls.Add(this.panelShowData, 0, 2);
            this.tableLayoutBackGround.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableLayoutBackGround.Controls.Add(this.gradientPanel1, 0, 0);
            this.tableLayoutBackGround.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutBackGround.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutBackGround.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutBackGround.Name = "tableLayoutBackGround";
            this.tableLayoutBackGround.RowCount = 3;
            this.tableLayoutBackGround.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutBackGround.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutBackGround.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutBackGround.Size = new System.Drawing.Size(1924, 554);
            this.tableLayoutBackGround.TabIndex = 2;
            // 
            // panelShowData
            // 
            this.panelShowData.BackColor = System.Drawing.Color.White;
            this.panelShowData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelShowData.Location = new System.Drawing.Point(0, 96);
            this.panelShowData.Margin = new System.Windows.Forms.Padding(0);
            this.panelShowData.Name = "panelShowData";
            this.panelShowData.Size = new System.Drawing.Size(1924, 458);
            this.panelShowData.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90.11765F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.882353F));
            this.tableLayoutPanel1.Controls.Add(this.btnOcultar, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutMenu, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 40);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1924, 55);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // btnOcultar
            // 
            this.btnOcultar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOcultar.AutoSize = true;
            this.btnOcultar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.btnOcultar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.btnOcultar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnOcultar.BorderRadius = 10;
            this.btnOcultar.BorderSize = 1;
            this.btnOcultar.FlatAppearance.BorderSize = 0;
            this.btnOcultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOcultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOcultar.ForeColor = System.Drawing.Color.Black;
            this.btnOcultar.Image = global::POS_DePrisa.Properties.Resources.iconOcultar28;
            this.btnOcultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOcultar.Location = new System.Drawing.Point(1756, 4);
            this.btnOcultar.Margin = new System.Windows.Forms.Padding(4);
            this.btnOcultar.Name = "btnOcultar";
            this.btnOcultar.Size = new System.Drawing.Size(164, 47);
            this.btnOcultar.TabIndex = 10;
            this.btnOcultar.Text = "Ocultar menu";
            this.btnOcultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOcultar.TextColor = System.Drawing.Color.Black;
            this.btnOcultar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOcultar.UseVisualStyleBackColor = false;
            this.btnOcultar.Click += new System.EventHandler(this.btnOcultar_Click);
            // 
            // flowLayoutMenu
            // 
            this.flowLayoutMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.flowLayoutMenu.Controls.Add(this.tsMenu);
            this.flowLayoutMenu.Controls.Add(this.btnNuevo);
            this.flowLayoutMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutMenu.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutMenu.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutMenu.Name = "flowLayoutMenu";
            this.flowLayoutMenu.Size = new System.Drawing.Size(1733, 55);
            this.flowLayoutMenu.TabIndex = 3;
            // 
            // tsMenu
            // 
            this.tsMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.tsMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevoUsuario,
            this.tsbMostrar});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(110, 27);
            this.tsMenu.TabIndex = 11;
            this.tsMenu.Visible = false;
            // 
            // tsbNuevoUsuario
            // 
            this.tsbNuevoUsuario.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNuevoUsuario.DoubleClickEnabled = true;
            this.tsbNuevoUsuario.Image = global::POS_DePrisa.Properties.Resources.icon_agregar_usuario;
            this.tsbNuevoUsuario.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevoUsuario.Name = "tsbNuevoUsuario";
            this.tsbNuevoUsuario.Size = new System.Drawing.Size(29, 24);
            this.tsbNuevoUsuario.Text = "Nuevo Usuario";
            this.tsbNuevoUsuario.Click += new System.EventHandler(this.tsbNuevoUsuario_Click);
            // 
            // tsbMostrar
            // 
            this.tsbMostrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMostrar.Image = global::POS_DePrisa.Properties.Resources.ver;
            this.tsbMostrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMostrar.Name = "tsbMostrar";
            this.tsbMostrar.Size = new System.Drawing.Size(29, 24);
            this.tsbMostrar.Text = "Mostrar Menu";
            this.tsbMostrar.Click += new System.EventHandler(this.tsbMostrar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.AutoSize = true;
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.btnNuevo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.btnNuevo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnNuevo.BorderRadius = 10;
            this.btnNuevo.BorderSize = 1;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.Color.Black;
            this.btnNuevo.Image = global::POS_DePrisa.Properties.Resources.iconAdd28;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(4, 4);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(4);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(132, 47);
            this.btnNuevo.TabIndex = 6;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.TextColor = System.Drawing.Color.Black;
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.ColorLeft = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(81)))), ((int)(((byte)(161)))));
            this.gradientPanel1.ColorRight = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gradientPanel1.Controls.Add(this.label1);
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(1924, 39);
            this.gradientPanel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario";
            // 
            // FrmUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1924, 554);
            this.Controls.Add(this.tableLayoutBackGround);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmUsuario";
            this.Text = "FrmUsuario";
            this.Load += new System.EventHandler(this.FrmUsuario_Load);
            this.tableLayoutBackGround.ResumeLayout(false);
            this.tableLayoutBackGround.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutMenu.ResumeLayout(false);
            this.flowLayoutMenu.PerformLayout();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutBackGround;
        private System.Windows.Forms.Panel panelShowData;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private customControls.RoundedButton btnOcultar;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutMenu;
        private customControls.RoundedButton btnNuevo;
        private customControls.GradientPanel gradientPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton tsbNuevoUsuario;
        private System.Windows.Forms.ToolStripButton tsbMostrar;
    }
}