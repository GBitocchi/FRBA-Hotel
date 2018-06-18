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
              string usuarioIngresado = String.Format("SELECT hues_mail FROM CAIA_UNLIMITED.Huesped WHERE hues_mail = '{0}', hues_documento = '{1}'  AND hues_documento_tipo = '{2}'",txtMail.Text.Trim(), txtNumero.Text.Trim(),txtTipo.Text.Trim());

              if (DataBase.realizarConsulta(usuarioIngresado).Tables[0].Rows.Count == 0)
              {
                  string[] formato = { txtMail.Text.Trim(), txtTipo.Text.Trim(), txtNumero.Text.Trim() };
                  var listViewItem = new ListViewItem(formato);
                  listaHuesped.Items.Add(listViewItem);                  
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
                  this.Hide();
                  new CrearHuesped(txtMail.Text.Trim(),txtTipo.Text.Trim(),txtNumero.Text.Trim(),codigoReserva).Show();
              }

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string consultaFecha = string.Format("select rese_fecha_desde as 'Fecha inicio' from CAIA_UNLIMITED.Reserva where rese_codigo='{0}'", codigoReserva);
            DataTable fecha = DataBase.realizarConsulta(consultaFecha).Tables[0];
            string fechaIngresoReserva = fecha.Rows[0][0].ToString();
            int resultado = DateTime.Compare(DateTime.Parse(txtIngreso.Text), DateTime.Parse(fechaIngresoReserva));

            if (resultado < 0)
            {
                MessageBox.Show("Ingreso anticipado a la fecha de ingreso establecido en la reserva");
            }
            else if (resultado == 0)
            {
                ejecutarStoredProcedureRegistrarCheckIn();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Ingreso posterior a la fecha establecida, perdida de reserva");
            }

        }

        private void ejecutarStoredProcedureRegistrarCheckIn()
        {
            SqlConnection db = DataBase.conectarBD();
            SqlCommand crearIngreso = new SqlCommand("sp_RegistrarIngreso", db);
            crearIngreso.CommandType = CommandType.StoredProcedure;
            crearIngreso.Parameters.AddWithValue("@fecha_Inicio", txtIngreso.Text.Trim());
            crearIngreso.Parameters.AddWithValue("@usuario", txtUsuario.Text.Trim());
            crearIngreso.Parameters.AddWithValue("@codigo_Reserva", codigoReserva);
            crearIngreso.ExecuteNonQuery();
            db.Close();
        }

        private void cbxRegistrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxRegistrar.SelectedItem.ToString() == "Ingreso")
            {
                
                btnAceptar.Enabled = true;
            }
            else
            {
                dataGridClientes.Enabled = true;
                button1.Enabled = true;

            }
        }
    }
}
