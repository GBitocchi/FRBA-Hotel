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
        public MenuModificacion()
        {
            InitializeComponent();
            string nueva_consulta = "select habi_numero as 'Numero de habitacion', habi_piso as 'Piso', habi_frente 'Ubicacion', habi_descripcion as 'Descripcion' from CAIA_UNLIMITED.Habitacion";
            DataSet ds_habitaciones = DataBase.realizarConsulta(nueva_consulta);
            dgHabitaciones.DataSource = ds_habitaciones.Tables[0];
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuHabitacion().Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

        }

        private void dgHabitaciones_DoubleClick(object sender, EventArgs e)
        {
            txtNroHabitacion.Text = dgHabitaciones.SelectedRows[0].Cells[1].Value.ToString();
            txtPiso.Text = dgHabitaciones.SelectedRows[0].Cells[2].Value.ToString();
            txtUbicacion.Text = dgHabitaciones.SelectedRows[0].Cells[3].Value.ToString();
            txtDescripcion.Text = dgHabitaciones.SelectedRows[0].Cells[4].Value.ToString();
        }

    }
}
