using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.ListadoEstadistico
{
    public partial class ListadosEstadisticos : Form
    {
        public ListadosEstadisticos()
        {
            InitializeComponent();
        }

        private void btnMasCanceladas_Click(object sender, EventArgs e)
        {
            new MasCanceladas().Show();
            this.Hide();
        }

        private void btnConsumiblesFacturados_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnMasMantenimiento_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnMasOcupadas_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnClientesPuntos_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}