namespace FrbaHotel.AbmHotel
{
    partial class FiltrarHotel
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
            this.txtNombreHotel = new System.Windows.Forms.TextBox();
            this.txtCantidadEstrellas = new System.Windows.Forms.TextBox();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.txtPais = new System.Windows.Forms.TextBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.dgHoteles = new System.Windows.Forms.DataGridView();
            this.btnAtras = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgHoteles)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNombreHotel
            // 
            this.txtNombreHotel.Location = new System.Drawing.Point(32, 65);
            this.txtNombreHotel.Name = "txtNombreHotel";
            this.txtNombreHotel.Size = new System.Drawing.Size(100, 20);
            this.txtNombreHotel.TabIndex = 0;
            // 
            // txtCantidadEstrellas
            // 
            this.txtCantidadEstrellas.Location = new System.Drawing.Point(138, 65);
            this.txtCantidadEstrellas.Name = "txtCantidadEstrellas";
            this.txtCantidadEstrellas.Size = new System.Drawing.Size(100, 20);
            this.txtCantidadEstrellas.TabIndex = 1;
            // 
            // txtCiudad
            // 
            this.txtCiudad.Location = new System.Drawing.Point(244, 65);
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(100, 20);
            this.txtCiudad.TabIndex = 2;
            // 
            // txtPais
            // 
            this.txtPais.Location = new System.Drawing.Point(350, 65);
            this.txtPais.Name = "txtPais";
            this.txtPais.Size = new System.Drawing.Size(100, 20);
            this.txtPais.TabIndex = 3;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(478, 65);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrar.TabIndex = 4;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // dgHoteles
            // 
            this.dgHoteles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgHoteles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHoteles.Location = new System.Drawing.Point(32, 91);
            this.dgHoteles.MultiSelect = false;
            this.dgHoteles.Name = "dgHoteles";
            this.dgHoteles.ReadOnly = true;
            this.dgHoteles.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgHoteles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgHoteles.Size = new System.Drawing.Size(521, 150);
            this.dgHoteles.TabIndex = 5;
            this.dgHoteles.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgHoteles_CellContentDoubleClick);
            // 
            // btnAtras
            // 
            this.btnAtras.Location = new System.Drawing.Point(478, 247);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(75, 23);
            this.btnAtras.TabIndex = 6;
            this.btnAtras.Text = "Atras";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Filtrar hoteles";
            // 
            // FiltrarHotel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 292);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.dgHoteles);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.txtPais);
            this.Controls.Add(this.txtCiudad);
            this.Controls.Add(this.txtCantidadEstrellas);
            this.Controls.Add(this.txtNombreHotel);
            this.Name = "FiltrarHotel";
            this.Text = "FiltrarHotel";
            ((System.ComponentModel.ISupportInitialize)(this.dgHoteles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombreHotel;
        private System.Windows.Forms.TextBox txtCantidadEstrellas;
        private System.Windows.Forms.TextBox txtCiudad;
        private System.Windows.Forms.TextBox txtPais;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.DataGridView dgHoteles;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Label label1;
    }
}