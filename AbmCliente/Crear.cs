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
    public partial class Crear : Form
    {
        public Crear()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private bool camposCompletos()
        {
            if (txtApellido.Text.Trim() == "")
            {
                return false;
            }
            if (txtNombre.Text.Trim()=="")
            {
                return false;
            } 
            if (txtNumero_Identificacion.Text.Trim()=="")
            {
                return false;
            } 
            if (txtTipo_Identificacion.Text.Trim()=="")
            {
                return false;
            } 
            if (txtEmail.Text.Trim()=="")
            {
                return false;
            } 
            if (txtNacimiento.Text.Trim()=="")
            {
                return false;
            } 
            if (txtNacimiento.Text.Trim()=="")
            {
                return false;
            } 
            if (txtCalle.Text.Trim()=="")
            {
                return false;
            } 
            if (txtCalle_Nro.Text.Trim()=="")
            {
                return false;
            } 
            if (txtPiso.Text.Trim()=="")
            {
                return false;
            } 
            if (txtDpto.Text.Trim()=="")
            {
                return false;
            } 
            if (txtCiudad.Text.Trim()=="")
            {
                return false;
            }
            if (txtPais.Text.Trim()== "")
            {
                return false;
            } 
            if (txtTelefono.Text.Trim()=="")
            {
                return false;
            }
            return true;
        }


        private void RestaurarFormulario()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtNumero_Identificacion.Clear();
            txtTipo_Identificacion.Clear();
            txtEmail.Clear();
            txtNacimiento.Clear();
            txtNacionalidad.Clear();
            txtCalle.Clear();
            txtCalle_Nro.Clear();
            txtPiso.Clear();
            txtDpto.Clear();
            txtCiudad.Clear();
            txtTelefono.Clear();
            txtPais.Clear();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (camposCompletos())
            {

                string email_ingresado = String.Format("SELECT hues_mail FROM CAIA_UNLIMITED.Huesped  where hues_mail='{0}'", txtEmail.Text.Trim());
                               
                if (DataBase.realizarConsulta(email_ingresado).Tables[0].Rows.Count == 0)
                {
                    ejecutarStoredProcedureCrear();
                    MessageBox.Show("Cliente " + txtNombre + " ingresado correctamente.");
                    RestaurarFormulario();
                    
                }else
                {
                    MessageBox.Show("El mail ingresado ya existe.");
                }
                                
            }
            else
            {
                MessageBox.Show("Complete todo los campos");
            }


        }

        private void ejecutarStoredProcedureCrear()
        {
            SqlConnection db = DataBase.conectarBD();
            SqlCommand crearCliente = new SqlCommand("sp_CrearCliente", db);
            crearCliente.CommandType = CommandType.StoredProcedure;
            crearCliente.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
            crearCliente.Parameters.AddWithValue("@apellido", txtApellido.Text.Trim());
            crearCliente.Parameters.AddWithValue("@documento", txtNumero_Identificacion.Text.Trim());
            crearCliente.Parameters.AddWithValue("@tipo", txtTipo_Identificacion.Text.Trim());
            crearCliente.Parameters.AddWithValue("@mail", txtEmail.Text.Trim());
            crearCliente.Parameters.AddWithValue("@fecha_nacimientno", txtNacimiento.Text.Trim());
            crearCliente.Parameters.AddWithValue("@nacionalidad", txtNacionalidad.Text.Trim());
            crearCliente.Parameters.AddWithValue("@calle", txtCalle.Text.Trim());
            crearCliente.Parameters.AddWithValue("@calle_nro", txtCalle_Nro.Text.Trim());
            crearCliente.Parameters.AddWithValue("@piso", txtPiso.Text.Trim());
            crearCliente.Parameters.AddWithValue("@dpto", txtDpto.Text.Trim());
            crearCliente.Parameters.AddWithValue("@ciudad", txtCiudad.Text.Trim());
            crearCliente.Parameters.AddWithValue("@pais", txtPais.Text.Trim());
            crearCliente.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
            crearCliente.ExecuteNonQuery();
            db.Close();
        }
        

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuClientes().Show();
        }
    }
}
