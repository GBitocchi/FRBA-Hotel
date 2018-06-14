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
        public MayorFacturacionConsumibles()
        {
            InitializeComponent();
            DataTable consumiblesFacturados = DataBase.realizarConsulta("select top 5 H.hote_id 'ID', hote_nombre as 'Nombre' from CAIA_UNLIMITED.Hotel H join CAIA_UNLIMITED.Reserva R on (H.hote_id = R.hote_id) join CAIA_UNLIMITED.Estadia E on (E.rese_codigo = R.rese_codigo) join CAIA_UNLIMITED.Factura F on (F.esta_codigo = E.esta_codigo) join CAIA_UNLIMITED.Item_Factura I on (F.fact_nro = I.fact_nro) group by H.hote_id, hote_nombre order by sum(I.item_cantidad) desc").Tables[0];
            if (consumiblesFacturados.Rows.Count == 0)
            {
                new DatosInsuficientes().Show();
                this.Hide();
            }
            else
            {
                dgMasFacturacion.DataSource = consumiblesFacturados;
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ListadosEstadisticos().Show();
        }


    }
}
