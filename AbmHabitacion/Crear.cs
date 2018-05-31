using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmHabitacion
{
    public partial class Crear : Form
    {
        int hotel_id;
        public Crear(int hotelId)
        {
            InitializeComponent();
            lblErrorDesc.Visible = false;
            lblErrorNroHab.Visible = false;
            lblErrorPiso.Visible = false;
            lblErrorTipoHab.Visible = false;
            lblErrorUbi.Visible = false;
            lblErrorHabiExistente.Visible = false;
            hotel_id = hotelId;
        }

        private bool constatarCampos()
        {
            if (txtNro_habitacion.Text == "")
            {
                lblErrorNroHab.Visible = true;
                return false;
            }
            else if (txtPiso.Text == "")
            {
                lblErrorPiso.Visible = true;
                return false;
            }
            else if (txtUbicacion.Text == "")
            {
                lblErrorUbi.Visible = true;
                return false;
            }
            else if (txtTipo_habitacion.Text == "")
            {
                lblErrorTipoHab.Visible = true;
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if(constatarCampos())
            {
                lblErrorDesc.Visible = false;
                lblErrorNroHab.Visible = false;
                lblErrorPiso.Visible = false;
                lblErrorTipoHab.Visible = false;
                lblErrorUbi.Visible = false;
                try
                {
                   // string nueva_habitacion = string.Format("SELECT hote_id, habi_numero, habi_piso, habi_frente, thab_codigo FROM CAIA_UNLIMITED.Habitacion WHERE habi_numero = {0} and habi_piso = {1} and habi_frente = {2} and thab_codigo = {3} and hote_id = {4}", txtNro_habitacion.Text.Trim(), txtPiso.Text.Trim(), txtUbicacion.Text.Trim(), txtTipo_habitacion.Text.Trim(), hote_id); //FALTA HOTE_ID
                    string nueva_habitacion = "SELECT hote_id, habi_numero, habi_piso, habi_frente, thab_codigo FROM CAIA_UNLIMITED.Habitacion where habi_numero= " + txtNro_habitacion.Text.Trim() + " and habi_piso=" + txtPiso.Text.Trim() + " and habi_frente='" + txtUbicacion.Text.Trim() + "' and thab_codigo=" + txtTipo_habitacion.Text.Trim() + " and hote_id=" + hotel_id.ToString(); 
                    DataSet ds = DataBase.realizarConsulta(nueva_habitacion);
                   
                    string id_hotel = ds.Tables[0].Rows[0]["hote_id"].ToString().Trim();
                    string habi_numero = ds.Tables[0].Rows[0]["habi_numero"].ToString().Trim();
                    string habi_piso = ds.Tables[0].Rows[0]["habi_piso"].ToString().Trim();
                    string habi_frente = ds.Tables[0].Rows[0]["habi_frente"].ToString().Trim();
                    string thab_codigo = ds.Tables[0].Rows[0]["thab_codigo"].ToString().Trim();

                    if (id_hotel == hotel_id.ToString() && habi_numero == txtNro_habitacion.Text.Trim() && habi_piso == txtPiso.Text.Trim() && habi_frente == txtUbicacion.Text.Trim() && thab_codigo == txtTipo_habitacion.Text.Trim())
                    {
                        lblErrorHabiExistente.Visible = true;
                    }
                }
                catch
                {
                    string nuevo_insert = "INSERT INTO CAIA_UNLIMITED.Habitacion (hote_id, habi_numero, habi_piso, habi_frente, habi_descripcion, thab_codigo) VALUES(" + hotel_id.ToString() + "," + txtNro_habitacion.Text.Trim() + "," + txtPiso.Text.Trim() + ",'" + txtUbicacion.Text.Trim() + "','" + txtDescripcion.Text.Trim() + "'," + txtTipo_habitacion.Text.Trim() + ")";
                    DataBase.procedureBD(nuevo_insert);
                    new HabitacionCreada().Show();
                    txtNro_habitacion.Clear();
                    txtPiso.Clear();
                    txtTipo_habitacion.Clear();
                    txtUbicacion.Clear();
                    txtDescripcion.Clear();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuHabitacion(hotel_id).Show();
        }
    }
}
