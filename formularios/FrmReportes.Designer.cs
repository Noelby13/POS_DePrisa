namespace POS_DePrisa.formularios
{
    partial class FrmReportes
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
            this.panelReportes = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnOcultar = new POS_DePrisa.customControls.RoundedButton();
            this.flowLayoutMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.gbTipoReporte = new System.Windows.Forms.GroupBox();
            this.cbxTipoReporte = new System.Windows.Forms.ComboBox();
            this.btnGenerarReporte = new POS_DePrisa.customControls.RoundedButton();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tscbTipoReporte = new System.Windows.Forms.ToolStripComboBox();
            this.tsbGenerarReporte = new System.Windows.Forms.ToolStripButton();
            this.tsbMostrar = new System.Windows.Forms.ToolStripButton();
            this.gradientPanel1 = new POS_DePrisa.customControls.GradientPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutBackGround.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutMenu.SuspendLayout();
            this.gbTipoReporte.SuspendLayout();
            this.tsMenu.SuspendLayout();
            this.gradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutBackGround
            // 
            this.tableLayoutBackGround.BackColor = System.Drawing.Color.Gray;
            this.tableLayoutBackGround.ColumnCount = 1;
            this.tableLayoutBackGround.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1732F));
            this.tableLayoutBackGround.Controls.Add(this.panelReportes, 0, 2);
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
            this.tableLayoutBackGround.Size = new System.Drawing.Size(1708, 564);
            this.tableLayoutBackGround.TabIndex = 3;
            // 
            // panelReportes
            // 
            this.panelReportes.BackColor = System.Drawing.Color.White;
            this.panelReportes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReportes.Location = new System.Drawing.Point(0, 96);
            this.panelReportes.Margin = new System.Windows.Forms.Padding(0);
            this.panelReportes.Name = "panelReportes";
            this.panelReportes.Size = new System.Drawing.Size(1732, 468);
            this.panelReportes.TabIndex = 2;
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1732, 55);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // btnOcultar
            // 
            this.btnOcultar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOcultar.AutoSize = true;
            this.btnOcultar.BackColor = System.Drawing.Color.White;
            this.btnOcultar.BackgroundColor = System.Drawing.Color.White;
            this.btnOcultar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnOcultar.BorderRadius = 10;
            this.btnOcultar.BorderSize = 1;
            this.btnOcultar.FlatAppearance.BorderSize = 0;
            this.btnOcultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOcultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOcultar.ForeColor = System.Drawing.Color.Black;
            this.btnOcultar.Image = global::POS_DePrisa.Properties.Resources.iconOcultar28;
            this.btnOcultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOcultar.Location = new System.Drawing.Point(1564, 4);
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
            this.flowLayoutMenu.Controls.Add(this.gbTipoReporte);
            this.flowLayoutMenu.Controls.Add(this.btnGenerarReporte);
            this.flowLayoutMenu.Controls.Add(this.tsMenu);
            this.flowLayoutMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutMenu.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutMenu.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutMenu.Name = "flowLayoutMenu";
            this.flowLayoutMenu.Size = new System.Drawing.Size(1560, 55);
            this.flowLayoutMenu.TabIndex = 3;
            // 
            // gbTipoReporte
            // 
            this.gbTipoReporte.Controls.Add(this.cbxTipoReporte);
            this.gbTipoReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTipoReporte.Location = new System.Drawing.Point(3, 3);
            this.gbTipoReporte.Name = "gbTipoReporte";
            this.gbTipoReporte.Size = new System.Drawing.Size(354, 52);
            this.gbTipoReporte.TabIndex = 12;
            this.gbTipoReporte.TabStop = false;
            this.gbTipoReporte.Text = "Seleccione su reporte";
            // 
            // cbxTipoReporte
            // 
            this.cbxTipoReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipoReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxTipoReporte.FormattingEnabled = true;
            this.cbxTipoReporte.Items.AddRange(new object[] {
            "-----REPORTES GENERALES-----",
            "Productos Disponibles"});
            this.cbxTipoReporte.Location = new System.Drawing.Point(0, 21);
            this.cbxTipoReporte.Name = "cbxTipoReporte";
            this.cbxTipoReporte.Size = new System.Drawing.Size(348, 28);
            this.cbxTipoReporte.TabIndex = 11;
            // 
            // btnGenerarReporte
            // 
            this.btnGenerarReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerarReporte.AutoSize = true;
            this.btnGenerarReporte.BackColor = System.Drawing.Color.White;
            this.btnGenerarReporte.BackgroundColor = System.Drawing.Color.White;
            this.btnGenerarReporte.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnGenerarReporte.BorderRadius = 10;
            this.btnGenerarReporte.BorderSize = 1;
            this.btnGenerarReporte.FlatAppearance.BorderSize = 0;
            this.btnGenerarReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarReporte.ForeColor = System.Drawing.Color.Black;
            this.btnGenerarReporte.Image = global::POS_DePrisa.Properties.Resources.iconPdf32;
            this.btnGenerarReporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerarReporte.Location = new System.Drawing.Point(364, 4);
            this.btnGenerarReporte.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerarReporte.Name = "btnGenerarReporte";
            this.btnGenerarReporte.Size = new System.Drawing.Size(191, 47);
            this.btnGenerarReporte.TabIndex = 9;
            this.btnGenerarReporte.Text = "Generar Reporte";
            this.btnGenerarReporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerarReporte.TextColor = System.Drawing.Color.Black;
            this.btnGenerarReporte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGenerarReporte.UseVisualStyleBackColor = false;
            this.btnGenerarReporte.Click += new System.EventHandler(this.btnGenerarReporte_Click);
            // 
            // tsMenu
            // 
            this.tsMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.tsMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tscbTipoReporte,
            this.tsbGenerarReporte,
            this.tsbMostrar});
            this.tsMenu.Location = new System.Drawing.Point(532, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(342, 31);
            this.tsMenu.TabIndex = 10;
            this.tsMenu.Visible = false;
            // 
            // tscbTipoReporte
            // 
            this.tscbTipoReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbTipoReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tscbTipoReporte.Items.AddRange(new object[] {
            "-----REPORTES GENERALES-----",
            "Productos Disponibles"});
            this.tscbTipoReporte.Name = "tscbTipoReporte";
            this.tscbTipoReporte.Size = new System.Drawing.Size(230, 31);
            // 
            // tsbGenerarReporte
            // 
            this.tsbGenerarReporte.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbGenerarReporte.Image = global::POS_DePrisa.Properties.Resources.iconPdf32;
            this.tsbGenerarReporte.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGenerarReporte.Name = "tsbGenerarReporte";
            this.tsbGenerarReporte.Size = new System.Drawing.Size(29, 28);
            this.tsbGenerarReporte.Text = "Generar Reporte";
            // 
            // tsbMostrar
            // 
            this.tsbMostrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMostrar.Image = global::POS_DePrisa.Properties.Resources.ver;
            this.tsbMostrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMostrar.Name = "tsbMostrar";
            this.tsbMostrar.Size = new System.Drawing.Size(29, 28);
            this.tsbMostrar.Text = "Mostrar Menu";
            this.tsbMostrar.Click += new System.EventHandler(this.tsbMostrar_Click);
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
            this.gradientPanel1.Size = new System.Drawing.Size(1732, 39);
            this.gradientPanel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Reportes";
            // 
            // FrmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1708, 564);
            this.Controls.Add(this.tableLayoutBackGround);
            this.Name = "FrmReportes";
            this.Text = "FrmReportes";
            this.tableLayoutBackGround.ResumeLayout(false);
            this.tableLayoutBackGround.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutMenu.ResumeLayout(false);
            this.flowLayoutMenu.PerformLayout();
            this.gbTipoReporte.ResumeLayout(false);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutBackGround;
        private System.Windows.Forms.Panel panelReportes;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private customControls.RoundedButton btnOcultar;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutMenu;
        private System.Windows.Forms.GroupBox gbTipoReporte;
        private System.Windows.Forms.ComboBox cbxTipoReporte;
        private customControls.RoundedButton btnGenerarReporte;
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripComboBox tscbTipoReporte;
        private System.Windows.Forms.ToolStripButton tsbGenerarReporte;
        private System.Windows.Forms.ToolStripButton tsbMostrar;
        private customControls.GradientPanel gradientPanel1;
        private System.Windows.Forms.Label label1;
    }
}