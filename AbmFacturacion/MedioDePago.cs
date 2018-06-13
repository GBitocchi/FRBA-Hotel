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

namespace FrbaHotel.AbmFacturacion
{
    public partial class MedioDePago : Form
    {
        string numeroFactura;
        public MedioDePago(string nroFactura)
        {
            InitializeComponent();
            numeroFactura = nroFactura;
        }

        private void btnEfectivo_Click(object sender, EventArgs e)
        {
            try
            {
                ejecutarStoredProcedure();
                this.Hide();
                new PagoRealizado().Show();
            }
            catch
            {
                new ErrorDePago().Show();
            }
        }

        private void ejecutarStoredProcedure()
        {
            string total = DataBase.realizarConsulta("select fact_total from CAIA_UNLIMITED.Factura where fact_nro=" + numeroFactura).Tables[0].Rows[0][0].ToString();
            SqlConnection db = DataBase.conectarBD();
            SqlCommand agregarPago = new SqlCommand("sp_AlmacenarPagoEfectivo", db);
            agregarPago.CommandType = CommandType.StoredProcedure;
            agregarPago.Parameters.AddWithValue("@monto", total);
            agregarPago.Parameters.AddWithValue("@factura_numero", numeroFactura);
            agregarPago.ExecuteNonQuery();
            db.Close();
        }

        private void btnTarjeta_Click(object sender, EventArgs e)
        {
            this.Hide();
            new PagarTarjeta(numeroFactura).Show();
        }
    }
}
