using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.Login
{
    public partial class Seleccion : Form
    {
        String nombreUsuario;
        DataSet dsPropiedadesUser;
        SqlConnection propiedadesUserConnection;
        SqlDataAdapter dpPropiedadesUser;

        public Seleccion(DataSet _dsPropiedadesUser, SqlConnection _propiedadesUserConnection, SqlDataAdapter _dpPropiedadesUser, String _nombreUsuario)
        {           
            InitializeComponent();
            this.nombreUsuario = _nombreUsuario;
            lblWelcome.Text = "Bienvenido " + this.nombreUsuario;
            lblErrorHotel.Visible = false;
            lblErrorRol.Visible = false;
            this.dsPropiedadesUser = _dsPropiedadesUser;
            this.propiedadesUserConnection = _propiedadesUserConnection;
            this.dpPropiedadesUser = _dpPropiedadesUser;          
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

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

        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new cambioContraseña(this.nombreUsuario).ShowDialog();       
            this.Show();            
        }
    }
}
