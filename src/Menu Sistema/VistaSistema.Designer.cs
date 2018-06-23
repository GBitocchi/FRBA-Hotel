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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaSistema));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.stripReserva = new System.Windows.Forms.ToolStripMenuItem();
            this.generarReservaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarReservaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelarReservaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stripUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarMiContraseñaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stripRol = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarRolesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stripHotel = new System.Windows.Forms.ToolStripMenuItem();
            this.crearHotelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarHotelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaHotelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stripHabitacion = new System.Windows.Forms.ToolStripMenuItem();
            this.crearHabitacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarHabitacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaDeHabitacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stripFacturar = new System.Windows.Forms.ToolStripMenuItem();
            this.stripListado = new System.Windows.Forms.ToolStripMenuItem();
            this.masTiempoFueraDeServiicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masReservasCanceladasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.habitacionesMasOcupadasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesConMasPuntosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mayorFacturacionDeConsumiblesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(364, 185);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(463, 257);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripReserva,
            this.stripUsuario,
            this.stripRol,
            this.stripHotel,
            this.stripHabitacion,
            this.stripFacturar,
            this.stripListado});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1179, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // stripReserva
            // 
            this.stripReserva.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generarReservaToolStripMenuItem,
            this.modificarReservaToolStripMenuItem,
            this.cancelarReservaToolStripMenuItem});
            this.stripReserva.Name = "stripReserva";
            this.stripReserva.Size = new System.Drawing.Size(59, 20);
            this.stripReserva.Text = "Reserva";
            this.stripReserva.Visible = false;
            this.stripReserva.Click += new System.EventHandler(this.reservaToolStripMenuItem_Click);
            // 
            // generarReservaToolStripMenuItem
            // 
            this.generarReservaToolStripMenuItem.Name = "generarReservaToolStripMenuItem";
            this.generarReservaToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.generarReservaToolStripMenuItem.Text = "Generar Reserva";
            this.generarReservaToolStripMenuItem.Click += new System.EventHandler(this.generarReservaToolStripMenuItem_Click);
            // 
            // modificarReservaToolStripMenuItem
            // 
            this.modificarReservaToolStripMenuItem.Name = "modificarReservaToolStripMenuItem";
            this.modificarReservaToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.modificarReservaToolStripMenuItem.Text = "Modificar Reserva";
            this.modificarReservaToolStripMenuItem.Click += new System.EventHandler(this.modificarReservaToolStripMenuItem_Click);
            // 
            // cancelarReservaToolStripMenuItem
            // 
            this.cancelarReservaToolStripMenuItem.Name = "cancelarReservaToolStripMenuItem";
            this.cancelarReservaToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.cancelarReservaToolStripMenuItem.Text = "Cancelar Reserva";
            // 
            // stripUsuario
            // 
            this.stripUsuario.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrarUsuariosToolStripMenuItem,
            this.cambiarMiContraseñaToolStripMenuItem,
            this.cerrarSesionToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.stripUsuario.Name = "stripUsuario";
            this.stripUsuario.Size = new System.Drawing.Size(59, 20);
            this.stripUsuario.Text = "Usuario";
            this.stripUsuario.Visible = false;
            // 
            // administrarUsuariosToolStripMenuItem
            // 
            this.administrarUsuariosToolStripMenuItem.Name = "administrarUsuariosToolStripMenuItem";
            this.administrarUsuariosToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.administrarUsuariosToolStripMenuItem.Text = "Administrar Usuarios";
            this.administrarUsuariosToolStripMenuItem.Click += new System.EventHandler(this.administrarUsuariosToolStripMenuItem_Click);
            // 
            // cambiarMiContraseñaToolStripMenuItem
            // 
            this.cambiarMiContraseñaToolStripMenuItem.Name = "cambiarMiContraseñaToolStripMenuItem";
            this.cambiarMiContraseñaToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.cambiarMiContraseñaToolStripMenuItem.Text = "Cambiar mi Contraseña";
            this.cambiarMiContraseñaToolStripMenuItem.Click += new System.EventHandler(this.cambiarMiContraseñaToolStripMenuItem_Click);
            // 
            // cerrarSesionToolStripMenuItem
            // 
            this.cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            this.cerrarSesionToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.cerrarSesionToolStripMenuItem.Text = "Cerrar Sesion";
            this.cerrarSesionToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesionToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // stripRol
            // 
            this.stripRol.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrarRolesToolStripMenuItem});
            this.stripRol.Name = "stripRol";
            this.stripRol.Size = new System.Drawing.Size(36, 20);
            this.stripRol.Text = "Rol";
            this.stripRol.Visible = false;
            // 
            // administrarRolesToolStripMenuItem
            // 
            this.administrarRolesToolStripMenuItem.Name = "administrarRolesToolStripMenuItem";
            this.administrarRolesToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.administrarRolesToolStripMenuItem.Text = "Administrar Roles";
            this.administrarRolesToolStripMenuItem.Click += new System.EventHandler(this.administrarRolesToolStripMenuItem_Click);
            // 
            // stripHotel
            // 
            this.stripHotel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearHotelToolStripMenuItem,
            this.modificarHotelToolStripMenuItem,
            this.bajaHotelToolStripMenuItem});
            this.stripHotel.Name = "stripHotel";
            this.stripHotel.Size = new System.Drawing.Size(48, 20);
            this.stripHotel.Text = "Hotel";
            this.stripHotel.Visible = false;
            // 
            // crearHotelToolStripMenuItem
            // 
            this.crearHotelToolStripMenuItem.Name = "crearHotelToolStripMenuItem";
            this.crearHotelToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.crearHotelToolStripMenuItem.Text = "Crear hotel";
            this.crearHotelToolStripMenuItem.Click += new System.EventHandler(this.crearHotelToolStripMenuItem_Click);
            // 
            // modificarHotelToolStripMenuItem
            // 
            this.modificarHotelToolStripMenuItem.Name = "modificarHotelToolStripMenuItem";
            this.modificarHotelToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.modificarHotelToolStripMenuItem.Text = "Modificar hotel";
            this.modificarHotelToolStripMenuItem.Click += new System.EventHandler(this.modificarHotelToolStripMenuItem_Click);
            // 
            // bajaHotelToolStripMenuItem
            // 
            this.bajaHotelToolStripMenuItem.Name = "bajaHotelToolStripMenuItem";
            this.bajaHotelToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.bajaHotelToolStripMenuItem.Text = "Baja hotel";
            this.bajaHotelToolStripMenuItem.Click += new System.EventHandler(this.bajaHotelToolStripMenuItem_Click);
            // 
            // stripHabitacion
            // 
            this.stripHabitacion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearHabitacionToolStripMenuItem,
            this.modificarHabitacionToolStripMenuItem,
            this.bajaDeHabitacionToolStripMenuItem});
            this.stripHabitacion.Name = "stripHabitacion";
            this.stripHabitacion.Size = new System.Drawing.Size(88, 20);
            this.stripHabitacion.Text = "Habitaciones";
            this.stripHabitacion.Visible = false;
            // 
            // crearHabitacionToolStripMenuItem
            // 
            this.crearHabitacionToolStripMenuItem.Name = "crearHabitacionToolStripMenuItem";
            this.crearHabitacionToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.crearHabitacionToolStripMenuItem.Text = "Crear habitacion";
            this.crearHabitacionToolStripMenuItem.Click += new System.EventHandler(this.crearHabitacionToolStripMenuItem_Click);
            // 
            // modificarHabitacionToolStripMenuItem
            // 
            this.modificarHabitacionToolStripMenuItem.Name = "modificarHabitacionToolStripMenuItem";
            this.modificarHabitacionToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.modificarHabitacionToolStripMenuItem.Text = "Modificar habitacion";
            this.modificarHabitacionToolStripMenuItem.Click += new System.EventHandler(this.modificarHabitacionToolStripMenuItem_Click);
            // 
            // bajaDeHabitacionToolStripMenuItem
            // 
            this.bajaDeHabitacionToolStripMenuItem.Name = "bajaDeHabitacionToolStripMenuItem";
            this.bajaDeHabitacionToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.bajaDeHabitacionToolStripMenuItem.Text = "Baja de habitacion";
            this.bajaDeHabitacionToolStripMenuItem.Click += new System.EventHandler(this.bajaDeHabitacionToolStripMenuItem_Click);
            // 
            // stripFacturar
            // 
            this.stripFacturar.Name = "stripFacturar";
            this.stripFacturar.Size = new System.Drawing.Size(62, 20);
            this.stripFacturar.Text = "Facturar";
            this.stripFacturar.Visible = false;
            this.stripFacturar.Click += new System.EventHandler(this.stripFacturar_Click);
            // 
            // stripListado
            // 
            this.stripListado.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.masTiempoFueraDeServiicoToolStripMenuItem,
            this.masReservasCanceladasToolStripMenuItem,
            this.habitacionesMasOcupadasToolStripMenuItem,
            this.clientesConMasPuntosToolStripMenuItem,
            this.mayorFacturacionDeConsumiblesToolStripMenuItem});
            this.stripListado.Name = "stripListado";
            this.stripListado.Size = new System.Drawing.Size(116, 20);
            this.stripListado.Text = "Listado estadistico";
            this.stripListado.Visible = false;
            // 
            // masTiempoFueraDeServiicoToolStripMenuItem
            // 
            this.masTiempoFueraDeServiicoToolStripMenuItem.Name = "masTiempoFueraDeServiicoToolStripMenuItem";
            this.masTiempoFueraDeServiicoToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.masTiempoFueraDeServiicoToolStripMenuItem.Text = "Mas tiempo fuera de servicio";
            this.masTiempoFueraDeServiicoToolStripMenuItem.Click += new System.EventHandler(this.masTiempoFueraDeServiicoToolStripMenuItem_Click);
            // 
            // masReservasCanceladasToolStripMenuItem
            // 
            this.masReservasCanceladasToolStripMenuItem.Name = "masReservasCanceladasToolStripMenuItem";
            this.masReservasCanceladasToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.masReservasCanceladasToolStripMenuItem.Text = "Mas reservas canceladas";
            this.masReservasCanceladasToolStripMenuItem.Click += new System.EventHandler(this.masReservasCanceladasToolStripMenuItem_Click);
            // 
            // habitacionesMasOcupadasToolStripMenuItem
            // 
            this.habitacionesMasOcupadasToolStripMenuItem.Name = "habitacionesMasOcupadasToolStripMenuItem";
            this.habitacionesMasOcupadasToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.habitacionesMasOcupadasToolStripMenuItem.Text = "Habitaciones mas ocupadas";
            this.habitacionesMasOcupadasToolStripMenuItem.Click += new System.EventHandler(this.habitacionesMasOcupadasToolStripMenuItem_Click);
            // 
            // clientesConMasPuntosToolStripMenuItem
            // 
            this.clientesConMasPuntosToolStripMenuItem.Name = "clientesConMasPuntosToolStripMenuItem";
            this.clientesConMasPuntosToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.clientesConMasPuntosToolStripMenuItem.Text = "Clientes con mas puntos";
            this.clientesConMasPuntosToolStripMenuItem.Click += new System.EventHandler(this.clientesConMasPuntosToolStripMenuItem_Click);
            // 
            // mayorFacturacionDeConsumiblesToolStripMenuItem
            // 
            this.mayorFacturacionDeConsumiblesToolStripMenuItem.Name = "mayorFacturacionDeConsumiblesToolStripMenuItem";
            this.mayorFacturacionDeConsumiblesToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.mayorFacturacionDeConsumiblesToolStripMenuItem.Text = "Mayor facturacion de consumibles";
            this.mayorFacturacionDeConsumiblesToolStripMenuItem.Click += new System.EventHandler(this.mayorFacturacionDeConsumiblesToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(97, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(999, 108);
            this.label1.TabIndex = 2;
            this.label1.Text = "FRBA-HOTEL System";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(1055, 476);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(84, 32);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Location = new System.Drawing.Point(72, 476);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(84, 32);
            this.btnVolver.TabIndex = 4;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // VistaSistema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1179, 547);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "VistaSistema";
            this.Text = "Menu principal";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem stripReserva;
        private System.Windows.Forms.ToolStripMenuItem generarReservaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarReservaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelarReservaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stripUsuario;
        private System.Windows.Forms.ToolStripMenuItem administrarUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarMiContraseñaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stripRol;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ToolStripMenuItem administrarRolesToolStripMenuItem;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.ToolStripMenuItem stripHotel;
        private System.Windows.Forms.ToolStripMenuItem crearHotelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarHotelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bajaHotelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stripHabitacion;
        private System.Windows.Forms.ToolStripMenuItem crearHabitacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bajaDeHabitacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarHabitacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stripFacturar;
        private System.Windows.Forms.ToolStripMenuItem stripListado;
        private System.Windows.Forms.ToolStripMenuItem masTiempoFueraDeServiicoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem masReservasCanceladasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem habitacionesMasOcupadasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesConMasPuntosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mayorFacturacionDeConsumiblesToolStripMenuItem;
    }
}