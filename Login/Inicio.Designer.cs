namespace FrbaHotel.Login
{
    partial class Inicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.btnGuest = new System.Windows.Forms.Button();
            this.btnUsuario = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblErrorBD = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGuest
            // 
            this.btnGuest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuest.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGuest.Location = new System.Drawing.Point(393, 561);
            this.btnGuest.Name = "btnGuest";
            this.btnGuest.Size = new System.Drawing.Size(121, 29);
            this.btnGuest.TabIndex = 1;
            this.btnGuest.Text = "Huesped";
            this.btnGuest.UseVisualStyleBackColor = true;
            this.btnGuest.Click += new System.EventHandler(this.btnGuest_Click);
            // 
            // btnUsuario
            // 
            this.btnUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuario.Location = new System.Drawing.Point(393, 491);
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.Size = new System.Drawing.Size(121, 31);
            this.btnUsuario.TabIndex = 0;
            this.btnUsuario.Text = "Usuario";
            this.btnUsuario.UseVisualStyleBackColor = true;
            this.btnUsuario.Click += new System.EventHandler(this.btnUsuario_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(305, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(301, 312);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(772, 662);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(77, 32);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(206, 380);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(531, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Por favor, seleccione un modo de acceso al sistema";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblErrorBD
            // 
            this.lblErrorBD.AutoSize = true;
            this.lblErrorBD.BackColor = System.Drawing.Color.Transparent;
            this.lblErrorBD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorBD.ForeColor = System.Drawing.Color.Red;
            this.lblErrorBD.Location = new System.Drawing.Point(180, 428);
            this.lblErrorBD.Name = "lblErrorBD";
            this.lblErrorBD.Size = new System.Drawing.Size(570, 16);
            this.lblErrorBD.TabIndex = 5;
            this.lblErrorBD.Text = "ERROR: NO SE HA PODIDO ESTABLECER CONEXION CON LA BASE DE DATOS";
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(886, 726);
            this.Controls.Add(this.lblErrorBD);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnUsuario);
            this.Controls.Add(this.btnGuest);
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRBA-HOTEL";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuest;
        private System.Windows.Forms.Button btnUsuario;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblErrorBD;
    }
}