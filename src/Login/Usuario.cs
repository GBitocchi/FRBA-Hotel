using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaHotel.Menu_Sistema;

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
            progressBar1.Visible = false;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Step = 25;
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
            
            progressBar1.Visible = true;
            progressBar1.PerformStep();
            
            if (txtUser.Text == "" && txtPW.Text == "")
            {
                progressBar1.Visible = false;
                lblErrorUser.Visible = true;
                lblErrorPW.Visible = true;
            }
            else if (txtPW.Text == "")
            {
                progressBar1.Visible = false;
                lblErrorPW.Visible = true;
            }
            else if (txtUser.Text == "")
            {
                progressBar1.Visible = false;
                lblErrorUser.Visible = true;
            }
            else
            {
                try
                {
                    progressBar1.PerformStep();
                    
                    string autentificacion = string.Format("SELECT usur_password, usur_intentos, usur_habilitado FROM CAIA_UNLIMITED.Usuario WHERE usur_username = '{0}'", txtUser.Text.Trim());

                    SqlConnection autentificacionConnection = DataBase.conectarBD();

                    DataSet dsAutentificacion = new DataSet();

                    SqlDataAdapter dpAutentificacion = new SqlDataAdapter(autentificacion, autentificacionConnection);

                    dpAutentificacion.Fill(dsAutentificacion);

                    progressBar1.PerformStep();

                    if (dsAutentificacion.Tables["CAIA_UNLIMITED.Usuario"].Rows.Count != 0 && ((dsAutentificacion.Tables["CAIA_UNLIMITED.Usuario"].Rows[0]["usur_password"].ToString().Trim()) == txtPW.Text.Trim()) && (((int)dsAutentificacion.Tables["CAIA_UNLIMITED.Usuario"].Rows[0]["usur_habilitado"]) != 0))
                    {
                        dsAutentificacion.Tables["CAIA_UNLIMITED.Usuario"].Rows[0]["usur_intentos"] = 0;
                        dpAutentificacion.Update(dsAutentificacion.Tables["CAIA_UNLIMITED.Usuario"]);
                        dsAutentificacion.Tables["CAIA_UNLIMITED.Usuario"].AcceptChanges();
                        autentificacionConnection.Close();

                        string propiedadesUser = string.Format("SELECT r.rol_nombre, r.rol_estado,h.hote_nombre FROM CAIA_UNLIMITED.Rol r INNER JOIN CAIA_UNLIMITED.Rol_X_Usuario ru on ru.rol_codigo = r.rol_codigo INNER JOIN CAIA_UNLIMITED.Usuario u on u.usur_username = ru.usur_username INNER JOIN CAIA_UNLIMITED.Usuario_X_Hotel uh on u.usur_username = uh.usur_username INNER JOIN CAIA_UNLIMITED.Hotel h on h.hote_id = uh.hote_id WHERE u.usur_username = '{0}'", txtUser.Text.Trim());

                        SqlConnection propiedadesUserConnection = DataBase.conectarBD();

                        DataSet dsPropiedadesUser = new DataSet();

                        SqlDataAdapter dpPropiedadesUser = new SqlDataAdapter(propiedadesUser, propiedadesUserConnection);

                        dpPropiedadesUser.Fill(dsPropiedadesUser);

                        progressBar1.PerformStep();
                        progressBar1.Visible = false;

                        this.Hide();           

                        if ((dsPropiedadesUser.Tables["CAIA_UNLIMITED.Hotel"].Rows.Count) > 1)
                        {
                            new Seleccion(dsPropiedadesUser, propiedadesUserConnection, dpPropiedadesUser, txtUser.Text.Trim()).Show();
                        }
                        else
                        {
                            if ((dsPropiedadesUser.Tables["CAIA_UNLIMITED.Rol"].Rows.Count) > 1)
                            {
                                new Seleccion(dsPropiedadesUser, propiedadesUserConnection, dpPropiedadesUser, txtUser.Text.Trim()).Show();
                            }
                            else
                            {
                                new VistaSistema().Show();
                            }
                        }
                    }
                    else if (dsAutentificacion.Tables["CAIA_UNLIMITED.Usuario"].Rows.Count != 0 && (((int)dsAutentificacion.Tables["CAIA_UNLIMITED.Usuario"].Rows[0]["usur_habilitado"]) == 0))
                    {
                        autentificacionConnection.Close();
                        progressBar1.PerformStep();
                        progressBar1.Visible = false;
                        MessageBox.Show("Se ha inhabilitado al usuario " + txtUser.Text.Trim() + " por muchos intentos de inicio de sesion. Contacte con el administrador.");
                    }
                    else if ((dsAutentificacion.Tables["CAIA_UNLIMITED.Usuario"].Rows.Count != 0 && (dsAutentificacion.Tables["CAIA_UNLIMITED.Usuario"].Rows[0]["usur_password"].ToString().Trim()) != txtPW.Text.Trim()))
                    {
                        int intentos = (int)dsAutentificacion.Tables["CAIA_UNLIMITED.Usuario"].Rows[0]["usur_intentos"];
                        intentos++;

                        progressBar1.PerformStep();
                        progressBar1.Visible = false;

                        if (intentos == 3)
                        {
                            dsAutentificacion.Tables["CAIA_UNLIMITED.Usuario"].Rows[0]["usur_habilitado"] = 0;
                            MessageBox.Show("Se ha inhabilitado al usuario " + txtUser.Text.Trim() + " por muchos intentos de inicio de sesion. Contacte con el administrador.");
                        }
                        else
                        {
                            dsAutentificacion.Tables["CAIA_UNLIMITED.Usuario"].Rows[0]["usur_intentos"] = intentos;
                        }

                        dpAutentificacion.Update(dsAutentificacion.Tables["CAIA_UNLIMITED.Usuario"]);
                        dsAutentificacion.Tables["CAIA_UNLIMITED.Usuario"].AcceptChanges();
                        autentificacionConnection.Close();
                        lblErrorAutentificacion.Visible = true;
                    }
                    else
                    {
                        autentificacionConnection.Close();
                        progressBar1.PerformStep();
                        progressBar1.Visible = false;
                        lblErrorAutentificacion.Visible = true;
                    }
                }
                catch (Exception errorDB)
                {
                    progressBar1.Visible = false;
                    MessageBox.Show(errorDB.Message);
                }
            }
        }

        private void txtPW_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
