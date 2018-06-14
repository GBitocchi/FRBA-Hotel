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
        }

        private void ActualizarBD() 
        {
            try
            {
                ejecutarStoredProcedure();
                new HabitacionModificada(hotel_id).Show();
            }
            catch
            {
                new HabitacionExistente().Show();
            }
        }

        private void ejecutarStoredProcedure()
        {
            SqlConnection db = DataBase.conectarBD();
            SqlCommand modificarHabitacion = new SqlCommand("sp_ModificarHabitacion", db);
            modificarHabitacion.CommandType = CommandType.StoredProcedure;
            modificarHabitacion.Parameters.AddWithValue("@numero_habitacion", txtNroHabitacion.Text.Trim());
            modificarHabitacion.Parameters.AddWithValue("@piso", txtPiso.Text.Trim());
            modificarHabitacion.Parameters.AddWithValue("@frente", txtUbicacion.Text.Trim());
            modificarHabitacion.Parameters.AddWithValue("@descripcion", txtDescripcion.Text.Trim());
            modificarHabitacion.Parameters.AddWithValue("@viejo_numero", numeroAnterior);
            modificarHabitacion.Parameters.AddWithValue("@idHotel", hotel_id);
            modificarHabitacion.ExecuteNonQuery();
            db.Close();
        }

        public MenuModificacion(string hotelId)
        {
            InitializeComponent();
            lblNroHabitacion.Visible = false;
            lblPiso.Visible = false;
            lblUbicacion.Visible = false;
            hotel_id = hotelId;
            MostrarDG();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuHabitacion(hotel_id).Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int aux;
            lblNroHabitacion.Visible = false;
            lblPiso.Visible = false;
            lblUbicacion.Visible = false;
            if (txtNroHabitacion.Text.Trim() == "")
            {
                lblNroHabitacion.Visible = true;
            }
            else if (txtPiso.Text.Trim() == "" || !int.TryParse(txtPiso.Text.Trim(), out aux))
            {
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
        }

    }
}
