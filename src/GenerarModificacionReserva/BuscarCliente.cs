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
        string mail;
        decimal documento;
        public bool eligioCliente { get { return eligio; } }
        public string clienteElegidoMail { get { return mail; } }
        public decimal clienteElegidoDocumento { get { return documento; } }

        private void cargarComboBoxTipoDocumento()
        {
            comboBoxTipoDocumento.Items.Clear();
            string tipoDocumento = "SELECT DISTINCT hues_documento_tipo as Documento FROM CAIA_UNLIMITED.Huesped WHERE hues_documento_tipo is not null UNION SELECT DISTINCT usur_documento_tipo as Documento FROM CAIA_UNLIMITED.Usuario WHERE usur_documento_tipo is not null";
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
                string queryCliente = string.Format("SELECT hues_mail as Mail, hues_nombre as Nombre, hues_apellido as Apellido, hues_documento as Documento, hues_nacionalidad as Nacionalidad, hues_documento_tipo as TipoDocumento, hues_habilitado as Estado FROM CAIA_UNLIMITED.Huesped where hues_mail = '{0}'", textBoxMail.Text.Trim());
                DataSet dsClientes = DataBase.realizarConsulta(queryCliente);
                dgvBuscarClientes.DataSource = dsClientes.Tables[0];
            }
            else
            {
                MessageBox.Show("Tiene que insertar un mail para filtrar con ellos.");
            }
        }

        private void comboBoxTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            string queryCliente = string.Format("SELECT hues_mail as Mail, hues_nombre as Nombre, hues_apellido as Apellido, hues_documento as Documento, hues_nacionalidad as Nacionalidad, hues_documento_tipo as TipoDocumento, hues_habilitado as Estado FROM CAIA_UNLIMITED.Huesped where hues_documento_tipo = '{0}'", comboBoxTipoDocumento.SelectedItem.ToString());
            DataSet dsClientes = DataBase.realizarConsulta(queryCliente);
            dgvBuscarClientes.DataSource = dsClientes.Tables[0];
        }

        private void btnSeleccionarNumeroIdentificacion_Click(object sender, EventArgs e)
        {
            if (textBoxNumeroDocumento.Text.Trim() != "")
            {
                string queryCliente = string.Format("SELECT hues_mail as Mail, hues_nombre as Nombre, hues_apellido as Apellido, hues_documento as Documento, hues_nacionalidad as Nacionalidad, hues_documento_tipo as TipoDocumento, hues_habilitado as Estado FROM CAIA_UNLIMITED.Huesped where hues_documento = '{0}'", textBoxNumeroDocumento.Text.Trim());
                DataSet dsClientes = DataBase.realizarConsulta(queryCliente);
                dgvBuscarClientes.DataSource = dsClientes.Tables[0];
            }
            else
            {
                MessageBox.Show("Tiene que insertar un numero de identificacion para filtrar con ellos.");
            }
       }
    }
}

