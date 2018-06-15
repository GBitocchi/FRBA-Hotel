using FrbaHotel.Menu_Sistema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmFacturacion
{
    public partial class EstadiasAFacturar : Form
    {
        public EstadiasAFacturar()
        {
            InitializeComponent();
            dgEstadias.DataSource = DataBase.realizarConsulta("select R.rese_codigo as 'Reserva', esta_codigo as 'Codigo', esta_fecha_inicio as 'Fecha de inicio', esta_cantidad_noches as 'Cantidad de noches', hote_id as 'Hotel' from CAIA_UNLIMITED.Estadia E join CAIA_UNLIMITED.Reserva R on (E.rese_codigo = R.rese_codigo) where DATEDIFF(day, DATEADD(day, esta_cantidad_noches, esta_fecha_inicio), GETDATE()) >= 0").Tables[0];
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            string codigoEstadia = dgEstadias.SelectedRows[0].Cells[1].Value.ToString();
            new Facturacion(codigoEstadia).Show();
            this.Hide();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
            new VistaSistema().Show();
        }
    }
}
