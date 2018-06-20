using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Security.Cryptography;

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
            lblBloqMayusActivated.Visible = false;
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
                SystemSounds.Hand.Play();
            }
            else if (txtNewPW.Text == "")
            {
                lblErrorNoNewPW.Visible = true;
                SystemSounds.Hand.Play();
            }
            else if (txtReEntryNewPW.Text == "")
            {
                lblErrorNoConfirmPW.Visible = true;
                SystemSounds.Hand.Play();
            }
            else if (txtReEntryNewPW.Text != txtNewPW.Text)
            {
                lblErrorPWsNoCoincidence.Visible = true;
                SystemSounds.Hand.Play();
            }
            else
            {
                try
                {
                    string queryChangePW = string.Format("UPDATE CAIA_UNLIMITED.Usuario SET usur_password = HASHBYTES('SHA2_256', '{0}') WHERE usur_username = '{1}' AND usur_password = HASHBYTES('SHA2_256', '{2}')", txtNewPW.Text.Trim(), this.nombreUsuario, txtCurrentPW.Text.Trim());
                    DataBase.procedureBD(queryChangePW);
                    MessageBox.Show("Cambio de contraseña realizado exitosamente!");
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception error)
                {
                    txtCurrentPW.Clear();
                    txtNewPW.Clear();
                    txtReEntryNewPW.Clear();
                    lblErrorWrongPW.Visible = true;
                    SystemSounds.Beep.Play();
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

        private void txtCurrentPW_TextChanged(object sender, EventArgs e)
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                lblBloqMayusActivated.Visible = true;
            }
            else
            {
                lblBloqMayusActivated.Visible = false;
            }
        }

        private void txtNewPW_TextChanged(object sender, EventArgs e)
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                lblBloqMayusActivated.Visible = true;
            }
            else
            {
                lblBloqMayusActivated.Visible = false;
            }
        }

        private void txtReEntryNewPW_TextChanged(object sender, EventArgs e)
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                lblBloqMayusActivated.Visible = true;
            }
            else
            {
                lblBloqMayusActivated.Visible = false;
            }
        }
    }
}
