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
                MessageBox.Show("Pago realizado correctamente.", "Pago realizado", MessageBoxButtons.OK);
                this.Hide();
            }
            catch
            {
                MessageBox.Show("No se pudo llevar a cabo el pago.", "Pago erroneo", MessageBoxButtons.OK);
            }
        }

        private void ejecutarStoredProcedure()
        {
            try
            {
                string total = DataBase.realizarConsulta("select fact_total from CAIA_UNLIMITED.Factura where fact_nro=" + numeroFactura).Tables[0].Rows[0][0].ToString();
                SqlConnection db = DataBase.conectarBD();
                SqlCommand agregarPago = new SqlCommand("CAIA_UNLIMITED.sp_AlmacenarPagoEfectivo", db);
                agregarPago.CommandType = CommandType.StoredProcedure;
                agregarPago.Parameters.AddWithValue("@monto", Convert.ToDouble(total));
                agregarPago.Parameters.AddWithValue("@numero_factura", numeroFactura);
                agregarPago.ExecuteNonQuery();
                db.Close();

            }
            catch
            {
                MessageBox.Show("No se pudo realizar el pago en efectivo", "Error de pago", MessageBoxButtons.OK);
            }
        }

        private void btnTarjeta_Click(object sender, EventArgs e)
        {
            new PagarTarjeta(numeroFactura).ShowDialog();
            this.Hide();
        }
    }
}
