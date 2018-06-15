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

namespace FrbaHotel.AbmHabitacion
{
    public partial class Crear : Form
    {
        string hotel_id;
        public Crear(string hotelId)
        {
            InitializeComponent();
            lblErrorDesc.Visible = false;
            lblErrorNroHab.Visible = false;
            lblErrorPiso.Visible = false;
            lblErrorUbi.Visible = false;
            lblErrorHabiExistente.Visible = false;
            cargarComboBox();
            hotel_id = hotelId;
        }

        private void cargarComboBox()
        {
            cbTipos.DataSource = DataBase.realizarConsulta("select thab_descripcion from CAIA_UNLIMITED.Tipo_Habitacion").Tables[0];
            cbTipos.DisplayMember = "thab_descripcion";
        }

        private bool constatarCampos()
        {
            int aux;
            if (txtNro_habitacion.Text.Trim() == "")
            {
                lblErrorNroHab.Visible = true;
                return false;
            }
            else if (txtPiso.Text.Trim() == "" || !int.TryParse(txtPiso.Text.Trim(), out aux))
            {
                lblErrorPiso.Visible = true;
                return false;
            }
            else if (txtUbicacion.Text.Trim() == "")
            {
                lblErrorUbi.Visible = true;
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if(constatarCampos())
            {
                Console.WriteLine(obtenerCodigo());
                ocultarErrores();
                try
                {
                    ejecutarStoredProcedure();
                    new HabitacionCreada().Show();
                    limpiarCampos();
                }
                catch
                {
                    new HabitacionExistente().Show();
                }  
            }
        }



        private void ejecutarStoredProcedure()
        {
            SqlConnection db = DataBase.conectarBD();
            SqlCommand crearHabitacion = new SqlCommand("sp_CrearHabitacion", db);
            crearHabitacion.CommandType = CommandType.StoredProcedure;
            crearHabitacion.Parameters.AddWithValue("@numero_habitacion", txtNro_habitacion.Text.Trim());
            crearHabitacion.Parameters.AddWithValue("@piso", txtPiso.Text.Trim());
            crearHabitacion.Parameters.AddWithValue("@frente", txtUbicacion.Text.Trim());
            crearHabitacion.Parameters.AddWithValue("@descripcion", txtDescripcion.Text.Trim());
            crearHabitacion.Parameters.AddWithValue("@tipo", obtenerCodigo());
            crearHabitacion.Parameters.AddWithValue("@idHotel", hotel_id);
            crearHabitacion.ExecuteNonQuery();
            db.Close();
        }

        private string obtenerCodigo()
        {
            string tipo = cbTipos.Text;
            DataTable tipos = DataBase.realizarConsulta("select thab_codigo from CAIA_UNLIMITED.Tipo_Habitacion where thab_descripcion = '" + tipo + "'").Tables[0];
            string codigoTipo = tipos.Rows[0][0].ToString();
            return codigoTipo;
        }

        private void limpiarCampos()
        {
            txtNro_habitacion.Clear();
            txtPiso.Clear();
            txtUbicacion.Clear();
            txtDescripcion.Clear();
        }

        private void ocultarErrores()
        {
            lblErrorDesc.Visible = false;
            lblErrorNroHab.Visible = false;
            lblErrorPiso.Visible = false;
            lblErrorUbi.Visible = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuHabitacion(hotel_id).Show();
        }
    }
}
