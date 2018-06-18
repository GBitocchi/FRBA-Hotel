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
        bool existe = false;
        string documento;
        string estadia;
        public Facturacion(string codigoEstadia)
        {
            InitializeComponent();
            estadia = codigoEstadia;
            cargarCampos(codigoEstadia);
            if (DataBase.realizarConsulta("select esta_codigo from CAIA_UNLIMITED.Factura where esta_codigo =" + codigoEstadia).Tables[0].Rows.Count == 0)
            {
                
                double totalAFacturar = 0;
                if ("All inclusive" != DataBase.realizarConsulta("select regi_descripcion from CAIA_UNLIMITED.Regimen R join CAIA_UNLIMITED.Reserva H on (R.regi_codigo = H.regi_codigo) join CAIA_UNLIMITED.Estadia E on (E.rese_codigo = H.rese_codigo) where esta_codigo =" + codigoEstadia).ToString().Trim())
                {
                    for (int i = 0; i < dgConsumibles.Rows.Count; i++)
                    {
                        totalAFacturar += Convert.ToInt32(dgConsumibles.Rows[i].Cells[2].Value) * Convert.ToInt32(dgConsumibles.Rows[i].Cells[3].Value);
                    }
                }
                totalAFacturar += Convert.ToInt32(txtNoches.Text.Trim()) * Convert.ToDouble(txtPrecioRegimen.Text.Trim()) * cantidadPersonas();
                txtTotal.Text = Convert.ToString(totalAFacturar);
            }
            else
            {
                existe = true;
                cargarFacturaExistente(codigoEstadia);
            }
            lblNroFactura.Visible = false;
            
        }

        private double cantidadPersonas()
        {
            string tipoHabitacion = DataBase.realizarConsulta("select thab_descripcion from CAIA_UNLIMITED.Estadia E join CAIA_UNLIMITED.Reserva R on (E.rese_codigo = R.rese_codigo) join CAIA_UNLIMITED.Habitacion H on (R.hote_id = H.hote_id and R.habi_numero = H.habi_numero) join CAIA_UNLIMITED.Tipo_Habitacion T on (H.thab_codigo = T.thab_codigo) where esta_codigo=" + estadia).Tables[0].Rows[0][0].ToString();
            if (tipoHabitacion == "Base Simple")
            {
                return 1;
            }
            else if (tipoHabitacion == "Base Doble")
            {
                return 2;
            }
            else if (tipoHabitacion == "Base Triple")
            {
                return 3;
            }
            else if (tipoHabitacion == "Base Cuadruple")
            {
                return 4;
            }
            else
            {
                return 2;
            }
        }

        private void cargarFacturaExistente(string codigoEstadia)
        {
            
            txtTotal.Text = DataBase.realizarConsulta("select fact_total from CAIA_UNLIMITED.Factura where esta_codigo =" + codigoEstadia).Tables[0].Rows[0][0].ToString();
            txtNroFactura.Text = DataBase.realizarConsulta("select fact_nro from CAIA_UNLIMITED.Factura where esta_codigo =" + codigoEstadia).Tables[0].Rows[0][0].ToString();
            txtNroFactura.ReadOnly = true;
        }

        private void cargarCampos(string codigoEstadia)
        {
            dgConsumibles.DataSource = DataBase.realizarConsulta("select cons_codigo as 'Codigo', cons_descripcion as 'Descripcion', cons_precio as 'Precio', count(*) as 'Cantidad' from CAIA_UNLIMITED.Consumible join CAIA_UNLIMITED.Consumible_X_Estadia on (cons_codigo = cons_esta_codigo_cons) where cons_esta_codigo_esta = " + codigoEstadia + " group by cons_codigo, cons_descripcion, cons_precio").Tables[0];
            DataSet huesped = DataBase.realizarConsulta("select rese_hues_mail, rese_hues_documento from CAIA_UNLIMITED.Estadia E join CAIA_UNLIMITED.Reserva R on (E.rese_codigo = R.rese_codigo) join CAIA_UNLIMITED.Reserva_X_Huesped on (R.rese_codigo = rese_hues_codigo) where esta_codigo =" + codigoEstadia);
            txtHuesped.Text = huesped.Tables[0].Rows[0][0].ToString();
            documento = huesped.Tables[0].Rows[0][1].ToString();
            txtPrecioRegimen.Text = DataBase.realizarConsulta("select regi_precio_base from CAIA_UNLIMITED.Regimen R join CAIA_UNLIMITED.Reserva H on (R.regi_codigo = H.regi_codigo) join CAIA_UNLIMITED.Estadia E on (E.rese_codigo = H.rese_codigo) where esta_codigo =" + codigoEstadia).Tables[0].Rows[0][0].ToString();
            txtPorcentual.Text = DataBase.realizarConsulta("select thab_porcentual from CAIA_UNLIMITED.Tipo_Habitacion T join CAIA_UNLIMITED.Habitacion H on (T.thab_codigo = H.thab_codigo) join CAIA_UNLIMITED.Reserva R on (H.hote_id = R.hote_id and H.habi_numero = R.habi_numero) join CAIA_UNLIMITED.Estadia E on (R.rese_codigo = E.rese_codigo) where esta_codigo =" + codigoEstadia).Tables[0].Rows[0][0].ToString();
            txtNoches.Text = DataBase.realizarConsulta("select esta_cantidad_noches from CAIA_UNLIMITED.Estadia where esta_codigo =" + codigoEstadia).Tables[0].Rows[0][0].ToString();

        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            lblNroFactura.Visible = false;
            try
            {
                if (!existe)
                {
                    if (txtNroFactura.Text.Trim() != "")
                    {
                        ejecutarStoredProcedure();
                        this.Hide();
                        new MedioDePago(txtNroFactura.Text.Trim()).Show();
                    }
                    else
                    {
                        lblNroFactura.Visible = true;
                    }
                      }
                else if (DataBase.realizarConsulta("select pago_codigo from CAIA_UNLIMITED.Factura where pago_codigo IS NOT NULL AND fact_nro =" + txtNroFactura.Text.Trim()).Tables[0].Rows.Count == 0)
                {
                    this.Hide();
                    new MedioDePago(txtNroFactura.Text.Trim()).Show();
                }
                else
                {
                    new FacturaYaPagada().Show();
                }
            }
            catch
            {
                new FacturaInvalida().Show();
            }
        }

        private void ejecutarStoredProcedure()
        {
            SqlConnection db = DataBase.conectarBD();
            SqlCommand agregarFactura = new SqlCommand("sp_AlmacenarFactura", db);
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
                SqlCommand agregarItemFactura = new SqlCommand("sp_AlmacenarItem", db);
                agregarItemFactura.CommandType = CommandType.StoredProcedure;
                agregarItemFactura.Parameters.AddWithValue("@consumible",item.Cells[0].Value.ToString());
                agregarItemFactura.Parameters.AddWithValue("@cantidad", item.Cells[3].Value.ToString());
                agregarItemFactura.Parameters.AddWithValue("@monto", (Convert.ToDouble(item.Cells[2].Value) * Convert.ToDouble(item.Cells[3].Value)).ToString());
                agregarItemFactura.Parameters.AddWithValue("@numero_factura", txtNroFactura.Text.Trim());
            }    
            db.Close();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
            new EstadiasAFacturar().Show();
        }
    }
}
