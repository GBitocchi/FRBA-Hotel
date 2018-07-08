namespace FrbaHotel.AbmFacturacion
{
    partial class Facturacion
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
            this.txtNroFactura = new System.Windows.Forms.TextBox();
            this.txtHuesped = new System.Windows.Forms.TextBox();
            this.dgConsumibles = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.btnPagar = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCostoExtra = new System.Windows.Forms.TextBox();
            this.txtPrecioRegimen = new System.Windows.Forms.TextBox();
            this.txtPorcentual = new System.Windows.Forms.TextBox();
            this.txtNochesReserva = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblDescuentos = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.txtNochesEstadia = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgConsumibles)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNroFactura
            // 
            this.txtNroFactura.Location = new System.Drawing.Point(435, 25);
            this.txtNroFactura.Name = "txtNroFactura";
            this.txtNroFactura.ReadOnly = true;
            this.txtNroFactura.Size = new System.Drawing.Size(100, 20);
            this.txtNroFactura.TabIndex = 0;
            // 
            // txtHuesped
            // 
            this.txtHuesped.Location = new System.Drawing.Point(334, 51);
            this.txtHuesped.Name = "txtHuesped";
            this.txtHuesped.ReadOnly = true;
            this.txtHuesped.Size = new System.Drawing.Size(201, 20);
            this.txtHuesped.TabIndex = 1;
            // 
            // dgConsumibles
            // 
            this.dgConsumibles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgConsumibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgConsumibles.Location = new System.Drawing.Point(22, 99);
            this.dgConsumibles.MultiSelect = false;
            this.dgConsumibles.Name = "dgConsumibles";
            this.dgConsumibles.ReadOnly = true;
            this.dgConsumibles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgConsumibles.Size = new System.Drawing.Size(513, 150);
            this.dgConsumibles.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mail de huesped";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Numero de factura";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Consumos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 451);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Total (US$)";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(435, 451);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(100, 20);
            this.txtTotal.TabIndex = 7;
            // 
            // btnPagar
            // 
            this.btnPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagar.Location = new System.Drawing.Point(357, 477);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(86, 39);
            this.btnPagar.TabIndex = 2;
            this.btnPagar.Text = "Pagar";
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // btnAtras
            // 
            this.btnAtras.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtras.Location = new System.Drawing.Point(449, 477);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(86, 39);
            this.btnAtras.TabIndex = 3;
            this.btnAtras.Text = "Atras";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(19, 307);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(221, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Costo de noches no utilizadas";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(19, 333);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Precio de regimen";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(18, 359);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(180, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Incremento por estrellas";
            // 
            // txtCostoExtra
            // 
            this.txtCostoExtra.Location = new System.Drawing.Point(435, 307);
            this.txtCostoExtra.Name = "txtCostoExtra";
            this.txtCostoExtra.ReadOnly = true;
            this.txtCostoExtra.Size = new System.Drawing.Size(100, 20);
            this.txtCostoExtra.TabIndex = 13;
            // 
            // txtPrecioRegimen
            // 
            this.txtPrecioRegimen.Location = new System.Drawing.Point(435, 333);
            this.txtPrecioRegimen.Name = "txtPrecioRegimen";
            this.txtPrecioRegimen.ReadOnly = true;
            this.txtPrecioRegimen.Size = new System.Drawing.Size(100, 20);
            this.txtPrecioRegimen.TabIndex = 14;
            // 
            // txtPorcentual
            // 
            this.txtPorcentual.Location = new System.Drawing.Point(435, 359);
            this.txtPorcentual.Name = "txtPorcentual";
            this.txtPorcentual.ReadOnly = true;
            this.txtPorcentual.Size = new System.Drawing.Size(100, 20);
            this.txtPorcentual.TabIndex = 16;
            // 
            // txtNochesReserva
            // 
            this.txtNochesReserva.Location = new System.Drawing.Point(435, 255);
            this.txtNochesReserva.Name = "txtNochesReserva";
            this.txtNochesReserva.ReadOnly = true;
            this.txtNochesReserva.Size = new System.Drawing.Size(100, 20);
            this.txtNochesReserva.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(19, 255);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(233, 20);
            this.label8.TabIndex = 18;
            this.label8.Text = "Cantidad de noches reservadas";
            // 
            // lblDescuentos
            // 
            this.lblDescuentos.AutoSize = true;
            this.lblDescuentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuentos.Location = new System.Drawing.Point(18, 387);
            this.lblDescuentos.Name = "lblDescuentos";
            this.lblDescuentos.Size = new System.Drawing.Size(208, 20);
            this.lblDescuentos.TabIndex = 20;
            this.lblDescuentos.Text = "Descuentos por All Inclusive";
            // 
            // txtDescuento
            // 
            this.txtDescuento.Location = new System.Drawing.Point(435, 387);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.ReadOnly = true;
            this.txtDescuento.Size = new System.Drawing.Size(100, 20);
            this.txtDescuento.TabIndex = 21;
            // 
            // txtNochesEstadia
            // 
            this.txtNochesEstadia.Location = new System.Drawing.Point(435, 281);
            this.txtNochesEstadia.Name = "txtNochesEstadia";
            this.txtNochesEstadia.ReadOnly = true;
            this.txtNochesEstadia.Size = new System.Drawing.Size(100, 20);
            this.txtNochesEstadia.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(18, 281);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(243, 20);
            this.label9.TabIndex = 23;
            this.label9.Text = "Cantidad de noches no utilziadas";
            // 
            // Facturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 537);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtNochesEstadia);
            this.Controls.Add(this.txtDescuento);
            this.Controls.Add(this.lblDescuentos);
            this.Controls.Add(this.txtNochesReserva);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPorcentual);
            this.Controls.Add(this.txtPrecioRegimen);
            this.Controls.Add(this.txtCostoExtra);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgConsumibles);
            this.Controls.Add(this.txtHuesped);
            this.Controls.Add(this.txtNroFactura);
            this.Name = "Facturacion";
            this.Text = "Facturacion";
            ((System.ComponentModel.ISupportInitialize)(this.dgConsumibles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNroFactura;
        private System.Windows.Forms.TextBox txtHuesped;
        private System.Windows.Forms.DataGridView dgConsumibles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCostoExtra;
        private System.Windows.Forms.TextBox txtPrecioRegimen;
        private System.Windows.Forms.TextBox txtPorcentual;
        private System.Windows.Forms.TextBox txtNochesReserva;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblDescuentos;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.TextBox txtNochesEstadia;
        private System.Windows.Forms.Label label9;
    }
}