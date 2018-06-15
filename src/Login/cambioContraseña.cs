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
    public partial class cambioContraseña : Form
    {
        String nombreUsuario;
        
        public cambioContraseña(String _nombreUsuario)
        {
            InitializeComponent();
            lblErrorNoConfirmPW.Visible = false;
            lblErrorNoNewPW.Visible = false;
            lblErrorNoCurrentPW.Visible = false;
            lblErrorPWsNoCoincidence.Visible = false;
            lblErrorWrongPW.Visible = false;
            this.nombreUsuario = _nombreUsuario;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lblErrorNoConfirmPW.Visible = false;
            lblErrorNoNewPW.Visible = false;
            lblErrorNoCurrentPW.Visible = false;
            lblErrorPWsNoCoincidence.Visible = false;
            lblErrorWrongPW.Visible = false;

            if (txtCurrentPW.Text == "")
            {
                lblErrorNoCurrentPW.Visible = true;
            }
            else if (txtNewPW.Text == "")
            {
                lblErrorNoNewPW.Visible = true;
            }
            else if (txtReEntryNewPW.Text == "")
            {
                lblErrorNoConfirmPW.Visible = true;
            }
            else if (txtReEntryNewPW.Text != txtNewPW.Text)
            {
                lblErrorPWsNoCoincidence.Visible = true;
            }
            else
            {
                try
                {
                    string queryChangePW = "UPDATE CAIA_UNLIMITED.Usuario SET usur_password='" + txtNewPW + "' where usur_username = '" + this.nombreUsuario + "' AND usur_password='" + txtCurrentPW + "'";
                    DataBase.procedureBD(queryChangePW);
                    MessageBox.Show("Cambio de contraseña realizado exitosamente!");
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception error)
                {                     
                    lblErrorWrongPW.Visible = true;
                }
            }                 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}
