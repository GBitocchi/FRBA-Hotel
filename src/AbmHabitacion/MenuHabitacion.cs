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
    public partial class MenuHabitacion : Form
    {
        string hotel_id;
        public MenuHabitacion(string hotelId)
        {
            InitializeComponent();
            hotel_id = hotelId;
        }

        private void crear_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Crear(hotel_id).Show();
        }

        private void modificar_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuModificacion(hotel_id).Show();
        }

        private void baja_Click(object sender, EventArgs e)
        {
            this.Hide();
            new BajaHabitacion(hotel_id).Show();
        }

        private void atras_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
