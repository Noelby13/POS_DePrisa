namespace POS_DePrisa.formularios
{
    partial class FrmDescuento
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
            this.btnAgregarProducto = new POS_DePrisa.customControls.RoundedButton();
            this.btnSalir = new POS_DePrisa.customControls.RoundedButton();
            this.lblPrecioNormal1 = new System.Windows.Forms.Label();
            this.lblNuevoPrecio = new System.Windows.Forms.Label();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.lblPrecioNormal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarProducto.AutoSize = true;
            this.btnAgregarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.btnAgregarProducto.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.btnAgregarProducto.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAgregarProducto.BorderRadius = 10;
            this.btnAgregarProducto.BorderSize = 1;
            this.btnAgregarProducto.FlatAppearance.BorderSize = 0;
            this.btnAgregarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarProducto.ForeColor = System.Drawing.Color.Black;
            this.btnAgregarProducto.Image = global::POS_DePrisa.Properties.Resources.iconOk32;
            this.btnAgregarProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarProducto.Location = new System.Drawing.Point(28, 194);
            this.btnAgregarProducto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(221, 47);
            this.btnAgregarProducto.TabIndex = 8;
            this.btnAgregarProducto.Text = "Cambiar precio";
            this.btnAgregarProducto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarProducto.TextColor = System.Drawing.Color.Black;
            this.btnAgregarProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregarProducto.UseVisualStyleBackColor = false;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.AutoSize = true;
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.btnSalir.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.btnSalir.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSalir.BorderRadius = 10;
            this.btnSalir.BorderSize = 1;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.Black;
            this.btnSalir.Image = global::POS_DePrisa.Properties.Resources.iconClose32;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(284, 194);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(139, 47);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextColor = System.Drawing.Color.Black;
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblPrecioNormal1
            // 
            this.lblPrecioNormal1.AutoSize = true;
            this.lblPrecioNormal1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblPrecioNormal1.Location = new System.Drawing.Point(23, 32);
            this.lblPrecioNormal1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrecioNormal1.Name = "lblPrecioNormal1";
            this.lblPrecioNormal1.Size = new System.Drawing.Size(140, 25);
            this.lblPrecioNormal1.TabIndex = 28;
            this.lblPrecioNormal1.Text = "Precio Normal:";
            // 
            // lblNuevoPrecio
            // 
            this.lblNuevoPrecio.AutoSize = true;
            this.lblNuevoPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblNuevoPrecio.Location = new System.Drawing.Point(23, 82);
            this.lblNuevoPrecio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNuevoPrecio.Name = "lblNuevoPrecio";
            this.lblNuevoPrecio.Size = new System.Drawing.Size(135, 25);
            this.lblNuevoPrecio.TabIndex = 29;
            this.lblNuevoPrecio.Text = "Nuevo Precio:";
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblDescuento.Location = new System.Drawing.Point(29, 134);
            this.lblDescuento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(112, 25);
            this.lblDescuento.TabIndex = 30;
            this.lblDescuento.Text = "Descuento:";
            // 
            // lblPrecioNormal
            // 
            this.lblPrecioNormal.AutoSize = true;
            this.lblPrecioNormal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioNormal.Location = new System.Drawing.Point(193, 32);
            this.lblPrecioNormal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrecioNormal.Name = "lblPrecioNormal";
            this.lblPrecioNormal.Size = new System.Drawing.Size(154, 25);
            this.lblPrecioNormal.TabIndex = 31;
            this.lblPrecioNormal.Text = "Precio Normal:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(192, 82);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 25);
            this.label4.TabIndex = 32;
            this.label4.Text = "C$:";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtPrecio.Location = new System.Drawing.Point(249, 75);
            this.txtPrecio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPrecio.Multiline = true;
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.ReadOnly = true;
            this.txtPrecio.Size = new System.Drawing.Size(172, 37);
            this.txtPrecio.TabIndex = 33;
            this.txtPrecio.TextChanged += new System.EventHandler(this.txtPrecio_TextChanged);
            // 
            // txtDescuento
            // 
            this.txtDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtDescuento.Location = new System.Drawing.Point(249, 122);
            this.txtDescuento.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDescuento.Multiline = true;
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(104, 37);
            this.txtDescuento.TabIndex = 34;
            this.txtDescuento.TextChanged += new System.EventHandler(this.txtDescuento_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(363, 132);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 25);
            this.label5.TabIndex = 35;
            this.label5.Text = "%";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 4);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 25);
            this.label3.TabIndex = 36;
            this.label3.Text = "<-";
            // 
            // FrmDescuento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 278);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDescuento);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblPrecioNormal);
            this.Controls.Add(this.lblDescuento);
            this.Controls.Add(this.lblNuevoPrecio);
            this.Controls.Add(this.lblPrecioNormal1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAgregarProducto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmDescuento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FrmDescuento";
            this.Load += new System.EventHandler(this.FrmDescuento_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private customControls.RoundedButton btnAgregarProducto;
        private customControls.RoundedButton btnSalir;
        private System.Windows.Forms.Label lblPrecioNormal1;
        private System.Windows.Forms.Label lblNuevoPrecio;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.Label lblPrecioNormal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
    }
}