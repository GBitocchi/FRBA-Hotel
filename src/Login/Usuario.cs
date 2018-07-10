using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaHotel.Menu_Sistema;
using System.Media;
using System.Security.Cryptography;

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
            lblBloqMayus.Visible = false;
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

        private byte[] encryptPassword(string password)
        {
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding encoder = Encoding.UTF8;
                return hash.ComputeHash(encoder.GetBytes(password));
            }
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
                SystemSounds.Exclamation.Play();
            }
            else if (txtPW.Text == "")
            {
                progressBar1.Visible = false;
                lblErrorPW.Visible = true;
                SystemSounds.Exclamation.Play();
            }
            else if (txtUser.Text == "")
            {
                progressBar1.Visible = false;
                lblErrorUser.Visible = true;
                SystemSounds.Exclamation.Play();
            }
            else
            {
                try
                {
                    progressBar1.PerformStep();

                    string autentificacion = string.Format("SELECT usur_id, usur_username, usur_intentos, usur_password, usur_habilitado FROM CAIA_UNLIMITED.Usuario WHERE usur_username = '{0}'", txtUser.Text.Trim());

                    SqlConnection autentificacionConnection = DataBase.conectarBD();

                    DataSet dsAutentificacion = new DataSet();

                    SqlDataAdapter dpAutentificacion = new SqlDataAdapter(autentificacion, autentificacionConnection);

                    SqlCommandBuilder builder = new SqlCommandBuilder(dpAutentificacion);

                    dpAutentificacion.Fill(dsAutentificacion);

                    progressBar1.PerformStep();

                    if (dsAutentificacion != null && dsAutentificacion.Tables.Count > 0 && dsAutentificacion.Tables[0].Rows.Count > 0)
                    {
                        byte[] passwordInDataBase = (byte[])(dsAutentificacion.Tables[0].Rows[0]["usur_password"]);
                        byte[] passwordEncrypted = encryptPassword(txtPW.Text.Trim());
                        MemoryStream ms = new MemoryStream(passwordInDataBase);

                        if ((passwordEncrypted.SequenceEqual(passwordInDataBase)) && ((bool)dsAutentificacion.Tables[0].Rows[0]["usur_habilitado"]))
                        {
                            dsAutentificacion.Tables[0].Rows[0]["usur_intentos"] = 0;
                            dpAutentificacion.UpdateCommand = builder.GetUpdateCommand();
                            dpAutentificacion.Update(dsAutentificacion.Tables[0]);
                            dsAutentificacion.Tables[0].AcceptChanges();
                            autentificacionConnection.Close();
                            
                            string hotelesUser = string.Format("SELECT h.hote_id as Hotel, h.hote_nombre as HotelNombre,CONCAT(d.dire_dom_calle,'-',d.dire_nro_calle) as HotelCompuesto FROM CAIA_UNLIMITED.Usuario u JOIN CAIA_UNLIMITED.Usuario_X_Hotel uh on u.usur_id = uh.usur_hote_idusur JOIN CAIA_UNLIMITED.Hotel h on h.hote_id = uh.usur_hote_idhote INNER JOIN CAIA_UNLIMITED.Direccion d on (h.dire_id = d.dire_id) WHERE u.usur_username = '{0}'", txtUser.Text.Trim());
                            DataSet dsHotelesUser = DataBase.realizarConsulta(hotelesUser);
                            string rolesUser = string.Format("SELECT r.rol_codigo as Rol, r.rol_nombre as RolNombre FROM CAIA_UNLIMITED.Rol r JOIN CAIA_UNLIMITED.Rol_X_Usuario ru on ru.rol_usur_codigo = r.rol_codigo JOIN CAIA_UNLIMITED.Usuario u on u.usur_id = ru.rol_usur_id WHERE u.usur_username = '{0}' AND r.rol_estado = 1 ", txtUser.Text.Trim());
                            DataSet dsRolesUser = DataBase.realizarConsulta(rolesUser);

                            progressBar1.PerformStep();
                            progressBar1.Visible = false;

                            this.Hide();

                            if ((dsHotelesUser == null || dsHotelesUser.Tables.Count <= 0 || dsHotelesUser.Tables[0].Rows.Count <= 0) || (dsRolesUser == null || dsRolesUser.Tables.Count <= 0 || dsRolesUser.Tables[0].Rows.Count <= 0))
                            {
                                MessageBox.Show("El usuario no tiene asignado ningun hotel o rol que este habilitado. Contacte con el administrador");
                                new Usuario().Show();
                            }
                            else if (dsHotelesUser != null && dsHotelesUser.Tables.Count > 0 && (dsHotelesUser.Tables[0].Rows.Count) > 1)
                            {
                                new Seleccion(dsHotelesUser, dsRolesUser, txtUser.Text.Trim()).Show();
                            }
                            else
                            {

                                if (dsRolesUser != null && dsRolesUser.Tables.Count > 0 && (dsRolesUser.Tables[0].Rows.Count) > 1)
                                {
                                    new Seleccion(dsRolesUser, (decimal)dsHotelesUser.Tables[0].Rows[0]["Hotel"], txtUser.Text.Trim()).Show();
                                }
                                else
                                {
                                    new VistaSistema((decimal)dsHotelesUser.Tables[0].Rows[0]["Hotel"], (decimal)dsRolesUser.Tables[0].Rows[0]["Rol"],txtUser.Text.Trim()).Show();
                                }
                            }
                        }
                        else if (((bool)dsAutentificacion.Tables[0].Rows[0]["usur_habilitado"]) == false)
                        {
                            autentificacionConnection.Close();
                            progressBar1.PerformStep();
                            progressBar1.Visible = false;                          
                            SystemSounds.Hand.Play();
                            MessageBox.Show("Se ha inhabilitado al usuario " + txtUser.Text.Trim() + ". Contacte con el administrador.");
                            txtPW.Clear();
                            txtUser.Clear();
                        }
                        else if (((passwordEncrypted.SequenceEqual(passwordInDataBase)) == false))
                        {
                            decimal intentos = (decimal)dsAutentificacion.Tables[0].Rows[0]["usur_intentos"];
                            intentos++;

                            progressBar1.PerformStep();
                            progressBar1.Visible = false;

                            if (intentos >= 3)
                            {
                                dsAutentificacion.Tables[0].Rows[0]["usur_intentos"] = intentos;
                                dsAutentificacion.Tables[0].Rows[0]["usur_habilitado"] = false;
                                MessageBox.Show("Se ha inhabilitado al usuario " + txtUser.Text.Trim() + " por muchos intentos de inicio de sesion. Contacte con el administrador.");
                            }
                            else
                            {
                                dsAutentificacion.Tables[0].Rows[0]["usur_intentos"] = intentos;
                            }

                            dpAutentificacion.UpdateCommand = builder.GetUpdateCommand();
                            dpAutentificacion.Update(dsAutentificacion.Tables[0]);
                            dsAutentificacion.Tables[0].AcceptChanges();
                            autentificacionConnection.Close();
                            txtPW.Clear();
                            txtUser.Clear();
                            SystemSounds.Beep.Play();
                            lblErrorAutentificacion.Visible = true;
                        }
                    }
                    else
                    {
                        autentificacionConnection.Close();
                        progressBar1.PerformStep();
                        progressBar1.Visible = false;
                        txtPW.Clear();
                        txtUser.Clear();
                        SystemSounds.Hand.Play();
                        lblErrorAutentificacion.Visible = true;
                    }
                }
                catch (Exception errorDB)
                {
                    progressBar1.Visible = false;
                    txtPW.Clear();
                    txtUser.Clear();
                    SystemSounds.Hand.Play();
                    MessageBox.Show(errorDB.Message);
                }
            }
        }

        private void txtPW_TextChanged(object sender, EventArgs e)
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                lblBloqMayus.Visible = true;
            }
            else
            {
                lblBloqMayus.Visible = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
