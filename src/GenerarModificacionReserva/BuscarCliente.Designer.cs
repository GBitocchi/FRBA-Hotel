namespace FrbaHotel.GenerarModificacionReserva
{
    partial class BuscarCliente
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
            this.comboBoxTipoDocumento = new System.Windows.Forms.ComboBox();
            this.textBoxNumeroDocumento = new System.Windows.Forms.TextBox();
            this.textBoxMail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvBuscarClientes = new System.Windows.Forms.DataGridView();
            this.btnMail = new System.Windows.Forms.Button();
            this.btnSeleccionarNumeroIdentificacion = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuscarClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(91, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Buscar por Mail:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(751, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(281, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Buscar por Numero Identificacion:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(398, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(253, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Buscar por Tipo Identificacion:";
            // 
            // comboBoxTipoDocumento
            // 
            this.comboBoxTipoDocumento.FormattingEnabled = true;
            this.comboBoxTipoDocumento.Location = new System.Drawing.Point(402, 154);
            this.comboBoxTipoDocumento.Name = "comboBoxTipoDocumento";
            this.comboBoxTipoDocumento.Size = new System.Drawing.Size(249, 21);
            this.comboBoxTipoDocumento.TabIndex = 4;
            this.comboBoxTipoDocumento.SelectedIndexChanged += new System.EventHandler(this.comboBoxTipoDocumento_SelectedIndexChanged);
            // 
            // textBoxNumeroDocumento
            // 
            this.textBoxNumeroDocumento.Location = new System.Drawing.Point(755, 154);
            this.textBoxNumeroDocumento.Name = "textBoxNumeroDocumento";
            this.textBoxNumeroDocumento.Size = new System.Drawing.Size(277, 20);
            this.textBoxNumeroDocumento.TabIndex = 5;
            // 
            // textBoxMail
            // 
            this.textBoxMail.Location = new System.Drawing.Point(44, 154);
            this.textBoxMail.Name = "textBoxMail";
            this.textBoxMail.Size = new System.Drawing.Size(225, 20);
            this.textBoxMail.TabIndex = 6;
            this.textBoxMail.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(45, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(463, 73);
            this.label4.TabIndex = 7;
            this.label4.Text = "Buscar Cliente";
            // 
            // dgvBuscarClientes
            // 
            this.dgvBuscarClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBuscarClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBuscarClientes.Location = new System.Drawing.Point(19, 214);
            this.dgvBuscarClientes.MultiSelect = false;
            this.dgvBuscarClientes.Name = "dgvBuscarClientes";
            this.dgvBuscarClientes.ReadOnly = true;
            this.dgvBuscarClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBuscarClientes.Size = new System.Drawing.Size(1030, 385);
            this.dgvBuscarClientes.TabIndex = 8;
            this.dgvBuscarClientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBuscarClientes_CellContentClick);
            // 
            // btnMail
            // 
            this.btnMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMail.Location = new System.Drawing.Point(105, 180);
            this.btnMail.Name = "btnMail";
            this.btnMail.Size = new System.Drawing.Size(113, 28);
            this.btnMail.TabIndex = 9;
            this.btnMail.Text = "Seleccionar";
            this.btnMail.UseVisualStyleBackColor = true;
            this.btnMail.Click += new System.EventHandler(this.btnMail_Click);
            // 
            // btnSeleccionarNumeroIdentificacion
            // 
            this.btnSeleccionarNumeroIdentificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionarNumeroIdentificacion.Location = new System.Drawing.Point(831, 180);
            this.btnSeleccionarNumeroIdentificacion.Name = "btnSeleccionarNumeroIdentificacion";
            this.btnSeleccionarNumeroIdentificacion.Size = new System.Drawing.Size(113, 28);
            this.btnSeleccionarNumeroIdentificacion.TabIndex = 10;
            this.btnSeleccionarNumeroIdentificacion.Text = "Seleccionar";
            this.btnSeleccionarNumeroIdentificacion.UseVisualStyleBackColor = true;
            this.btnSeleccionarNumeroIdentificacion.Click += new System.EventHandler(this.btnSeleccionarNumeroIdentificacion_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(19, 605);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 28);
            this.button1.TabIndex = 11;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BuscarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1061, 637);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSeleccionarNumeroIdentificacion);
            this.Controls.Add(this.btnMail);
            this.Controls.Add(this.dgvBuscarClientes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxMail);
            this.Controls.Add(this.textBoxNumeroDocumento);
            this.Controls.Add(this.comboBoxTipoDocumento);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "BuscarCliente";
            this.Text = "BuscarCliente";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuscarClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxTipoDocumento;
        private System.Windows.Forms.TextBox textBoxNumeroDocumento;
        private System.Windows.Forms.TextBox textBoxMail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvBuscarClientes;
        private System.Windows.Forms.Button btnMail;
        private System.Windows.Forms.Button btnSeleccionarNumeroIdentificacion;
        private System.Windows.Forms.Button button1;
    }
}