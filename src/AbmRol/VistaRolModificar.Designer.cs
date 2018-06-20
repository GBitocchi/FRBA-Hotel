namespace FrbaHotel.AbmRol
{
    partial class VistaRolModificar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaRolModificar));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbRolNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rbActivated = new System.Windows.Forms.RadioButton();
            this.rbDeactivated = new System.Windows.Forms.RadioButton();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.listBoxFuncionalidades = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxFuncionalidades = new System.Windows.Forms.ComboBox();
            this.btnAñadirFuncionalidad = new System.Windows.Forms.Button();
            this.btnQuitarFuncionalidad = new System.Windows.Forms.Button();
            this.lblErrorNombreRol = new System.Windows.Forms.Label();
            this.lblErrorFuncionalidad = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(833, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(289, 289);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(109, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(418, 73);
            this.label1.TabIndex = 1;
            this.label1.Text = "Modificar Rol";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(102, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(301, 42);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre del Rol:";
            // 
            // txbRolNombre
            // 
            this.txbRolNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbRolNombre.Location = new System.Drawing.Point(381, 251);
            this.txbRolNombre.Name = "txbRolNombre";
            this.txbRolNombre.Size = new System.Drawing.Size(341, 31);
            this.txbRolNombre.TabIndex = 3;
            this.txbRolNombre.TextChanged += new System.EventHandler(this.txbRolNombre_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(102, 315);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(286, 42);
            this.label3.TabIndex = 4;
            this.label3.Text = "Estado del Rol:";
            // 
            // rbActivated
            // 
            this.rbActivated.AutoSize = true;
            this.rbActivated.BackColor = System.Drawing.Color.Transparent;
            this.rbActivated.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbActivated.Location = new System.Drawing.Point(351, 401);
            this.rbActivated.Name = "rbActivated";
            this.rbActivated.Size = new System.Drawing.Size(121, 29);
            this.rbActivated.TabIndex = 5;
            this.rbActivated.TabStop = true;
            this.rbActivated.Text = "Activado";
            this.rbActivated.UseVisualStyleBackColor = false;
            this.rbActivated.CheckedChanged += new System.EventHandler(this.rbActivated_CheckedChanged);
            // 
            // rbDeactivated
            // 
            this.rbDeactivated.AutoSize = true;
            this.rbDeactivated.BackColor = System.Drawing.Color.Transparent;
            this.rbDeactivated.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDeactivated.Location = new System.Drawing.Point(602, 401);
            this.rbDeactivated.Name = "rbDeactivated";
            this.rbDeactivated.Size = new System.Drawing.Size(160, 29);
            this.rbDeactivated.TabIndex = 6;
            this.rbDeactivated.TabStop = true;
            this.rbDeactivated.Text = "Desactivado";
            this.rbDeactivated.UseVisualStyleBackColor = false;
            this.rbDeactivated.CheckedChanged += new System.EventHandler(this.rbDeactivated_CheckedChanged);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(141, 764);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(94, 46);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(908, 764);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(91, 46);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // listBoxFuncionalidades
            // 
            this.listBoxFuncionalidades.FormattingEnabled = true;
            this.listBoxFuncionalidades.Location = new System.Drawing.Point(625, 506);
            this.listBoxFuncionalidades.Name = "listBoxFuncionalidades";
            this.listBoxFuncionalidades.Size = new System.Drawing.Size(259, 225);
            this.listBoxFuncionalidades.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(102, 452);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(318, 42);
            this.label4.TabIndex = 10;
            this.label4.Text = "Funcionalidades:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // comboBoxFuncionalidades
            // 
            this.comboBoxFuncionalidades.FormattingEnabled = true;
            this.comboBoxFuncionalidades.Location = new System.Drawing.Point(136, 529);
            this.comboBoxFuncionalidades.Name = "comboBoxFuncionalidades";
            this.comboBoxFuncionalidades.Size = new System.Drawing.Size(241, 21);
            this.comboBoxFuncionalidades.TabIndex = 11;
            // 
            // btnAñadirFuncionalidad
            // 
            this.btnAñadirFuncionalidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAñadirFuncionalidad.Location = new System.Drawing.Point(443, 527);
            this.btnAñadirFuncionalidad.Name = "btnAñadirFuncionalidad";
            this.btnAñadirFuncionalidad.Size = new System.Drawing.Size(84, 41);
            this.btnAñadirFuncionalidad.TabIndex = 12;
            this.btnAñadirFuncionalidad.Text = "Añadir";
            this.btnAñadirFuncionalidad.UseVisualStyleBackColor = true;
            this.btnAñadirFuncionalidad.Click += new System.EventHandler(this.btnAñadirFuncionalidad_Click);
            // 
            // btnQuitarFuncionalidad
            // 
            this.btnQuitarFuncionalidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitarFuncionalidad.Location = new System.Drawing.Point(443, 598);
            this.btnQuitarFuncionalidad.Name = "btnQuitarFuncionalidad";
            this.btnQuitarFuncionalidad.Size = new System.Drawing.Size(84, 43);
            this.btnQuitarFuncionalidad.TabIndex = 13;
            this.btnQuitarFuncionalidad.Text = "Quitar";
            this.btnQuitarFuncionalidad.UseVisualStyleBackColor = true;
            this.btnQuitarFuncionalidad.Click += new System.EventHandler(this.btnQuitarFuncionalidad_Click);
            // 
            // lblErrorNombreRol
            // 
            this.lblErrorNombreRol.AutoSize = true;
            this.lblErrorNombreRol.BackColor = System.Drawing.Color.Transparent;
            this.lblErrorNombreRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorNombreRol.ForeColor = System.Drawing.Color.Red;
            this.lblErrorNombreRol.Location = new System.Drawing.Point(136, 257);
            this.lblErrorNombreRol.Name = "lblErrorNombreRol";
            this.lblErrorNombreRol.Size = new System.Drawing.Size(214, 25);
            this.lblErrorNombreRol.TabIndex = 14;
            this.lblErrorNombreRol.Text = "* Campo Necesario";
            // 
            // lblErrorFuncionalidad
            // 
            this.lblErrorFuncionalidad.AutoSize = true;
            this.lblErrorFuncionalidad.BackColor = System.Drawing.Color.Transparent;
            this.lblErrorFuncionalidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorFuncionalidad.ForeColor = System.Drawing.Color.Red;
            this.lblErrorFuncionalidad.Location = new System.Drawing.Point(88, 686);
            this.lblErrorFuncionalidad.Name = "lblErrorFuncionalidad";
            this.lblErrorFuncionalidad.Size = new System.Drawing.Size(501, 25);
            this.lblErrorFuncionalidad.TabIndex = 16;
            this.lblErrorFuncionalidad.Text = "* Debe especificar al menos una funcionalidad";
            // 
            // VistaRolModificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1154, 845);
            this.Controls.Add(this.lblErrorFuncionalidad);
            this.Controls.Add(this.lblErrorNombreRol);
            this.Controls.Add(this.btnQuitarFuncionalidad);
            this.Controls.Add(this.btnAñadirFuncionalidad);
            this.Controls.Add(this.comboBoxFuncionalidades);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listBoxFuncionalidades);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.rbDeactivated);
            this.Controls.Add(this.rbActivated);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbRolNombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "VistaRolModificar";
            this.Text = "VistaRolModificar";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbRolNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbActivated;
        private System.Windows.Forms.RadioButton rbDeactivated;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ListBox listBoxFuncionalidades;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxFuncionalidades;
        private System.Windows.Forms.Button btnAñadirFuncionalidad;
        private System.Windows.Forms.Button btnQuitarFuncionalidad;
        private System.Windows.Forms.Label lblErrorNombreRol;
        private System.Windows.Forms.Label lblErrorFuncionalidad;
    }
}