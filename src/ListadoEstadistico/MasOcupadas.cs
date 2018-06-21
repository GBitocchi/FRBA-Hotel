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
    public partial class MasOcupadas : Form
    {
        public MasOcupadas()
        {
            InitializeComponent();
            dgOcupadas.DataSource = DataBase.realizarConsulta("select * from CAIA_UNLIMITED.vw_MasOcupada").Tables[0];
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
