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
        string idHotelActual;
        Boolean esUsuario;
        public MenuCancelarReserva(String idHotel)
        {
            InitializeComponent();
            txtCancelacion.Text = Convert.ToString(DataBase.fechaSistema());
            idHotelActual = idHotel;
            cbxUsuario.Enabled = false;
       
            cbxUsuario.SelectedIndex = 1;
            txtMail.Enabled = false;
            esUsuario = true;            
        }

        public MenuCancelarReserva()
        {
            InitializeComponent();
            txtCancelacion.Text = Convert.ToString(DataBase.fechaSistema());
            cbxUsuario.SelectedIndex = 0;
            txtUsername.Enabled = false;
            esUsuario = false;
            cbxUsuario.Enabled = false;
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
                        if (esUsuario)
                        {
                            if (perteneceAlHotel())
                            {
                                ejecutarRestoPrograma();
                            }

                        }
                        else
                        {
                            ejecutarRestoPrograma();
                        }

                        
                        
                        
                        
                        
                            
                        
                    }
                }     
            

            }
            else
            {
                MessageBox.Show("Complete todo los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ejecutarRestoPrograma()
        {
            if (reservaNoCancelada())
            {
                if (noTerminoReserva())
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
                                    ejecutarStoredProcedureCancelarReservaHuesped();
                                    limpiarFormulario();
                                    MessageBox.Show("Reserva cancelada", "Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }

                        }
                        else if (cbxUsuario.SelectedItem.ToString() == "Recepcion")
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


                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Operacion cancelada, fecha proxima a fecha de inicio de reserva", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Operacion cancelada, la reserva ya finalizo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }


        }




        private bool perteneceAlHotel()
        {
            string codigoHotel = String.Format("select habi_rese_codigo from CAIA_UNLIMITED.Habitacion_X_Reserva where habi_rese_codigo='{0}' AND habi_rese_id='{1}' ", txtNumero_Reserva.Text.Trim(), idHotelActual);

            if (DataBase.realizarConsulta(codigoHotel).Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("El codigo de reserva no corresponde al hotel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;

        }

        private void limpiarFormulario()
        {
            txtCancelacion.Clear();
            txtUsername.Clear();
            txtMail.Clear();
            txtMotivo.Clear();
            txtNumero_Reserva.Clear();
        }


        private bool reservaNoCancelada()
        {
            string codigoReservaIngresado = String.Format("select reca_rese from CAIA_UNLIMITED.Reserva_Cancelada where reca_rese= '{0}'", txtNumero_Reserva.Text.Trim());
            if (DataBase.realizarConsulta(codigoReservaIngresado).Tables[0].Rows.Count == 0)
            {
                
                return true;
            }
            else
            {
                MessageBox.Show("La reserva ya fue cancelada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
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

        private void ejecutarStoredProcedureCancelarReservaHuesped()
        {
            SqlConnection db = DataBase.conectarBD();
            SqlCommand cancelarReserva = new SqlCommand("CAIA_UNLIMITED.sp_CancelarReservaHuesped", db);
            cancelarReserva.CommandType = CommandType.StoredProcedure;
            cancelarReserva.Parameters.AddWithValue("@codigo_Reserva", txtNumero_Reserva.Text.Trim());
            cancelarReserva.Parameters.AddWithValue("@motivo", txtMotivo.Text.Trim());
            
            cancelarReserva.Parameters.AddWithValue("@fecha_cancelacion", DateTime.Parse(txtCancelacion.Text));
            
            
            cancelarReserva.ExecuteNonQuery();
            db.Close();
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

            cancelarReserva.Parameters.AddWithValue("@usuario",Convert.ToInt32(idUsuario));
            cancelarReserva.Parameters.AddWithValue("@estado", "Reserva cancelada por recepcion");
            cancelarReserva.ExecuteNonQuery();
            db.Close();
        }

        private bool fechaEnCondicion()
        {
             string consultaFecha = string.Format("select rese_fecha_desde as 'Fecha inicio' from CAIA_UNLIMITED.Reserva where rese_codigo='{0}'", txtNumero_Reserva.Text.Trim());
             DataTable fecha = DataBase.realizarConsulta(consultaFecha).Tables[0];
             string fechaIngresoReserva = fecha.Rows[0][0].ToString();


             if (DateTime.Parse(fechaIngresoReserva).Day == DateTime.Parse(txtCancelacion.Text.Trim()).Day && DateTime.Parse(fechaIngresoReserva).Month == DateTime.Parse(txtCancelacion.Text.Trim()).Month && DateTime.Parse(fechaIngresoReserva).Year==DateTime.Parse(txtCancelacion.Text.Trim()).Year)
             {
                 return false;
             }
             else
             {
                 return true;
             }

        }

        private bool noTerminoReserva()
        {
            string consultaFechaFinEstadia = string.Format("select esta_fecha_fin from CAIA_UNLIMITED.Estadia where rese_codigo= '{0}'", txtNumero_Reserva.Text.Trim());
            DataTable fechaFinObtenida = DataBase.realizarConsulta(consultaFechaFinEstadia).Tables[0];
            


            if (fechaFinObtenida.Rows.Count==0)
            {
                return true;
            }
            else
            {
                if (DBNull.Value.Equals(fechaFinObtenida.Rows[0][0]))
                {
                    return true;
                }
                else
                {
                    return false;
                }
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

    }
}
