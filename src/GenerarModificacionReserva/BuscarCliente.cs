using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.GenerarModificacionReserva
{
    public partial class BuscarCliente : Form
    {
        bool eligio = false;
        string nombre;
        string apellido;
        string mail;
        decimal documento;
        string tipoDocumento;
        string direccion;
        decimal numeroDireccion;
        string telefono;
        string ciudad;
        string pais;
        public bool eligioCliente { get { return eligio; } }
        public string clienteElegidoMail { get { return mail; } }
        public string clienteElegidoNombre { get { return nombre; } }
        public string clienteElegidoApellido { get { return apellido; } }
        public string clienteElegidoTipoDocumento { get { return tipoDocumento; } }
        public decimal clienteElegidoDocumento { get { return documento; } }
        public string clienteElegidoDireccion { get { return direccion; } }
        public decimal clienteElegidoNumeroDireccion { get { return numeroDireccion; } }
        public string clienteElegidoTelefono { get { return telefono; } }
        public string clienteElegidoCiudad { get { return ciudad; } }
        public string clienteElegidoPais { get { return pais; } }

        private void cargarComboBoxTipoDocumento()
        {
            comboBoxTipoDocumento.Items.Clear();
            string tipoDocumento = "SELECT DISTINCT hues_documento_tipo as Documento FROM CAIA_UNLIMITED.Huesped WHERE hues_documento_tipo is not null";
            DataSet dsTipoDocumento = DataBase.realizarConsulta(tipoDocumento);

            foreach (DataRow unTipoDocumento in dsTipoDocumento.Tables[0].Rows)
            {
                comboBoxTipoDocumento.Items.Add((string)unTipoDocumento["Documento"]);
            }
            if (comboBoxTipoDocumento.Items.Count > 0)
            {
                comboBoxTipoDocumento.SelectedIndex = 0;
            }
        }

        public BuscarCliente()
        {
            InitializeComponent();
            cargarComboBoxTipoDocumento();           
            DataGridViewButtonColumn botonSeleccionar = new DataGridViewButtonColumn();
            botonSeleccionar.HeaderText = "Elegir";
            botonSeleccionar.Text = "            Seleccionar          ";
            botonSeleccionar.UseColumnTextForButtonValue = true;
            dgvBuscarClientes.Columns.Add(botonSeleccionar);
            dgvBuscarClientes.AllowUserToAddRows = false;
        }

        private void dgvBuscarClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            try
            {
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {
                    this.documento = Convert.ToDecimal(dgvBuscarClientes.Rows[e.RowIndex].Cells["Documento"].Value.ToString());
                    this.mail = dgvBuscarClientes.Rows[e.RowIndex].Cells["Mail"].Value.ToString();
                    this.nombre = dgvBuscarClientes.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                    this.apellido = dgvBuscarClientes.Rows[e.RowIndex].Cells["Apellido"].Value.ToString();
                    this.tipoDocumento = dgvBuscarClientes.Rows[e.RowIndex].Cells["TipoDocumento"].Value.ToString();
                    this.direccion = dgvBuscarClientes.Rows[e.RowIndex].Cells["Direccion"].Value.ToString();
                    this.numeroDireccion = Convert.ToDecimal(dgvBuscarClientes.Rows[e.RowIndex].Cells["NroDireccion"].Value.ToString());
                    this.telefono = dgvBuscarClientes.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
                    this.ciudad = dgvBuscarClientes.Rows[e.RowIndex].Cells["Ciudad"].Value.ToString();
                    this.pais = dgvBuscarClientes.Rows[e.RowIndex].Cells["Pais"].Value.ToString();
                    this.eligio = true;
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (IndexOutOfRangeException iorem)
            {

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnMail_Click(object sender, EventArgs e)
        {
            if (textBoxMail.Text.Trim() != "")
            {
                string queryCliente = string.Format("SELECT h.hues_mail as Mail, h.hues_nombre as Nombre, h.hues_apellido as Apellido, h.hues_documento as Documento, h.hues_documento_tipo as TipoDocumento, d.dire_dom_calle as Direccion, d.dire_nro_calle as NroDireccion, d.dire_telefono as Telefono, d.dire_ciudad as Ciudad, d.dire_pais as Pais FROM CAIA_UNLIMITED.Huesped h JOIN CAIA_UNLIMITED.Direccion d on (h.dire_id = d.dire_id) where h.hues_mail LIKE '{0}' AND h.hues_documento LIKE '{1}' AND h.hues_habilitado = 1", "%" + textBoxMail.Text.Trim() + "%", "%" + textBoxNumeroDocumento.Text.Trim() + "%");
                DataSet dsClientes = DataBase.realizarConsulta(queryCliente);
                dgvBuscarClientes.DataSource = dsClientes.Tables[0];
                dgvBuscarClientes.AllowUserToAddRows = false;
            }
            else
            {
                MessageBox.Show("Tiene que insertar un mail para filtrar con ellos.");
            }
        }

        private void comboBoxTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            string queryCliente = string.Format("SELECT h.hues_mail as Mail, h.hues_nombre as Nombre, h.hues_apellido as Apellido, h.hues_documento as Documento, h.hues_documento_tipo as TipoDocumento, d.dire_dom_calle as Direccion, d.dire_nro_calle as NroDireccion, d.dire_telefono as Telefono, d.dire_ciudad as Ciudad, d.dire_pais as Pais FROM CAIA_UNLIMITED.Huesped h JOIN CAIA_UNLIMITED.Direccion d on (h.dire_id = d.dire_id) where h.hues_documento_tipo like '{0}' AND h.hues_habilitado = 1", "%" + comboBoxTipoDocumento.SelectedItem.ToString() + "%");
            DataSet dsClientes = DataBase.realizarConsulta(queryCliente);
            dgvBuscarClientes.DataSource = dsClientes.Tables[0];
            dgvBuscarClientes.AllowUserToAddRows = false;
        }

        private void btnSeleccionarNumeroIdentificacion_Click(object sender, EventArgs e)
        {
            if (textBoxNumeroDocumento.Text.Trim() != "")
            {
                string queryCliente = string.Format("SELECT h.hues_mail as Mail, h.hues_nombre as Nombre, h.hues_apellido as Apellido, h.hues_documento as Documento, h.hues_documento_tipo as TipoDocumento, d.dire_dom_calle as Direccion, d.dire_nro_calle as NroDireccion, d.dire_telefono as Telefono, d.dire_ciudad as Ciudad, d.dire_pais as Pais FROM CAIA_UNLIMITED.Huesped h JOIN CAIA_UNLIMITED.Direccion d on (h.dire_id = d.dire_id) where h.hues_mail LIKE '{0}' AND h.hues_documento LIKE '{1}' AND h.hues_habilitado = 1", "%" + textBoxMail.Text.Trim() + "%", "%" + textBoxNumeroDocumento.Text.Trim() + "%");
                DataSet dsClientes = DataBase.realizarConsulta(queryCliente);
                dgvBuscarClientes.DataSource = dsClientes.Tables[0];
                dgvBuscarClientes.AllowUserToAddRows = false;
            }
            else
            {
                MessageBox.Show("Tiene que insertar un numero de identificacion para filtrar con ellos.");
            }
       }

        private void button1_Click(object sender, EventArgs e)
        {
            string queryCliente = string.Format("SELECT h.hues_mail as Mail, h.hues_nombre as Nombre, h.hues_apellido as Apellido, h.hues_documento as Documento, h.hues_documento_tipo as TipoDocumento, d.dire_dom_calle as Direccion, d.dire_nro_calle as NroDireccion, d.dire_telefono as Telefono, d.dire_ciudad as Ciudad, d.dire_pais as Pais FROM CAIA_UNLIMITED.Huesped h JOIN CAIA_UNLIMITED.Direccion d on (h.dire_id = d.dire_id) where h.hues_documento_tipo like '{0}' AND h.hues_habilitado = 1", "%" + comboBoxTipoDocumento.SelectedItem.ToString() + "%");
            DataSet dsClientes = DataBase.realizarConsulta(queryCliente);
            dgvBuscarClientes.DataSource = dsClientes.Tables[0];
            dgvBuscarClientes.AllowUserToAddRows = false;
        }
    }
}

