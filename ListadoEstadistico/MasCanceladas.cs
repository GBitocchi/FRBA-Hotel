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
            DataTable canceladas = DataBase.realizarConsulta("SELECT TOP 5 H.hote_id as 'ID', hote_nombre as 'Nombre' FROM CAIA_UNLIMITED.Hotel H join CAIA_UNLIMITED.Reserva R on (H.hote_id = R.hote_id) join CAIA_UNLIMITED.Estado_Reserva E on (E.esre_codigo = R.esre_codigo) WHERE esre_detalle LIKE '%cancelada%' GROUP BY H.hote_id, hote_nombre ORDER BY COUNT(*) DESC").Tables[0];
            if (canceladas.Rows.Count == 0)
            {
                new NingunaCancelada().Show();
                this.Hide();
            }
            else
            {
                dgCanceladas.DataSource = canceladas;
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ListadosEstadisticos().Show();
        }
    }
}
