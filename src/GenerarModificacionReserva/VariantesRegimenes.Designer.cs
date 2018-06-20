namespace FrbaHotel.GenerarModificacionReserva
{
    partial class VariantesRegimenes
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
            this.dgvRegimenes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegimenes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(366, 73);
            this.label1.TabIndex = 1;
            this.label1.Text = "Regimenes";
            // 
            // dgvRegimenes
            // 
            this.dgvRegimenes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRegimenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegimenes.Location = new System.Drawing.Point(40, 96);
            this.dgvRegimenes.MultiSelect = false;
            this.dgvRegimenes.Name = "dgvRegimenes";
            this.dgvRegimenes.ReadOnly = true;
            this.dgvRegimenes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRegimenes.Size = new System.Drawing.Size(1030, 805);
            this.dgvRegimenes.TabIndex = 4;
            this.dgvRegimenes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRegimenes_CellContentClick_1);
            // 
            // VariantesRegimenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1102, 946);
            this.Controls.Add(this.dgvRegimenes);
            this.Controls.Add(this.label1);
            this.Name = "VariantesRegimenes";
            this.Text = "VariantesRegimenes";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegimenes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvRegimenes;
    }
}