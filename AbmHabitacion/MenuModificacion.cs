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
            string nueva_consulta = "select * from Habitacion";
            DataSet ds_habitaciones = DataBase.realizarConsulta(nueva_consulta);
            DataTable habitaciones = ds_habitaciones.Tables[0];
            dgHabitaciones.DataSource = habitaciones;
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

        }

    }
}
