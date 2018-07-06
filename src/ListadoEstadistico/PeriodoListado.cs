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

namespace FrbaHotel.ListadoEstadistico
{
    public partial class PeriodoListado : Form
    {
        public PeriodoListado()
        {
            InitializeComponent();
            cbTrimestre.SelectedIndex = 0;
            cbListado.SelectedIndex = 0;
            lblAno.Visible = false;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int aux;
            if (txtAno.Text.Trim() == "")
            {
                MessageBox.Show("Falta el año de la consulta", "Faltan datos", MessageBoxButtons.OK);
                this.Show();
                lblAno.Visible = true;
            }
            else if (!Int32.TryParse(txtAno.Text.Trim(), out aux))
            {
                MessageBox.Show("El año debe ser un numero", "Error de datos", MessageBoxButtons.OK);
                this.Show();
            }
            else
            {
                string anio = txtAno.Text.Trim();
                string trimestre = (cbTrimestre.SelectedIndex + 1).ToString();
                int listado = cbListado.SelectedIndex;
                switch (listado)
                {
                    case 0:
                        {
                            DataTable canceladas = DataBase.realizarConsulta("SELECT TOP 5 H.hote_id as 'ID', hote_nombre as 'Nombre' FROM CAIA_UNLIMITED.Hotel H join CAIA_UNLIMITED.Habitacion_X_Reserva X on (X.habi_rese_id = H.hote_id)	join CAIA_UNLIMITED.Reserva R on (R.rese_codigo = X.habi_rese_codigo) join CAIA_UNLIMITED.Reserva_Cancelada C on (C.reca_rese = R.rese_codigo) WHERE DATEPART(QUARTER, R.rese_fecha_desde) = " + trimestre + " and YEAR(R.rese_fecha_desde) = " + anio + " GROUP BY H.hote_id, hote_nombre ORDER BY COUNT(*) desc").Tables[0];
                            if (canceladas.Rows.Count == 0)
                            {
                                MessageBox.Show("No hay datos suficientes para listar", "Faltan datos", MessageBoxButtons.OK);
                            }
                            else
                            {
                                new MasCanceladas(canceladas).ShowDialog();
                                this.Show();
                            }
                        };
                        break;
                    case 1:
                        {
                            DataTable consumibles = DataBase.realizarConsulta("select top 5 H.hote_id 'ID', hote_nombre as 'Nombre' from CAIA_UNLIMITED.Hotel H join CAIA_UNLIMITED.Habitacion_X_Reserva X on (X.habi_rese_id = H.hote_id) join CAIA_UNLIMITED.Estadia E on (E.rese_codigo = X.habi_rese_codigo) join CAIA_UNLIMITED.Factura F on (F.esta_codigo = E.esta_codigo) join CAIA_UNLIMITED.Item_Factura I on (F.fact_nro = I.fact_nro) where DATEPART(QUARTER, fact_fecha) = " + trimestre + " and YEAR(fact_fecha) = " + anio + " group by H.hote_id, hote_nombre order by sum(I.item_cantidad) desc ").Tables[0];
                            if (consumibles.Rows.Count == 0)
                            {
                                MessageBox.Show("No hay datos suficientes para listar", "Faltan datos", MessageBoxButtons.OK);
                            }
                            else
                            {
                                new MayorFacturacionConsumibles(consumibles).ShowDialog();
                                this.Show();
                            }
                        };
                        break;
                    case 2:
                        {
                            DataTable mantenimientos = DataBase.realizarConsulta("select top 5 H.hote_id as 'ID', hote_nombre as 'Nombre' from CAIA_UNLIMITED.Hotel H join CAIA_UNLIMITED.Mantenimiento M on (H.hote_id = M.hote_id) where DATEPART(quarter, M.mant_fecha_inicio) = " + trimestre + " and YEAR(M.mant_fecha_inicio) = " + anio + " group by H.hote_id, hote_nombre order by sum(datediff(day, mant_fecha_inicio, mant_fecha_fin)) desc").Tables[0];
                            if (mantenimientos.Rows.Count == 0)
                            {
                                MessageBox.Show("No hay datos suficientes para listar", "Faltan datos", MessageBoxButtons.OK);
                            }
                            else
                            {
                                new MasMantenimiento(mantenimientos).ShowDialog();
                                this.Show();
                            }
                        };
                        break;
                    case 3:
                        {
                            DataTable ocupadas = DataBase.realizarConsulta("select top 5 A.habi_numero as 'Habitacion', A.hote_id as 'Hotel', A.habi_piso as 'Piso', A.habi_frente as 'Frente'  from CAIA_UNLIMITED.Habitacion A join CAIA_UNLIMITED.Hotel H on (H.hote_id = A.hote_id) join CAIA_UNLIMITED.Habitacion_X_Reserva X on (X.habi_rese_id = H.hote_id and X.habi_rese_numero = A.habi_numero) join CAIA_UNLIMITED.Estadia E on (X.habi_rese_codigo = E.rese_codigo) where DATEPART(QUARTER, E.esta_fecha_inicio) = " + trimestre + " and YEAR(E.esta_fecha_inicio) = " + anio + " group by A.habi_numero, A.hote_id, A.habi_piso, A.habi_frente order by sum(DATEDIFF(day, E.esta_fecha_inicio, E.esta_fecha_fin)), count(*) desc").Tables[0]; 
                            if (ocupadas.Rows.Count == 0)
                            {
                                MessageBox.Show("No hay datos suficientes para listar", "Faltan datos", MessageBoxButtons.OK);
                            }
                            else
                            {
                                new MasOcupadas(ocupadas).ShowDialog();
                                this.Show();
                            }
                        };
                        break;
                    case 4:
                        {
                            DataTable clientes = DataBase.realizarConsulta("select top 5 H.hues_mail as 'Mail', H.hues_documento as 'Documento', hues_nombre as 'Nombre', hues_apellido as 'Apellido' from CAIA_UNLIMITED.Factura F join CAIA_UNLIMITED.Item_Factura I on (F.fact_nro = I.fact_nro) join CAIA_UNLIMITED.Huesped H on (F.hues_documento = H.hues_documento and F.hues_mail = H.hues_mail) where DATEPART(QUARTER, fact_fecha) = " + trimestre + " and YEAR(fact_fecha) = " + anio + " group by H.hues_mail, H.hues_documento, hues_nombre, hues_apellido order by sum((I.item_monto*I.item_cantidad)/10) + sum((F.fact_total-(I.item_monto*I.item_cantidad))/20) desc").Tables[0]; 
                            if (clientes.Rows.Count == 0)
                            {
                                MessageBox.Show("No hay datos suficientes para listar", "Faltan datos", MessageBoxButtons.OK);
                            }
                            else
                            {
                                new MasPuntosCliente(clientes).ShowDialog();
                                this.Show();
                            }
                        };
                        break;
                }
            }

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
