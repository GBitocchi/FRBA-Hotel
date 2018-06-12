namespace FrbaHotel.AbmFacturacion
{
    partial class EstadiasAFacturar
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
            this.dgEstadias = new System.Windows.Forms.DataGridView();
            this.Estadias = new System.Windows.Forms.Label();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgEstadias)).BeginInit();
            this.SuspendLayout();
            // 
            // dgEstadias
            // 
            this.dgEstadias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgEstadias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEstadias.Location = new System.Drawing.Point(52, 70);
            this.dgEstadias.MultiSelect = false;
            this.dgEstadias.Name = "dgEstadias";
            this.dgEstadias.ReadOnly = true;
            this.dgEstadias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgEstadias.Size = new System.Drawing.Size(531, 150);
            this.dgEstadias.TabIndex = 0;
            // 
            // Estadias
            // 
            this.Estadias.AutoSize = true;
            this.Estadias.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Estadias.Location = new System.Drawing.Point(47, 31);
            this.Estadias.Name = "Estadias";
            this.Estadias.Size = new System.Drawing.Size(87, 25);
            this.Estadias.TabIndex = 1;
            this.Estadias.Text = "Estadias";
            // 
            // btnFacturar
            // 
            this.btnFacturar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacturar.Location = new System.Drawing.Point(405, 232);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(86, 39);
            this.btnFacturar.TabIndex = 2;
            this.btnFacturar.Text = "Facturar";
            this.btnFacturar.UseVisualStyleBackColor = true;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
            // 
            // btnAtras
            // 
            this.btnAtras.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtras.Location = new System.Drawing.Point(497, 232);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(86, 39);
            this.btnAtras.TabIndex = 3;
            this.btnAtras.Text = "Atras";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // EstadiasAFacturar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 299);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.btnFacturar);
            this.Controls.Add(this.Estadias);
            this.Controls.Add(this.dgEstadias);
            this.Name = "EstadiasAFacturar";
            this.Text = "EstadiasAFacturar";
            ((System.ComponentModel.ISupportInitialize)(this.dgEstadias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgEstadias;
        private System.Windows.Forms.Label Estadias;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.Button btnAtras;
    }
}