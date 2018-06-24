using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaHotel.GenerarModificacionReserva;
using FrbaHotel.Login;
using FrbaHotel.AbmUsuario;
using FrbaHotel.AbmRol;
using FrbaHotel.AbmHotel;
using FrbaHotel.AbmHabitacion;
using FrbaHotel.AbmFacturacion;
using FrbaHotel.ListadoEstadistico;
using FrbaHotel.CancelarReserva;
using FrbaHotel.AbmCliente;
using FrbaHotel.RegistrarConsumible;
using FrbaHotel.RegistrarEstadia;
using System.Data.SqlClient;


namespace FrbaHotel.Menu_Sistema
{
    public partial class VistaSistema : Form
    {
        decimal idHotel;
        decimal codigoRol;
        string nombreUsuario;
        bool guest = false;

        public VistaSistema(decimal _idHotel, decimal _codigoRol, string _nombreUsuario)
        {
            InitializeComponent();
            this.idHotel = _idHotel;
            this.codigoRol = _codigoRol;
            this.nombreUsuario = _nombreUsuario;

            habilitarHoteles();

            string queryFuncionalidadesUsuario = string.Format("SELECT f.func_detalle as Funcionalidades FROM CAIA_UNLIMITED.Funcionalidad f JOIN CAIA_UNLIMITED.Funcionalidad_X_Rol fr on fr.func_rol_codigo_func = f.func_codigo WHERE fr.func_rol_codigo_rol = '{0}'", _codigoRol);
            DataSet dsFuncionalidadesUsuario = DataBase.realizarConsulta(queryFuncionalidadesUsuario);

            foreach (DataRow unaFuncionalidad in dsFuncionalidadesUsuario.Tables[0].Rows)
            {
                if (unaFuncionalidad["Funcionalidades"].ToString() == "RESERVA")
                {
                    stripReserva.Visible = true;
                }
                else if (unaFuncionalidad["Funcionalidades"].ToString() == "ABM_ROL")
                {
                    stripRol.Visible = true;
                }
                else if (unaFuncionalidad["Funcionalidades"].ToString() == "ABM_USUARIO")
                {
                    stripUsuario.Visible = true;
                }
                else if (unaFuncionalidad["Funcionalidades"].ToString() == "ABM_HOTEL")
                {
                    stripHotel.Visible = true;
                }
                else if (unaFuncionalidad["Funcionalidades"].ToString() == "ABM_HABITACION")
                {
                    stripHabitacion.Visible = true;
                }
                else if (unaFuncionalidad["Funcionalidades"].ToString() == "FACTURAR")
                {
                    stripFacturar.Visible = true;
                }
                else if (unaFuncionalidad["Funcionalidades"].ToString() == "LISTADO_ESTADISTICO")
                {
                    stripListado.Visible = true;
                }
                else if (unaFuncionalidad["Funcionalidades"].ToString() == "ABM_CLIENTE")
                {
                    stripHuesped.Visible = true;
                }
                else if (unaFuncionalidad["Funcionalidades"].ToString() == "ESTADIA")
                {
                    stripEstadia.Visible = true;
                }
                else if (unaFuncionalidad["Funcionalidades"].ToString() == "CANCELAR_RESERVA")
                {
                    stripCancelar_Reserva.Visible = true;
                }
                else if (unaFuncionalidad["Funcionalidades"].ToString() == "CONSUMIBLES")
                {
                    stripConsumibles.Visible = true;
                }
            }
        }

        private static void habilitarHoteles()
        {
            SqlConnection db = DataBase.conectarBD();
            SqlCommand altaHoteles = new SqlCommand("CAIA_UNLIMITED.sp_AltaHotel", db);
            altaHoteles.CommandType = CommandType.StoredProcedure;
            altaHoteles.Parameters.AddWithValue("@fecha", DataBase.fechaSistema());
            altaHoteles.ExecuteNonQuery();
            db.Close();
        }

        public VistaSistema()
        {
            InitializeComponent();
            this.guest = true;
            stripReserva.Visible = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void generarReservaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!guest)
            {
                new GenerarReserva(this.idHotel,this.nombreUsuario).ShowDialog();
                this.Show();
            }
            else
            {
                new GenerarReserva().ShowDialog();
                this.Show();
            } 
        }

        private void modificarReservaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!guest)
            {
                new ModificarReserva(this.idHotel,this.nombreUsuario).ShowDialog();
                this.Show();
            }
            else
            {
                new ModificarReserva().ShowDialog();
                this.Show();
            }
        }

        private void administrarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new VistaUsuario(this.idHotel).ShowDialog();
            this.Show();
        }

        private void cambiarMiContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new cambioContraseña(this.nombreUsuario).ShowDialog();
            this.Show();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Usuario().Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void administrarRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new VistaRol(this.idHotel, this.codigoRol, this.nombreUsuario).Show();  
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Inicio().Show();
        }

        private void reservaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void crearHotelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CrearHotel().ShowDialog();
            this.Show();
        }

        private void modificarHotelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FiltrarHotel().ShowDialog();
            this.Show();
        }

        private void bajaHotelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new BajaHotel().ShowDialog();
            this.Show();
        }

        private void crearHabitacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CrearHabitacion(Convert.ToString(idHotel)).ShowDialog();
            this.Show();
        }

        private void bajaDeHabitacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new BajaHabitacion(Convert.ToString(idHotel)).ShowDialog();
            this.Show();
        }

        private void modificarHabitacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new MenuModificacion(Convert.ToString(idHotel)).ShowDialog();
            this.Show();
        }

        private void stripFacturar_Click(object sender, EventArgs e)
        {
            new EstadiasAFacturar(Convert.ToString(idHotel)).ShowDialog();
            this.Show();
        }

        private void masTiempoFueraDeServiicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DataBase.realizarConsulta("select * from CAIA_UNLIMITED.vw_MasMantenimiento").Tables[0].Rows.Count != 0)
            {
                new MasMantenimiento().ShowDialog();
                this.Show();
            }
            else
            {
                this.Hide();
                MessageBox.Show("No hay datos suficientes para realizar el listado", "Datos insuficientes", MessageBoxButtons.OK);
            }
        }

        private void masReservasCanceladasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DataBase.realizarConsulta("select * from CAIA_UNLIMITED.vw_MasCancelada").Tables[0].Rows.Count != 0)
            {
                new MasCanceladas().ShowDialog();
                this.Show();
            }
            else
            {
                this.Hide();
                MessageBox.Show("No hay datos suficientes para realizar el listado", "Datos insuficientes", MessageBoxButtons.OK);
            }
        }

        private void habitacionesMasOcupadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DataBase.realizarConsulta("select * from CAIA_UNLIMITED.vw_MasOcupada").Tables[0].Rows.Count != 0)
            {
                new MasOcupadas().ShowDialog();
                this.Show();
            }
            else
            {
                this.Hide();
                MessageBox.Show("No hay datos suficientes para realizar el listado", "Datos insuficientes", MessageBoxButtons.OK);
            }
            
        }

        private void clientesConMasPuntosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DataBase.realizarConsulta("select * from CAIA_UNLIMITED.vw_MasPuntos").Tables[0].Rows.Count != 0)
            {
                new MasPuntosCliente().ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("No hay datos suficientes para realizar el listado", "Datos insuficientes", MessageBoxButtons.OK);
            }
        }

        private void mayorFacturacionDeConsumiblesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DataBase.realizarConsulta("select * from CAIA_UNLIMITED.vw_MasFacturacion").Tables[0].Rows.Count != 0)
            {
                new MayorFacturacionConsumibles().ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("No hay datos suficientes para realizar el listado", "Datos insuficientes", MessageBoxButtons.OK);
            }
        }

        private void VistaSistema_Load(object sender, EventArgs e)
        {

        }

        private void cancelarReservaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new MenuCancelarReserva().ShowDialog();
            this.Show();
        }

        private void crearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Crear().ShowDialog();
            this.Show();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new MenuModificarYBaja().ShowDialog();
            this.Show();
        }

        private void darDeBajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new MenuModificarYBaja().ShowDialog();
            this.Show();
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new MenuRegistrarEstadia().ShowDialog();
            this.Show();
        }

        private void registrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new MenuRegistrarConsumible().ShowDialog();
            this.Show();
        }

        private void stripCancelar_Reserva_Click(object sender, EventArgs e)
        {
            new MenuCancelarReserva().ShowDialog();
            this.Show();
        }

        
    }
}
