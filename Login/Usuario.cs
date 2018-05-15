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
    public partial class Usuario : Form
    {
        public Usuario()
        {
            InitializeComponent();
            lblErrorAutentificacion.Visible = false;
            lblErrorUser.Visible = false;
            lblErrorPW.Visible = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Inicio().Show();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "" && txtPW.Text == "")
            {
                lblErrorUser.Visible = true;
                lblErrorPW.Visible = true;
            }
            else if (txtPW.Text == "")
            {
                lblErrorUser.Visible = false;
                lblErrorPW.Visible = true;
            }
            else if (txtUser.Text == "")
            {
                lblErrorUser.Visible = true;
                lblErrorPW.Visible = false;
            }
            else
            {
                lblErrorUser.Visible = false;
                lblErrorPW.Visible = false;

                try
                {
                    string autentificacion = string.Format("SELECT usur_username, usur_password FROM CAIA_UNLIMITED.Usuario WHERE usur_name = '{0}' AND usur_password = '{1}'", txtUser.Text.Trim(), txtPW.Text.Trim());

                    DataSet ds = DataBase.realizarConsulta(autentificacion);

                    string account = ds.Tables[0].Rows[0]["usur_username"].ToString().Trim();
                    string password = ds.Tables[0].Rows[0]["usur_password"].ToString().Trim();

                    if (account == txtUser.Text.Trim() && password == txtPW.Text.Trim())
                    {
                        
                    }
                }
                catch (Exception error)
                {
                    lblErrorAutentificacion.Visible = true;
                }
            }
        }
    }
}
