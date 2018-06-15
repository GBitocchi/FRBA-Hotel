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
    public partial class MasCanceladas : Form
    {
        public MasCanceladas()
        {
            InitializeComponent();
            dgCanceladas.DataSource = DataBase.realizarConsulta("select * from CAIA_UNLIMITED.vw_MasCancelada").Tables[0];
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ListadosEstadisticos().Show();
        }
    }
}
