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
    public partial class MenuModificacion : Form
    {
        string numeroAnterior;
        string numeroPiso;
        string ubicacion;
        string descripcion;
        string hotel_id;
        private void MostrarDG()
        {
            string nueva_consulta = "select habi_numero as 'Numero de habitacion', habi_piso as 'Piso', habi_frente 'Ubicacion', habi_descripcion as 'Descripcion' from CAIA_UNLIMITED.Habitacion where hote_id = " + hotel_id.ToString();
            DataSet ds_habitaciones = DataBase.realizarConsulta(nueva_consulta);
            dgHabitaciones.DataSource = ds_habitaciones.Tables[0];
            dgHabitaciones.AllowUserToAddRows = false;
        }



        private void ActualizarBD() 
        {
            try
            {
                if (DataBase.realizarConsulta("select * from CAIA_UNLIMITED.Habitacion where habi_numero =" + txtNroHabitacion.Text.Trim() + " and hote_id = " + hotel_id).Tables[0].Rows.Count == 0)
                {
                    ejecutarStoredProcedure();
                    MessageBox.Show("Habitacion modificada exitosamente.", "Modificacion exitosa", MessageBoxButtons.OK);
                    limpiarCampos();
                    btnModificar.Visible = false;
                }
                else
                {
                    MessageBox.Show("Numero de habitacion ya existente.", "Modificacion erronea", MessageBoxButtons.OK);

                }
            }
            catch
            {
                MessageBox.Show("No se pudo modificar la habitacion.", "Error de habitacion", MessageBoxButtons.OK);
            }  
        }

        private void limpiarCampos()
        {
            txtNroHabitacion.Clear();
            txtPiso.Clear();
            txtUbicacion.Clear();
            txtDescripcion.Clear();
        }

        private void ejecutarStoredProcedure()
        {
            SqlConnection db = DataBase.conectarBD();
            SqlCommand modificarHabitacion = new SqlCommand("CAIA_UNLIMITED.sp_ModificarHabitacion", db);
            modificarHabitacion.CommandType = CommandType.StoredProcedure;
            modificarHabitacion.Parameters.AddWithValue("@numero_habitacion", Convert.ToInt32(txtNroHabitacion.Text.Trim()));
            modificarHabitacion.Parameters.AddWithValue("@piso", Convert.ToInt32(txtPiso.Text.Trim()));
            modificarHabitacion.Parameters.AddWithValue("@frente", txtUbicacion.Text.Trim());
            modificarHabitacion.Parameters.AddWithValue("@descripcion", txtDescripcion.Text.Trim());
            modificarHabitacion.Parameters.AddWithValue("@viejo_numero", numeroAnterior);
            modificarHabitacion.Parameters.AddWithValue("@idHotel", Convert.ToInt32(hotel_id));
            modificarHabitacion.ExecuteNonQuery();
            db.Close();
        }

        public MenuModificacion(string hotelId)
        {
            InitializeComponent();
            ocultarErrores();
            hotel_id = hotelId;
            MostrarDG();
        }

        private void ocultarErrores()
        {
            btnModificar.Visible = false;
            lblNroHabitacion.Visible = false;
            lblPiso.Visible = false;
            lblUbicacion.Visible = false;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int aux;
            lblNroHabitacion.Visible = false;
            lblPiso.Visible = false;
            lblUbicacion.Visible = false;
            if (txtNroHabitacion.Text.Trim() == "")
            {
                MessageBox.Show("Complete el numero de habitacion.", "Campos incompletos", MessageBoxButtons.OK);
                lblNroHabitacion.Visible = true;
            }
            else if (!Int32.TryParse(txtNroHabitacion.Text.Trim(), out aux))
            {
                MessageBox.Show("El numero de habitacion debe ser numero", "Campos invalidos", MessageBoxButtons.OK);
                lblNroHabitacion.Visible = true;
            }
            else if (txtPiso.Text.Trim() == "") 
            {
                MessageBox.Show("Complete el numero de piso.", "Campos incompletos", MessageBoxButtons.OK);
                lblPiso.Visible = true;
            }
            else if (!int.TryParse(txtPiso.Text.Trim(), out aux))
            {
                MessageBox.Show("El numero de piso debe ser numero.", "Campos invalidos", MessageBoxButtons.OK);
                lblPiso.Visible = true;

            }
            else if (txtUbicacion.Text.Trim() == "")
            {
                lblUbicacion.Visible = true;
            }
            else if (txtNroHabitacion.Text.Trim() != numeroAnterior || txtPiso.Text.Trim() != numeroPiso || txtUbicacion.Text.Trim() != ubicacion || txtDescripcion.Text.Trim() != descripcion)
            {
                ActualizarBD();
                MostrarDG();
            }
        }

        private void dgHabitaciones_DoubleClick(object sender, EventArgs e)
        {
            txtNroHabitacion.Text = dgHabitaciones.SelectedRows[0].Cells[0].Value.ToString();
            numeroAnterior = txtNroHabitacion.Text.Trim();
            numeroPiso = dgHabitaciones.SelectedRows[0].Cells[1].Value.ToString();
            ubicacion = dgHabitaciones.SelectedRows[0].Cells[2].Value.ToString();
            descripcion = dgHabitaciones.SelectedRows[0].Cells[3].Value.ToString();
            txtPiso.Text = dgHabitaciones.SelectedRows[0].Cells[1].Value.ToString();
            txtUbicacion.Text = dgHabitaciones.SelectedRows[0].Cells[2].Value.ToString();
            txtDescripcion.Text = dgHabitaciones.SelectedRows[0].Cells[3].Value.ToString();
            btnModificar.Visible = true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            ocultarErrores();
        }

    }
}
