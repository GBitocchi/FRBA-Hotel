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
            lblErrorAutentificacion.Visible = false;
            lblErrorUser.Visible = false;
            lblErrorPW.Visible = false;
            
            if (txtUser.Text == "" && txtPW.Text == "")
            {
                lblErrorUser.Visible = true;
                lblErrorPW.Visible = true;
            }
            else if (txtPW.Text == "")
            {
                lblErrorPW.Visible = true;
            }
            else if (txtUser.Text == "")
            {
                lblErrorUser.Visible = true;
            }
            else
            {         
                string autentificacion = string.Format("SELECT u.usur_password, u.usur_intentos, u.usur_habilitado, r.rol_nombre, h.hote_nombre FROM CAIA_UNLIMITED.Rol r INNER JOIN CAIA_UNLIMITED.Rol_X_Usuario ru on ru.rol_codigo = r.rol_codigo INNER JOIN CAIA_UNLIMITED.Usuario u on u.usur_username = ru.usur_username INNER JOIN CAIA_UNLIMITED.Usuario_X_Hotel uh on u.usur_username = uh.usur_username INNER JOIN CAIA_UNLIMITED.Hotel h on h.hote_id = uh.hote_id WHERE u.usur_username = '{0}' AND r.rol_estado = 1",txtUser.Text.Trim());

                DataSet dsAutentificacion = DataBase.realizarConsulta(autentificacion);

                if (dsAutentificacion.Tables["CAIA_UNLIMITED.Usuario"].Rows.Count != 0 && ((dsAutentificacion.Tables["CAIA_UNLIMITED.Usuario"].Rows[0]["u.usur_password"].ToString().Trim()) == txtPW.Text.Trim()) && (((int)dsAutentificacion.Tables["CAIA_UNLIMITED.Usuario"].Rows[0]["u.usur_intentos"])!=3))
                {
                    dsAutentificacion.Tables["CAIA_UNLIMITED.Usuario"].Rows[0]["u.usur_intentos"] = 0;
                    dsAutentificacion.Tables["CAIA_UNLIMITED.Usuario"].AcceptChanges();

                    if ((dsAutentificacion.Tables["CAIA_UNLIMITED.Hotel"].Rows.Count) > 1)
                    {
                        this.Hide();
                        new Seleccion(dsAutentificacion).Show();
                    }
                    else
                    {
                        if ((dsAutentificacion.Tables["CAIA_UNLIMITED.Rol"].Rows.Count) > 1)
                        {
                            this.Hide();
                            new Seleccion(dsAutentificacion).Show();
                        }
                        else
                        {
                            this.Hide();
                            new VistaSistema().Show();
                        }
                    }                                                   
                }
                else if ((dsAutentificacion.Tables["CAIA_UNLIMITED.Usuario"].Rows[0]["u.usur_password"].ToString().Trim()) != txtPW.Text.Trim())
                {
                    int intentos = (int)dsAutentificacion.Tables["CAIA_UNLIMITED.Usuario"].Rows[0]["u.usur_intentos"];

                    if (intentos == 3)
                    {                      
                        dsAutentificacion.Tables["CAIA_UNLIMITED.Usuario"].Rows[0]["u.usur_habilitado"] = 0;
                        dsAutentificacion.Tables["CAIA_UNLIMITED.Usuario"].AcceptChanges();
                        MessageBox.Show("Se ha inhabilitado al usuario " +txtUser.Text.Trim()+" por muchos intentos de inicio de sesion. Contacte con el administrador.");
                    }
                    else
                    {
                        intentos++;
                        dsAutentificacion.Tables["CAIA_UNLIMITED.Usuario"].Rows[0]["u.usur_intentos"] = intentos;
                        dsAutentificacion.Tables["CAIA_UNLIMITED.Usuario"].AcceptChanges();
                    }
                    
                    lblErrorAutentificacion.Visible = true;  
                }
                else
                {                                       
                    lblErrorAutentificacion.Visible = true;                                    
                }
                            
            }
        }

        private void txtPW_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
