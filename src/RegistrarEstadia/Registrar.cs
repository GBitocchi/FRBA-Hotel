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

            //txtFecha.Text = Convert.ToString(DataBase.fechaSistema());
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
                        
                            if (cbxRegistrar.SelectedItem.ToString() == "Ingreso")
                            {
                                if (listaHuesped.Items.Count != 0)
                                {
                                    string consultaFecha = string.Format("select rese_fecha_desde as 'Fecha inicio' from CAIA_UNLIMITED.Reserva where rese_codigo='{0}'", codigoReserva);
                                    DataTable fecha = DataBase.realizarConsulta(consultaFecha).Tables[0];
                                    string fechaIngresoReserva = fecha.Rows[0][0].ToString();
                                    //
                                    //UTILIIZAR FECHA ACTUAL
                                   // int resultado = DateTime.Compare(DateTime.Parse(txtFecha.Text), DateTime.Parse(fechaIngresoReserva));
                                    if (DateTime.Parse(fechaIngresoReserva) == DateTime.Parse(txtFecha.Text.Trim()) )
                                    {
                                        ejecutarStoredProcedureRegistrarCheckIn();
                                        MessageBox.Show("Fecha de ingreso de reserva registrada correctamente", "Registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        limpiarTodo();
                                    }
                                    else if (DateTime.Parse(fechaIngresoReserva) > DateTime.Parse(txtFecha.Text.Trim()))
                                    {
                                        MessageBox.Show("Ingreso anticipado a la fecha de ingreso establecido en la reserva", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Ingreso posterior a la fecha establecida, perdida de reserva", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        this.Hide();
                                        new CancelarReservaHuesped(txtUsuario.Text.Trim(), codigoReserva).Show();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Ingrese los datos de los huespedes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else if (cbxRegistrar.SelectedItem.ToString() == "Egreso")
                            {
                                if (verificarSiYaRegistroIngreso())
                                {
                                    string consutaIdEstadia = string.Format("select esta_codigo from CAIA_UNLIMITED.Estadia where rese_codigo='{0}'", codigoReserva);
                                    DataTable idObtenido = DataBase.realizarConsulta(consutaIdEstadia).Tables[0];
                                    string idEstadia = idObtenido.Rows[0][0].ToString();


                                    ejecutarStoredProcedureRegistrarCheckOut(idEstadia);
                                    MessageBox.Show("Fecha de egreso de reserva registrada correctamente", "Registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    limpiarTodo();
                                }
                                else
                                {
                                    MessageBox.Show("Debe ingresar el ingreso de la estadia primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            

                       
                    }
                    else
                    {
                        MessageBox.Show("El usuario ingresado no pertenece al hotel de dicha reserva.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        private void limpiarTodo()
        {
            txtUsuario.Clear();
            txtFecha.Clear();
            btnIngresar.Enabled = true;
            gbxHuesped.Enabled = true;
            txtUsuario.Enabled = true;
            txtMail.Clear();
            txtTipo.Clear();
            txtNumero.Clear();
            listaHuesped.Clear();
            cbxRegistrar.SelectedIndex = -1;
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
            SqlCommand crearIngreso = new SqlCommand("CAIA_UNLIMITED.sp_RegistrarIngreso", db);
            crearIngreso.CommandType = CommandType.StoredProcedure;
            //AGREGAR FECHA ACTUAL
            crearIngreso.Parameters.AddWithValue("@fecha_Inicio", DateTime.Parse(txtFecha.Text.Trim()));
            crearIngreso.Parameters.AddWithValue("@usuario", txtUsuario.Text.Trim());
            crearIngreso.Parameters.AddWithValue("@codigo_reserva", codigoReserva);
            crearIngreso.ExecuteNonQuery();
            db.Close();
        }

        private void ejecutarStoredProcedureRegistrarCheckOut(string idEstadia)
        {

            SqlConnection db = DataBase.conectarBD();
            SqlCommand crearEgreso = new SqlCommand("CAIA_UNLIMITED.sp_RegistrarEgres", db);
            crearEgreso.CommandType = CommandType.StoredProcedure;
            //AGREGAR FECHA ACTUAL
            crearEgreso.Parameters.AddWithValue("@fecha_egreso", DateTime.Parse(txtFecha.Text.Trim()));
            crearEgreso.Parameters.AddWithValue("@usuario", txtUsuario.Text.Trim());
            crearEgreso.Parameters.AddWithValue("@estadia_Id", idEstadia);
            crearEgreso.ExecuteNonQuery();
            db.Close();
        }


        private void cbxRegistrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarRegistroEstadia();
            if (cbxRegistrar.SelectedIndex != -1)
            {
                if (cbxRegistrar.SelectedItem.ToString() == "Egreso")
                {
                    gbxHuesped.Enabled = false;
                    verificarSiYaRegistroEgreso();
                }
                else
                {

                    if (verificarSiYaRegistroIngreso())
                    {
                        string fechaIngresoBuscada = String.Format("select esta_fecha_inicio FROM CAIA_UNLIMITED.Estadia where rese_codigo='{0}'", codigoReserva);
                        DataTable fechaIngresoObtenida = DataBase.realizarConsulta(fechaIngresoBuscada).Tables[0];
                        string fechaIngreso = fechaIngresoObtenida.Rows[0][0].ToString();
                        txtFecha.Text = fechaIngreso;

                        string usuarioBuscado = String.Format("select usur_checkin FROM CAIA_UNLIMITED.Estadia where rese_codigo='{0}'", codigoReserva);
                        DataTable usuarioEncontrado = DataBase.realizarConsulta(usuarioBuscado).Tables[0];
                        string usuario = usuarioEncontrado.Rows[0][0].ToString();
                        txtUsuario.Text = usuario;

                        btnIngresar.Enabled = false;
                        gbxHuesped.Enabled = false;
                        txtUsuario.Enabled = false;
                    }
                    btnAceptar.Enabled = true;

                }
            }
        }

        private void verificarSiYaRegistroEgreso()
        {
            string fechaEgresoBuscada = String.Format("select esta_fecha_fin as FechaFin FROM CAIA_UNLIMITED.Estadia where rese_codigo='{0}'", codigoReserva);
            DataSet fecha=DataBase.realizarConsulta(fechaEgresoBuscada);
            
            if ( DBNull.Value.Equals(fecha.Tables[0].Rows[0]["FechaFin"]))
            {
               
            }
            else
            {

                DataTable fechaEgresoObtenida = DataBase.realizarConsulta(fechaEgresoBuscada).Tables[0];
                string fechaEgreso = fechaEgresoObtenida.Rows[0][0].ToString();
                txtFecha.Text = fechaEgreso;

                string usuarioBuscado = String.Format("select usur_checkout FROM CAIA_UNLIMITED.Estadia where rese_codigo='{0}'", codigoReserva);
                DataTable usuarioEncontrado = DataBase.realizarConsulta(usuarioBuscado).Tables[0];
                string usuario = usuarioEncontrado.Rows[0][0].ToString();
                txtUsuario.Text = usuario;

                btnIngresar.Enabled = false;
                gbxHuesped.Enabled = false;
                txtUsuario.Enabled = false;
            }
        }

        private void limpiarRegistroEstadia()
        {
            txtUsuario.Clear();
            txtFecha.Clear();
            btnIngresar.Enabled = true;
            gbxHuesped.Enabled = true;
            txtUsuario.Enabled = true;
        }

        private bool verificarSiYaRegistroIngreso()
        {
             string fechaIngresoBuscada = String.Format("select esta_fecha_inicio FROM CAIA_UNLIMITED.Estadia where rese_codigo='{0}'",codigoReserva);

             if (DataBase.realizarConsulta(fechaIngresoBuscada).Tables[0].Rows.Count == 0)
             {
                 return false;
             }
             else
             {
                 return true;
             }


        }


        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            txtFecha.Text = calendario.SelectionStart.ToShortDateString();
        }

        private void btnVolver_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new MenuRegistrarEstadia();
        }
    }
}
