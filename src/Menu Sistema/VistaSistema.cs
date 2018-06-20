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
                    stripUsuario.Visible = false;
                }
            }
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
            new VistaRol().ShowDialog();
            this.Show();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Inicio().Show();
        }

        private void reservaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
