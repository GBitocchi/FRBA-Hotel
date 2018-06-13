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
    public partial class MenuModificarDarDeBaja : Form
    {
        public MenuModificarDarDeBaja()
        {
            InitializeComponent();
            DataSet regimenes = DataBase.realizarConsulta("select regi_codigo as 'Codigo', regi_descripcion as 'Descripcion', regi_precio_base as 'Precio base', regi_estado as 'Estado' from CAIA_UNLIMITED.Hotel ");
            dgRegimenes.DataSource = regimenes.Tables[0];
        }

        private void dgRegimenes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string codigo = dgRegimenes.SelectedRows[0].Cells[0].Value.ToString();
            this.Hide();
            new Modificacion(codigo).Show();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuRegimen().Show();
        }
    }
}
