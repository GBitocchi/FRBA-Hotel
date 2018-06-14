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
    public partial class MasTiempoMantenimiento : Form
    {
        public MasTiempoMantenimiento()
        {
            InitializeComponent();
            DataTable mantenimientos = DataBase.realizarConsulta("select top 5 H.hote_id as 'ID', hote_nombre as 'Nombre' from CAIA_UNLIMITED.Hotel H join CAIA_UNLIMITED.Mantenimiento M on (H.hote_id = M.hote_id) group by H.hote_id, hote_nombre order by sum(datediff(day, mant_fecha_inicio, mant_fecha_fin)) desc").Tables[0];
            if (mantenimientos.Rows.Count == 0)
            {
                this.Hide();
                new DatosInsuficientes().Show();
            }
            else
            {
                dgMantenimientos.DataSource = mantenimientos;
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ListadosEstadisticos().Show();
        }
    }
}
