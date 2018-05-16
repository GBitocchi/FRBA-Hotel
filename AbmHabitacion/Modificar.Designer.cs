namespace FrbaHotel.AbmHabitacion
{
    partial class Modificar
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtNro_habitacion = new System.Windows.Forms.TextBox();
            this.txtPiso = new System.Windows.Forms.TextBox();
            this.txtUbicacion = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(360, 199);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(98, 34);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(183, 199);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(98, 34);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtNro_habitacion
            // 
            this.txtNro_habitacion.Location = new System.Drawing.Point(200, 56);
            this.txtNro_habitacion.Name = "txtNro_habitacion";
            this.txtNro_habitacion.Size = new System.Drawing.Size(100, 20);
            this.txtNro_habitacion.TabIndex = 2;
            // 
            // txtPiso
            // 
            this.txtPiso.Location = new System.Drawing.Point(200, 82);
            this.txtPiso.Name = "txtPiso";
            this.txtPiso.Size = new System.Drawing.Size(100, 20);
            this.txtPiso.TabIndex = 3;
            // 
            // txtUbicacion
            // 
            this.txtUbicacion.Location = new System.Drawing.Point(200, 108);
            this.txtUbicacion.Name = "txtUbicacion";
            this.txtUbicacion.Size = new System.Drawing.Size(100, 20);
            this.txtUbicacion.TabIndex = 4;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(388, 56);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(100, 96);
            this.txtDescripcion.TabIndex = 5;
            this.txtDescripcion.Text = "";
            // 
            // Modificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 261);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtUbicacion);
            this.Controls.Add(this.txtPiso);
            this.Controls.Add(this.txtNro_habitacion);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Name = "Modificar";
            this.Text = "Modificar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtNro_habitacion;
        private System.Windows.Forms.TextBox txtPiso;
        private System.Windows.Forms.TextBox txtUbicacion;
        private System.Windows.Forms.RichTextBox txtDescripcion;
    }
}