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
    public partial class PagarTarjeta : Form
    {
        string numeroFactura;
        public PagarTarjeta(string nroFactura)
        {
            InitializeComponent();
            numeroFactura = nroFactura;
            ocultarErrores();
            txtTotal.Text = DataBase.realizarConsulta("select fact_total from CAIA_UNLIMITED.Factura where fact_nro =" + nroFactura).Tables[0].Rows[0][0].ToString();
        }

        private void ocultarErrores()
        {
            lblApellido.Visible = false;
            lblBanco.Visible = false;
            lblCodigo.Visible = false;
            lblFecha.Visible = false;
            lblNombre.Visible = false;
            lblNumero.Visible = false;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ocultarErrores();
            if (completo())
            {
                   try
                   {
                       ejecutarStoredProcedure();
                       MessageBox.Show("Pago realizado correctamente.", "Pago realizado", MessageBoxButtons.OK);
                       this.Hide();
                   }
                   catch
                   {
                       MessageBox.Show("No se pudo llevar a cabo el pago con tarjeta.", "Error de pago", MessageBoxButtons.OK);
                   }
               }
        }

        private void ejecutarStoredProcedure()
        {
                SqlConnection db = DataBase.conectarBD();
                SqlCommand agregarPago = new SqlCommand("CAIA_UNLIMITED.sp_AlmacenarPagoTarjeta", db);
                agregarPago.CommandType = CommandType.StoredProcedure;
                agregarPago.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                agregarPago.Parameters.AddWithValue("@apellido", txtApellido.Text.Trim());
                agregarPago.Parameters.AddWithValue("@numero_tarjeta", txtNroTarjeta.Text.Trim());
                agregarPago.Parameters.AddWithValue("@codigo_seguridad", txtCodigo.Text.Trim());
                agregarPago.Parameters.AddWithValue("@banco", txtBanco.Text.Trim());
                agregarPago.Parameters.AddWithValue("@fecha_vencimiento", dtVencimiento.Value);
                agregarPago.Parameters.AddWithValue("@monto", Convert.ToDouble(txtTotal.Text.Trim()));
                agregarPago.Parameters.AddWithValue("@numero_factura", numeroFactura);
                agregarPago.ExecuteNonQuery();
                db.Close();
        }

        private bool camposCorrectos()
        {
            int a, b;
            return Int32.TryParse(txtNroTarjeta.Text.Trim(), out a) && Int32.TryParse(txtCodigo.Text.Trim(), out b);
        }

        private bool completo()
        {
            double o;
            int aux;
            if (txtNombre.Text.Trim() == "")
            {
                lblNombre.Visible = true;
            }
            else if (txtApellido.Text.Trim() == "")
            {
                lblApellido.Visible = true;
            }
            else if (txtNroTarjeta.Text.Trim() == "")
            {
                lblNumero.Visible = true;
            }
            else if(!Double.TryParse(txtNroTarjeta.Text.Trim(), out o))
            {
                MessageBox.Show("El numero de tarjeta debe ser numero.", "Campo invalido", MessageBoxButtons.OK);
                lblNumero.Visible = true;
                return false;
            }
            else if (txtNroTarjeta.Text.Trim().Length > 20)
            {
                MessageBox.Show("El numero de tarjeta tiene como maximo veinte digitos", "Campo invalido", MessageBoxButtons.OK);
                lblNumero.Visible = true;
                return false;
            }
            else if (txtCodigo.Text.Trim() == "")
            {
                lblCodigo.Visible = true;
            }
            else if (!int.TryParse(txtCodigo.Text.Trim(), out aux))
            {
                MessageBox.Show("El codigo de seguridad debe ser numero.", "Campo invalido", MessageBoxButtons.OK);
                lblCodigo.Visible = true;
                return false;
            }
            else if (txtCodigo.Text.Trim().Length > 4)
            {
                MessageBox.Show("El codigo de seguridad tiene como maximo cuatro digitos", "Campo invaldo", MessageBoxButtons.OK);
                lblCodigo.Visible = true;
                return false;
            }
            else if (txtBanco.Text.Trim() == "")
            {
                lblBanco.Visible = true;
            }
            else if (dtVencimiento.Value <= DateTime.Now)
            {
                lblFecha.Visible = true;
            }
            else
            {
                return true;
            }
            MessageBox.Show("Complete los campos vacios o erroneos", "Campos invalidos", MessageBoxButtons.OK);
            return false;
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            ocultarErrores();
            txtApellido.Clear();
            txtBanco.Clear();
            txtCodigo.Clear();
            txtNombre.Clear();
            txtNroTarjeta.Clear();
        }
    }
}
