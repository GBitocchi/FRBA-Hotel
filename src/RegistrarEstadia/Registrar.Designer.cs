namespace FrbaHotel.RegistrarEstadia
{
    partial class Registrar
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.gbxHuesped = new System.Windows.Forms.GroupBox();
            this.listaHuesped = new System.Windows.Forms.ListView();
            this.Email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Nro = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tipo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxRegistrar = new System.Windows.Forms.ComboBox();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.calendario = new System.Windows.Forms.MonthCalendar();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.gbxHuesped.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(208, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingresar datos del huesped";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tipo de identificacion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mail";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nro. de identificacion";
            // 
            // txtTipo
            // 
            this.txtTipo.Location = new System.Drawing.Point(157, 53);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Size = new System.Drawing.Size(168, 20);
            this.txtTipo.TabIndex = 4;
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(157, 89);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(168, 20);
            this.txtNumero.TabIndex = 5;
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(157, 127);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(168, 20);
            this.txtMail.TabIndex = 6;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(114, 164);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(99, 26);
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // gbxHuesped
            // 
            this.gbxHuesped.Controls.Add(this.listaHuesped);
            this.gbxHuesped.Controls.Add(this.label1);
            this.gbxHuesped.Controls.Add(this.btnAceptar);
            this.gbxHuesped.Controls.Add(this.label2);
            this.gbxHuesped.Controls.Add(this.label3);
            this.gbxHuesped.Controls.Add(this.txtMail);
            this.gbxHuesped.Controls.Add(this.label4);
            this.gbxHuesped.Controls.Add(this.txtNumero);
            this.gbxHuesped.Controls.Add(this.txtTipo);
            this.gbxHuesped.Location = new System.Drawing.Point(36, 256);
            this.gbxHuesped.Name = "gbxHuesped";
            this.gbxHuesped.Size = new System.Drawing.Size(648, 224);
            this.gbxHuesped.TabIndex = 9;
            this.gbxHuesped.TabStop = false;
            this.gbxHuesped.Text = "Datos huesped";
            // 
            // listaHuesped
            // 
            this.listaHuesped.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Email,
            this.Nro,
            this.Tipo});
            this.listaHuesped.Location = new System.Drawing.Point(341, 49);
            this.listaHuesped.Margin = new System.Windows.Forms.Padding(2);
            this.listaHuesped.Name = "listaHuesped";
            this.listaHuesped.Size = new System.Drawing.Size(300, 154);
            this.listaHuesped.TabIndex = 108;
            this.listaHuesped.UseCompatibleStateImageBehavior = false;
            this.listaHuesped.View = System.Windows.Forms.View.Details;
            // 
            // Email
            // 
            this.Email.Text = "Email";
            this.Email.Width = 146;
            // 
            // Nro
            // 
            this.Nro.Text = "Nro";
            this.Nro.Width = 89;
            // 
            // Tipo
            // 
            this.Tipo.Text = "Tipo";
            this.Tipo.Width = 147;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnIngresar);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtUsuario);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cbxRegistrar);
            this.groupBox2.Controls.Add(this.btnSeleccionar);
            this.groupBox2.Controls.Add(this.calendario);
            this.groupBox2.Controls.Add(this.txtFecha);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(36, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(648, 227);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Registrar estadia";
            // 
            // btnIngresar
            // 
            this.btnIngresar.Location = new System.Drawing.Point(115, 181);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(99, 26);
            this.btnIngresar.TabIndex = 10;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 302;
            this.label6.Text = "Registrar";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(158, 88);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(173, 20);
            this.txtUsuario.TabIndex = 301;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 300;
            this.label5.Text = "Usuario";
            // 
            // cbxRegistrar
            // 
            this.cbxRegistrar.FormattingEnabled = true;
            this.cbxRegistrar.Items.AddRange(new object[] {
            "Ingreso",
            "Egreso"});
            this.cbxRegistrar.Location = new System.Drawing.Point(158, 46);
            this.cbxRegistrar.Name = "cbxRegistrar";
            this.cbxRegistrar.Size = new System.Drawing.Size(173, 21);
            this.cbxRegistrar.TabIndex = 299;
            this.cbxRegistrar.SelectedIndexChanged += new System.EventHandler(this.cbxRegistrar_SelectedIndexChanged);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Location = new System.Drawing.Point(473, 190);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(109, 26);
            this.btnSeleccionar.TabIndex = 298;
            this.btnSeleccionar.Text = "Seleccionar fecha";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // calendario
            // 
            this.calendario.Location = new System.Drawing.Point(428, 16);
            this.calendario.Name = "calendario";
            this.calendario.TabIndex = 297;
            // 
            // txtFecha
            // 
            this.txtFecha.Enabled = false;
            this.txtFecha.Location = new System.Drawing.Point(158, 138);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(173, 20);
            this.txtFecha.TabIndex = 296;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(33, 141);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 295;
            this.label10.Text = "Fecha";
            // 
            // Registrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 519);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbxHuesped);
            this.Name = "Registrar";
            this.Text = "Datos del cliente";
            this.gbxHuesped.ResumeLayout(false);
            this.gbxHuesped.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTipo;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.GroupBox gbxHuesped;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbxRegistrar;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.MonthCalendar calendario;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.ListView listaHuesped;
        private System.Windows.Forms.ColumnHeader Email;
        private System.Windows.Forms.ColumnHeader Nro;
        private System.Windows.Forms.ColumnHeader Tipo;
    }
}