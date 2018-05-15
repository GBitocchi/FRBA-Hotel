using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.Login
{
    public partial class Inicio : Form
    {
        public Inicio()
        {         
            InitializeComponent();
            lblErrorBD.Visible = false;

            try
            {
                DataBase.conectarBD();
            }
            catch (Exception e)
            {
                lblErrorBD.Visible = true;
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Usuario().Show();
        }

        private void btnGuest_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Huesped().Show();
        }
    }
}
