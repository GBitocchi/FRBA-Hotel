namespace FrbaHotel.RegistrarConsumible
{
    partial class MenuRegistrarConsumible
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodigo_Estadia = new System.Windows.Forms.TextBox();
            this.txtHabitacion = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.cbxConsumible = new System.Windows.Forms.ComboBox();
            this.listaConsumibles = new System.Windows.Forms.ListView();
            this.Consumible = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cantidad = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Precio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAgregar_Consumible = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnIngresar_Consumibles = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAgregar_Reserva = new System.Windows.Forms.Button();
            this.txtRegimen = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtHotel = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnEliminar_Consumible = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo de estadia";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Habitacion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Consumible";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Cantidad";
            // 
            // txtCodigo_Estadia
            // 
            this.txtCodigo_Estadia.Location = new System.Drawing.Point(133, 51);
            this.txtCodigo_Estadia.Name = "txtCodigo_Estadia";
            this.txtCodigo_Estadia.Size = new System.Drawing.Size(214, 20);
            this.txtCodigo_Estadia.TabIndex = 6;
            // 
            // txtHabitacion
            // 
            this.txtHabitacion.Enabled = false;
            this.txtHabitacion.Location = new System.Drawing.Point(133, 117);
            this.txtHabitacion.Name = "txtHabitacion";
            this.txtHabitacion.Size = new System.Drawing.Size(214, 20);
            this.txtHabitacion.TabIndex = 7;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(133, 226);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(214, 20);
            this.txtCantidad.TabIndex = 8;
            // 
            // cbxConsumible
            // 
            this.cbxConsumible.FormattingEnabled = true;
            this.cbxConsumible.Location = new System.Drawing.Point(133, 189);
            this.cbxConsumible.Name = "cbxConsumible";
            this.cbxConsumible.Size = new System.Drawing.Size(214, 21);
            this.cbxConsumible.TabIndex = 9;
            // 
            // listaConsumibles
            // 
            this.listaConsumibles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Consumible,
            this.Cantidad,
            this.Precio});
            this.listaConsumibles.Location = new System.Drawing.Point(32, 267);
            this.listaConsumibles.Name = "listaConsumibles";
            this.listaConsumibles.Size = new System.Drawing.Size(315, 133);
            this.listaConsumibles.TabIndex = 10;
            this.listaConsumibles.UseCompatibleStateImageBehavior = false;
            this.listaConsumibles.SelectedIndexChanged += new System.EventHandler(this.listaConsumibles_SelectedIndexChanged);
            // 
            // Consumible
            // 
            this.Consumible.Text = "Consumible";
            // 
            // Cantidad
            // 
            this.Cantidad.Text = "Cantidad";
            // 
            // Precio
            // 
            this.Precio.Text = "Precio";
            // 
            // btnAgregar_Consumible
            // 
            this.btnAgregar_Consumible.Location = new System.Drawing.Point(374, 204);
            this.btnAgregar_Consumible.Name = "btnAgregar_Consumible";
            this.btnAgregar_Consumible.Size = new System.Drawing.Size(120, 25);
            this.btnAgregar_Consumible.TabIndex = 11;
            this.btnAgregar_Consumible.Text = "Agregar consumible";
            this.btnAgregar_Consumible.UseVisualStyleBackColor = true;
            this.btnAgregar_Consumible.Click += new System.EventHandler(this.btnAgregar_Consumible_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(97, 412);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(120, 33);
            this.btnLimpiar.TabIndex = 13;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnIngresar_Consumibles
            // 
            this.btnIngresar_Consumibles.Location = new System.Drawing.Point(299, 412);
            this.btnIngresar_Consumibles.Name = "btnIngresar_Consumibles";
            this.btnIngresar_Consumibles.Size = new System.Drawing.Size(120, 33);
            this.btnIngresar_Consumibles.TabIndex = 14;
            this.btnIngresar_Consumibles.Text = "Ingresar consumibles";
            this.btnIngresar_Consumibles.UseVisualStyleBackColor = true;
            this.btnIngresar_Consumibles.Click += new System.EventHandler(this.btnIngresar_Consumibles_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(150, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(248, 25);
            this.label5.TabIndex = 15;
            this.label5.Text = "Registro de consumibles";
            // 
            // btnAgregar_Reserva
            // 
            this.btnAgregar_Reserva.Location = new System.Drawing.Point(374, 48);
            this.btnAgregar_Reserva.Name = "btnAgregar_Reserva";
            this.btnAgregar_Reserva.Size = new System.Drawing.Size(120, 25);
            this.btnAgregar_Reserva.TabIndex = 16;
            this.btnAgregar_Reserva.Text = "Agregar estadia";
            this.btnAgregar_Reserva.UseVisualStyleBackColor = true;
            this.btnAgregar_Reserva.Click += new System.EventHandler(this.btnAgregar_Reserva_Click);
            // 
            // txtRegimen
            // 
            this.txtRegimen.Enabled = false;
            this.txtRegimen.Location = new System.Drawing.Point(133, 153);
            this.txtRegimen.Name = "txtRegimen";
            this.txtRegimen.Size = new System.Drawing.Size(214, 20);
            this.txtRegimen.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Regimen";
            // 
            // txtHotel
            // 
            this.txtHotel.Enabled = false;
            this.txtHotel.Location = new System.Drawing.Point(133, 83);
            this.txtHotel.Name = "txtHotel";
            this.txtHotel.Size = new System.Drawing.Size(214, 20);
            this.txtHotel.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Hotel";
            // 
            // btnEliminar_Consumible
            // 
            this.btnEliminar_Consumible.Location = new System.Drawing.Point(374, 322);
            this.btnEliminar_Consumible.Name = "btnEliminar_Consumible";
            this.btnEliminar_Consumible.Size = new System.Drawing.Size(120, 25);
            this.btnEliminar_Consumible.TabIndex = 21;
            this.btnEliminar_Consumible.Text = "Eliminar consumible";
            this.btnEliminar_Consumible.UseVisualStyleBackColor = true;
            this.btnEliminar_Consumible.Click += new System.EventHandler(this.btnEliminar_Consumible_Click);
            // 
            // MenuRegistrarConsumible
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 469);
            this.Controls.Add(this.btnEliminar_Consumible);
            this.Controls.Add(this.txtHotel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtRegimen);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnAgregar_Reserva);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnIngresar_Consumibles);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnAgregar_Consumible);
            this.Controls.Add(this.listaConsumibles);
            this.Controls.Add(this.cbxConsumible);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.txtHabitacion);
            this.Controls.Add(this.txtCodigo_Estadia);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MenuRegistrarConsumible";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCodigo_Estadia;
        private System.Windows.Forms.TextBox txtHabitacion;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.ComboBox cbxConsumible;
        private System.Windows.Forms.ListView listaConsumibles;
        private System.Windows.Forms.Button btnAgregar_Consumible;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnIngresar_Consumibles;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAgregar_Reserva;
        private System.Windows.Forms.TextBox txtRegimen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtHotel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ColumnHeader Consumible;
        private System.Windows.Forms.ColumnHeader Cantidad;
        private System.Windows.Forms.ColumnHeader Precio;
        private System.Windows.Forms.Button btnEliminar_Consumible;
    }
}