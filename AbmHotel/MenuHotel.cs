using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaHotel.Menu_Sistema;

namespace FrbaHotel.AbmHotel
{
    public partial class MenuHotel : Form
    {
        public MenuHotel()//Falta agregar hote_id al constructor
        {
            InitializeComponent();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CrearHotel().Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FiltrarHotel().Show();
        }

        private void btnEstado_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
            new VistaSistema().Show();
        }
    }
}
