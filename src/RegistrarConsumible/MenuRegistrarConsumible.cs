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

namespace FrbaHotel.RegistrarConsumible
{
    public partial class MenuRegistrarConsumible : Form
    {
        public MenuRegistrarConsumible()
        {
            InitializeComponent();
            cbxConsumible.DataSource = DataBase.realizarConsulta("select * from CAIA_UNLIMITED.Consumible").Tables[0];
            cbxConsumible.DisplayMember = "cons_descripcion";
        }

        private void btnAgregar_Consumible_Click(object sender, EventArgs e)
        {
            //VERIFICAR SI SE INGRESO TODO BIEN
            string consumible = cbxConsumible.SelectedValue.ToString();
            string cantidad = txtCantidad.Text;
            string consultaPrecio = string.Format("select cons_precio as 'Precio'from CAIA_UNLIMITED.Consumible where cons_descripcion='{0}'", consumible);
            DataTable precioObtenido = DataBase.realizarConsulta(consultaPrecio).Tables[0];
            string precio = precioObtenido.Rows[0][0].ToString();

            string[] formato = { consumible, cantidad, precio };
            var listViewItem = new ListViewItem(formato);
            listaConsumibles.Items.Add(listViewItem);
            cbxConsumible.SelectedIndex = 0;
            txtCantidad.Text = "0";
        }

        private void btnAgregar_Reserva_Click(object sender, EventArgs e)
        {
            string codigoEstadiaIngresado = string.Format("select esta_codigo as 'Codigo estadia' from CAIA_UNLIMITED.Estadia where esta_codigo='{0}'", txtCodigo_Estadia.Text);

            if (DataBase.realizarConsulta(codigoEstadiaIngresado).Tables[0].Rows.Count == 0)
            {
                string consultaHabitacion = string.Format("select habi_numero as 'Numero habitacion' from CAIA_UNLIMITED.Reserva R join CAIA_UNLIMITED.Estadia E on (R.rese_codigo = E.rese_codigo) where esta_codigo='{0}'", txtCodigo_Estadia.Text);
                DataTable habitacion = DataBase.realizarConsulta(consultaHabitacion).Tables[0];
                txtHabitacion.Text = habitacion.Rows[0][0].ToString();

                string consultaHotel = string.Format("select R.hote_id as 'Codigo hotel' from CAIA_UNLIMITED.Reserva R join CAIA_UNLIMITED.Estadia E on (R.rese_codigo = E.rese_codigo) where esta_codigo='{0}'", txtCodigo_Estadia.Text.Trim());
                DataTable hotel = DataBase.realizarConsulta(consultaHotel).Tables[0];
                txtHotel.Text = hotel.Rows[0][0].ToString();

                string consultaRegimen = string.Format("select regi_descripcion as 'Regimen' from CAIA_UNLIMITED.Regimen R join CAIA_UNLIMITED.Regimen_X_Hotel X on (R.regi_codigo = X.regi_codigo) join CAIA_UNLIMITED.Hotel H on (H.hote_id = X.hote_id) where esta_codigo='{0}'", txtHotel.Text);
                DataTable regimen = DataBase.realizarConsulta(consultaHabitacion).Tables[0];
                txtRegimen.Text = regimen.Rows[0][0].ToString();
            }
            else
            {
                MessageBox.Show("El codigo estadia es incorrecto.");
            }
        }

        private void btnEliminar_Consumible_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in listaConsumibles.SelectedItems)
            {
                listaConsumibles.Items.Remove(eachItem);
            }
        }

        private void btnIngresar_Consumibles_Click(object sender, EventArgs e)
        {
            SqlConnection db = DataBase.conectarBD();

            if (listaConsumibles != null)
            {
                foreach (ListViewItem eachItem in listaConsumibles.Items)
                {

                    string consultaCodigo = string.Format("select cons_codigo as 'Codigo'from CAIA_UNLIMITED.Consumible where cons_descripcion='{0}' and cons_precio='{1}'=", eachItem.SubItems[0].Text.ToString(), eachItem.SubItems[2].Text.ToString());
                    DataTable precioObtenido = DataBase.realizarConsulta(consultaCodigo).Tables[0];
                    string precio = precioObtenido.Rows[0][0].ToString();

                    SqlCommand registrarConsumible = new SqlCommand("sp_RegistrarConsumible", db);
                    registrarConsumible.CommandType = CommandType.StoredProcedure;
                    registrarConsumible.Parameters.AddWithValue("@codigo_Estadia", txtCodigo_Estadia.Text.Trim());
                    registrarConsumible.Parameters.AddWithValue("@codigo_Consumible", precio);

                    registrarConsumible.ExecuteNonQuery();

                }
                db.Close();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCodigo_Estadia.Clear();
            txtCantidad.Clear();
            txtHabitacion.Clear();
            txtHotel.Clear();
            txtRegimen.Clear();
            cbxConsumible.SelectedIndex = 0;
            listaConsumibles.Items.Clear();
        }

        private void listaConsumibles_SelectedIndexChanged(object sender, EventArgs e)
        {

        } 
    }
}
