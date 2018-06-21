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

namespace FrbaHotel.CancelarReserva
{
    public partial class MenuCancelarReserva : Form
    {
        public MenuCancelarReserva()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (camposCompletos())
            {
                if (camposValidos())
                {
                    if (reservaCorrecta())
                    {
                        if (fechaEnCondicion())
                        {
                   
                        
                            if (cbxUsuario.SelectedItem.ToString() == "Huesped")
                            {
                                if (formatoMailCorrecto())
                                {
                                    string mailIngresado = String.Format("SELECT rese_hues_mail FROM CAIA_UNLIMITED.Reserva_X_Huesped where rese_hues_mail = '{0}'  and rese_hues_codigo = '{1}'", txtMail.Text.Trim(), txtNumero_Reserva.Text.Trim());

                                    if (DataBase.realizarConsulta(mailIngresado).Tables[0].Rows.Count == 0)
                                    {
                                        MessageBox.Show("El huesped no corresponde con la reserva", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        ejecutarStoredProcedureCancelarReserva();
                                        limpiarFormulario();
                                        MessageBox.Show("Reserva cancelada", "Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }

                            }
                            else if (cbxUsuario.SelectedItem.ToString() == "Recepcion")
                            {

                                string consultaHotelId = string.Format("SELECT habi_rese_id FROM CAIA_UNLIMITED.Habitacion_X_Reserva  WHERE habi_rese_codigo ='{0}'", txtNumero_Reserva.Text.Trim());
                                DataTable hotelIdObtenida = DataBase.realizarConsulta(consultaHotelId).Tables[0];
                                string hotelID = hotelIdObtenida.Rows[0][0].ToString();

                                string usernameIngresado = String.Format("SELECT usur_hote_username FROM CAIA_UNLIMITED.Usuario_X_Hotel  WHERE usur_hote_id='{0}' and usur_hote_username= '{1}'", hotelID,txtUsername.Text.Trim());

                                if (DataBase.realizarConsulta(usernameIngresado).Tables[0].Rows.Count == 0)
                                {
                                    MessageBox.Show("El usuario no corresponde con el hotel donde se registro la reserva", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    ejecutarStoredProcedureCancelarReserva();

                                    limpiarFormulario();

                                    MessageBox.Show("Reserva cancelada", "Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        
                                    
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Operacion cancelada, fecha proxima a fecha de inicio de reserva", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            txtMail.Clear();
            txtMotivo.Clear();
            txtNumero_Reserva.Clear();
            cbxUsuario.SelectedIndex = 0;
        }


        private bool reservaCorrecta()
        {
             string codigoReservaIngresado = String.Format("SELECT rese_codigo FROM CAIA_UNLIMITED.Reserva WHERE rese_codigo = '{0}'", txtNumero_Reserva.Text.Trim());

             if (DataBase.realizarConsulta(codigoReservaIngresado).Tables[0].Rows.Count == 0)
             {
                 MessageBox.Show("Codigo de reseva incorrecto.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                 return false;
             }
             else
             {
                 return true;
             }
        }


        private bool formatoMailCorrecto()
        {
            Regex expEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (!expEmail.IsMatch(txtMail.Text))
            {
                MessageBox.Show("Formato de mail ingresado incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void ejecutarStoredProcedureCancelarReserva()
        {
            SqlConnection db = DataBase.conectarBD();
            SqlCommand cancelarReserva = new SqlCommand("CAIA_UNLIMITED.sp_CancelarReserva", db);
            cancelarReserva.CommandType = CommandType.StoredProcedure;
            cancelarReserva.Parameters.AddWithValue("@codigo_Reserva", txtNumero_Reserva.Text.Trim());
            cancelarReserva.Parameters.AddWithValue("@motivo", txtMotivo.Text.Trim());
            //FECHA ACTUAL
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

             //FECHA ACTUAL
             if (DateTime.Parse(fechaIngresoReserva)==DateTime.Parse(txtCancelacion.Text.Trim()) )
             {
                 return false;
             }
             else
             {
                 return true;
             }

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
            if (txtMail.Text.Trim() == "" && txtUsername.Text.Trim()=="")
            {
                MessageBox.Show("Ingrese el mail/usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void cbxUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(cbxUsuario.SelectedItem) == "Huesped")
            {
                txtUsername.Enabled = false;
                txtMail.Enabled = true;
            }
            else
            {
                txtUsername.Enabled = true;
                txtMail.Enabled = false;
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            txtCancelacion.Text = calendario.SelectionStart.ToShortDateString();
        }

    }
}
