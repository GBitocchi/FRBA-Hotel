using FrbaHotel.AbmHotel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.Menu_Sistema
{
    public partial class VistaSistema : Form
    {
        public VistaSistema()
        {
            InitializeComponent();
            chequearMantenimientos();
        }

        private static void chequearMantenimientos()
        {
            SqlConnection db = DataBase.conectarBD();
            SqlCommand altaHoteles = new SqlCommand("CAIA_UNLIMITED.sp_AltaHotel", db);
            altaHoteles.CommandType = CommandType.StoredProcedure;
            altaHoteles.Parameters.AddWithValue("@fecha", DataBase.fechaSistema());
            altaHoteles.ExecuteNonQuery();
            db.Close();
        }

        private void btnHotel_Click(object sender, EventArgs e)
        {
            //CHEQUEAR PERMISOS
            new MenuHotel().Show();
            this.Hide();
        }
    }
}
