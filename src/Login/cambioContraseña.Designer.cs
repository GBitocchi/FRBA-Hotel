namespace FrbaHotel.Login
{
    partial class cambioContraseña
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cambioContraseña));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCurrentPW = new System.Windows.Forms.TextBox();
            this.txtNewPW = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtReEntryNewPW = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.lblErrorNoNewPW = new System.Windows.Forms.Label();
            this.lblErrorNoConfirmPW = new System.Windows.Forms.Label();
            this.lblErrorNoCurrentPW = new System.Windows.Forms.Label();
            this.lblErrorPWsNoCoincidence = new System.Windows.Forms.Label();
            this.lblErrorWrongPW = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(802, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(261, 265);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(78, 852);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "Volver";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(968, 852);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 30);
            this.button2.TabIndex = 2;
            this.button2.Text = "Salir";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(65, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(698, 73);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cambio de contraseña";
            // 
            // txtCurrentPW
            // 
            this.txtCurrentPW.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtCurrentPW.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentPW.Location = new System.Drawing.Point(476, 346);
            this.txtCurrentPW.Name = "txtCurrentPW";
            this.txtCurrentPW.PasswordChar = '*';
            this.txtCurrentPW.Size = new System.Drawing.Size(227, 26);
            this.txtCurrentPW.TabIndex = 4;
            // 
            // txtNewPW
            // 
            this.txtNewPW.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtNewPW.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPW.Location = new System.Drawing.Point(476, 461);
            this.txtNewPW.Name = "txtNewPW";
            this.txtNewPW.PasswordChar = '*';
            this.txtNewPW.Size = new System.Drawing.Size(227, 26);
            this.txtNewPW.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(449, 295);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(284, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ingrese su actual contraseña:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(449, 408);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(286, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "Ingrese su nueva contraseña:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(449, 524);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(300, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "Confirme su nueva contraseña:";
            // 
            // txtReEntryNewPW
            // 
            this.txtReEntryNewPW.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtReEntryNewPW.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReEntryNewPW.Location = new System.Drawing.Point(476, 576);
            this.txtReEntryNewPW.Name = "txtReEntryNewPW";
            this.txtReEntryNewPW.PasswordChar = '*';
            this.txtReEntryNewPW.Size = new System.Drawing.Size(227, 26);
            this.txtReEntryNewPW.TabIndex = 9;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(686, 635);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(77, 31);
            this.button3.TabIndex = 10;
            this.button3.Text = "Aceptar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lblErrorNoNewPW
            // 
            this.lblErrorNoNewPW.AutoSize = true;
            this.lblErrorNoNewPW.BackColor = System.Drawing.Color.Transparent;
            this.lblErrorNoNewPW.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorNoNewPW.ForeColor = System.Drawing.Color.Red;
            this.lblErrorNoNewPW.Location = new System.Drawing.Point(223, 464);
            this.lblErrorNoNewPW.Name = "lblErrorNoNewPW";
            this.lblErrorNoNewPW.Size = new System.Drawing.Size(207, 20);
            this.lblErrorNoNewPW.TabIndex = 11;
            this.lblErrorNoNewPW.Text = "*Ingrese una contraseña";
            // 
            // lblErrorNoConfirmPW
            // 
            this.lblErrorNoConfirmPW.AutoSize = true;
            this.lblErrorNoConfirmPW.BackColor = System.Drawing.Color.Transparent;
            this.lblErrorNoConfirmPW.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorNoConfirmPW.ForeColor = System.Drawing.Color.Red;
            this.lblErrorNoConfirmPW.Location = new System.Drawing.Point(136, 582);
            this.lblErrorNoConfirmPW.Name = "lblErrorNoConfirmPW";
            this.lblErrorNoConfirmPW.Size = new System.Drawing.Size(294, 20);
            this.lblErrorNoConfirmPW.TabIndex = 12;
            this.lblErrorNoConfirmPW.Text = "*Ingrese nuevamente la contraseña";
            // 
            // lblErrorNoCurrentPW
            // 
            this.lblErrorNoCurrentPW.AutoSize = true;
            this.lblErrorNoCurrentPW.BackColor = System.Drawing.Color.Transparent;
            this.lblErrorNoCurrentPW.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorNoCurrentPW.ForeColor = System.Drawing.Color.Red;
            this.lblErrorNoCurrentPW.Location = new System.Drawing.Point(234, 349);
            this.lblErrorNoCurrentPW.Name = "lblErrorNoCurrentPW";
            this.lblErrorNoCurrentPW.Size = new System.Drawing.Size(196, 20);
            this.lblErrorNoCurrentPW.TabIndex = 13;
            this.lblErrorNoCurrentPW.Text = "*Ingrese su contraseña";
            // 
            // lblErrorPWsNoCoincidence
            // 
            this.lblErrorPWsNoCoincidence.AutoSize = true;
            this.lblErrorPWsNoCoincidence.BackColor = System.Drawing.Color.Transparent;
            this.lblErrorPWsNoCoincidence.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorPWsNoCoincidence.ForeColor = System.Drawing.Color.Red;
            this.lblErrorPWsNoCoincidence.Location = new System.Drawing.Point(136, 524);
            this.lblErrorPWsNoCoincidence.Name = "lblErrorPWsNoCoincidence";
            this.lblErrorPWsNoCoincidence.Size = new System.Drawing.Size(297, 24);
            this.lblErrorPWsNoCoincidence.TabIndex = 14;
            this.lblErrorPWsNoCoincidence.Text = "*Las contraseñas no coinciden";
            // 
            // lblErrorWrongPW
            // 
            this.lblErrorWrongPW.AutoSize = true;
            this.lblErrorWrongPW.BackColor = System.Drawing.Color.Transparent;
            this.lblErrorWrongPW.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorWrongPW.ForeColor = System.Drawing.Color.Red;
            this.lblErrorWrongPW.Location = new System.Drawing.Point(338, 640);
            this.lblErrorWrongPW.Name = "lblErrorWrongPW";
            this.lblErrorWrongPW.Size = new System.Drawing.Size(294, 20);
            this.lblErrorWrongPW.TabIndex = 15;
            this.lblErrorWrongPW.Text = "*La contraseña actual es incorrecta";
            // 
            // cambioContraseña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1093, 895);
            this.Controls.Add(this.lblErrorWrongPW);
            this.Controls.Add(this.lblErrorPWsNoCoincidence);
            this.Controls.Add(this.lblErrorNoCurrentPW);
            this.Controls.Add(this.lblErrorNoConfirmPW);
            this.Controls.Add(this.lblErrorNoNewPW);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txtReEntryNewPW);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNewPW);
            this.Controls.Add(this.txtCurrentPW);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "cambioContraseña";
            this.Text = "FRBA-HOTEL";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCurrentPW;
        private System.Windows.Forms.TextBox txtNewPW;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtReEntryNewPW;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lblErrorNoNewPW;
        private System.Windows.Forms.Label lblErrorNoConfirmPW;
        private System.Windows.Forms.Label lblErrorNoCurrentPW;
        private System.Windows.Forms.Label lblErrorPWsNoCoincidence;
        private System.Windows.Forms.Label lblErrorWrongPW;
    }
}