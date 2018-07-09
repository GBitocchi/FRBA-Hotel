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
            this.stripEstadia = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stripCancelar_Reserva = new System.Windows.Forms.ToolStripMenuItem();
            this.stripReserva = new System.Windows.Forms.ToolStripMenuItem();
            this.generarReservaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarReservaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.stripHuesped = new System.Windows.Forms.ToolStripMenuItem();
            this.crearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stripConsumibles = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.stripListado = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.Fecha = new System.Windows.Forms.Label();
            this.txtFechaSistema = new System.Windows.Forms.TextBox();
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
            this.stripEstadia,
            this.stripCancelar_Reserva,
            this.stripReserva,
            this.stripUsuario,
            this.stripRol,
            this.stripHotel,
            this.stripHabitacion,
            this.stripFacturar,
            this.stripHuesped,
            this.stripConsumibles,
            this.stripListado});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1179, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // stripEstadia
            // 
            this.stripEstadia.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarToolStripMenuItem});
            this.stripEstadia.Name = "stripEstadia";
            this.stripEstadia.Size = new System.Drawing.Size(56, 20);
            this.stripEstadia.Text = "Estadia";
            this.stripEstadia.Visible = false;
            // 
            // registrarToolStripMenuItem
            // 
            this.registrarToolStripMenuItem.Name = "registrarToolStripMenuItem";
            this.registrarToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.registrarToolStripMenuItem.Text = "Registrar";
            this.registrarToolStripMenuItem.Click += new System.EventHandler(this.registrarToolStripMenuItem_Click);
            // 
            // stripCancelar_Reserva
            // 
            this.stripCancelar_Reserva.Name = "stripCancelar_Reserva";
            this.stripCancelar_Reserva.Size = new System.Drawing.Size(105, 20);
            this.stripCancelar_Reserva.Text = "Cancelar reserva";
            this.stripCancelar_Reserva.Visible = false;
            this.stripCancelar_Reserva.Click += new System.EventHandler(this.stripCancelar_Reserva_Click);
            // 
            // stripReserva
            // 
            this.stripReserva.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generarReservaToolStripMenuItem,
            this.modificarReservaToolStripMenuItem});
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
            // stripHuesped
            // 
            this.stripHuesped.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearToolStripMenuItem,
            this.modificarToolStripMenuItem});
            this.stripHuesped.Name = "stripHuesped";
            this.stripHuesped.Size = new System.Drawing.Size(66, 20);
            this.stripHuesped.Text = "Huesped";
            this.stripHuesped.Visible = false;
            // 
            // crearToolStripMenuItem
            // 
            this.crearToolStripMenuItem.Name = "crearToolStripMenuItem";
            this.crearToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.crearToolStripMenuItem.Text = "Crear";
            this.crearToolStripMenuItem.Click += new System.EventHandler(this.crearToolStripMenuItem_Click);
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.modificarToolStripMenuItem.Text = "Modificar";
            this.modificarToolStripMenuItem.Click += new System.EventHandler(this.modificarToolStripMenuItem_Click);
            // 
            // stripConsumibles
            // 
            this.stripConsumibles.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarToolStripMenuItem1});
            this.stripConsumibles.Name = "stripConsumibles";
            this.stripConsumibles.Size = new System.Drawing.Size(88, 20);
            this.stripConsumibles.Text = "Consumibles";
            this.stripConsumibles.Visible = false;
            // 
            // registrarToolStripMenuItem1
            // 
            this.registrarToolStripMenuItem1.Name = "registrarToolStripMenuItem1";
            this.registrarToolStripMenuItem1.Size = new System.Drawing.Size(120, 22);
            this.registrarToolStripMenuItem1.Text = "Registrar";
            this.registrarToolStripMenuItem1.Click += new System.EventHandler(this.registrarToolStripMenuItem1_Click);
            // 
            // stripListado
            // 
            this.stripListado.Name = "stripListado";
            this.stripListado.Size = new System.Drawing.Size(116, 20);
            this.stripListado.Text = "Listado estadistico";
            this.stripListado.Visible = false;
            this.stripListado.Click += new System.EventHandler(this.stripListado_Click);
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
            // Fecha
            // 
            this.Fecha.AutoSize = true;
            this.Fecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fecha.Location = new System.Drawing.Point(468, 476);
            this.Fecha.Name = "Fecha";
            this.Fecha.Size = new System.Drawing.Size(54, 20);
            this.Fecha.TabIndex = 5;
            this.Fecha.Text = "Fecha";
            // 
            // txtFechaSistema
            // 
            this.txtFechaSistema.Enabled = false;
            this.txtFechaSistema.Location = new System.Drawing.Point(539, 476);
            this.txtFechaSistema.Name = "txtFechaSistema";
            this.txtFechaSistema.Size = new System.Drawing.Size(183, 20);
            this.txtFechaSistema.TabIndex = 6;
            // 
            // VistaSistema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1179, 547);
            this.Controls.Add(this.txtFechaSistema);
            this.Controls.Add(this.Fecha);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "VistaSistema";
            this.Text = "Menu principal";
            this.Load += new System.EventHandler(this.VistaSistema_Load);
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
        private System.Windows.Forms.ToolStripMenuItem stripHuesped;
        private System.Windows.Forms.ToolStripMenuItem crearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stripEstadia;
        private System.Windows.Forms.ToolStripMenuItem registrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stripConsumibles;
        private System.Windows.Forms.ToolStripMenuItem registrarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem stripCancelar_Reserva;
        private System.Windows.Forms.Label Fecha;
        private System.Windows.Forms.TextBox txtFechaSistema;
        private System.Windows.Forms.ToolStripMenuItem stripListado;
    }
}