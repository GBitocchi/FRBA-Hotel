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
using System.Text.RegularExpressions;

namespace FrbaHotel.RegistrarEstadia
{
    public partial class CancelarReservaHuesped : Form
    {
        private Registrar formulario;
        string idHotelActual;
        public CancelarReservaHuesped(string username, string codigoReserva, string idHotel, Registrar formuRegistrar)
        {
            InitializeComponent();
            txtUsername.Text = username;
            txtNumero_Reserva.Text = codigoReserva;
            txtNumero_Reserva.Enabled = false;
            txtUsername.Enabled = false;
            txtCancelacion.Text = Convert.ToString(DataBase.fechaSistema());
            idHotelActual = idHotel;
            this.formulario = formuRegistrar;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (camposCompletos())
            {
                if (camposValidos())
                {
                    if (reservaCorrecta())
                    {
                        
                           

                                string consultaIdUsuario = string.Format("SELECT usur_id FROM CAIA_UNLIMITED.Usuario  WHERE usur_username ='{0}'", txtUsername.Text.Trim());
                                DataTable idUsuarioObtenido = DataBase.realizarConsulta(consultaIdUsuario).Tables[0];
                                string idUsuario = idUsuarioObtenido.Rows[0][0].ToString();

                                string usernameIngresado = String.Format("SELECT usur_hote_idusur FROM CAIA_UNLIMITED.Usuario_X_Hotel  WHERE usur_hote_idhote='{0}' and usur_hote_idusur= '{1}'", idHotelActual, idUsuario);

                                if (DataBase.realizarConsulta(usernameIngresado).Tables[0].Rows.Count == 0)
                                {
                                    MessageBox.Show("El usuario no corresponde con el hotel donde se registro la reserva", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    ejecutarStoredProcedureCancelarReservaUsuario();

                                    limpiarFormulario();

                                    MessageBox.Show("Reserva cancelada", "Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    this.Close();

                                }
                            
                    }
                }


            }
            else
            {
                MessageBox.Show("Complete todo los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void limpiarFormulario()
        {
            txtCancelacion.Clear();
            txtUsername.Clear();
            txtMotivo.Clear();
            txtNumero_Reserva.Clear();
        }


        private bool reservaCorrecta()
        {
            string codigoReservaIngresado = String.Format("SELECT rese_codigo FROM CAIA_UNLIMITED.Reserva WHERE rese_codigo = '{0}'", txtNumero_Reserva.Text.Trim());

            if (DataBase.realizarConsulta(codigoReservaIngresado).Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Codigo de reseva incorrecto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

       

        private bool camposValidos()
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtNumero_Reserva.Text, @"^\d+$"))
            {
                MessageBox.Show("Solo se permiten valores numericos en el numero de reserva", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            else
            {
                return true;
            }
        }

        private void ejecutarStoredProcedureCancelarReservaUsuario()
        {
            SqlConnection db = DataBase.conectarBD();
            SqlCommand cancelarReserva = new SqlCommand("CAIA_UNLIMITED.sp_CancelarReservaUsuario", db);
            cancelarReserva.CommandType = CommandType.StoredProcedure;
            cancelarReserva.Parameters.AddWithValue("@codigo_Reserva", txtNumero_Reserva.Text.Trim());
            cancelarReserva.Parameters.AddWithValue("@motivo", txtMotivo.Text.Trim());

            cancelarReserva.Parameters.AddWithValue("@fecha_cancelacion", DateTime.Parse(txtCancelacion.Text));

            string consultaIdUsuario = string.Format("SELECT usur_id FROM CAIA_UNLIMITED.Usuario  WHERE usur_username ='{0}'", txtUsername.Text.Trim());
            DataTable idUsuarioObtenido = DataBase.realizarConsulta(consultaIdUsuario).Tables[0];
            string idUsuario = idUsuarioObtenido.Rows[0][0].ToString();

            cancelarReserva.Parameters.AddWithValue("@usuario", Convert.ToInt32(idUsuario));
            cancelarReserva.Parameters.AddWithValue("@estado", "Reserva cancelada por Non-Show");
            cancelarReserva.ExecuteNonQuery();
            db.Close();
        }

      


        private bool camposCompletos()
        {
            if (txtNumero_Reserva.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el numero de reserva", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtCancelacion.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la fecha", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtMotivo.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el motivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }  
            return true;
        }

        private void txtMail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
      

    }
}
