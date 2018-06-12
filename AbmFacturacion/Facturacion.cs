using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public Facturacion(string codigoEstadia)
        {
            InitializeComponent();
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
                totalAFacturar += Convert.ToInt32(txtNoches.Text.Trim()) * Convert.ToDouble(txtPrecioRegimen.Text.Trim());
                txtTotal.Text = Convert.ToString(totalAFacturar);
            }
            else
            {
                cargarFacturaExistente(codigoEstadia);
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
            txtHuesped.Text = DataBase.realizarConsulta("select rese_hues_mail from CAIA_UNLIMITED.Estadia E join CAIA_UNLIMITED.Reserva R on (E.rese_codigo = R.rese_codigo) join CAIA_UNLIMITED.Reserva_X_Huesped on (R.rese_codigo = rese_hues_codigo) where esta_codigo =" + codigoEstadia).Tables[0].Rows[0][0].ToString();
            txtPrecioRegimen.Text = DataBase.realizarConsulta("select regi_precio_base from CAIA_UNLIMITED.Regimen R join CAIA_UNLIMITED.Reserva H on (R.regi_codigo = H.regi_codigo) join CAIA_UNLIMITED.Estadia E on (E.rese_codigo = H.rese_codigo) where esta_codigo =" + codigoEstadia).Tables[0].Rows[0][0].ToString();
            txtPorcentual.Text = DataBase.realizarConsulta("select thab_porcentual from CAIA_UNLIMITED.Tipo_Habitacion T join CAIA_UNLIMITED.Habitacion H on (T.thab_codigo = H.thab_codigo) join CAIA_UNLIMITED.Reserva R on (H.hote_id = R.hote_id and H.habi_numero = R.habi_numero) join CAIA_UNLIMITED.Estadia E on (R.rese_codigo = E.rese_codigo) where esta_codigo =" + codigoEstadia).Tables[0].Rows[0][0].ToString();
            txtNoches.Text = DataBase.realizarConsulta("select esta_cantidad_noches from CAIA_UNLIMITED.Estadia where esta_codigo =" + codigoEstadia).Tables[0].Rows[0][0].ToString();

        }

        private void btnPagar_Click(object sender, EventArgs e)
        {

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
            new EstadiasAFacturar().Show();
        }
    }
}
