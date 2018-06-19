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
    public partial class Registrar : Form
    {
        string codigoReserva;
        public Registrar(string cod)
        {
            InitializeComponent();
            codigoReserva = cod;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (camposCompletosClientes())
            {
                if (camposValidos())
                {
                    if (formatoMailCorrecto())
                    {
                        string usuarioIngresado = String.Format("SELECT hues_mail FROM CAIA_UNLIMITED.Huesped WHERE hues_mail = '{0}' AND hues_documento = '{1}'  AND hues_documento_tipo = '{2}'", txtMail.Text.Trim(), txtNumero.Text.Trim(), txtTipo.Text.Trim());

                        if (DataBase.realizarConsulta(usuarioIngresado).Tables[0].Rows.Count == 0)
                        {
                            string[] formato = { txtMail.Text.Trim(), txtTipo.Text.Trim(), txtNumero.Text.Trim() };
                            var listViewItem = new ListViewItem(formato);
                            listaHuesped.Items.Add(listViewItem);
                            this.Hide();
                            new CrearHuesped(txtMail.Text.Trim(), txtTipo.Text.Trim(), txtNumero.Text.Trim(), codigoReserva).Show();
                            txtMail.Clear();
                            txtTipo.Clear();
                            txtNumero.Clear();                           
                        }
                        else
                        {
                            string[] formato = { txtMail.Text.Trim(), txtTipo.Text.Trim(), txtNumero.Text.Trim() };
                            var listViewItem = new ListViewItem(formato);
                            listaHuesped.Items.Add(listViewItem);
                            txtMail.Clear();
                            txtTipo.Clear();
                            txtNumero.Clear();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Ingrese todos los campos.");
            }

        }

        private bool camposCompletosClientes()
        {            
            if (txtNumero.Text.Trim() == "")
            {
                return false;
            }
            if (txtTipo.Text.Trim() == "")
            {
                return false;
            }
            if (txtMail.Text.Trim() == "")
            {
                return false;
            }
            return true;
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
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtNumero.Text, @"^\d+$"))
            {
                MessageBox.Show("Solo se permiten valores numericos en el numero de identificacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            else
            {
                return true;
            }
        }


        private void btnVolver_Click(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (camposCompletos())
            {
                if (esUsuario())
                {
                    if (usuarioCorrecto())
                    {
                        if (listaHuesped.Items.Count != 0)
                        {
                            if (cbxRegistrar.SelectedItem.ToString() == "Ingreso")
                            {
                                string consultaFecha = string.Format("select rese_fecha_desde as 'Fecha inicio' from CAIA_UNLIMITED.Reserva where rese_codigo='{0}'", codigoReserva);
                                DataTable fecha = DataBase.realizarConsulta(consultaFecha).Tables[0];
                                string fechaIngresoReserva = fecha.Rows[0][0].ToString();
                                int resultado = DateTime.Compare(DateTime.Parse(txtFecha.Text), DateTime.Parse(fechaIngresoReserva));
                                if (DateTime.Parse(txtFecha.Text).Day == DateTime.Parse(fechaIngresoReserva).Day && DateTime.Parse(txtFecha.Text).Month == DateTime.Parse(fechaIngresoReserva).Month && DateTime.Parse(txtFecha.Text).Year == DateTime.Parse(fechaIngresoReserva).Year)
                                {
                                    ejecutarStoredProcedureRegistrarCheckIn();
                                    this.Hide();
                                }
                                else if (resultado < 0)
                                {
                                    MessageBox.Show("Ingreso anticipado a la fecha de ingreso establecido en la reserva");
                                }
                                else
                                {
                                    MessageBox.Show("Ingreso posterior a la fecha establecida, perdida de reserva");
                                    this.Hide();
                                    new CancelarReservaHuesped(txtUsuario.Text.Trim(), codigoReserva).Show();
                                }
                            }
                            else if (cbxRegistrar.SelectedItem.ToString() == "Egreso")
                            {
                                string consultaFechaInicioEstadia = string.Format("select esta_fecha_inicio as 'Fecha inicio' from CAIA_UNLIMITED.Estadia where rese_codigo='{0}'", codigoReserva);
                                DataTable fecha = DataBase.realizarConsulta(consultaFechaInicioEstadia).Tables[0];
                                string fechaInicio = fecha.Rows[0][0].ToString();

                                TimeSpan diasDiferencia = DateTime.Parse(fechaInicio) - DateTime.Parse(txtFecha.Text.Trim());
                                int cantidadNoches = diasDiferencia.Days - 1;
                                ejecutarStoredProcedureRegistrarCheckOut(cantidadNoches);
                            }
                        }
                        else
                        {
                                MessageBox.Show("Ingrese los datos de los huespedes.");
                        }
                    }
                    else
                    {
                            MessageBox.Show("El usuario ingresado no pertenece al hotel de dicha reserva.");
                    }
                }
                else
                {
                        MessageBox.Show("El usuario ingresado es incorrecto.");
                }
                
                
            }
            else
            {
                MessageBox.Show("Ingrese todos los campos.");
            }

        }

        private bool esUsuario()
        {
            string usernameIngresado = String.Format("SELECT usur_username FROM CAIA_UNLIMITED.Usuario  WHERE usur_username='{0}'", txtUsuario.Text.Trim());

            if (DataBase.realizarConsulta(usernameIngresado).Tables[0].Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool usuarioCorrecto()
        {
            string consultaHotelId = string.Format("SELECT habi_rese_id FROM CAIA_UNLIMITED.Habitacion_X_Reserva  WHERE habi_rese_codigo ='{0}'", codigoReserva);
            DataTable hotelIdObtenida = DataBase.realizarConsulta(consultaHotelId).Tables[0];
            string hotelID = hotelIdObtenida.Rows[0][0].ToString();

            string usernameIngresado = String.Format("SELECT usur_hote_username FROM CAIA_UNLIMITED.Usuario_X_Hotel  WHERE usur_hote_id='{0}' and usur_hote_username= '{1}'", hotelID, txtUsuario.Text.Trim());

            if (DataBase.realizarConsulta(usernameIngresado).Tables[0].Rows.Count == 0)
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
            if (txtUsuario.Text.Trim() == "")
            {
                return false;
            }
            if (txtFecha.Text.Trim() == "")
            {
                return false;
            }
            if (cbxRegistrar.SelectedItem.ToString() == "Egreso" && cbxRegistrar.SelectedItem.ToString() == "Ingreso")
            {
                return false;
            }
            return true;
        }

        private void ejecutarStoredProcedureRegistrarCheckIn()
        {
            SqlConnection db = DataBase.conectarBD();
            SqlCommand crearIngreso = new SqlCommand("sp_RegistrarIngreso", db);
            crearIngreso.CommandType = CommandType.StoredProcedure;
            crearIngreso.Parameters.AddWithValue("@fecha_Inicio", DateTime.Parse(txtFecha.Text.Trim()));
            crearIngreso.Parameters.AddWithValue("@usuario", txtUsuario.Text.Trim());
            crearIngreso.Parameters.AddWithValue("@codigo_reserva", codigoReserva);
            crearIngreso.ExecuteNonQuery();
            db.Close();
        }

        private void ejecutarStoredProcedureRegistrarCheckOut(int cantidadNoches)
        {
            SqlConnection db = DataBase.conectarBD();
            SqlCommand crearEgreso = new SqlCommand("sp_RegistrarEgreso", db);
            crearEgreso.CommandType = CommandType.StoredProcedure;
            crearEgreso.Parameters.AddWithValue("@cantidad_noches", cantidadNoches.ToString());
            crearEgreso.Parameters.AddWithValue("@usuario", txtUsuario.Text.Trim());
            crearEgreso.ExecuteNonQuery();
            db.Close();
        }


        private void cbxRegistrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxRegistrar.SelectedItem.ToString() == "Egreso")
            {
                gbxHuesped.Enabled = false;
            }
            else
            {
                btnAceptar.Enabled = true;
                gbxHuesped.Enabled = true;
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            txtFecha.Text = calendario.SelectionStart.ToShortDateString();
        }
    }
}
