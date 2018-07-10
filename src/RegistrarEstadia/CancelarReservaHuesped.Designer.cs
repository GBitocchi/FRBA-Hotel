namespace FrbaHotel.RegistrarEstadia
{
    partial class CancelarReservaHuesped
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtMotivo = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCancelacion = new System.Windows.Forms.TextBox();
            this.txtNumero_Reserva = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtUsername);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(113, 330);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(276, 75);
            this.groupBox2.TabIndex = 319;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Recepcion";
            // 
            // txtUsername
            // 
            this.txtUsername.Enabled = false;
            this.txtUsername.Location = new System.Drawing.Point(87, 32);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(173, 20);
            this.txtUsername.TabIndex = 310;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 309;
            this.label4.Text = "Username";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(189, 431);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(114, 39);
            this.btnAceptar.TabIndex = 316;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(37, 216);
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(428, 106);
            this.txtMotivo.TabIndex = 315;
            this.txtMotivo.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 314;
            this.label1.Text = "Numero de reserva";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(173, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 24);
            this.label5.TabIndex = 313;
            this.label5.Text = "Cancelar reserva";
            // 
            // txtCancelacion
            // 
            this.txtCancelacion.Enabled = false;
            this.txtCancelacion.Location = new System.Drawing.Point(229, 121);
            this.txtCancelacion.Name = "txtCancelacion";
            this.txtCancelacion.Size = new System.Drawing.Size(173, 20);
            this.txtCancelacion.TabIndex = 310;
            // 
            // txtNumero_Reserva
            // 
            this.txtNumero_Reserva.Location = new System.Drawing.Point(229, 81);
            this.txtNumero_Reserva.Name = "txtNumero_Reserva";
            this.txtNumero_Reserva.Size = new System.Drawing.Size(173, 20);
            this.txtNumero_Reserva.TabIndex = 309;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(104, 124);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 13);
            this.label10.TabIndex = 308;
            this.label10.Text = "Fecha de cancelacion";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(103, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 307;
            this.label6.Text = "Motivo";
            // 
            // CancelarReservaHuesped
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 496);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCancelacion);
            this.Controls.Add(this.txtNumero_Reserva);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.Name = "CancelarReservaHuesped";
            this.Text = "CancelarReservaHuesped";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.RichTextBox txtMotivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCancelacion;
        private System.Windows.Forms.TextBox txtNumero_Reserva;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
    }
}