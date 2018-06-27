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
using System.Text.RegularExpressions;

namespace FrbaHotel.AbmCliente
{
    public partial class Modificar : Form
    {
        string nombreAnt, apellidoAnt, dniAnt, tipoAnt, mailAnt, nacimientoAnt, nacionalidadAnt, calleAnt, numeroAnt, pisoAnt, dptoAnt, ciudadAnt, paisAtn, telefonoAnt;
        int estadoAnt;

        public Modificar(string mail, string documento, string tipo)
        {
            InitializeComponent();
            mailAnt = mail;
            dniAnt = documento;
            tipoAnt = tipo;
            string consultaCliente = string.Format("select hues_nombre as 'Nombre', hues_apellido as 'Apellido', hues_documento as'DNI', hues_documento_tipo as 'Tipo', hues_mail as 'E-Mail', hues_nacimiento as 'Fecha de nacimiento', hues_nacionalidad as 'Nacionalidad', dire_dom_calle as 'Calle', dire_nro_calle as 'Nro', dire_piso as 'Piso', dire_dpto as 'Dpto', dire_ciudad as 'Ciudad',dire_pais as 'Pais', dire_telefono as 'Telefono', hues_habilitado as 'Estado' from CAIA_UNLIMITED.Huesped H join CAIA_UNLIMITED.Direccion D on (H.dire_id = D.dire_id) where hues_mail='{0}' and hues_documento='{1}' and hues_documento_tipo='{2}'", mail,documento,tipo); 
            DataTable cliente = DataBase.realizarConsulta(consultaCliente).Tables[0];
            cargarInfo(cliente);
            valoresAnterioresCliente();
        }

       

        private void cargarInfo(DataTable cliente)
        {
            txtNombre.Text = cliente.Rows[0][0].ToString();
            txtApellido.Text = cliente.Rows[0][1].ToString();
            txtDni.Text = cliente.Rows[0][2].ToString();
            txtTipo.Text = cliente.Rows[0][3].ToString();
            txtEmail.Text= cliente.Rows[0][4].ToString();
            txtNacimiento.Text = cliente.Rows[0][5].ToString();
            txtNacionalidad.Text= cliente.Rows[0][6].ToString();
            txtCalle.Text = cliente.Rows[0][7].ToString();
            txtCalle_Nro.Text= cliente.Rows[0][8].ToString();
            txtPiso.Text= cliente.Rows[0][9].ToString();
            txtDpto.Text= cliente.Rows[0][10].ToString();
            txtCiudad.Text= cliente.Rows[0][11].ToString();
            txtPais.Text = cliente.Rows[0][12].ToString();
            txtTelefono.Text= cliente.Rows[0][13].ToString();
            string estado = cliente.Rows[0][14].ToString();
            if (bool.Parse(estado))
            {
                rbtHabilitado.Select();
            }
            else
            {
                rbtInabilitado.Select();
            }
        }

        private void valoresAnterioresCliente()
        {
            nombreAnt =txtNombre.Text;
            apellidoAnt =txtApellido.Text;            
            nacimientoAnt = txtNacimiento.Text;
            nacionalidadAnt = txtNacionalidad.Text;
            calleAnt = txtCalle.Text;
            numeroAnt = txtCalle_Nro.Text;
            pisoAnt = txtPiso.Text;
            dptoAnt = txtDpto.Text;
            ciudadAnt = txtCiudad.Text;
            paisAtn = txtPais.Text;
            telefonoAnt = txtTelefono.Text;
            if (rbtHabilitado.Checked)
            {
                estadoAnt = 1;
            }
            else
            {
                estadoAnt = 0;
            }
        }


        private void ejecutarStoredProcedureModificar() 
        {
            SqlConnection db = DataBase.conectarBD();
            SqlCommand crearCliente = new SqlCommand("CAIA_UNLIMITED.sp_ModificarHuesped", db);
            crearCliente.CommandType = CommandType.StoredProcedure;
            crearCliente.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
            crearCliente.Parameters.AddWithValue("@apellido", txtApellido.Text.Trim());
            crearCliente.Parameters.AddWithValue("@documento", txtDni.Text.Trim());
            crearCliente.Parameters.AddWithValue("@tipo", txtTipo.Text.Trim());
            crearCliente.Parameters.AddWithValue("@mail", txtEmail.Text.Trim());
            if (txtNacimiento.Text.Trim() != "")
            {
                crearCliente.Parameters.AddWithValue("@fecha_nacimiento", DateTime.Parse(txtNacimiento.Text));
            }
            else
            {
                crearCliente.Parameters.AddWithValue("@fecha_nacimiento", txtNacimiento.Text);
            }
            crearCliente.Parameters.AddWithValue("@nacionalidad", txtNacionalidad.Text.Trim());
            crearCliente.Parameters.AddWithValue("@calle", txtCalle.Text.Trim());
            crearCliente.Parameters.AddWithValue("@calle_nro", txtCalle_Nro.Text.Trim());
            if (txtPiso.Text.Trim() == "")
            {
                crearCliente.Parameters.AddWithValue("@piso", DBNull.Value);
            }
            else
            {
                crearCliente.Parameters.AddWithValue("@piso", Convert.ToInt32(txtPiso.Text.Trim()));
            }
            crearCliente.Parameters.AddWithValue("@dpto", txtDpto.Text.Trim());
            crearCliente.Parameters.AddWithValue("@ciudad", txtCiudad.Text.Trim());
            crearCliente.Parameters.AddWithValue("@pais", txtPais.Text.Trim());
            crearCliente.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
            if (rbtHabilitado.Checked)
            {
                crearCliente.Parameters.AddWithValue("@estado", 1);
            }
            else
            {
                crearCliente.Parameters.AddWithValue("@estado", 0);
            }
            crearCliente.Parameters.AddWithValue("@documentoViejo",dniAnt);
            crearCliente.Parameters.AddWithValue("@tipoViejo", tipoAnt);
            crearCliente.Parameters.AddWithValue("@mailViejo", mailAnt);
            
            crearCliente.ExecuteNonQuery();
            db.Close();
        }

        

        private int estadoDelHuesped()
        {
            if (rbtHabilitado.Checked)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private bool estaCompleto()
        {
            if (txtApellido.Text.Trim() == "")
            {
                lblApellido.Visible = true;
                return false;
            }
            if (txtNombre.Text.Trim() == "")
            {
                lblNombre.Visible = true;
                return false;
            }
            if (txtDni.Text.Trim() == "")
            {
                lblIdentificacion.Visible = true;
                return false;
            }
            if (txtTipo.Text.Trim() == "")
            {
                lblTipo.Visible = true;
                return false;
            }
            if (txtEmail.Text.Trim() == "")
            {
                lblMail.Visible = true;
                return false;
            }

            if (txtCalle.Text.Trim() == "")
            {
                lblCalle.Visible = true;
                return false;
            }
            if (txtCalle_Nro.Text.Trim() == "")
            {
                lblNro.Visible = true;
                return false;
            }            
            if (txtNacionalidad.Text.Trim() == "")
            {
                lblNacionalidad.Visible = true;
                return false;
            }
            return true;
            
        }

        private void btnModificar_Cliente_Click(object sender, EventArgs e)
        {
            reestrablecerLabels();
            if (estaCompleto())
            {
                if (camposValidos())
                   {
                    if (formatoMailCorrecto())
                    {
                        if (estadoDelHuesped() != estadoAnt && rbtHabilitado.Checked)
                        {
                            
                                        string email_ingresado = String.Format("SELECT hues_mail, hues_habilitado FROM CAIA_UNLIMITED.Huesped  where hues_mail='{0}'", txtEmail.Text.Trim());
                                        

                                       

                                        if (DataBase.realizarConsulta(email_ingresado).Tables[0].Rows.Count == 0)
                                        {                                           
                                                ejecutarStoredProcedureModificar();
                                                MessageBox.Show("Cliente modificado exitosamente", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                this.Hide();
                                                new MenuModificarYBaja().Show();
                                                                                    }
                                        else
                                        {
                                            MessageBox.Show("El mail ingresado ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    

                        }
                        else /////////////////////////////SI MODIFIQUE SIN CAMBIAR EL ESTADO
                        {
                            if (hayModificaciones())
                            {
                                if (seModificoElMAilDni())
                                {
                                    if (seModificoElDniYMail())
                                    {
                                        string email_ingresado = String.Format("SELECT hues_mail, hues_habilitado FROM CAIA_UNLIMITED.Huesped  where hues_mail='{0}'", txtEmail.Text.Trim());
                                        string documento_ingresado = String.Format("SELECT hues_documento FROM CAIA_UNLIMITED.Huesped WHERE hues_documento = '{0}'  AND hues_documento_tipo = '{1}'", txtDni.Text.Trim(), txtTipo.Text.Trim());

                                        if (DataBase.realizarConsulta(email_ingresado).Tables[0].Rows.Count == 0)
                                        {
                                            if (DataBase.realizarConsulta(documento_ingresado).Tables[0].Rows.Count == 0)
                                            {
                                                ejecutarStoredProcedureModificar();
                                                MessageBox.Show("Cliente modificado exitosamente", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                this.Hide();
                                                new MenuModificarYBaja().Show();
                                            }
                                            else
                                            {
                                                MessageBox.Show("El tipo y numero de identificacion ingresado ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("El mail ingresado ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    else if (seModificoElMail())
                                    {
                                        string email_ingresado = String.Format("SELECT hues_mail, hues_habilitado FROM CAIA_UNLIMITED.Huesped  where hues_mail='{0}'", txtEmail.Text.Trim());

                                        if (DataBase.realizarConsulta(email_ingresado).Tables[0].Rows.Count == 0)
                                        {
                                            ejecutarStoredProcedureModificar();
                                            MessageBox.Show("Cliente modificado exitosamente", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            this.Hide();
                                            new MenuModificarYBaja().Show();

                                        }
                                        else
                                        {
                                            MessageBox.Show("El mail ingresado ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    else// SI MODIFICO SOLO EL DNI
                                    {

                                        string documento_ingresado = String.Format("SELECT hues_documento FROM CAIA_UNLIMITED.Huesped WHERE hues_documento = '{0}'  AND hues_documento_tipo = '{1}'", txtDni.Text.Trim(), txtTipo.Text.Trim());


                                        if (DataBase.realizarConsulta(documento_ingresado).Tables[0].Rows.Count == 0)
                                        {
                                            ejecutarStoredProcedureModificar();
                                            MessageBox.Show("Cliente modificado exitosamente", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            this.Hide();
                                            new MenuModificarYBaja().Show();
                                        }
                                        else
                                        {
                                            MessageBox.Show("El tipo y numero de identificacion ingresado ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }


                                    }
                                }// MODIFIQUE COSAS MENOS EL MAIL O DNI
                                else
                                {
                                    ejecutarStoredProcedureModificar();
                                    MessageBox.Show("Cliente modificado exitosamente", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Hide();
                                    new MenuModificarYBaja().Show();
                                }
                            }
                            else
                            {
                                MessageBox.Show("No se realizaron cambios en el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }

                        }                            
                    }
                }
                

            }
            else
            {
                MessageBox.Show("Campo/s incompletos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private bool modificaronLosCampos()
        {
            if (txtNombre.Text.Trim() == nombreAnt && txtApellido.Text.Trim() == apellidoAnt && txtDni.Text.Trim() == dniAnt && txtTipo.Text.Trim() == tipoAnt && txtEmail.Text.Trim() == mailAnt && txtNacimiento.Text.Trim() == nacimientoAnt && txtNacionalidad.Text.Trim() == nacionalidadAnt && txtCalle.Text.Trim() == calleAnt && txtCalle_Nro.Text.Trim() == numeroAnt && txtPiso.Text.Trim() == pisoAnt && txtDpto.Text.Trim() == dptoAnt && txtCiudad.Text.Trim() == ciudadAnt && txtPais.Text.Trim() == paisAtn && txtTelefono.Text.Trim() == telefonoAnt)
            {
                return false;
            }
            return true;
        }


        private bool seModificoElMail()
        {
            
            if (txtEmail.Text.Trim() != mailAnt)
            {
                return true;
            }
            return false;
        }

        private bool seModificoElDniYMail()
        {
            if (txtDni.Text.Trim() != dniAnt && txtTipo.Text.Trim() != tipoAnt && txtEmail.Text.Trim() != mailAnt)
            {
                return true;
            }
            return false;
        }

        private bool seModificoElMAilDni()
        {
            if (txtDni.Text.Trim() != dniAnt && txtTipo.Text.Trim() != tipoAnt) 
            {
                return true;
            }
            if (txtEmail.Text.Trim() != mailAnt)
            {
                return true;
            }
            return false;
        }




        private void reestrablecerLabels()
        {
            lblApellido.Visible = false;
            lblNombre.Visible = false;
            lblIdentificacion.Visible = false;
            lblTipo.Visible = false;
            lblNacimiento.Visible = false;
            lblNacionalidad.Visible = false;
            lblMail.Visible = false;
            lblCalle.Visible = false;
            lblNro.Visible = false;
        }

        private bool formatoMailCorrecto()
        {
            Regex expEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (!expEmail.IsMatch(txtEmail.Text))
            {
                MessageBox.Show("Formato de mail ingresado incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool camposValidos()
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtDni.Text, @"^\d+$"))
            {
                MessageBox.Show("Solo se permiten valores numericos en el numero de identificacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            if (txtTelefono.Text != "")
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(txtTelefono.Text, @"^\d+$"))
                {
                    MessageBox.Show("Solo se permiten valores numericos en el telefono", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;

                }
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtCalle_Nro.Text, @"^\d+$"))
            {
                MessageBox.Show("Solo se permiten valores numericos en el numero de calle", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
           
            if (txtPiso.Text != "")
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(txtPiso.Text, @"^\d+$"))
                {
                    MessageBox.Show("Solo se permiten valores numericos en el piso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;

                }
            }
            
                return true;
            
        }


        private void btnDar_Baja_Click(object sender, EventArgs e)
        {
            if (hayModificaciones())
            {
                MessageBox.Show("No se puede dar de baja, se realizaron cambios en el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (rbtHabilitado.Checked)
                {
                           ejecutarStoredProcedureDarDeBaja();
                            MessageBox.Show("Cliente dado de baja exitosamente", "Baja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            new MenuModificarYBaja().Show();                       
                }
                else
                {
                    MessageBox.Show("El huesped ya esta dado de baja.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                           
            
                
            }
        }

        private bool hayModificaciones()
        {
            if (txtNombre.Text.Trim() == nombreAnt && txtApellido.Text.Trim() == apellidoAnt && txtDni.Text.Trim() == dniAnt && txtTipo.Text.Trim() == tipoAnt && txtEmail.Text.Trim() == mailAnt && txtNacimiento.Text.Trim() == nacimientoAnt && txtNacionalidad.Text.Trim() == nacionalidadAnt && txtCalle.Text.Trim() == calleAnt && txtCalle_Nro.Text.Trim() == numeroAnt && txtPiso.Text.Trim() == pisoAnt && txtDpto.Text.Trim() == dptoAnt && txtCiudad.Text.Trim() == ciudadAnt && txtPais.Text.Trim() == paisAtn && txtTelefono.Text.Trim() == telefonoAnt && estadoDelHuesped() == estadoAnt)
            {
                return false;
            }
            return true;
        }

        private void ejecutarStoredProcedureDarDeBaja() 
        {
            SqlConnection db = DataBase.conectarBD();
            SqlCommand crearCliente = new SqlCommand("CAIA_UNLIMITED.sp_BajaHuesped", db);
            crearCliente.CommandType = CommandType.StoredProcedure;
            crearCliente.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
            crearCliente.ExecuteNonQuery();
            db.Close();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            txtNacimiento.Text = calendario.SelectionStart.ToShortDateString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuModificarYBaja().Show();
        }

    }
}
