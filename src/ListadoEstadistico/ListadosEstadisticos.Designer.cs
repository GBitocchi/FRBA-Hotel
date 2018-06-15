namespace FrbaHotel.ListadoEstadistico
{
    partial class ListadosEstadisticos
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
            this.btnMasCanceladas = new System.Windows.Forms.Button();
            this.btnConsumiblesFacturados = new System.Windows.Forms.Button();
            this.btnMasMantenimiento = new System.Windows.Forms.Button();
            this.btnMasOcupadas = new System.Windows.Forms.Button();
            this.btnClientesPuntos = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione el tipo de listado";
            // 
            // btnMasCanceladas
            // 
            this.btnMasCanceladas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMasCanceladas.Location = new System.Drawing.Point(32, 61);
            this.btnMasCanceladas.Name = "btnMasCanceladas";
            this.btnMasCanceladas.Size = new System.Drawing.Size(228, 37);
            this.btnMasCanceladas.TabIndex = 1;
            this.btnMasCanceladas.Text = "Mas reservas canceladas";
            this.btnMasCanceladas.UseVisualStyleBackColor = true;
            this.btnMasCanceladas.Click += new System.EventHandler(this.btnMasCanceladas_Click);
            // 
            // btnConsumiblesFacturados
            // 
            this.btnConsumiblesFacturados.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsumiblesFacturados.Location = new System.Drawing.Point(32, 104);
            this.btnConsumiblesFacturados.Name = "btnConsumiblesFacturados";
            this.btnConsumiblesFacturados.Size = new System.Drawing.Size(228, 37);
            this.btnConsumiblesFacturados.TabIndex = 2;
            this.btnConsumiblesFacturados.Text = "Mas consumibles facturados";
            this.btnConsumiblesFacturados.UseVisualStyleBackColor = true;
            this.btnConsumiblesFacturados.Click += new System.EventHandler(this.btnConsumiblesFacturados_Click);
            // 
            // btnMasMantenimiento
            // 
            this.btnMasMantenimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMasMantenimiento.Location = new System.Drawing.Point(32, 147);
            this.btnMasMantenimiento.Name = "btnMasMantenimiento";
            this.btnMasMantenimiento.Size = new System.Drawing.Size(228, 37);
            this.btnMasMantenimiento.TabIndex = 3;
            this.btnMasMantenimiento.Text = "Mas dias fuera de servicio";
            this.btnMasMantenimiento.UseVisualStyleBackColor = true;
            this.btnMasMantenimiento.Click += new System.EventHandler(this.btnMasMantenimiento_Click);
            // 
            // btnMasOcupadas
            // 
            this.btnMasOcupadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMasOcupadas.Location = new System.Drawing.Point(32, 190);
            this.btnMasOcupadas.Name = "btnMasOcupadas";
            this.btnMasOcupadas.Size = new System.Drawing.Size(228, 37);
            this.btnMasOcupadas.TabIndex = 4;
            this.btnMasOcupadas.Text = "Habitaciones mas ocupadas";
            this.btnMasOcupadas.UseVisualStyleBackColor = true;
            this.btnMasOcupadas.Click += new System.EventHandler(this.btnMasOcupadas_Click);
            // 
            // btnClientesPuntos
            // 
            this.btnClientesPuntos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientesPuntos.Location = new System.Drawing.Point(32, 233);
            this.btnClientesPuntos.Name = "btnClientesPuntos";
            this.btnClientesPuntos.Size = new System.Drawing.Size(228, 37);
            this.btnClientesPuntos.TabIndex = 5;
            this.btnClientesPuntos.Text = "Clientes con mas puntos";
            this.btnClientesPuntos.UseVisualStyleBackColor = true;
            this.btnClientesPuntos.Click += new System.EventHandler(this.btnClientesPuntos_Click);
            // 
            // btnAtras
            // 
            this.btnAtras.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtras.Location = new System.Drawing.Point(32, 276);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(228, 37);
            this.btnAtras.TabIndex = 6;
            this.btnAtras.Text = "Atras";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // ListadosEstadisticos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 332);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.btnClientesPuntos);
            this.Controls.Add(this.btnMasOcupadas);
            this.Controls.Add(this.btnMasMantenimiento);
            this.Controls.Add(this.btnConsumiblesFacturados);
            this.Controls.Add(this.btnMasCanceladas);
            this.Controls.Add(this.label1);
            this.Name = "ListadosEstadisticos";
            this.Text = "Listados estadisticos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMasCanceladas;
        private System.Windows.Forms.Button btnConsumiblesFacturados;
        private System.Windows.Forms.Button btnMasMantenimiento;
        private System.Windows.Forms.Button btnMasOcupadas;
        private System.Windows.Forms.Button btnClientesPuntos;
        private System.Windows.Forms.Button btnAtras;
    }
}