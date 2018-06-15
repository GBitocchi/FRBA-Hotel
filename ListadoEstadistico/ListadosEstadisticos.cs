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

namespace FrbaHotel.ListadoEstadistico
{
    public partial class ListadosEstadisticos : Form
    {
        public ListadosEstadisticos()
        {
            InitializeComponent();
        }

        private void btnMasCanceladas_Click(object sender, EventArgs e)
        {
            if (DataBase.realizarConsulta("select * from CAIA_UNLIMITED.vw_MasCancelada").Tables[0].Rows.Count == 0)
            {
                new DatosInsuficientes().Show();
            }
            else
            {
                new MasCanceladas().Show();
                this.Hide();
            }
        }

        private void btnConsumiblesFacturados_Click(object sender, EventArgs e)
        {
            if (DataBase.realizarConsulta("select * from CAIA_UNLIMITED.vw_MasFacturacion").Tables[0].Rows.Count == 0)
            {
                new DatosInsuficientes().Show();
            }
            else
            {
                new MayorFacturacionConsumibles().Show();
                this.Hide();
            }
        }

        private void btnMasMantenimiento_Click(object sender, EventArgs e)
        {
            if (DataBase.realizarConsulta("select * from CAIA_UNLIMITED.vw_MasMantenimiento").Tables[0].Rows.Count == 0)
            {
                new DatosInsuficientes().Show();
            }
            else
            {
                new MasMantenimiento().Show();
                this.Hide();
            }
        }

        private void btnMasOcupadas_Click(object sender, EventArgs e)
        {
            if (DataBase.realizarConsulta("select * from CAIA_UNLIMITED.vw_MasOcupada").Tables[0].Rows.Count == 0)
            {
                new DatosInsuficientes().Show();
            }
            else
            {
                new MasOcupadas().Show();
                this.Hide();
            }
        }

        private void btnClientesPuntos_Click(object sender, EventArgs e)
        {
            if (DataBase.realizarConsulta("select * from CAIA_UNLIMITED.vw_MasPuntos").Tables[0].Rows.Count == 0)
            {
                new DatosInsuficientes().Show();
            }
            else
            {
                new MasPuntosCliente().Show();
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