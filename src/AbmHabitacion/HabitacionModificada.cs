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
    public partial class HabitacionModificada : Form
    {
        string idHotel;
        public HabitacionModificada(string hotel_id)
        {
            InitializeComponent();
            idHotel = hotel_id;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuHabitacion(idHotel).Show();
        }
    }
}
