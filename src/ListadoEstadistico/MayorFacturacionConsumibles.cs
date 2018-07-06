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
    public partial class MayorFacturacionConsumibles : Form
    {
        public MayorFacturacionConsumibles(DataTable consumibles)
        {
            InitializeComponent();
            dgMasFacturacion.DataSource = consumibles;
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


    }
}
