namespace FrbaHotel.Menu_Sistema
{
    partial class VistaSistema
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
            this.btnHotel = new System.Windows.Forms.Button();
            this.btnHabitaciones = new System.Windows.Forms.Button();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.btnListado = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnHotel
            // 
            this.btnHotel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHotel.Location = new System.Drawing.Point(55, 96);
            this.btnHotel.Name = "btnHotel";
            this.btnHotel.Size = new System.Drawing.Size(173, 28);
            this.btnHotel.TabIndex = 0;
            this.btnHotel.Text = "Menu hotel";
            this.btnHotel.UseVisualStyleBackColor = true;
            this.btnHotel.Click += new System.EventHandler(this.btnHotel_Click);
            // 
            // btnHabitaciones
            // 
            this.btnHabitaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHabitaciones.Location = new System.Drawing.Point(55, 130);
            this.btnHabitaciones.Name = "btnHabitaciones";
            this.btnHabitaciones.Size = new System.Drawing.Size(173, 28);
            this.btnHabitaciones.TabIndex = 1;
            this.btnHabitaciones.Text = "Menu habitaciones";
            this.btnHabitaciones.UseVisualStyleBackColor = true;
            // 
            // btnFacturar
            // 
            this.btnFacturar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacturar.Location = new System.Drawing.Point(55, 164);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(173, 28);
            this.btnFacturar.TabIndex = 2;
            this.btnFacturar.Text = "Facturar estadia";
            this.btnFacturar.UseVisualStyleBackColor = true;
            // 
            // btnListado
            // 
            this.btnListado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListado.Location = new System.Drawing.Point(55, 198);
            this.btnListado.Name = "btnListado";
            this.btnListado.Size = new System.Drawing.Size(173, 28);
            this.btnListado.TabIndex = 3;
            this.btnListado.Text = "Listado estadistico";
            this.btnListado.UseVisualStyleBackColor = true;
            // 
            // VistaSistema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 275);
            this.Controls.Add(this.btnListado);
            this.Controls.Add(this.btnFacturar);
            this.Controls.Add(this.btnHabitaciones);
            this.Controls.Add(this.btnHotel);
            this.Name = "VistaSistema";
            this.Text = "FRBA-HOTEL";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnHotel;
        private System.Windows.Forms.Button btnHabitaciones;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.Button btnListado;
    }
}