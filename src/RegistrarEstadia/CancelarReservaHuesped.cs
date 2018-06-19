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

namespace FrbaHotel.RegistrarEstadia
{
    public partial class CancelarReservaHuesped : Form
    {
        public CancelarReservaHuesped(string username, string codigoReserva)
        {
            InitializeComponent();
            cbxUsuario.SelectedIndex=1;
            txtUsername.Text = username;
            txtNumero_Reserva.Text = codigoReserva;
            txtNumero_Reserva.Enabled = false;
            txtUsername.Enabled = false;
            cbxUsuario.Enabled = false;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (camposCompletos())
            {
                if (fechaEnCondicion())
                {
                    if (cbxUsuario.SelectedItem.ToString() == "Huesped")
                    {
                        string mailIngresado = String.Format("SELECT hues_mail FROM CAIA_UNLIMITED.Reserva_X_Huesped WHERE hues_mail = '{0}'  AND rese_codigo = '{1}'", txtMail.Text.Trim(), txtNumero_Reserva.Text.Trim());

                        if (DataBase.realizarConsulta(mailIngresado).Tables[0].Rows.Count == 0)
                        {
                            ejecutarStoredProcedureCancelarReserva();
                        }
                        else
                        {
                            MessageBox.Show("El huesped no correspondo con la reserva");
                        }

                    }
                    else if (cbxUsuario.SelectedItem.ToString() == "Recepcion")
                    {
                        string usernameIngresado = String.Format("SELECT usur_username FROM CAIA_UNLIMITED.Usuario_X_Hotel X join CAIA_UNLIMITED.Reserva R on (X.hote_id = R.hote_id) WHERE rese_codigo = '{0}'", txtNumero_Reserva.Text.Trim());

                        if (DataBase.realizarConsulta(usernameIngresado).Tables[0].Rows.Count == 0)
                        {
                            ejecutarStoredProcedureCancelarReserva();
                            this.Hide();
                            //VOLVER A REGISTRAR
                        }
                        else
                        {
                            MessageBox.Show("El usuario no correspondo con el hotel donde se registro la reserva");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Operacion cancelada, fecha proxima a fecha de inicio de reserva");
                }

            }
            else
            {
                MessageBox.Show("Complete todo los campos");
            }
        }


        private void ejecutarStoredProcedureCancelarReserva()
        {
            SqlConnection db = DataBase.conectarBD();
            SqlCommand cancelarReserva = new SqlCommand("sp_CancelarReserva", db);
            cancelarReserva.CommandType = CommandType.StoredProcedure;
            cancelarReserva.Parameters.AddWithValue("@codigo_Reserva", txtNumero_Reserva.Text.Trim());
            cancelarReserva.Parameters.AddWithValue("@motivo", txtMotivo.Text.Trim());
            cancelarReserva.Parameters.AddWithValue("@fecha_cancelacion", DateTime.Parse(txtCancelacion.Text));
            if (cbxUsuario.SelectedItem.ToString() == "Huesped")
            {
                cancelarReserva.Parameters.AddWithValue("@usuario", txtMail.Text.Trim());
            }
            else
            {
                cancelarReserva.Parameters.AddWithValue("@usuario", txtUsername.Text.Trim());
            }
            cancelarReserva.ExecuteNonQuery();
            db.Close();
        }

        private bool fechaEnCondicion()
        {
            string consultaFecha = string.Format("select rese_fecha_desde as 'Fecha inicio' from CAIA_UNLIMITED.Reserva where rese_codigo='{0}'", txtNumero_Reserva.Text.Trim());
            DataTable fecha = DataBase.realizarConsulta(consultaFecha).Tables[0];
            string fechaIngresoReserva = fecha.Rows[0][0].ToString();

            if (DateTime.Parse(txtCancelacion.Text).Day < DateTime.Parse(fechaIngresoReserva).Day && DateTime.Parse(txtCancelacion.Text).Month == DateTime.Parse(fechaIngresoReserva).Month && DateTime.Parse(txtCancelacion.Text).Year == DateTime.Parse(fechaIngresoReserva).Year)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        private bool camposCompletos()
        {
            if (txtNumero_Reserva.Text.Trim() == "")
            {
                return false;
            }
            if (txtCancelacion.Text.Trim() == "")
            {
                return false;
            }
            if (txtMotivo.Text.Trim() == "")
            {
                return false;
            }
            if (txtMail.Text.Trim() == "" || txtUsername.Text.Trim() == "")
            {
                return false;
            }
            return true;
        }       

        private void cbxUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxUsuario.SelectedItem.ToString() == "Huesped")
            {
                txtUsername.Enabled = false;
            }
            else
            {
                txtMail.Enabled = false;
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            txtCancelacion.Text = calendario.SelectionStart.ToShortDateString();
        }
    }
}
