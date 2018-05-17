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
        public MenuHabitacion()
        {
            InitializeComponent();
        }

        private void crear_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Crear().Show();
        }

        private void modificar_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuModificacion().Show();
        }

        private void baja_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void atras_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
