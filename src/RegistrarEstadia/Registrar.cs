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

        string codigoReserva, idHotelActual;
        int cantHuespedPosible;

        public Registrar(string cod, string idHotel)
        {
            InitializeComponent();
            codigoReserva = cod;
            idHotelActual = idHotel;

            txtFecha.Text = Convert.ToString(DataBase.fechaSistema());

            string habitacionesBuscadas = String.Format("SELECT habi_rese_numero FROM CAIA_UNLIMITED.Habitacion_X_Reserva WHERE habi_rese_codigo = '{0}' and habi_rese_id = '{1}'", cod, idHotelActual);
            DataTable habitacionesObtenidas = DataBase.realizarConsulta(habitacionesBuscadas).Tables[0];

            foreach (DataRow habitacion in habitacionesObtenidas.Rows)
            {
                string habitacionSeleccionada = habitacion[0].ToString();

                string tipoHabitacionBuscada = String.Format("SELECT thab_codigo FROM CAIA_UNLIMITED.Habitacion WHERE habi_numero = '{0}'", habitacionSeleccionada);
                DataTable tipoHabitacionObtenido = DataBase.realizarConsulta(tipoHabitacionBuscada).Tables[0];
                string tipoHabitacion = tipoHabitacionObtenido.Rows[0][0].ToString();

                string tipoBuscado = String.Format("SELECT thab_descripcion FROM CAIA_UNLIMITED.Tipo_Habitacion WHERE thab_codigo = '{0}'", tipoHabitacion);
                DataTable tipoObtenido = DataBase.realizarConsulta(tipoBuscado).Tables[0];
                string tipo = tipoObtenido.Rows[0][0].ToString();

                registrarCantidadHuespedesDisponibles(tipo);

            }

            DataSet huespedes = DataBase.realizarConsulta("select hues_mail as 'Mail', hues_nombre as 'Nombre', hues_apellido as 'Apellido', hues_documento as 'Documento', hues_documento_tipo as 'Tipo'  from CAIA_UNLIMITED.Huesped where hues_habilitado=1 ");
            dgClientes.DataSource = huespedes.Tables[0];

        }

        private void registrarCantidadHuespedesDisponibles(string tipo)
        {
            if (tipo.Equals("Base Simple"))
            {
                cantHuespedPosible++;
            }
            else if (tipo.Equals("Base Doble"))
            {
                cantHuespedPosible = cantHuespedPosible + 2;
            }
            else if (tipo.Equals("Base Triple"))
            {
                cantHuespedPosible = cantHuespedPosible + 3;
            }
            else if (tipo.Equals("Base Cuadruple"))
            {
                cantHuespedPosible = cantHuespedPosible + 4;
            }
            else if (tipo.Equals("King"))
            {
                cantHuespedPosible = cantHuespedPosible + 2;
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (camposValidos1())
            {
                if (formatoMailCorrecto1())
                {

                    string consulta = generarConsulta();
                    if (consulta != "")
                    {
                        DataSet huespedes = DataBase.realizarConsulta(consulta);
                        dgClientes.DataSource = huespedes.Tables[0];
                    }
                }
            }         

        }

        private bool formatoMailCorrecto1()
        {
            if (txtMail.Text != "")
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
            return true;
        }

        private bool camposValidos1()
        {
            if (txtNumero.Text != "")
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
            return true;
        }

        private string generarConsulta()
        {
            string consulta;
            if (txtMail.Text.Trim() == "" && txtTipo.Text.Trim() == "" && txtNumero.Text.Trim() == "")
            {
                consulta = "select hues_mail as 'E-Mail', hues_nombre as 'Nombre', hues_apellido as 'Apellido', hues_documento as'DNI', hues_documento_tipo as 'Tipo'  from CAIA_UNLIMITED.Huesped H join CAIA_UNLIMITED.Direccion D on (H.dire_id = D.dire_id)";
            }
            else
            {
                consulta = "select hues_mail as 'E-Mail', hues_nombre as 'Nombre', hues_apellido as 'Apellido', hues_documento as'DNI', hues_documento_tipo as 'Tipo'  from CAIA_UNLIMITED.Huesped H join CAIA_UNLIMITED.Direccion D on (H.dire_id = D.dire_id) where ";
                bool hayOtro = false;


                if (txtNumero.Text.Trim() != "")
                {
                    if (hayOtro)
                    {
                        consulta += " and ";
                    }
                    else
                    {
                        hayOtro = true;
                    }
                    int documento;
                    if (int.TryParse(txtNumero.Text.Trim(), out documento))
                    {
                        consulta += string.Format("hues_documento LIKE {0}", "%"+documento+"%");
                    }
                    else
                    {
                        MessageBox.Show("Campo/s invalidos");
                        return "";
                    }
                }

                if (txtTipo.Text.Trim() != "")
                {
                    if (hayOtro)
                    {
                        consulta += " and ";
                    }
                    else
                    {
                        hayOtro = true;
                    }
                    consulta += string.Format("hues_documento_tipo LIKE '%{0}%'", txtTipo.Text.Trim());
                }

                if (txtMail.Text.Trim() != "")
                {
                    if (hayOtro)
                    {
                        consulta += " and ";
                    }
                    consulta += string.Format("hues_mail LIKE '%{0}%'", txtMail.Text.Trim());
                }

            }

            return consulta;
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


                                    TimeSpan ts = Convert.ToDateTime(txtFecha.Text.Trim()) - Convert.ToDateTime(fechaIngresoReserva);
                                    if (DateTime.Parse(fechaIngresoReserva).Day == DateTime.Parse(txtFecha.Text.Trim()).Day && DateTime.Parse(fechaIngresoReserva).Month == DateTime.Parse(txtFecha.Text.Trim()).Month && DateTime.Parse(fechaIngresoReserva).Year == DateTime.Parse(txtFecha.Text.Trim()).Year)
                                    {
                                        ejecutarStoredProcedureRegistrarCheckIn();


                                        MessageBox.Show("Fecha de ingreso de reserva registrada correctamente", "Registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        string consultaEstadia = string.Format("select esta_codigo from CAIA_UNLIMITED.Estadia where rese_codigo ='{0}'", codigoReserva);
                                        DataTable estadiaObtenida = DataBase.realizarConsulta(consultaEstadia).Tables[0];
                                        string estadiaId = estadiaObtenida.Rows[0][0].ToString();

                                        MessageBox.Show("El codigo de estadia es: "+estadiaId, "Registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        limpiarTodo();
                                    }
                                    else if (ts.Days<0 )
                                    {
                                        MessageBox.Show("Ingreso anticipado a la fecha de ingreso establecido en la reserva", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Ingreso posterior a la fecha establecida, perdida de reserva", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        this.Hide();
                                        new CancelarReservaHuesped(txtUsuario.Text.Trim(), codigoReserva, idHotelActual).Show();
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
            string consultaIdUsuario = string.Format("SELECT usur_id FROM CAIA_UNLIMITED.Usuario  WHERE usur_username ='{0}'", txtUsuario.Text.Trim());
            DataTable idUsuarioObtenido = DataBase.realizarConsulta(consultaIdUsuario).Tables[0];
            string idUsuario = idUsuarioObtenido.Rows[0][0].ToString();

            string usernameIngresado = String.Format("SELECT usur_hote_idusur FROM CAIA_UNLIMITED.Usuario_X_Hotel  WHERE usur_hote_idhote='{0}' and usur_hote_idusur= '{1}'", idHotelActual, idUsuario);

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
            crearIngreso.Parameters.AddWithValue("@fecha_Inicio", DateTime.Parse(txtFecha.Text.Trim()));
            string consultaIdUsuario = string.Format("SELECT usur_id FROM CAIA_UNLIMITED.Usuario  WHERE usur_username ='{0}'", txtUsuario.Text.Trim());
            DataTable idUsuarioObtenido = DataBase.realizarConsulta(consultaIdUsuario).Tables[0];
            string idUsuario = idUsuarioObtenido.Rows[0][0].ToString();

            crearIngreso.Parameters.AddWithValue("@usuario",Convert.ToInt32(idUsuario));
            crearIngreso.Parameters.AddWithValue("@codigo_reserva", codigoReserva);
            crearIngreso.ExecuteNonQuery();
            db.Close();
        }

        private void ejecutarStoredProcedureRegistrarCheckOut(string idEstadia)
        {

            SqlConnection db = DataBase.conectarBD();
            SqlCommand crearEgreso = new SqlCommand("CAIA_UNLIMITED.sp_RegistrarEgreso", db);
            crearEgreso.CommandType = CommandType.StoredProcedure;
            crearEgreso.Parameters.AddWithValue("@fecha_egreso", DateTime.Parse(txtFecha.Text.Trim()));
            string consultaIdUsuario = string.Format("SELECT usur_id FROM CAIA_UNLIMITED.Usuario  WHERE usur_username ='{0}'", txtUsuario.Text.Trim());
            DataTable idUsuarioObtenido = DataBase.realizarConsulta(consultaIdUsuario).Tables[0];
            string idUsuario = idUsuarioObtenido.Rows[0][0].ToString();

            crearEgreso.Parameters.AddWithValue("@usuario", Convert.ToInt32(idUsuario));

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

                        string idUsuarioBuscado = String.Format("select usur_checkin FROM CAIA_UNLIMITED.Estadia where rese_codigo='{0}'", codigoReserva);
                        DataTable idUsuarioEncontrado = DataBase.realizarConsulta(idUsuarioBuscado).Tables[0];
                        string idUsuario = idUsuarioEncontrado.Rows[0][0].ToString();

                        string usuarioBuscado = String.Format("select usur_username FROM CAIA_UNLIMITED.Usuario where usur_id='{0}'", idUsuario);
                        DataTable usuarioEncontrado = DataBase.realizarConsulta(usuarioBuscado).Tables[0];
                        string usuario = usuarioEncontrado.Rows[0][0].ToString();
                        
                        txtUsuario.Text = usuario;

                        btnIngresar.Enabled = false;
                        gbxHuesped.Enabled = false;
                        txtUsuario.Enabled = false;
                    }
                    btnBuscar.Enabled = true;
                    btnCrear.Enabled = true;
                    dgClientes.Enabled = true;
                    btnEliminar.Enabled = true;

                }
            }
        }

        private void verificarSiYaRegistroEgreso()
        {
            string fechaEgresoBuscada = String.Format("select esta_fecha_fin as FechaFin FROM CAIA_UNLIMITED.Estadia where rese_codigo='{0}'", codigoReserva);
            DataTable fecha = DataBase.realizarConsulta(fechaEgresoBuscada).Tables[0];
            if (fecha.Rows.Count==0)
            {
            }
            else
            {

                if (DBNull.Value.Equals(fecha.Rows[0]["FechaFin"]))
                {

                }
                else
                {

                    DataTable fechaEgresoObtenida = DataBase.realizarConsulta(fechaEgresoBuscada).Tables[0];
                    string fechaEgreso = fechaEgresoObtenida.Rows[0][0].ToString();
                    txtFecha.Text = fechaEgreso;

                    string idUsuarioBuscado = String.Format("select usur_checkout FROM CAIA_UNLIMITED.Estadia where rese_codigo='{0}'", codigoReserva);
                    DataTable idUsuarioEncontrado = DataBase.realizarConsulta(idUsuarioBuscado).Tables[0];
                    string idUsuario = idUsuarioEncontrado.Rows[0][0].ToString();

                    string usuarioBuscado = String.Format("select usur_username FROM CAIA_UNLIMITED.Usuario where usur_id='{0}'", idUsuario);
                    DataTable usuarioEncontrado = DataBase.realizarConsulta(usuarioBuscado).Tables[0];
                    string usuario = usuarioEncontrado.Rows[0][0].ToString();
                    txtUsuario.Text = usuario;

                    btnIngresar.Enabled = false;
                    gbxHuesped.Enabled = false;
                    txtUsuario.Enabled = false;
                }
            }
        }

        private void limpiarRegistroEstadia()
        {
            txtUsuario.Clear();
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


        private void btnVolver_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {          
                    if (listaHuesped.Items.Count < cantHuespedPosible)
                    {
                        new CrearHuesped(codigoReserva, this).Show();
                        
                        txtMail.Clear();
                        txtTipo.Clear();
                        txtNumero.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Ya llego al máximo de huespedes posibles para la habitación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtMail.Clear();
                        txtNumero.Clear();
                        txtTipo.Clear();
                    }
        }

        

        private bool noLoIngreso()
        {
            for (int i = 0; i < listaHuesped.Items.Count; i++)
            {
                if (listaHuesped.Items[i].SubItems[0].Text == dgClientes.SelectedRows[0].Cells[0].Value.ToString())
                {
                    return false;
                }

            }

            return true;
        }

        private void dgClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (listaHuesped.Items.Count < cantHuespedPosible)
            {
                if (noLoIngreso())
                {
                    string mail = dgClientes.SelectedRows[0].Cells[0].Value.ToString();
                    string documento = dgClientes.SelectedRows[0].Cells[3].Value.ToString(); ;
                    string tipo = dgClientes.SelectedRows[0].Cells[4].Value.ToString(); ;

                    string[] formato = { mail.Trim(), documento.Trim(), tipo.Trim() };
                    var listViewItem = new ListViewItem(formato);
                    listaHuesped.Items.Add(listViewItem);

                    txtMail.Clear();
                    txtTipo.Clear();
                    txtNumero.Clear();
                }

            }
            else
            {
                MessageBox.Show("Ya llego al máximo de huespedes posibles para la habitación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMail.Clear();
                txtNumero.Clear();
                txtTipo.Clear();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in listaHuesped.SelectedItems)
            {
                listaHuesped.Items.Remove(eachItem);
            }
        }
    }
}
