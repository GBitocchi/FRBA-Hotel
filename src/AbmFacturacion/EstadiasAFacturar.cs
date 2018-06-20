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
            dgEstadias.DataSource = DataBase.realizarConsulta("select R.rese_codigo as 'Reserva', esta_codigo as 'Codigo', esta_fecha_inicio as 'Fecha de inicio', DATEDIFF(day, esta_fecha_inicio, esta_fecha_fin) as 'Cantidad de noches', habi_rese_id as 'Hotel' from CAIA_UNLIMITED.Estadia E join CAIA_UNLIMITED.Reserva R on (E.rese_codigo = R.rese_codigo) join CAIA_UNLIMITED.Habitacion_X_Reserva on (R.rese_codigo = habi_rese_codigo) where DATEDIFF(day, esta_fecha_fin, convert(datetime, '" + DataBase.fechaSistema().ToString("yyyy-MM-dd hh:mm:ss") + "', 121)) >= 0 order by esta_fecha_inicio").Tables[0];
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            if (dgEstadias.Rows.Count > 1)
            {
                string codigoEstadia = dgEstadias.SelectedRows[0].Cells[1].Value.ToString();
                new Facturacion(codigoEstadia).Show();
                this.Hide();
            }
            
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
            new VistaSistema().Show();
        }
    }
}
