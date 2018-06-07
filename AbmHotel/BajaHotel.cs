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
    public partial class BajaHotel : Form
    {
        public BajaHotel()
        {
            InitializeComponent();
            DataSet hoteles = DataBase.realizarConsulta("select hote_id as 'ID', hote_nombre as 'Nombre', hote_cant_estrellas as 'Estrellas', hote_mail as 'Mail', dire_dom_calle as 'Calle', dire_nro_calle as 'Numero', dire_ciudad as 'Ciudad', dire_pais as 'Pais' from CAIA_UNLIMITED.Hotel H join CAIA_UNLIMITED.Direccion D on (H.dire_id = D.dire_id)");
            dgHoteles.DataSource = hoteles.Tables[0];
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuHotel().Show();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {

        }
    }
}
