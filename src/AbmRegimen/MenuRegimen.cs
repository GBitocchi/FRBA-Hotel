using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmRegimen
{
    public partial class MenuRegimen : Form
    {
        public MenuRegimen()
        {
            InitializeComponent();
        }
              

        private void btnCrear_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new Crear().Show();
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            this.Hide();

            new MenuModificarDarDeBaja().Show();
        }
       
    }
}
