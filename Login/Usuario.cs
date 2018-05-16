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
                string autentificacion = string.Format("SELECT usur_password, usur_intentos, usur_habilitado, rol_nombre FROM CAIA_UNLIMITED.Rol INNER JOIN CAIA_UNLIMITED.Rol_X_Usuario on rol_usur_codigo = rol_codigo INNER JOIN CAIA_UNLIMITED.Usuario on usur_username = rol_usur_codigo WHERE usur_username = '{0}' AND rol_estado = 1",txtUser.Text.Trim());

                DataSet dsAutentificacion = DataBase.realizarConsulta(autentificacion);

                if (dsAutentificacion.Tables[0].Rows.Count != 0 && ((dsAutentificacion.Tables[0].Rows[0]["usur_password"].ToString().Trim()) == txtPW.Text.Trim()))
                {
                    dsAutentificacion.Tables[0].Rows[0]["usur_intentos"] = 0;
                    dsAutentificacion.Tables[0].AcceptChanges();
                    
                    List<String> listaRoles = new List<string>();

                    for (int i = 0; i < dsAutentificacion.Tables[0].Rows.Count; i++)
                    {             
                        if((dsAutentificacion.Tables[0].Rows[i]["rol_nombre"])!= null){
                            listaRoles.Add(dsAutentificacion.Tables[0].Rows[i]["rol_nombre"].ToString().Trim());
                        }                     
                    }

                    if (listaRoles.Count >= 2)
                    {
                        this.Hide();
                        new SeleccionRol(listaRoles).Show();
                    }
                    else
                    {
                        this.Hide();
                        new VistaSistema().Show();
                    }                      
                }
                else if ((dsAutentificacion.Tables[0].Rows[0]["usur_password"].ToString().Trim()) != txtPW.Text.Trim())
                {               
                    int intentos = (int)dsAutentificacion.Tables[0].Rows[0]["usur_intentos"];

                    if (intentos == 3)
                    {
                        dsAutentificacion.Tables[0].Rows[0]["usur_habilitado"] = 0;
                        dsAutentificacion.Tables[0].AcceptChanges();
                    }
                    else
                    {
                        intentos++;
                        dsAutentificacion.Tables[0].Rows[0]["usur_intentos"] = intentos;
                        dsAutentificacion.Tables[0].AcceptChanges();
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
