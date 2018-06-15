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
            DataTable mantenimientos = DataBase.realizarConsulta("select * from CAIA_UNLIMITED.vw_MantenimientosTerminados").Tables[0];
            foreach (DataRow mantenimiento in mantenimientos.Rows)
            {
                SqlConnection db = DataBase.conectarBD();
                SqlCommand altaHotel = new SqlCommand("CAIA_UNLIMITED.sp_AltaHotel", db);
                altaHotel.CommandType = CommandType.StoredProcedure;
                altaHotel.Parameters.AddWithValue("@idHotel", mantenimiento[0]);
                altaHotel.ExecuteNonQuery();
                db.Close();
            }
        }

        private void btnHotel_Click(object sender, EventArgs e)
        {
            //CHEQUEAR PERMISOS
            new MenuHotel().Show();
            this.Hide();
        }
    }
}
