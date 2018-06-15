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

namespace FrbaHotel.AbmCliente
{
    public partial class Modificar : Form
    {
        string nombreAnt, apellidoAnt, dniAnt, tipoAnt, mailAnt, nacimientoAnt, nacionalidadAnt, calleAnt, numeroAnt, pisoAnt, dptoAnt, ciudadAnt, paisAtn, telefonoAnt;
        int estadoAnt;

        public Modificar(string mail)
        {
            InitializeComponent();
            mailAnt = mail;
            string consultaCliente = string.Format("select hues_nombre as 'Nombre', hues_apellido as 'Apellido', hues_documento as'DNI', hues_documento_tipo as 'Tipo', hues_mail as 'E-Mail', hues_nacimiento as 'Fecha de nacimiento', hues_nacionalidad as 'Nacionalidad', dire_dom_calle as 'Calle', dire_nro_calle as 'Nro', dire_piso as 'Piso', dire_dpto as 'Dpto', dire_ciudad as 'Ciudad',dire_pais as 'Pais', dire_telefono as 'Telefono', hues_habilitado as 'Estado' from CAIA_UNLIMITED.Huesped H join CAIA_UNLIMITED.Direccion D on (H.dire_id = D.dire_id) where hues_mail='{0}'", mail); 
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
            dniAnt =txtDni.Text;
            tipoAnt = txtTipo.Text;
            mailAnt = txtEmail.Text;
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
            SqlCommand crearCliente = new SqlCommand("sp_ModificarHues", db);
            crearCliente.CommandType = CommandType.StoredProcedure;
            crearCliente.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
            crearCliente.Parameters.AddWithValue("@apellido", txtApellido.Text.Trim());
            crearCliente.Parameters.AddWithValue("@documento", txtDni.Text.Trim());
            crearCliente.Parameters.AddWithValue("@tipo", txtTipo.Text.Trim());
            crearCliente.Parameters.AddWithValue("@mail", txtEmail.Text.Trim());
            crearCliente.Parameters.AddWithValue("@fecha_nacimiento", DateTime.Parse(txtNacimiento.Text));
            crearCliente.Parameters.AddWithValue("@nacionalidad", txtNacionalidad.Text.Trim());
            crearCliente.Parameters.AddWithValue("@calle", txtCalle.Text.Trim());
            crearCliente.Parameters.AddWithValue("@calle_nro", txtCalle_Nro.Text.Trim());
            crearCliente.Parameters.AddWithValue("@piso", txtPiso.Text.Trim());
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
            
            crearCliente.ExecuteNonQuery();
            db.Close();
        }

        private bool hayModificaciones()
        {
            if (txtNombre.Text.Trim() == nombreAnt && txtApellido.Text.Trim() == apellidoAnt && txtDni.Text.Trim() == dniAnt && txtTipo.Text.Trim() == tipoAnt && txtEmail.Text.Trim() == mailAnt && txtNacimiento.Text.Trim() == nacimientoAnt && txtNacionalidad.Text.Trim() == nacionalidadAnt && txtCalle.Text.Trim() == calleAnt && txtCalle_Nro.Text.Trim() == numeroAnt && txtPiso.Text.Trim() == pisoAnt && txtDpto.Text.Trim() == dptoAnt && txtCiudad.Text.Trim() == ciudadAnt && txtPais.Text.Trim() == paisAtn && txtTelefono.Text.Trim() == telefonoAnt)
            {
                return false;
            }
            return true;
        }

        private bool estaCompleto()
        {
            if (txtApellido.Text.Trim() == "")
            {
                return false;
            }
            if (txtNombre.Text.Trim() == "")
            {
                return false;
            }
            if (txtDni.Text.Trim() == "")
            {
                return false;
            }
            if (txtTipo.Text.Trim() == "")
            {
                return false;
            }
            if (txtEmail.Text.Trim() == "")
            {
                return false;
            }
            if (txtNacimiento.Text.Trim() == "")
            {
                return false;
            }
            if (txtNacimiento.Text.Trim() == "")
            {
                return false;
            }
            if (txtCalle.Text.Trim() == "")
            {
                return false;
            }
            if (txtCalle_Nro.Text.Trim() == "")
            {
                return false;
            }
            if (txtPiso.Text.Trim() == "")
            {
                return false;
            }
            if (txtDpto.Text.Trim() == "")
            {
                return false;
            }
            if (txtCiudad.Text.Trim() == "")
            {
                return false;
            }
            if (txtPais.Text.Trim() == "")
            {
                return false;
            }
            if (txtTelefono.Text.Trim() == "")
            {
                return false;
            }
            return true;
           
        }

        private void btnModificar_Cliente_Click(object sender, EventArgs e)
        {
            if (estaCompleto())
            {
                if (hayModificaciones())
                {
                    ejecutarStoredProcedureModificar();
                    MessageBox.Show("Cliente modificado exitosamente");
                    this.Hide();
                    new MenuModificarYBaja().Show();
                }
                else
                {
                    MessageBox.Show("No se realizaron cambios en los campo/s");
                }

            }
            else
            {
                MessageBox.Show("Campo/s incompletos");
            }

        }

        private void btnDar_Baja_Click(object sender, EventArgs e)
        {
            if (hayModificaciones())
            {
                MessageBox.Show("No se puede dar de baja, se realizaron cambios en el cliente.");
            }
            else
            {                
                ejecutarStoredProcedureDarDeBaja();
                MessageBox.Show("Cliente dado de baja exitosamente");
                this.Hide();
                new MenuModificarYBaja().Show();
            }
        }

        private void ejecutarStoredProcedureDarDeBaja() 
        {
            SqlConnection db = DataBase.conectarBD();
            SqlCommand crearCliente = new SqlCommand("sp_BajaHues", db);
            crearCliente.CommandType = CommandType.StoredProcedure;
            crearCliente.Parameters.AddWithValue("@mail", txtEmail.Text.Trim());
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
