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

namespace FrbaHotel.GenerarModificacionReserva
{
    public partial class ModificarReserva : Form
    {

        decimal hotel;
        bool guest = true;
        bool existeCliente = false;
        string mail;
        decimal documento;
        decimal reserva;
        DateTime fechaElegidaInicio;
        decimal regimen;
        string username;
        DataSet dsHoteles;
        DataSet dsRegimenes;
        TimeSpan difference;
        HabitacionalitiesCollection lh;

        public ModificarReserva()
        {
            InitializeComponent();
            listBoxTipoHabitacion.Items.Clear();
            limpiarErrores();
            limpiarTextBox();
        }

        public ModificarReserva(decimal _hotel, string _username)
        {
            InitializeComponent();
            listBoxTipoHabitacion.Items.Clear();
            limpiarErrores();
            limpiarTextBox();
            this.hotel = _hotel;
            this.username = _username;
            this.guest = false;
            comboHoteles.Visible = false;
            lblHotel.Visible = false;
            btnSeleccionarHotel.Visible = false;
            textBoxHotel.Visible = false;
            lblErrorHotel.Visible = false;
        }

        private void eliminarHabitacionesAnteriores()
        {
            SqlConnection createConnection = DataBase.conectarBD();
            SqlCommand insertCliente = new SqlCommand("[CAIA_UNLIMITED].sp_eliminarHabitaciones", createConnection);
            insertCliente.CommandType = CommandType.StoredProcedure;
            insertCliente.Parameters.AddWithValue("@codigoReserva", this.reserva);
            insertCliente.Parameters.AddWithValue("@hotel", this.hotel);
            insertCliente.ExecuteNonQuery();
            createConnection.Close();
        }

        private void cargarComboBoxRegimenes()
        {
            string regimenes = string.Format("SELECT DISTINCT r.regi_descripcion as Descripcion, r.regi_codigo as Codigo FROM CAIA_UNLIMITED.Regimen r JOIN CAIA_UNLIMITED.Regimen_X_Hotel rh on r.regi_codigo = rh.regi_hote_codigo JOIN CAIA_UNLIMITED.Hotel h on h.hote_id = rh.regi_hote_id WHERE h.hote_id = '{0}' AND r.regi_estado = 1", this.hotel);
            DataSet dsRegimenes = DataBase.realizarConsulta(regimenes);
            this.dsRegimenes = dsRegimenes;
            foreach (DataRow unRegimen in dsRegimenes.Tables[0].Rows)
            {
                cbxRegimenEstadia.Items.Add((string)unRegimen["Descripcion"]);
            }
            if (cbxRegimenEstadia.Items.Count > 0)
            {
                cbxRegimenEstadia.SelectedIndex = 0;
            }
        }

        private void cargarComboBoxTipoDocumento()
        {
            comboBoxTipoDocumentoCliente.Items.Clear();
            string tipoDocumento = "SELECT DISTINCT hues_documento_tipo as Documento FROM CAIA_UNLIMITED.Huesped WHERE hues_documento_tipo is not null UNION SELECT DISTINCT usur_documento_tipo as Documento FROM CAIA_UNLIMITED.Usuario WHERE usur_documento_tipo is not null";
            DataSet dsTipoDocumento = DataBase.realizarConsulta(tipoDocumento);

            foreach (DataRow unTipoDocumento in dsTipoDocumento.Tables[0].Rows)
            {
                comboBoxTipoDocumentoCliente.Items.Add((string)unTipoDocumento["Documento"]);
            }
            if (comboBoxTipoDocumentoCliente.Items.Count > 0)
            {
                comboBoxTipoDocumentoCliente.SelectedIndex = 0;
            }
        }

        private void cargarComboBoxTipoHabitacion()
        {
            string tiposHabitaciones = string.Format("SELECT DISTINCT thab_descripcion as Descripcion FROM CAIA_UNLIMITED.Tipo_Habitacion th JOIN CAIA_UNLIMITED.Habitacion h on h.thab_codigo = th.thab_codigo WHERE h.hote_id = '{0}'", this.hotel);
            DataSet dsTiposHabitaciones = DataBase.realizarConsulta(tiposHabitaciones);

            foreach (DataRow unTipo in dsTiposHabitaciones.Tables[0].Rows)
            {
                cbxTipoHabitacion.Items.Add((string)unTipo["Descripcion"]);
            }
            if (cbxTipoHabitacion.Items.Count > 0)
            {
                cbxTipoHabitacion.SelectedIndex = 0;
            }
        }

        private void cargarComboBoxHoteles()
        {
            string hoteles = "SELECT CONCAT(hote_id, '-', hote_nombre) as Hotel, hote_id as idHotel FROM CAIA_UNLIMITED.Hotel WHERE hote_habilitado = 1";
            DataSet dsHoteles = DataBase.realizarConsulta(hoteles);
            this.dsHoteles = dsHoteles;

            foreach (DataRow unHotel in dsHoteles.Tables[0].Rows)
            {
                comboHoteles.Items.Add((string)unHotel["Hotel"]);
            }
            if (comboHoteles.Items.Count > 0)
            {
                comboHoteles.SelectedIndex = 0;
            }
        }

        private void limpiarTextBox()
        {
            textBoxApellido.Clear();
            textBoxCiudad.Clear();
            textBoxDireccion.Clear();
            textBoxDocumento.Clear();
            textBoxMail.Clear();
            textBoxNombre.Clear();
            textBoxPais.Clear();
            textBoxTelefono.Clear();
            txbRegimen.Clear();
            textBoxHotel.Clear();
            textBoxReserva.Clear();
        }

        private void limpiarErrores()
        {
            lblErrorApellido.Visible = false;
            lblErrorCiudad.Visible = false;
            lblErrorDireccion.Visible = false;
            lblErrorDocumento.Visible = false;
            lblerrorfechas.Visible = false;
            lblErrorHotel.Visible = false;
            lblErrorMail.Visible = false;
            lblErrorNoField.Visible = false;
            lblErrorNombre.Visible = false;
            lblErrorNumberValue.Visible = false;
            lblErrorPais.Visible = false;
            lblErrorPaso1.Visible = false;
            lblErrorTipoHabitacion.Visible = false;
            lblErrorFechaFin.Visible = false;
            lblErrorFechaInicio.Visible = false;
            lblErrorTelefono.Visible = false;
            lbllistBoxNoItem.Visible = false;
            lblErrorReserva.Visible = false;
            labelWrongCodigo.Visible = false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lblerrorcantidad_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void lblErrorPaso1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

        }

        private void btnRegimenSeleccionar_Click(object sender, EventArgs e)
        {

        }

        private void btnCheckear_Click(object sender, EventArgs e)
        {


        }

        private void btnSeleccionarHotel_Click(object sender, EventArgs e)
        {

        }

        private void textBoxPais_TextChanged(object sender, EventArgs e)
        {

        }

        private void calendarInicio_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
        }

        private void btnConfirmarPaso_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnSeleccionarReserva_Click(object sender, EventArgs e)
        {
            try
            {
                lblErrorNoField.Visible = false;
                lblErrorNumberValue.Visible = false;
                lblErrorReserva.Visible = false;
                int parsedValue;
                if (textBoxReserva.Text.Trim() == "")
                {
                    lblErrorNoField.Visible = true;
                    lblErrorReserva.Visible = true;
                }
                else if (!int.TryParse(textBoxReserva.Text.Trim(), out parsedValue))
                {
                    lblErrorNumberValue.Visible = true;
                    lblErrorReserva.Visible = true;
                }
                else
                {
                    string queryReserva = string.Format("SELECT r.rese_fecha_realizacion as FechaSistema, r.rese_fecha_desde as FechaComienzo, r.rese_cantidad_noches as CantidadNoches, re.regi_descripcion as Regimen, CONCAT(hr.habi_rese_id, '-', ho.hote_nombre) as Hotel, hr.habi_rese_id as idHotel, hr.habi_rese_numero as nroHabitacion, th.thab_descripcion as TipoHabitacion FROM CAIA_UNLIMITED.Reserva r JOIN CAIA_UNLIMITED.Habitacion_X_Reserva hr on hr.habi_rese_codigo = r.rese_codigo JOIN CAIA_UNLIMITED.Habitacion h on (h.habi_numero = hr.habi_rese_numero AND h.hote_id = hr.habi_rese_id) JOIN CAIA_UNLIMITED.Hotel ho on (ho.hote_id = h.hote_id) JOIN CAIA_UNLIMITED.Regimen_X_Hotel reh on ho.hote_id = reh.regi_hote_id JOIN CAIA_UNLIMITED.Regimen re on re.regi_codigo = reh.regi_hote_codigo JOIN CAIA_UNLIMITED.Tipo_Habitacion th on th.thab_codigo = h.thab_codigo WHERE r.rese_codigo = '{0}' AND r.regi_codigo = re.regi_codigo", textBoxReserva.Text.Trim());
                    DataSet dsReserva = DataBase.realizarConsulta(queryReserva);
                    this.fechaElegidaInicio = Convert.ToDateTime(dsReserva.Tables[0].Rows[0]["FechaComienzo"].ToString());
                    TimeSpan difference = fechaElegidaInicio - DataBase.fechaSistema();
                    string queryCancelada = string.Format("SELECT rese_codigo FROM CAIA_UNLIMITED.Reserva JOIN CAIA_UNLIMITED.Reserva_Cancelada on (reca_rese = rese_codigo) AND rese_codigo = '{0}'", textBoxReserva.Text.Trim());
                    DataSet dsCancelada = DataBase.realizarConsulta(queryCancelada);
                    if (dsCancelada != null && dsCancelada.Tables.Count > 0 && dsCancelada.Tables[0].Rows.Count > 0)
                    {
                        if (difference.Days <= 1)
                        {
                            MessageBox.Show("No puede modificar su reserva! El plazo de modificacion es hasta 1 dia antes del ingreso.");
                            return;
                        }
                        calendarInicio.SetDate(this.fechaElegidaInicio);
                        calendarFin.SetDate(this.fechaElegidaInicio.AddDays(Convert.ToDouble((decimal)dsReserva.Tables[0].Rows[0]["CantidadNoches"])));
                        textBoxHotel.Text = dsReserva.Tables[0].Rows[0]["Hotel"].ToString();
                        txbRegimen.Text = dsReserva.Tables[0].Rows[0]["Regimen"].ToString();
                        foreach (DataRow unTipoHabitacion in dsReserva.Tables[0].Rows)
                        {
                            listBoxTipoHabitacion.Items.Add((string)unTipoHabitacion["TipoHabitacion"]);
                        }

                        if (listBoxTipoHabitacion.Items.Count > 0)
                        {
                            listBoxTipoHabitacion.SelectedIndex = 0;
                            listBoxTipoHabitacion.Sorted = true;
                        }
                        this.hotel = (decimal)dsReserva.Tables[0].Rows[0]["idHotel"];
                        cargarComboBoxHoteles();
                        cargarComboBoxRegimenes();
                        cargarComboBoxTipoHabitacion();
                        this.reserva = Convert.ToDecimal(textBoxReserva.Text.Trim());
                    }
                    else
                    {
                        MessageBox.Show("No puede modificar su reserva porque la cancelo!");
                        return;
                    }
                }
            }
            catch (Exception errorDB)
            {
                labelWrongCodigo.Visible = true;
            }
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            if (cbxTipoHabitacion.SelectedItem != null)
            {
                listBoxTipoHabitacion.Items.Add(cbxTipoHabitacion.SelectedItem);
                listBoxTipoHabitacion.SelectedIndex = 0;
                listBoxTipoHabitacion.Sorted = true;
            }
        }

        private void btnCheckear_Click_1(object sender, EventArgs e)
        {
            lblErrorFechaInicio.Visible = false;
            lblErrorFechaFin.Visible = false;
            lblErrorTipoHabitacion.Visible = false;
            lbllistBoxNoItem.Visible = false;
            this.lblerrorfechas.Visible = false;

            if (calendarFin.SelectionStart <= calendarInicio.SelectionStart)
            {
                this.lblerrorfechas.Visible = true;
                lblErrorFechaInicio.Visible = true;
                lblErrorFechaFin.Visible = true;
            }
            else if (calendarFin.SelectionStart < DataBase.fechaSistema())
            {
                lblErrorFechaFin.Visible = true;
                MessageBox.Show("No puede reservar por dias anteriores a los de hoy.");
            }
            else if (calendarInicio.SelectionStart < DataBase.fechaSistema())
            {
                lblErrorFechaInicio.Visible = true;
                MessageBox.Show("No puede reservar por dias anteriores a los de hoy.");
            }
            else if (listBoxTipoHabitacion.Items.Count == 0)
            {
                lblErrorTipoHabitacion.Visible = true;
                lbllistBoxNoItem.Visible = true;
            }
            else if (guest)
            {
                if (txbRegimen.Text.Trim() == "")
                {
                    this.Hide();
                    VariantesRegimenes variantes = new VariantesRegimenes(this.hotel);
                    variantes.ShowDialog();
                    this.Show();
                    if (variantes.eligioRegimen)
                    {
                        this.regimen = variantes.regimenElegido;
                        string fechaDisponibleHotel = string.Format("SELECT mant_fecha_inicio as FechaInicio, mant_fecha_fin as FechaFin FROM CAIA_UNLIMITED.Mantenimiento where hote_id = '{0}'", this.hotel);
                        DataSet dsFechasHotel = DataBase.realizarConsulta(fechaDisponibleHotel);
                        DateTime fechaElegidaInicio = calendarInicio.SelectionStart;
                        DateTime fechaElegidaFin = calendarFin.SelectionStart;
                        string fechaInicio = fechaElegidaInicio.ToString("yyyy-MM-dd HH:mm:ss");
                        string fechaFin = fechaElegidaFin.ToString("yyyy-MM-dd HH:mm:ss");
                        TimeSpan difference = fechaElegidaFin - fechaElegidaInicio;
                        this.difference = difference;
                        this.fechaElegidaInicio = fechaElegidaInicio;
                        if (dsFechasHotel != null && dsFechasHotel.Tables.Count > 0 && dsFechasHotel.Tables[0].Rows.Count > 0 && !DBNull.Value.Equals(dsFechasHotel.Tables[0].Rows[0]["FechaInicio"]) && !DBNull.Value.Equals(dsFechasHotel.Tables[0].Rows[0]["FechaFin"]))
                        {
                            DateTime fechaInicioHotel = Convert.ToDateTime(dsFechasHotel.Tables[0].Rows[0]["FechaInicio"].ToString());
                            DateTime fechaFinHotel = Convert.ToDateTime(dsFechasHotel.Tables[0].Rows[0]["FechaFin"].ToString());
                            if (((DateTime.Compare(fechaElegidaInicio, fechaInicioHotel)) < 0) || ((DateTime.Compare(fechaElegidaFin, fechaFinHotel)) > 0))
                            {
                                MessageBox.Show("El Hotel no esta abierto entre las fechas elegidas. Por favor, seleccione otras.");
                                return;
                            }
                        }
                        string queryRegimen = string.Format("SELECT regi_precio_base as Precio FROM CAIA_UNLIMITED.Regimen where regi_codigo = '{0}'", regimen);
                        string queryEstrella = string.Format("SELECT hote_recarga_estrella as Recarga FROM CAIA_UNLIMITED.Hotel where hote_id = '{0}'", this.hotel);
                        DataSet dsPrecioRegimen = DataBase.realizarConsulta(queryRegimen);
                        DataSet dsRecarga = DataBase.realizarConsulta(queryEstrella);
                        decimal costoTotal = 0;
                        string msg = "";
                        HabitacionalitiesCollection lh = new HabitacionalitiesCollection();
                        string anterior = "No especificado";
                        string queryNumeroHabitacion;
                        int j = 1;
                        eliminarHabitacionesAnteriores();

                        foreach (string tipitoHabitacion in listBoxTipoHabitacion.Items)
                        {
                            if (tipitoHabitacion == anterior)
                            {
                                j++;
                            }
                            else
                            {
                                anterior = tipitoHabitacion;
                                j = 1;
                            }
                            string queryHabitacionDisponible = string.Format("SELECT COUNT(*) FROM (SELECT h.habi_numero FROM CAIA_UNLIMITED.Tipo_Habitacion th JOIN CAIA_UNLIMITED.Habitacion h on h.thab_codigo = th.thab_codigo WHERE h.hote_id = '{0}' AND h.habi_habilitado = 1 AND th.thab_descripcion = '{1}' AND (SELECT COUNT(*) FROM CAIA_UNLIMITED.Habitacion_X_Reserva hr JOIN CAIA_UNLIMITED.Reserva r on (r.rese_codigo = hr.habi_rese_codigo AND '{0}' = hr.habi_rese_id AND hr.habi_rese_numero = h.habi_numero) WHERE (r.rese_fecha_desde between CONVERT(DATETIME,'{2}',120) AND CONVERT(DATETIME,'{3}',120)) OR (dateadd(day,r.rese_cantidad_noches,r.rese_fecha_desde) between CONVERT(DATETIME,'{2}',120) AND CONVERT(DATETIME,'{3}',120)))=0) t2", this.hotel, tipitoHabitacion, fechaInicio, fechaFin);
                            SqlConnection connection = DataBase.conectarBD();
                            SqlCommand commDisponibles = new SqlCommand(queryHabitacionDisponible, connection);
                            Int32 countDisponibles = Convert.ToInt32(commDisponibles.ExecuteScalar());
                            connection.Close();
                            if (countDisponibles < 1 || j > countDisponibles)
                            {
                                MessageBox.Show("No hay habitaciones disponibles de " + tipitoHabitacion + " en las fechas especificadas");
                                return;
                            }
                            queryNumeroHabitacion = string.Format("SELECT TOP " + countDisponibles.ToString() + " t2.HabitacionNumero FROM (SELECT DISTINCT h.habi_numero as HabitacionNumero,h.habi_piso as HabitacionPiso FROM CAIA_UNLIMITED.Tipo_Habitacion th JOIN CAIA_UNLIMITED.Habitacion h on h.thab_codigo = th.thab_codigo WHERE h.hote_id = '{0}' AND h.habi_habilitado = 1 AND th.thab_descripcion = '{1}' AND (SELECT COUNT(*) FROM CAIA_UNLIMITED.Habitacion_X_Reserva hr JOIN CAIA_UNLIMITED.Reserva r on (r.rese_codigo = hr.habi_rese_codigo AND '{0}' = hr.habi_rese_id AND hr.habi_rese_numero = h.habi_numero) WHERE (r.rese_fecha_desde between CONVERT(DATETIME,'{2}',120) AND CONVERT(DATETIME,'{3}',120)) OR (dateadd(day,r.rese_cantidad_noches,r.rese_fecha_desde) between CONVERT(DATETIME,'{2}',120) AND CONVERT(DATETIME,'{3}',120)))=0) t2", this.hotel, tipitoHabitacion, fechaInicio, fechaFin);
                            DataSet dsNumeroHabitacion = DataBase.realizarConsulta(queryNumeroHabitacion);
                            lh.Add(new Habitacionalities { Habitacion = ((decimal)(dsNumeroHabitacion.Tables[0].Rows[j - 1][0])) });
                            string queryTipitoHabitacion = string.Format("SELECT TOP 1 thab_porcentual as PrecioHabitacion FROM CAIA_UNLIMITED.Tipo_Habitacion where thab_descripcion = '{0}'", tipitoHabitacion);
                            DataSet dsTipitoHabitacion = DataBase.realizarConsulta(queryTipitoHabitacion);
                            decimal costoUnaHabitacion = 0;
                            if (tipitoHabitacion == "Base Doble" || tipitoHabitacion == "King")
                            {
                                costoUnaHabitacion = (2 * (decimal)dsPrecioRegimen.Tables[0].Rows[0]["Precio"]) + (decimal)dsRecarga.Tables[0].Rows[0]["Recarga"];
                            }
                            if (tipitoHabitacion == "Base Simple")
                            {
                                costoUnaHabitacion = (1 * (decimal)dsPrecioRegimen.Tables[0].Rows[0]["Precio"]) + (decimal)dsRecarga.Tables[0].Rows[0]["Recarga"];
                            }
                            if (tipitoHabitacion == "Base Triple")
                            {
                                costoUnaHabitacion = (3 * (decimal)dsPrecioRegimen.Tables[0].Rows[0]["Precio"]) + (decimal)dsRecarga.Tables[0].Rows[0]["Recarga"];
                            }
                            if (tipitoHabitacion == "Base Cuadruple")
                            {
                                costoUnaHabitacion = (4 * (decimal)dsPrecioRegimen.Tables[0].Rows[0]["Precio"]) + (decimal)dsRecarga.Tables[0].Rows[0]["Recarga"];
                            }
                            msg += (string.Format("El monto de la habitacion " + tipitoHabitacion + "es de '{0}' \n", costoUnaHabitacion));
                            costoTotal = costoTotal + costoUnaHabitacion;
                        }

                        this.lh = lh;

                        MessageBox.Show(msg);

                        if (MessageBox.Show("El costo total de la reserva es de " + costoTotal.ToString() + ".¿Desea generar la reserva?", "Pregunta", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
                        {
                            return;
                        }

                        cargarComboBoxTipoDocumento();
                        lblNombre.Visible = true;
                        textBoxNombre.Visible = true;
                        lblApellido.Visible = true;
                        textBoxApellido.Visible = true;
                        lblMail.Visible = true;
                        textBoxMail.Visible = true; ;
                        lblDocumento.Visible = true;
                        textBoxDocumento.Visible = true;
                        lblTipoDocumentoCliente.Visible = true;
                        comboBoxTipoDocumentoCliente.Visible = true;
                        lblDireccion.Visible = true;
                        textBoxDireccion.Visible = true;
                        lblTelefono.Visible = true;
                        textBoxTelefono.Visible = true;
                        lblNumeroDireccion.Visible = true;
                        textBoxNumeroDireccion.Visible = true;
                        lblCity.Visible = true;
                        textBoxCiudad.Visible = true;
                        lblPais.Visible = true;
                        textBoxPais.Visible = true;
                        buttonBuscarCliente.Visible = true;
                        btnCheckear.Visible = false;
                        btnConfirmarPaso.Enabled = true;
                        calendarInicio.Visible = false;
                        calendarFin.Visible = false;
                        labelRegimen.Visible = false;
                        txbRegimen.Visible = false;
                        cbxRegimenEstadia.Visible = false;
                        btnRegimenSeleccionar.Visible = false;
                        btnAgregar.Visible = false;
                        btnQuitar.Visible = false;
                        listBoxTipoHabitacion.Visible = false;
                        labelTpoHabitacion.Visible = false;
                        lblHotel.Visible = false;
                        cbxTipoHabitacion.Visible = false;
                        btnSeleccionarHotel.Visible = false;
                        comboHoteles.Visible = false;
                        textBoxHotel.Visible = false;
                        btnConfirmarPaso.Visible = true;
                        labelFechaInicio.Visible = false;
                        labelFechaFin.Visible = false;
                        lblErrorReserva.Visible = false;
                        labelWrongCodigo.Visible = false;
                        lblReserva.Visible = false;
                        textBoxReserva.Visible = false;
                        btnSeleccionarReserva.Visible = false;

                    }
                }
                else
                {
                    string fechaDisponibleHotel = string.Format("SELECT mant_fecha_inicio as FechaInicio, mant_fecha_fin as FechaFin FROM CAIA_UNLIMITED.Mantenimiento where hote_id = '{0}'", this.hotel);
                    DataSet dsFechasHotel = DataBase.realizarConsulta(fechaDisponibleHotel);
                    DateTime fechaElegidaInicio = calendarInicio.SelectionStart;
                    DateTime fechaElegidaFin = calendarFin.SelectionStart;
                    string fechaInicio = fechaElegidaInicio.ToString("yyyy-MM-dd HH:mm:ss");
                    string fechaFin = fechaElegidaFin.ToString("yyyy-MM-dd HH:mm:ss");
                    TimeSpan difference = fechaElegidaFin - fechaElegidaInicio;
                    this.difference = difference;
                    this.fechaElegidaInicio = fechaElegidaInicio;
                    if (dsFechasHotel != null && dsFechasHotel.Tables.Count > 0 && dsFechasHotel.Tables[0].Rows.Count > 0 && !DBNull.Value.Equals(dsFechasHotel.Tables[0].Rows[0]["FechaInicio"]) && !DBNull.Value.Equals(dsFechasHotel.Tables[0].Rows[0]["FechaFin"]))
                    {
                        DateTime fechaInicioHotel = Convert.ToDateTime(dsFechasHotel.Tables[0].Rows[0]["FechaInicio"].ToString());
                        DateTime fechaFinHotel = Convert.ToDateTime(dsFechasHotel.Tables[0].Rows[0]["FechaFin"].ToString());
                        if (((DateTime.Compare(fechaElegidaInicio, fechaInicioHotel)) < 0) || ((DateTime.Compare(fechaElegidaFin, fechaFinHotel)) > 0))
                        {
                            MessageBox.Show("El Hotel no esta abierto entre las fechas elegidas. Por favor, seleccione otras.");
                            return;
                        }
                    }
                    string queryRegimen = string.Format("SELECT regi_precio_base as Precio FROM CAIA_UNLIMITED.Regimen where regi_codigo = '{0}'", regimen);
                    string queryEstrella = string.Format("SELECT hote_recarga_estrella as Recarga FROM CAIA_UNLIMITED.Hotel where hote_id = '{0}'", this.hotel);
                    DataSet dsPrecioRegimen = DataBase.realizarConsulta(queryRegimen);
                    DataSet dsRecarga = DataBase.realizarConsulta(queryEstrella);
                    decimal costoTotal = 0;
                    string msg = "";
                    HabitacionalitiesCollection lh = new HabitacionalitiesCollection();
                    string anterior = "No especificado";
                    string queryNumeroHabitacion;
                    int j = 1;
                    eliminarHabitacionesAnteriores();

                    foreach (string tipitoHabitacion in listBoxTipoHabitacion.Items)
                    {
                        if (tipitoHabitacion == anterior)
                        {
                            j++;
                        }
                        else
                        {
                            anterior = tipitoHabitacion;
                            j = 1;
                        }
                        string queryHabitacionDisponible = string.Format("SELECT COUNT(*) FROM (SELECT h.habi_numero FROM CAIA_UNLIMITED.Tipo_Habitacion th JOIN CAIA_UNLIMITED.Habitacion h on h.thab_codigo = th.thab_codigo WHERE h.hote_id = '{0}' AND h.habi_habilitado = 1 AND th.thab_descripcion = '{1}' AND (SELECT COUNT(*) FROM CAIA_UNLIMITED.Habitacion_X_Reserva hr JOIN CAIA_UNLIMITED.Reserva r on (r.rese_codigo = hr.habi_rese_codigo AND '{0}' = hr.habi_rese_id AND hr.habi_rese_numero = h.habi_numero) WHERE (r.rese_fecha_desde between CONVERT(DATETIME,'{2}',120) AND CONVERT(DATETIME,'{3}',120)) OR (dateadd(day,r.rese_cantidad_noches,r.rese_fecha_desde) between CONVERT(DATETIME,'{2}',120) AND CONVERT(DATETIME,'{3}',120)))=0) t2", this.hotel, tipitoHabitacion, fechaInicio, fechaFin);
                        SqlConnection connection = DataBase.conectarBD();
                        SqlCommand commDisponibles = new SqlCommand(queryHabitacionDisponible, connection);
                        Int32 countDisponibles = Convert.ToInt32(commDisponibles.ExecuteScalar());
                        connection.Close();
                        if (countDisponibles < 1 || j > countDisponibles)
                        {
                            MessageBox.Show("No hay habitaciones disponibles de " + tipitoHabitacion + " en las fechas especificadas");
                            return;
                        }
                        queryNumeroHabitacion = string.Format("SELECT TOP " + countDisponibles.ToString() + " t2.HabitacionNumero FROM (SELECT DISTINCT h.habi_numero as HabitacionNumero,h.habi_piso as HabitacionPiso FROM CAIA_UNLIMITED.Tipo_Habitacion th JOIN CAIA_UNLIMITED.Habitacion h on h.thab_codigo = th.thab_codigo WHERE h.hote_id = '{0}' AND h.habi_habilitado = 1 AND th.thab_descripcion = '{1}' AND (SELECT COUNT(*) FROM CAIA_UNLIMITED.Habitacion_X_Reserva hr JOIN CAIA_UNLIMITED.Reserva r on (r.rese_codigo = hr.habi_rese_codigo AND '{0}' = hr.habi_rese_id AND hr.habi_rese_numero = h.habi_numero) WHERE (r.rese_fecha_desde between CONVERT(DATETIME,'{2}',120) AND CONVERT(DATETIME,'{3}',120)) OR (dateadd(day,r.rese_cantidad_noches,r.rese_fecha_desde) between CONVERT(DATETIME,'{2}',120) AND CONVERT(DATETIME,'{3}',120)))=0) t2", this.hotel, tipitoHabitacion, fechaInicio, fechaFin);
                        DataSet dsNumeroHabitacion = DataBase.realizarConsulta(queryNumeroHabitacion);
                        lh.Add(new Habitacionalities { Habitacion = ((decimal)(dsNumeroHabitacion.Tables[0].Rows[j - 1][0])) });
                        string queryTipitoHabitacion = string.Format("SELECT TOP 1 thab_porcentual as PrecioHabitacion FROM CAIA_UNLIMITED.Tipo_Habitacion where thab_descripcion = '{0}'", tipitoHabitacion);
                        DataSet dsTipitoHabitacion = DataBase.realizarConsulta(queryTipitoHabitacion);
                        decimal costoUnaHabitacion = 0;
                        if (tipitoHabitacion == "Base Doble" || tipitoHabitacion == "King")
                        {
                            costoUnaHabitacion = (2 * (decimal)dsPrecioRegimen.Tables[0].Rows[0]["Precio"]) + (decimal)dsRecarga.Tables[0].Rows[0]["Recarga"];
                        }
                        if (tipitoHabitacion == "Base Simple")
                        {
                            costoUnaHabitacion = (1 * (decimal)dsPrecioRegimen.Tables[0].Rows[0]["Precio"]) + (decimal)dsRecarga.Tables[0].Rows[0]["Recarga"];
                        }
                        if (tipitoHabitacion == "Base Triple")
                        {
                            costoUnaHabitacion = (3 * (decimal)dsPrecioRegimen.Tables[0].Rows[0]["Precio"]) + (decimal)dsRecarga.Tables[0].Rows[0]["Recarga"];
                        }
                        if (tipitoHabitacion == "Base Cuadruple")
                        {
                            costoUnaHabitacion = (4 * (decimal)dsPrecioRegimen.Tables[0].Rows[0]["Precio"]) + (decimal)dsRecarga.Tables[0].Rows[0]["Recarga"];
                        }
                        msg += (string.Format("El monto de la habitacion " + tipitoHabitacion + "es de '{0}' \n", costoUnaHabitacion));
                        costoTotal = costoTotal + costoUnaHabitacion;
                    }

                    this.lh = lh;

                    MessageBox.Show(msg);

                    if (MessageBox.Show("El costo total de la reserva es de " + costoTotal.ToString() + ".¿Desea generar la reserva?", "Pregunta", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
                    {
                        return;
                    }

                    cargarComboBoxTipoDocumento();
                    lblNombre.Visible = true;
                    textBoxNombre.Visible = true;
                    lblApellido.Visible = true;
                    textBoxApellido.Visible = true;
                    lblMail.Visible = true;
                    textBoxMail.Visible = true; ;
                    lblDocumento.Visible = true;
                    textBoxDocumento.Visible = true;
                    lblTipoDocumentoCliente.Visible = true;
                    comboBoxTipoDocumentoCliente.Visible = true;
                    lblDireccion.Visible = true;
                    textBoxDireccion.Visible = true;
                    lblTelefono.Visible = true;
                    textBoxTelefono.Visible = true;
                    lblNumeroDireccion.Visible = true;
                    textBoxNumeroDireccion.Visible = true;
                    lblCity.Visible = true;
                    textBoxCiudad.Visible = true;
                    lblPais.Visible = true;
                    textBoxPais.Visible = true;
                    buttonBuscarCliente.Visible = true;
                    btnCheckear.Visible = false;
                    btnConfirmarPaso.Enabled = true;
                    calendarInicio.Visible = false;
                    calendarFin.Visible = false;
                    labelRegimen.Visible = false;
                    txbRegimen.Visible = false;
                    cbxRegimenEstadia.Visible = false;
                    btnRegimenSeleccionar.Visible = false;
                    btnAgregar.Visible = false;
                    btnQuitar.Visible = false;
                    listBoxTipoHabitacion.Visible = false;
                    labelTpoHabitacion.Visible = false;
                    lblHotel.Visible = false;
                    cbxTipoHabitacion.Visible = false;
                    btnSeleccionarHotel.Visible = false;
                    comboHoteles.Visible = false;
                    textBoxHotel.Visible = false;
                    btnConfirmarPaso.Visible = true;
                    labelFechaInicio.Visible = false;
                    labelFechaFin.Visible = false;
                    lblErrorReserva.Visible = false;
                    labelWrongCodigo.Visible = false;
                    lblReserva.Visible = false;
                    textBoxReserva.Visible = false;
                    btnSeleccionarReserva.Visible = false;

                }
            }
            else
            {
                if (txbRegimen.Text.Trim() == "")
                {
                    this.Hide();
                    VariantesRegimenes variantes = new VariantesRegimenes(this.hotel);
                    variantes.ShowDialog();
                    this.Show();
                    if (variantes.eligioRegimen)
                    {
                        decimal regimen = variantes.regimenElegido;

                        string fechaDisponibleHotel = string.Format("SELECT mant_fecha_inicio as FechaInicio, mant_fecha_fin as FechaFin FROM CAIA_UNLIMITED.Mantenimiento where hote_id = '{0}'", this.hotel);
                        DataSet dsFechasHotel = DataBase.realizarConsulta(fechaDisponibleHotel);
                        DateTime fechaElegidaInicio = calendarInicio.SelectionStart;
                        DateTime fechaElegidaFin = calendarFin.SelectionStart;
                        string fechaInicio = fechaElegidaInicio.ToString("yyyy-MM-dd HH:mm:ss");
                        string fechaFin = fechaElegidaFin.ToString("yyyy-MM-dd HH:mm:ss");
                        TimeSpan difference = fechaElegidaFin - fechaElegidaInicio;
                        this.difference = difference;
                        this.fechaElegidaInicio = fechaElegidaInicio;
                        if (dsFechasHotel != null && dsFechasHotel.Tables.Count > 0 && dsFechasHotel.Tables[0].Rows.Count > 0 && !DBNull.Value.Equals(dsFechasHotel.Tables[0].Rows[0]["FechaInicio"]) && !DBNull.Value.Equals(dsFechasHotel.Tables[0].Rows[0]["FechaFin"]))
                        {
                            DateTime fechaInicioHotel = Convert.ToDateTime(dsFechasHotel.Tables[0].Rows[0]["FechaInicio"].ToString());
                            DateTime fechaFinHotel = Convert.ToDateTime(dsFechasHotel.Tables[0].Rows[0]["FechaFin"].ToString());
                            if (((DateTime.Compare(fechaElegidaInicio, fechaInicioHotel)) < 0) || ((DateTime.Compare(fechaElegidaFin, fechaFinHotel)) > 0))
                            {
                                MessageBox.Show("El Hotel no esta abierto entre las fechas elegidas. Por favor, seleccione otras.");
                                return;
                            }
                        }
                        string queryRegimen = string.Format("SELECT regi_precio_base as Precio FROM CAIA_UNLIMITED.Regimen where regi_codigo = '{0}'", regimen);
                        string queryEstrella = string.Format("SELECT hote_recarga_estrella as Recarga FROM CAIA_UNLIMITED.Hotel where hote_id = '{0}'", this.hotel);
                        DataSet dsPrecioRegimen = DataBase.realizarConsulta(queryRegimen);
                        DataSet dsRecarga = DataBase.realizarConsulta(queryEstrella);
                        decimal costoTotal = 0;
                        string msg = "";
                        HabitacionalitiesCollection lh = new HabitacionalitiesCollection();
                        string anterior = "No especificado";
                        string queryNumeroHabitacion;
                        int j = 1;
                        eliminarHabitacionesAnteriores();

                        foreach (string tipitoHabitacion in listBoxTipoHabitacion.Items)
                        {
                            if (tipitoHabitacion == anterior)
                            {
                                j++;
                            }
                            else
                            {
                                anterior = tipitoHabitacion;
                                j = 1;
                            }
                            string queryHabitacionDisponible = string.Format("SELECT COUNT(*) FROM (SELECT h.habi_numero FROM CAIA_UNLIMITED.Tipo_Habitacion th JOIN CAIA_UNLIMITED.Habitacion h on h.thab_codigo = th.thab_codigo WHERE h.hote_id = '{0}' AND h.habi_habilitado = 1 AND th.thab_descripcion = '{1}' AND (SELECT COUNT(*) FROM CAIA_UNLIMITED.Habitacion_X_Reserva hr JOIN CAIA_UNLIMITED.Reserva r on (r.rese_codigo = hr.habi_rese_codigo AND '{0}' = hr.habi_rese_id AND hr.habi_rese_numero = h.habi_numero) WHERE (r.rese_fecha_desde between CONVERT(DATETIME,'{2}',120) AND CONVERT(DATETIME,'{3}',120)) OR (dateadd(day,r.rese_cantidad_noches,r.rese_fecha_desde) between CONVERT(DATETIME,'{2}',120) AND CONVERT(DATETIME,'{3}',120)))=0) t2", this.hotel, tipitoHabitacion, fechaInicio, fechaFin);
                            SqlConnection connection = DataBase.conectarBD();
                            SqlCommand commDisponibles = new SqlCommand(queryHabitacionDisponible, connection);
                            Int32 countDisponibles = Convert.ToInt32(commDisponibles.ExecuteScalar());
                            connection.Close();
                            if (countDisponibles < 1 || j > countDisponibles)
                            {
                                MessageBox.Show("No hay habitaciones disponibles de " + tipitoHabitacion + " en las fechas especificadas");
                                return;
                            }
                            queryNumeroHabitacion = string.Format("SELECT TOP " + countDisponibles.ToString() + " t2.HabitacionNumero FROM (SELECT DISTINCT h.habi_numero as HabitacionNumero,h.habi_piso as HabitacionPiso FROM CAIA_UNLIMITED.Tipo_Habitacion th JOIN CAIA_UNLIMITED.Habitacion h on h.thab_codigo = th.thab_codigo WHERE h.hote_id = '{0}' AND h.habi_habilitado = 1 AND th.thab_descripcion = '{1}' AND (SELECT COUNT(*) FROM CAIA_UNLIMITED.Habitacion_X_Reserva hr JOIN CAIA_UNLIMITED.Reserva r on (r.rese_codigo = hr.habi_rese_codigo AND '{0}' = hr.habi_rese_id AND hr.habi_rese_numero = h.habi_numero) WHERE (r.rese_fecha_desde between CONVERT(DATETIME,'{2}',120) AND CONVERT(DATETIME,'{3}',120)) OR (dateadd(day,r.rese_cantidad_noches,r.rese_fecha_desde) between CONVERT(DATETIME,'{2}',120) AND CONVERT(DATETIME,'{3}',120)))=0) t2", this.hotel, tipitoHabitacion, fechaInicio, fechaFin);
                            DataSet dsNumeroHabitacion = DataBase.realizarConsulta(queryNumeroHabitacion);
                            lh.Add(new Habitacionalities { Habitacion = ((decimal)(dsNumeroHabitacion.Tables[0].Rows[j - 1][0])) });
                            string queryTipitoHabitacion = string.Format("SELECT TOP 1 thab_porcentual as PrecioHabitacion FROM CAIA_UNLIMITED.Tipo_Habitacion where thab_descripcion = '{0}'", tipitoHabitacion);
                            DataSet dsTipitoHabitacion = DataBase.realizarConsulta(queryTipitoHabitacion);
                            decimal costoUnaHabitacion = 0;
                            if (tipitoHabitacion == "Base Doble" || tipitoHabitacion == "King")
                            {
                                costoUnaHabitacion = (2 * (decimal)dsPrecioRegimen.Tables[0].Rows[0]["Precio"]) + (decimal)dsRecarga.Tables[0].Rows[0]["Recarga"];
                            }
                            if (tipitoHabitacion == "Base Simple")
                            {
                                costoUnaHabitacion = (1 * (decimal)dsPrecioRegimen.Tables[0].Rows[0]["Precio"]) + (decimal)dsRecarga.Tables[0].Rows[0]["Recarga"];
                            }
                            if (tipitoHabitacion == "Base Triple")
                            {
                                costoUnaHabitacion = (3 * (decimal)dsPrecioRegimen.Tables[0].Rows[0]["Precio"]) + (decimal)dsRecarga.Tables[0].Rows[0]["Recarga"];
                            }
                            if (tipitoHabitacion == "Base Cuadruple")
                            {
                                costoUnaHabitacion = (4 * (decimal)dsPrecioRegimen.Tables[0].Rows[0]["Precio"]) + (decimal)dsRecarga.Tables[0].Rows[0]["Recarga"];
                            }
                            msg += (string.Format("El monto de la habitacion " + tipitoHabitacion + "es de '{0}' \n", costoUnaHabitacion));
                            costoTotal = costoTotal + costoUnaHabitacion;
                        }

                        this.lh = lh;

                        MessageBox.Show(msg);

                        if (MessageBox.Show("El costo total de la reserva es de " + costoTotal.ToString() + ".¿Desea generar la reserva?", "Pregunta", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
                        {
                            return;
                        }

                        cargarComboBoxTipoDocumento();
                        lblNombre.Visible = true;
                        textBoxNombre.Visible = true;
                        lblApellido.Visible = true;
                        textBoxApellido.Visible = true;
                        lblMail.Visible = true;
                        textBoxMail.Visible = true; ;
                        lblDocumento.Visible = true;
                        textBoxDocumento.Visible = true;
                        lblTipoDocumentoCliente.Visible = true;
                        comboBoxTipoDocumentoCliente.Visible = true;
                        lblDireccion.Visible = true;
                        textBoxDireccion.Visible = true;
                        lblTelefono.Visible = true;
                        textBoxTelefono.Visible = true;
                        lblNumeroDireccion.Visible = true;
                        textBoxNumeroDireccion.Visible = true;
                        lblCity.Visible = true;
                        textBoxCiudad.Visible = true;
                        lblPais.Visible = true;
                        textBoxPais.Visible = true;
                        buttonBuscarCliente.Visible = true;
                        btnCheckear.Visible = false;
                        btnConfirmarPaso.Enabled = true;
                        calendarInicio.Visible = false;
                        calendarFin.Visible = false;
                        labelRegimen.Visible = false;
                        txbRegimen.Visible = false;
                        cbxRegimenEstadia.Visible = false;
                        btnRegimenSeleccionar.Visible = false;
                        btnAgregar.Visible = false;
                        btnQuitar.Visible = false;
                        listBoxTipoHabitacion.Visible = false;
                        labelTpoHabitacion.Visible = false;
                        lblHotel.Visible = false;
                        cbxTipoHabitacion.Visible = false;
                        btnSeleccionarHotel.Visible = false;
                        comboHoteles.Visible = false;
                        textBoxHotel.Visible = false;
                        btnConfirmarPaso.Visible = true;
                        labelFechaInicio.Visible = false;
                        labelFechaFin.Visible = false;
                        lblErrorReserva.Visible = false;
                        labelWrongCodigo.Visible = false;
                        lblReserva.Visible = false;
                        textBoxReserva.Visible = false;
                        btnSeleccionarReserva.Visible = false;

                    }
                }
                else
                {
                    string fechaDisponibleHotel = string.Format("SELECT mant_fecha_inicio as FechaInicio, mant_fecha_fin as FechaFin FROM CAIA_UNLIMITED.Mantenimiento where hote_id = '{0}'", this.hotel);
                    DataSet dsFechasHotel = DataBase.realizarConsulta(fechaDisponibleHotel);
                    DateTime fechaElegidaInicio = calendarInicio.SelectionStart;
                    DateTime fechaElegidaFin = calendarFin.SelectionStart;
                    string fechaInicio = fechaElegidaInicio.ToString("yyyy-MM-dd HH:mm:ss");
                    string fechaFin = fechaElegidaFin.ToString("yyyy-MM-dd HH:mm:ss");
                    TimeSpan difference = fechaElegidaFin - fechaElegidaInicio;
                    this.difference = difference;
                    this.fechaElegidaInicio = fechaElegidaInicio;
                    if (dsFechasHotel != null && dsFechasHotel.Tables.Count > 0 && dsFechasHotel.Tables[0].Rows.Count > 0 && !DBNull.Value.Equals(dsFechasHotel.Tables[0].Rows[0]["FechaInicio"]) && !DBNull.Value.Equals(dsFechasHotel.Tables[0].Rows[0]["FechaFin"]))
                    {
                        DateTime fechaInicioHotel = Convert.ToDateTime(dsFechasHotel.Tables[0].Rows[0]["FechaInicio"].ToString());
                        DateTime fechaFinHotel = Convert.ToDateTime(dsFechasHotel.Tables[0].Rows[0]["FechaFin"].ToString());
                        if (((DateTime.Compare(fechaElegidaInicio, fechaInicioHotel)) < 0) || ((DateTime.Compare(fechaElegidaFin, fechaFinHotel)) > 0))
                        {
                            MessageBox.Show("El Hotel no esta abierto entre las fechas elegidas. Por favor, seleccione otras.");
                            return;
                        }
                    }
                    string queryRegimen = string.Format("SELECT regi_precio_base as Precio FROM CAIA_UNLIMITED.Regimen where regi_codigo = '{0}'", regimen);
                    string queryEstrella = string.Format("SELECT hote_recarga_estrella as Recarga FROM CAIA_UNLIMITED.Hotel where hote_id = '{0}'", this.hotel);
                    DataSet dsPrecioRegimen = DataBase.realizarConsulta(queryRegimen);
                    DataSet dsRecarga = DataBase.realizarConsulta(queryEstrella);
                    decimal costoTotal = 0;
                    string msg = "";
                    HabitacionalitiesCollection lh = new HabitacionalitiesCollection();
                    string anterior = "No especificado";
                    string queryNumeroHabitacion;
                    int j = 1;
                    eliminarHabitacionesAnteriores();

                    foreach (string tipitoHabitacion in listBoxTipoHabitacion.Items)
                    {
                        if (tipitoHabitacion == anterior)
                        {
                            j++;
                        }
                        else
                        {
                            anterior = tipitoHabitacion;
                            j = 1;
                        }
                        string queryHabitacionDisponible = string.Format("SELECT COUNT(*) FROM (SELECT h.habi_numero FROM CAIA_UNLIMITED.Tipo_Habitacion th JOIN CAIA_UNLIMITED.Habitacion h on h.thab_codigo = th.thab_codigo WHERE h.hote_id = '{0}' AND h.habi_habilitado = 1 AND th.thab_descripcion = '{1}' AND (SELECT COUNT(*) FROM CAIA_UNLIMITED.Habitacion_X_Reserva hr JOIN CAIA_UNLIMITED.Reserva r on (r.rese_codigo = hr.habi_rese_codigo AND '{0}' = hr.habi_rese_id AND hr.habi_rese_numero = h.habi_numero) WHERE (r.rese_fecha_desde between CONVERT(DATETIME,'{2}',120) AND CONVERT(DATETIME,'{3}',120)) OR (dateadd(day,r.rese_cantidad_noches,r.rese_fecha_desde) between CONVERT(DATETIME,'{2}',120) AND CONVERT(DATETIME,'{3}',120)))=0) t2", this.hotel, tipitoHabitacion, fechaInicio, fechaFin);
                        SqlConnection connection = DataBase.conectarBD();
                        SqlCommand commDisponibles = new SqlCommand(queryHabitacionDisponible, connection);
                        Int32 countDisponibles = Convert.ToInt32(commDisponibles.ExecuteScalar());
                        connection.Close();
                        if (countDisponibles < 1 || j > countDisponibles)
                        {
                            MessageBox.Show("No hay habitaciones disponibles de " + tipitoHabitacion + " en las fechas especificadas");
                            return;
                        }
                        queryNumeroHabitacion = string.Format("SELECT TOP " + countDisponibles.ToString() + " t2.HabitacionNumero FROM (SELECT DISTINCT h.habi_numero as HabitacionNumero,h.habi_piso as HabitacionPiso FROM CAIA_UNLIMITED.Tipo_Habitacion th JOIN CAIA_UNLIMITED.Habitacion h on h.thab_codigo = th.thab_codigo WHERE h.hote_id = '{0}' AND h.habi_habilitado = 1 AND th.thab_descripcion = '{1}' AND (SELECT COUNT(*) FROM CAIA_UNLIMITED.Habitacion_X_Reserva hr JOIN CAIA_UNLIMITED.Reserva r on (r.rese_codigo = hr.habi_rese_codigo AND '{0}' = hr.habi_rese_id AND hr.habi_rese_numero = h.habi_numero) WHERE (r.rese_fecha_desde between CONVERT(DATETIME,'{2}',120) AND CONVERT(DATETIME,'{3}',120)) OR (dateadd(day,r.rese_cantidad_noches,r.rese_fecha_desde) between CONVERT(DATETIME,'{2}',120) AND CONVERT(DATETIME,'{3}',120)))=0) t2", this.hotel, tipitoHabitacion, fechaInicio, fechaFin);
                        DataSet dsNumeroHabitacion = DataBase.realizarConsulta(queryNumeroHabitacion);
                        lh.Add(new Habitacionalities { Habitacion = ((decimal)(dsNumeroHabitacion.Tables[0].Rows[j - 1][0])) });
                        string queryTipitoHabitacion = string.Format("SELECT TOP 1 thab_porcentual as PrecioHabitacion FROM CAIA_UNLIMITED.Tipo_Habitacion where thab_descripcion = '{0}'", tipitoHabitacion);
                        DataSet dsTipitoHabitacion = DataBase.realizarConsulta(queryTipitoHabitacion);
                        decimal costoUnaHabitacion = 0;
                        if (tipitoHabitacion == "Base Doble" || tipitoHabitacion == "King")
                        {
                            costoUnaHabitacion = (2 * (decimal)dsPrecioRegimen.Tables[0].Rows[0]["Precio"]) + (decimal)dsRecarga.Tables[0].Rows[0]["Recarga"];
                        }
                        if (tipitoHabitacion == "Base Simple")
                        {
                            costoUnaHabitacion = (1 * (decimal)dsPrecioRegimen.Tables[0].Rows[0]["Precio"]) + (decimal)dsRecarga.Tables[0].Rows[0]["Recarga"];
                        }
                        if (tipitoHabitacion == "Base Triple")
                        {
                            costoUnaHabitacion = (3 * (decimal)dsPrecioRegimen.Tables[0].Rows[0]["Precio"]) + (decimal)dsRecarga.Tables[0].Rows[0]["Recarga"];
                        }
                        if (tipitoHabitacion == "Base Cuadruple")
                        {
                            costoUnaHabitacion = (4 * (decimal)dsPrecioRegimen.Tables[0].Rows[0]["Precio"]) + (decimal)dsRecarga.Tables[0].Rows[0]["Recarga"];
                        }
                        msg += (string.Format("El monto de la habitacion " + tipitoHabitacion + "es de '{0}' \n", costoUnaHabitacion));
                        costoTotal = costoTotal + costoUnaHabitacion;
                    }

                    this.lh = lh;

                    MessageBox.Show(msg);

                    if (MessageBox.Show("El costo total de la reserva es de " + costoTotal.ToString() + ".¿Desea generar la reserva?", "Pregunta", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
                    {
                        return;
                    }

                    cargarComboBoxTipoDocumento();
                    lblNombre.Visible = true;
                    textBoxNombre.Visible = true;
                    lblApellido.Visible = true;
                    textBoxApellido.Visible = true;
                    lblMail.Visible = true;
                    textBoxMail.Visible = true; ;
                    lblDocumento.Visible = true;
                    textBoxDocumento.Visible = true;
                    lblTipoDocumentoCliente.Visible = true;
                    comboBoxTipoDocumentoCliente.Visible = true;
                    lblDireccion.Visible = true;
                    textBoxDireccion.Visible = true;
                    lblTelefono.Visible = true;
                    textBoxTelefono.Visible = true;
                    lblNumeroDireccion.Visible = true;
                    textBoxNumeroDireccion.Visible = true;
                    lblCity.Visible = true;
                    textBoxCiudad.Visible = true;
                    lblPais.Visible = true;
                    textBoxPais.Visible = true;
                    buttonBuscarCliente.Visible = true;
                    btnCheckear.Visible = false;
                    btnConfirmarPaso.Enabled = true;
                    calendarInicio.Visible = false;
                    calendarFin.Visible = false;
                    labelRegimen.Visible = false;
                    txbRegimen.Visible = false;
                    cbxRegimenEstadia.Visible = false;
                    btnRegimenSeleccionar.Visible = false;
                    btnAgregar.Visible = false;
                    btnQuitar.Visible = false;
                    listBoxTipoHabitacion.Visible = false;
                    labelTpoHabitacion.Visible = false;
                    lblHotel.Visible = false;
                    cbxTipoHabitacion.Visible = false;
                    btnSeleccionarHotel.Visible = false;
                    comboHoteles.Visible = false;
                    textBoxHotel.Visible = false;
                    btnConfirmarPaso.Visible = true;
                    labelFechaInicio.Visible = false;
                    labelFechaFin.Visible = false;
                    lblErrorReserva.Visible = false;
                    labelWrongCodigo.Visible = false;
                    lblReserva.Visible = false;
                    textBoxReserva.Visible = false;
                    btnSeleccionarReserva.Visible = false;

                }
            }


        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            listBoxTipoHabitacion.Items.Clear();
            cbxRegimenEstadia.Text = "";
            cbxTipoHabitacion.Text = "";
            cbxRegimenEstadia.Items.Clear();
            cbxTipoHabitacion.Items.Clear();
            limpiarErrores();
            limpiarTextBox();
            if (guest)
            {
                cargarComboBoxHoteles();
            }
            else
            {
                cargarComboBoxRegimenes();
                cargarComboBoxTipoHabitacion();
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (listBoxTipoHabitacion.SelectedItem != null)
            {
                listBoxTipoHabitacion.Items.Remove(listBoxTipoHabitacion.SelectedItem);
                if (listBoxTipoHabitacion.Items.Count > 0)
                    listBoxTipoHabitacion.SelectedIndex = 0;
            }
        }

        private void btnSeleccionarHotel_Click_1(object sender, EventArgs e)
        {
            textBoxHotel.Text = comboHoteles.SelectedItem.ToString();
            for (int i = 0; i < this.dsHoteles.Tables[0].Rows.Count; i++)
            {
                if (((string)(this.dsHoteles.Tables[0].Rows[i]["Hotel"])) == comboHoteles.SelectedItem.ToString())
                {
                    this.hotel = (decimal)this.dsHoteles.Tables[0].Rows[i]["idHotel"];
                }
            }

            listBoxTipoHabitacion.Items.Clear();
            cbxRegimenEstadia.Text = "";
            cbxTipoHabitacion.Text = "";
            cbxRegimenEstadia.Items.Clear();
            cbxTipoHabitacion.Items.Clear();
            cargarComboBoxRegimenes();
            cargarComboBoxTipoHabitacion();
        }

        private void btnRegimenSeleccionar_Click_1(object sender, EventArgs e)
        {
            if (cbxRegimenEstadia.SelectedItem != null)
            {
                txbRegimen.Text = cbxRegimenEstadia.SelectedItem.ToString();

                for (int i = 0; i < this.dsRegimenes.Tables[0].Rows.Count; i++)
                {
                    if (((string)(this.dsRegimenes.Tables[0].Rows[i]["Descripcion"])) == cbxRegimenEstadia.SelectedItem.ToString())
                    {
                        this.regimen = (decimal)this.dsRegimenes.Tables[0].Rows[i]["Codigo"];
                    }
                }
            }
        }

        private void buttonBuscarCliente_Click(object sender, EventArgs e)
        {
            this.Hide();
            BuscarCliente clienteBuscarte = new BuscarCliente();
            clienteBuscarte.ShowDialog();
            this.Show();
            if (clienteBuscarte.eligioCliente)
            {
                this.existeCliente = true;
                this.mail = clienteBuscarte.clienteElegidoMail;
                this.documento = clienteBuscarte.clienteElegidoDocumento;
                lblNombre.Visible = false;
                lblErrorNombre.Visible = false;
                textBoxNombre.Visible = false;
                lblApellido.Visible = false;
                lblErrorApellido.Visible = false;
                textBoxApellido.Visible = false;
                lblMail.Visible = false;
                lblErrorMail.Visible = false;
                textBoxMail.Visible = false;
                lblDocumento.Visible = false;
                lblErrorDocumento.Visible = false;
                textBoxDocumento.Visible = false;
                lblTipoDocumentoCliente.Visible = false;
                comboBoxTipoDocumentoCliente.Visible = false;
                lblDireccion.Visible = false;
                lblErrorDireccion.Visible = false;
                textBoxDireccion.Visible = false;
                lblTelefono.Visible = false;
                lblErrorTelefono.Visible = false;
                textBoxTelefono.Visible = false;
                lblNumeroDireccion.Visible = false;
                lblNroDireccion.Visible = false;
                textBoxNumeroDireccion.Visible = false;
                lblCity.Visible = false;
                lblErrorCiudad.Visible = false;
                textBoxCiudad.Visible = false;
                lblPais.Visible = false;
                lblErrorPais.Visible = false;
                textBoxPais.Visible = false;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirmarPaso_Click_1(object sender, EventArgs e)
        {
            if (existeCliente)
            {
                SqlConnection createConnection = DataBase.conectarBD();
                SqlCommand insertCommand;
                if (guest)
                {
                    insertCommand = new SqlCommand("[CAIA_UNLIMITED].sp_ModificarReservaHuesped", createConnection);
                    insertCommand.CommandType = CommandType.StoredProcedure;
                    insertCommand.Parameters.AddWithValue("@usuarioModificacion", "Guest");
                }
                else
                {
                    insertCommand = new SqlCommand("[CAIA_UNLIMITED].sp_ModificarReservaUsuario", createConnection);
                    insertCommand.CommandType = CommandType.StoredProcedure;
                    insertCommand.Parameters.AddWithValue("@usuarioModificacion", this.username);
                }
                insertCommand.Parameters.AddWithValue("@codigoReserva", this.reserva);
                insertCommand.Parameters.AddWithValue("@hotel", this.hotel);
                insertCommand.Parameters.AddWithValue("@fechaRealizacion", DataBase.fechaSistema());
                insertCommand.Parameters.AddWithValue("@fechaDesde", fechaElegidaInicio);
                insertCommand.Parameters.AddWithValue("@cantidadNoches", (decimal)difference.Days);
                insertCommand.Parameters.AddWithValue("@regimen", regimen);
                insertCommand.Parameters.AddWithValue("@estado", "Reserva modificada");
                SqlParameter tvpParam = insertCommand.Parameters.AddWithValue("@lista_Habitaciones", lh);
                tvpParam.SqlDbType = SqlDbType.Structured;
                tvpParam.TypeName = "[CAIA_UNLIMITED].HabitacionesLista";
                insertCommand.ExecuteNonQuery();

                SqlCommand insertCliente = new SqlCommand("[CAIA_UNLIMITED].sp_ModificarClienteExistente", createConnection);
                insertCliente.CommandType = CommandType.StoredProcedure;
                insertCliente.Parameters.AddWithValue("@codigoReserva", this.reserva);
                insertCliente.Parameters.AddWithValue("@documento", this.documento);
                insertCliente.Parameters.AddWithValue("@mail", this.mail);
                insertCliente.ExecuteNonQuery();

                MessageBox.Show("Reserva modificada exitosamente!");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                int parsedValue;
                if (textBoxNombre.Text.Trim() == "")
                {
                    lblErrorNombre.Visible = true;
                    lblErrorNoField.Visible = true;
                }
                else if (textBoxApellido.Text.Trim() == "")
                {
                    lblErrorApellido.Visible = true;
                    lblErrorNoField.Visible = true;
                }
                else if (textBoxMail.Text.Trim() == "")
                {
                    lblErrorMail.Visible = true;
                    lblErrorNoField.Visible = true;
                }
                else if (textBoxDocumento.Text.Trim() == "")
                {
                    lblErrorDocumento.Visible = true;
                    lblErrorNoField.Visible = true;
                }
                else if (textBoxTelefono.Text.Trim() == "")
                {
                    lblErrorTelefono.Visible = true;
                    lblErrorNoField.Visible = true;
                }
                else if (textBoxDireccion.Text.Trim() == "")
                {
                    lblErrorDireccion.Visible = true;
                    lblErrorNoField.Visible = true;
                }
                else if (textBoxNumeroDireccion.Text.Trim() == "")
                {
                    lblNroDireccion.Visible = true;
                    lblErrorNoField.Visible = true;
                }
                else if (!int.TryParse(textBoxTelefono.Text.Trim(), out parsedValue))
                {
                    lblErrorNumberValue.Visible = true;
                    lblErrorTelefono.Visible = true;
                }
                else if (textBoxPais.Text.Trim() == "")
                {
                    lblErrorPais.Visible = true;
                    lblErrorNoField.Visible = true;
                }
                else if (textBoxCiudad.Text.Trim() == "")
                {
                    lblErrorCiudad.Visible = true;
                    lblErrorNoField.Visible = true;
                }
                else
                {
                    SqlConnection createConnection = DataBase.conectarBD();
                    SqlCommand insertCommand;
                    string yaExistePKS = string.Format("SELECT COUNT(*) FROM CAIA_UNLIMITED.Huesped WHERE (hues_mail = '{0}' OR hues_documento = '{1}')", textBoxMail.Text.Trim(), textBoxDocumento.Text.Trim());
                    SqlCommand commYaExistePKS = new SqlCommand(yaExistePKS, createConnection);
                    Int32 countYaExistentesPKS = Convert.ToInt32(commYaExistePKS.ExecuteScalar());
                    if (countYaExistentesPKS > 0)
                    {
                        MessageBox.Show("El mail o numero de identifacion ingresados coinciden con el de un usuario anterior. Intente con otro o elija un usuario ya existente");
                        return;
                    }
                    if (guest)
                    {
                        insertCommand = new SqlCommand("[CAIA_UNLIMITED].sp_ModificarReservaHuesped", createConnection);
                        insertCommand.CommandType = CommandType.StoredProcedure;
                        insertCommand.Parameters.AddWithValue("@usuarioModificacion", "Guest");
                    }
                    else
                    {
                        insertCommand = new SqlCommand("[CAIA_UNLIMITED].sp_ModificarReservaUsuario", createConnection);
                        insertCommand.CommandType = CommandType.StoredProcedure;
                        insertCommand.Parameters.AddWithValue("@usuarioModificacion", this.username);
                    }
                    insertCommand.Parameters.AddWithValue("@codigoReserva", this.reserva);
                    insertCommand.Parameters.AddWithValue("@hotel", this.hotel);
                    insertCommand.Parameters.AddWithValue("@fechaRealizacion", DataBase.fechaSistema());
                    insertCommand.Parameters.AddWithValue("@fechaDesde", fechaElegidaInicio);
                    insertCommand.Parameters.AddWithValue("@cantidadNoches", (decimal)difference.Days);
                    insertCommand.Parameters.AddWithValue("@regimen", regimen);
                    insertCommand.Parameters.AddWithValue("@estado", "Reserva modificada");
                    SqlParameter tvpParam = insertCommand.Parameters.AddWithValue("@lista_Habitaciones", lh);
                    tvpParam.SqlDbType = SqlDbType.Structured;
                    tvpParam.TypeName = "[CAIA_UNLIMITED].HabitacionesLista";
                    insertCommand.ExecuteNonQuery();

                    SqlCommand insertCliente = new SqlCommand("[CAIA_UNLIMITED].sp_CrearCliente", createConnection);
                    insertCliente.CommandType = CommandType.StoredProcedure;
                    insertCliente.Parameters.AddWithValue("@codigoReserva", this.reserva);
                    insertCliente.Parameters.AddWithValue("@name", textBoxNombre.Text.Trim());
                    insertCliente.Parameters.AddWithValue("@apellido", textBoxApellido.Text.Trim());
                    insertCliente.Parameters.AddWithValue("@tipoDocumento", comboBoxTipoDocumentoCliente.SelectedItem.ToString());
                    insertCliente.Parameters.AddWithValue("@documento", decimal.Parse(textBoxDocumento.Text.Trim()));
                    insertCliente.Parameters.AddWithValue("@pais", textBoxPais.Text.Trim());
                    insertCliente.Parameters.AddWithValue("@ciudad", textBoxCiudad.Text.Trim());
                    insertCliente.Parameters.AddWithValue("@telefono", decimal.Parse(textBoxTelefono.Text.Trim()));
                    insertCliente.Parameters.AddWithValue("@mail", textBoxMail.Text.Trim());
                    insertCliente.Parameters.AddWithValue("@calle", textBoxDireccion.Text.Trim());
                    insertCliente.Parameters.AddWithValue("@numeroCalle", decimal.Parse(textBoxNumeroDireccion.Text.Trim()));
                    insertCliente.ExecuteNonQuery();

                    MessageBox.Show("Reserva realizada exitosamente!");
                    createConnection.Close();
                    this.DialogResult = DialogResult.OK;
                }

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
