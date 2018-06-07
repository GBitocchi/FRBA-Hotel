using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmHotel
{
    public partial class FechasMantenimiento : Form
    {
        string hotelID;
        public FechasMantenimiento(string idHotel)
        {
            InitializeComponent();
            hotelID = idHotel;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = dtInicio.Value;
            DateTime fechaFin = dtFin.Value;
            string consultarPorReservas = string.Format("select * from CAIA_UNLIMITED.Reserva where hote_id = {0} and (rese_fecha_desde >= {1} and DATEADD(day, rese_cantidad_noches) <= {2}) and (DATEADD(day, rese_cantidad_noches) <= {2} and rese_fecha_desde >= {1})",
                hotelID, fechaInicio.ToString("yyyy-mm-dd"), fechaFin.ToString("yyyy-mm-dd"));

        }

    }
}
