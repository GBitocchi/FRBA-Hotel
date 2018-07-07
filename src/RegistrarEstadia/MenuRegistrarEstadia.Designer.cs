namespace FrbaHotel.RegistrarEstadia
{
    partial class MenuRegistrarEstadia
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
            this.txtCodigo_Reserva = new System.Windows.Forms.TextBox();
            this.bntIngresar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(91, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registrar estadia";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Codigo de reserva";
            // 
            // txtCodigo_Reserva
            // 
            this.txtCodigo_Reserva.Location = new System.Drawing.Point(135, 76);
            this.txtCodigo_Reserva.Name = "txtCodigo_Reserva";
            this.txtCodigo_Reserva.Size = new System.Drawing.Size(154, 20);
            this.txtCodigo_Reserva.TabIndex = 2;
            // 
            // bntIngresar
            // 
            this.bntIngresar.Location = new System.Drawing.Point(39, 126);
            this.bntIngresar.Name = "bntIngresar";
            this.bntIngresar.Size = new System.Drawing.Size(115, 28);
            this.bntIngresar.TabIndex = 3;
            this.bntIngresar.Text = "Ingresar";
            this.bntIngresar.UseVisualStyleBackColor = true;
            this.bntIngresar.Click += new System.EventHandler(this.bntIngresar_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(174, 126);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(115, 28);
            this.btnLimpar.TabIndex = 4;
            this.btnLimpar.Text = "Limpiar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // MenuRegistrarEstadia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 184);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.bntIngresar);
            this.Controls.Add(this.txtCodigo_Reserva);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MenuRegistrarEstadia";
            this.Text = "Registrar estadia";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodigo_Reserva;
        private System.Windows.Forms.Button bntIngresar;
        private System.Windows.Forms.Button btnLimpar;
    }
}