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
using FrbaHotel.Menu_Sistema;

namespace FrbaHotel.Login
{
    public partial class Seleccion : Form
    {
        String nombreUsuario;
        DataSet dsHotelesUser;
        DataSet dsRolesUser;
        decimal idHotel;
        decimal rolCodigo;

        private void CargarRoles()
        {
            cbRoles.Items.Clear();
            foreach (DataRow unRol in this.dsRolesUser.Tables[0].Rows)
            {
                cbRoles.Items.Add((string)unRol["RolNombre"]);
            }
            if (cbRoles.Items.Count > 0)
            {
                cbRoles.SelectedIndex = 0;
            }
            cbRoles.Visible = true;
        }

        private void CargarHoteles()
        {
            cbHoteles.Items.Clear();
            foreach (DataRow unHotel in this.dsHotelesUser.Tables[0].Rows)
            {
                cbHoteles.Items.Add(Convert.ToString((decimal)unHotel["Hotel"]));
            }
            if (cbHoteles.Items.Count > 0)
            {
                cbHoteles.SelectedIndex = 0;
            }
            cbHoteles.Visible = true;                      
        }
       

        public Seleccion(DataSet _dsHotelesUser, DataSet _dsRolesUser, String _nombreUsuario)
        {           
            InitializeComponent();
            this.nombreUsuario = _nombreUsuario;
            lblWelcome.Text = "Bienvenido " + this.nombreUsuario;
            this.dsHotelesUser = _dsHotelesUser;
            this.dsRolesUser = _dsRolesUser;
            this.nombreUsuario = _nombreUsuario;
            CargarHoteles();
            
            if ((this.dsRolesUser.Tables[0].Rows.Count) > 1)
            {
                CargarRoles();       
            }
            else
            {
                lblRolSeleccion.Visible = false;
                cbRoles.Visible = false;
                this.rolCodigo = (decimal)this.dsRolesUser.Tables[0].Rows[0]["Rol"];
            }
        }

        public Seleccion(DataSet _dsRolesUser, decimal _idHotel, String _nombreUsuario)
        {
            InitializeComponent();
            this.nombreUsuario = _nombreUsuario;
            lblWelcome.Text = "Bienvenido " + this.nombreUsuario;
            lblHotelSeleccion.Visible = false;
            cbHoteles.Visible = false;
            this.dsRolesUser = _dsRolesUser;
            this.dsHotelesUser = null;
            this.idHotel = _idHotel;
            this.nombreUsuario = _nombreUsuario;
            CargarRoles();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.dsHotelesUser != null)
            {
                this.idHotel = Convert.ToDecimal(cbHoteles.Text);

                if ((this.dsRolesUser.Tables[0].Rows.Count) > 1)
                {
                    this.rolCodigo = Convert.ToDecimal(cbRoles.Text);
                }
            }
            else
            {
                this.rolCodigo = Convert.ToDecimal(cbRoles.Text);
            }

            this.Hide();
            new VistaSistema(this.idHotel,this.rolCodigo).Show();
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
