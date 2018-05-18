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
    public partial class BajaHabitacion : Form
    {
        //int hote_id;
        private void MostrarDG()
        {
            string nueva_consulta = "select habi_numero as 'Numero de habitacion', habi_piso as 'Piso', habi_frente 'Ubicacion', habi_habilitado as 'Habilitada' from CAIA_UNLIMITED.Habitacion";
            DataSet ds_habitaciones = DataBase.realizarConsulta(nueva_consulta);
            dgBajaHabitacion.DataSource = ds_habitaciones.Tables[0];
        }

        public BajaHabitacion(/*int id_hotel*/)
        {
            InitializeComponent();
           // hote_id = id_hotel;
            MostrarDG();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuHabitacion().Show();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            string numero_habitacion = dgBajaHabitacion.SelectedRows[0].Cells[0].Value.ToString();
            string estado_actual = dgBajaHabitacion.SelectedRows[0].Cells[3].Value.ToString();
            if (estado_actual != "0")
            {
                string baja_habitacion = "update CAIA_UNLIMITED.Habitacion set habi_habilitado = 0 where habi_numero =" + numero_habitacion + " and hote_id=" + 0;
                DataBase.procedureBD(baja_habitacion);
                new EstadoCambiado().Show();
                MostrarDG();
            }
           
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            string numero_habitacion = dgBajaHabitacion.SelectedRows[0].Cells[0].Value.ToString();
            string estado_actual = dgBajaHabitacion.SelectedRows[0].Cells[3].Value.ToString();
            if (estado_actual != "1") 
            {
                string alta_habitacion = "update CAIA_UNLIMITED.Habitacion set habi_habilitado = 1 where habi_numero =" + numero_habitacion + " and hote_id=" + 0;
                DataBase.procedureBD(alta_habitacion);
                new EstadoCambiado().Show();
                MostrarDG();
            }         
        }
    }
}
