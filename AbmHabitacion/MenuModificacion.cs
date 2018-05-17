using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmHabitacion
{
    public partial class MenuModificacion : Form
    {
        string hote_id;
        string numeroAnterior;
        private void MostrarDG()
        {
            string nueva_consulta = "select habi_numero as 'Numero de habitacion', habi_piso as 'Piso', habi_frente 'Ubicacion', habi_descripcion as 'Descripcion' from CAIA_UNLIMITED.Habitacion";
            DataSet ds_habitaciones = DataBase.realizarConsulta(nueva_consulta);
            dgHabitaciones.DataSource = ds_habitaciones.Tables[0];
        }

        private void ActualizarBD() 
        {
            string actualizacion ="update CAIA_UNLIMITED.Habitacion set habi_numero= '" + txtNroHabitacion.Text + "', habi_piso = '" + txtPiso.Text + "', habi_frente ='" + txtUbicacion.Text + "', habi_descripcion ='" + txtDescripcion.Text + "' where hote_id = '" + hote_id + "' and habi_numero ='" + txtNroHabitacion.Text + "'";
            DataBase.procedureBD(actualizacion);
            new HabitacionModificada().Show();

        }

        public MenuModificacion()
        {
            InitializeComponent();
            MostrarDG();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuHabitacion().Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ActualizarBD();
            MostrarDG();
        }

        private void dgHabitaciones_DoubleClick(object sender, EventArgs e)
        {
            hote_id = "0";
            txtNroHabitacion.Text = dgHabitaciones.SelectedRows[0].Cells[0].Value.ToString();
            numeroAnterior = txtNroHabitacion.Text.Trim();
            txtPiso.Text = dgHabitaciones.SelectedRows[0].Cells[1].Value.ToString();
            txtUbicacion.Text = dgHabitaciones.SelectedRows[0].Cells[2].Value.ToString();
            txtDescripcion.Text = dgHabitaciones.SelectedRows[0].Cells[3].Value.ToString();
        }

    }
}
