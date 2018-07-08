using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmFacturacion
{
    public partial class Facturacion : Form
    {
        bool existe;
        string documento;
        string estadia;
        public Facturacion(string codigoEstadia)
        {
            InitializeComponent();
            estadia = codigoEstadia;
            cargarCampos(codigoEstadia);
            if (DataBase.realizarConsulta("select esta_codigo from CAIA_UNLIMITED.Factura where esta_codigo =" + codigoEstadia).Tables[0].Rows.Count == 0)
            {
                txtNroFactura.Text = DataBase.realizarConsulta("select max(fact_nro)+1 from CAIA_UNLIMITED.Factura").Tables[0].Rows[0][0].ToString();
                double totalAFacturar = 0;
                if ("All inclusive" != DataBase.realizarConsulta("select regi_descripcion from CAIA_UNLIMITED.Regimen R join CAIA_UNLIMITED.Reserva H on (R.regi_codigo = H.regi_codigo) join CAIA_UNLIMITED.Estadia E on (E.rese_codigo = H.rese_codigo) where esta_codigo =" + codigoEstadia).Tables[0].Rows[0][0].ToString().Trim())
                {
                    lblDescuentos.Visible = false;
                    txtDescuento.Visible = false;
                    for (int i = 0; i < dgConsumibles.Rows.Count; i++)
                    {
                        totalAFacturar += Convert.ToInt32(dgConsumibles.Rows[i].Cells[2].Value) * Convert.ToInt32(dgConsumibles.Rows[i].Cells[3].Value);
                    }
                }
                else if ("All inclusive" == DataBase.realizarConsulta("select regi_descripcion from CAIA_UNLIMITED.Regimen R join CAIA_UNLIMITED.Reserva H on (R.regi_codigo = H.regi_codigo) join CAIA_UNLIMITED.Estadia E on (E.rese_codigo = H.rese_codigo) where esta_codigo =" + codigoEstadia).Tables[0].Rows[0][0].ToString().Trim())
                {
                    double descuento = 0;
                    for (int i = 0; i < dgConsumibles.Rows.Count; i++)
                    {
                        descuento += Convert.ToInt32(dgConsumibles.Rows[i].Cells[2].Value) * Convert.ToInt32(dgConsumibles.Rows[i].Cells[3].Value);
                    }
                    txtDescuento.Text = Convert.ToString(descuento);
                }    
                totalAFacturar += Convert.ToInt32(txtNochesReserva.Text.Trim()) * (Convert.ToDouble(txtPrecioRegimen.Text.Trim()) * cantidadPersonas() + Convert.ToDouble(txtPorcentual.Text));
                txtTotal.Text = Convert.ToString(totalAFacturar);
                existe = false;
            }
            else
            {
                if ("All inclusive" == DataBase.realizarConsulta("select regi_descripcion from CAIA_UNLIMITED.Regimen R join CAIA_UNLIMITED.Reserva H on (R.regi_codigo = H.regi_codigo) join CAIA_UNLIMITED.Estadia E on (E.rese_codigo = H.rese_codigo) where esta_codigo =" + codigoEstadia).Tables[0].Rows[0][0].ToString().Trim())
                {
                    double descuento = 0;
                    for (int i = 0; i < dgConsumibles.Rows.Count; i++)
                    {
                        descuento += Convert.ToInt32(dgConsumibles.Rows[i].Cells[2].Value) * Convert.ToInt32(dgConsumibles.Rows[i].Cells[3].Value);
                    }
                    txtDescuento.Text = Convert.ToString(descuento);
                }
                else
                {
                    lblDescuentos.Visible = false;
                    txtDescuento.Visible = false;
                }
                existe = true;
                cargarFacturaExistente(codigoEstadia);
            }
            dgConsumibles.AllowUserToAddRows = false;
        }

        private double cantidadPersonas()
        {
            int cantidadPersonas = 0;
            DataTable tiposHabitacion = DataBase.realizarConsulta("select thab_descripcion from CAIA_UNLIMITED.Estadia E join CAIA_UNLIMITED.Reserva R on (E.rese_codigo = R.rese_codigo) join CAIA_UNLIMITED.Habitacion_X_Reserva X on (R.rese_codigo = X.habi_rese_codigo) join CAIA_UNLIMITED.Habitacion H on (H.hote_id = X.habi_rese_id and H.habi_numero = habi_rese_numero) join CAIA_UNLIMITED.Tipo_Habitacion T on (T.thab_codigo = H.thab_codigo) where esta_codigo=" + estadia).Tables[0];
            foreach (DataRow tipoHabitacion in tiposHabitacion.Rows)
            {
                if (tipoHabitacion[0].ToString() == "Base Simple")
                {
                   cantidadPersonas += 1;
                }
                else if (tipoHabitacion[0].ToString() == "Base Doble")
                {
                    cantidadPersonas += 2;
                }
                else if (tipoHabitacion[0].ToString() == "Base Triple")
                {
                    cantidadPersonas += 3;
                }
                else if (tipoHabitacion[0].ToString() == "Base Cuadruple")
                {
                    cantidadPersonas += 4;
                }
                else
                {
                    cantidadPersonas += 2;
                }
            }
            return cantidadPersonas;
        }

        private void cargarFacturaExistente(string codigoEstadia)
        {
            
            txtTotal.Text = DataBase.realizarConsulta("select fact_total from CAIA_UNLIMITED.Factura where esta_codigo =" + codigoEstadia).Tables[0].Rows[0][0].ToString();
            txtNroFactura.Text = DataBase.realizarConsulta("select fact_nro from CAIA_UNLIMITED.Factura where esta_codigo =" + codigoEstadia).Tables[0].Rows[0][0].ToString();
            txtNroFactura.ReadOnly = true;
        }

        private void cargarCampos(string codigoEstadia)
        {
            dgConsumibles.DataSource = DataBase.realizarConsulta("select cons_codigo as 'Codigo', cons_descripcion as 'Descripcion', cons_precio as 'Precio', cons_esta_cantidad as 'Cantidad' from CAIA_UNLIMITED.Consumible join CAIA_UNLIMITED.Consumible_X_Estadia on (cons_codigo = cons_esta_codigo_cons) where cons_esta_codigo_esta = " + codigoEstadia + " group by cons_codigo, cons_descripcion, cons_precio, cons_esta_cantidad").Tables[0];
            DataSet huesped = DataBase.realizarConsulta("select rese_hues_mail, rese_hues_documento from CAIA_UNLIMITED.Estadia E join CAIA_UNLIMITED.Reserva R on (E.rese_codigo = R.rese_codigo) join CAIA_UNLIMITED.Reserva_X_Huesped on (R.rese_codigo = rese_hues_codigo) where esta_codigo =" + codigoEstadia);
            txtHuesped.Text = huesped.Tables[0].Rows[0][0].ToString();
            documento = huesped.Tables[0].Rows[0][1].ToString();
            txtPrecioRegimen.Text = DataBase.realizarConsulta("select regi_precio_base from CAIA_UNLIMITED.Regimen R join CAIA_UNLIMITED.Reserva H on (R.regi_codigo = H.regi_codigo) join CAIA_UNLIMITED.Estadia E on (E.rese_codigo = H.rese_codigo) where esta_codigo =" + codigoEstadia).Tables[0].Rows[0][0].ToString();
            txtPorcentual.Text = DataBase.realizarConsulta("select H.hote_recarga_estrella * H.hote_cant_estrellas from CAIA_UNLIMITED.Hotel H join CAIA_UNLIMITED.Habitacion_X_Reserva X on (X.habi_rese_id = H.hote_id) join CAIA_UNLIMITED.Reserva R on (R.rese_codigo = X.habi_rese_codigo) join CAIA_UNLIMITED.Estadia E on (E.rese_codigo = R.rese_codigo) where esta_codigo = " + codigoEstadia).Tables[0].Rows[0][0].ToString();
            txtNochesReserva.Text = DataBase.realizarConsulta("select rese_cantidad_noches from CAIA_UNLIMITED.Reserva R join CAIA_UNLIMITED.Estadia E on (R.rese_codigo = E.rese_codigo) where esta_codigo = " + codigoEstadia).Tables[0].Rows[0][0].ToString();
            txtNochesEstadia.Text = Convert.ToString(Convert.ToDouble(txtNochesReserva.Text.Trim()) - Convert.ToDouble(DataBase.realizarConsulta("select DATEDIFF(day, esta_fecha_inicio, esta_fecha_fin) from CAIA_UNLIMITED.Estadia where esta_codigo =" + codigoEstadia).Tables[0].Rows[0][0].ToString()));
            txtCostoExtra.Text = (Convert.ToDouble(txtNochesEstadia.Text.Trim()) * Convert.ToDouble(txtPrecioRegimen.Text.Trim())).ToString();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!existe)
                {
                    ejecutarStoredProcedure();
                    existe = true;
                    new MedioDePago(txtNroFactura.Text.Trim()).ShowDialog();
                }
                else if (DataBase.realizarConsulta("select pago_codigo from CAIA_UNLIMITED.Factura where pago_codigo IS NOT NULL AND fact_nro =" + txtNroFactura.Text.Trim()).Tables[0].Rows.Count == 0)
                {
                    new MedioDePago(txtNroFactura.Text.Trim()).ShowDialog();
                }
                else
                {
                    MessageBox.Show("La factura ya se encuentra pagada.", "Factura pagada", MessageBoxButtons.OK);
                }
            }
            catch
            {
                MessageBox.Show("No se puede facturar.", "Facturacion erronea", MessageBoxButtons.OK);
            }
        }

        private void ejecutarStoredProcedure()
        {
            try
            {
                SqlConnection db = DataBase.conectarBD();
                SqlCommand agregarFactura = new SqlCommand("CAIA_UNLIMITED.sp_AlmacenarFactura", db);
                agregarFactura.CommandType = CommandType.StoredProcedure;
                agregarFactura.Parameters.AddWithValue("@numero", txtNroFactura.Text.Trim());
                agregarFactura.Parameters.AddWithValue("@total", txtTotal.Text.Trim());
                agregarFactura.Parameters.AddWithValue("@estadia", estadia);
                agregarFactura.Parameters.AddWithValue("@mail", txtHuesped.Text.Trim());
                agregarFactura.Parameters.AddWithValue("@documento", documento);
                agregarFactura.Parameters.AddWithValue("@fecha", DataBase.fechaSistema());
                agregarFactura.ExecuteNonQuery();
                foreach (DataGridViewRow item in dgConsumibles.Rows)
                {
                    SqlCommand agregarItemFactura = new SqlCommand("CAIA_UNLIMITED.sp_AlmacenarItem", db);
                    agregarItemFactura.CommandType = CommandType.StoredProcedure;
                    agregarItemFactura.Parameters.AddWithValue("@consumible", item.Cells[0].Value.ToString());
                    agregarItemFactura.Parameters.AddWithValue("@cantidad", item.Cells[3].Value.ToString());
                    agregarItemFactura.Parameters.AddWithValue("@monto", (Convert.ToDouble(item.Cells[2].Value) * Convert.ToDouble(item.Cells[3].Value)).ToString());
                    agregarItemFactura.Parameters.AddWithValue("@numero_factura", txtNroFactura.Text.Trim());
                }
                db.Close();
            }
            catch
            {
                MessageBox.Show("Error al llevar a cabo la facturacion", "Error de facturacion", MessageBoxButtons.OK);
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
