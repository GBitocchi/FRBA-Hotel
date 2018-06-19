using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmHotel
{
    public partial class ModificarHotel : Form
    {
        string hotel_id;
        string nombreViejo, mailViejo, cantidadDeEstrellas, telefonoViejo, direccionVieja, numeroViejo, ciudadVieja, paisViejo;
        public ModificarHotel(string hotelId)
        {
            InitializeComponent();
            hotel_id = hotelId;
            string consultaHotel = string.Format("select hote_nombre as 'Nombre hotel', hote_mail as 'Mail', hote_cant_estrellas as 'Cantidad de estrellas', dire_telefono as 'Telefono', dire_dom_calle as 'Calle', dire_nro_calle as 'Numero de calle', dire_ciudad as 'Ciudad', dire_pais as 'Pais', hote_fecha_creacion as 'Fecha' from CAIA_UNLIMITED.Hotel H join CAIA_UNLIMITED.Direccion D on (H.dire_id = D.dire_id) where hote_id = {0}", hotel_id);
            DataTable hotel = DataBase.realizarConsulta(consultaHotel).Tables[0];
            cargarTextBoxes(hotel);
            dgRegimenes.DataSource = DataBase.realizarConsulta("select regi_codigo, regi_descripcion, regi_precio_base, 1 as 'Habilitado' from CAIA_UNLIMITED.Regimen join CAIA_UNLIMITED.Regimen_X_Hotel on (regi_codigo = regi_hote_codigo) join CAIA_UNLIMITED.Hotel on (hote_id = regi_hote_id) where hote_id =" + hotel_id + "union select regi_codigo, regi_descripcion, regi_precio_base, 0 as 'Habilitado' from CAIA_UNLIMITED.Regimen R where not exists(select regi_codigo from CAIA_UNLIMITED.Regimen_X_Hotel X where R.regi_codigo = X.regi_hote_codigo and regi_hote_id =" + hotel_id + ")" ).Tables[0];
            valoresViejos();
            ocultarErrores();
            dgRegimenes.AllowUserToAddRows = false;
        }

        private void ocultarErrores()
        {
            lblCiudad.Visible = false;
            lblDireccion.Visible = false;
            lblMail.Visible = false;
            lblNombreHotel.Visible = false;
            lblPais.Visible = false;
            lblTelefono.Visible = false;
            lblRegimenes.Visible = false;
            lblFecha.Visible = false;
            lblEstrellas.Visible = false;
        }

        private void valoresViejos()
        {
            nombreViejo = txtNombreHotel.Text;
            mailViejo = txtMail.Text;
            cantidadDeEstrellas = (cbCantidadEstrellas.SelectedIndex + 1).ToString();
            telefonoViejo = txtTelefono.Text;
            direccionVieja = txtDireccion.Text;
            numeroViejo = txtNumero.Text;
            ciudadVieja = txtCiudad.Text;
            paisViejo = txtPais.Text;
        }

        private void cargarTextBoxes(DataTable hotel)
        {
            txtNombreHotel.Text = hotel.Rows[0][0].ToString();
            txtMail.Text = hotel.Rows[0][1].ToString();
            cbCantidadEstrellas.SelectedIndex = Int32.Parse(hotel.Rows[0][2].ToString()) - 1;
            txtTelefono.Text = hotel.Rows[0][3].ToString();
            txtDireccion.Text = hotel.Rows[0][4].ToString();
            txtNumero.Text = hotel.Rows[0][5].ToString();
            txtCiudad.Text = hotel.Rows[0][6].ToString();
            txtPais.Text = hotel.Rows[0][7].ToString();
            if (hotel.Rows[0][8].ToString() == "")
            {
                dtFechaCreacion.Value = DataBase.fechaSistema();
            }
            else
            {
                dtFechaCreacion.Value = Convert.ToDateTime(hotel.Rows[0][8].ToString());
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ocultarErrores();
            if (completo())
            {
                if (hayModificaciones())
                {
                    if (reservasPorRegimen())
                    {
                        ejecutarStoredProcedure();
                        new HotelModificado().Show();
                        this.Hide();
                    }
                    else
                    {
                        new ReservasParaRegimen().Show();
                    }
                }

            }
        }

        private bool reservasPorRegimen()
        {
            foreach (DataGridViewRow regimen in dgRegimenes.Rows)
            {
                if (!dgRegimenes.SelectedRows.Contains(regimen) && regimen.Cells[3].Value.ToString() == "1")
                {
                    if (DataBase.realizarConsulta("select * from CAIA_UNLIMITED.Reserva R join CAIA_UNLIMITED.Habitacion_X_Reserva X on (X.habi_rese_codigo = R.rese_codigo) join CAIA_UNLIMITED.Hotel H on (H.hote_id = X.habi_rese_id) join CAIA_UNLIMITED.Regimen E on (E.regi_codigo = R.regi_codigo) where H.hote_id =" + hotel_id + " and E.regi_codigo =" + regimen.Cells[0].Value.ToString()).Tables[0].Rows.Count != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void ejecutarStoredProcedure()
        {
            SqlConnection db = DataBase.conectarBD();
            SqlCommand modificarHotel = new SqlCommand("CAIA_UNLIMITED.sp_ModificarHotel", db);
            modificarHotel.CommandType = CommandType.StoredProcedure;
            modificarHotel.Parameters.AddWithValue("@idHotel", Convert.ToInt32(hotel_id));
            modificarHotel.Parameters.AddWithValue("@nombre_hotel", txtNombreHotel.Text.Trim());
            modificarHotel.Parameters.AddWithValue("@mail", txtMail.Text.Trim());
            modificarHotel.Parameters.AddWithValue("@estrellas", cbCantidadEstrellas.SelectedIndex + 1);
            modificarHotel.Parameters.AddWithValue("@hote_telefono", txtTelefono.Text.Trim());
            modificarHotel.Parameters.AddWithValue("@calle", txtDireccion.Text.Trim());
            modificarHotel.Parameters.AddWithValue("@numero_calle", Int32.Parse(txtNumero.Text.Trim()));
            modificarHotel.Parameters.AddWithValue("@ciudad", txtCiudad.Text.Trim());
            modificarHotel.Parameters.AddWithValue("@pais", txtPais.Text.Trim());
            modificarHotel.Parameters.AddWithValue("@fecha", dtFechaCreacion.Value.ToString("yyyyMMdd"));
            modificarHotel.ExecuteNonQuery();
            SqlCommand eliminarRegimenes = new SqlCommand("CAIA_UNLIMITED.sp_EliminarRegimenes", db);
            eliminarRegimenes.CommandType = CommandType.StoredProcedure;
            eliminarRegimenes.Parameters.AddWithValue("@hotel", hotel_id);
            eliminarRegimenes.ExecuteNonQuery();
            foreach (DataGridViewRow regimen in dgRegimenes.SelectedRows)
            {
                SqlCommand agregarRegimen = new SqlCommand("CAIA_UNLIMITED.sp_AgregarRegimenXHotel", db);
                agregarRegimen.CommandType = CommandType.StoredProcedure;
                agregarRegimen.Parameters.AddWithValue("@codigo_regimen", regimen.Cells[0].Value.ToString());
                agregarRegimen.Parameters.AddWithValue("@id_hotel", hotel_id);
                agregarRegimen.ExecuteNonQuery();
            }
            db.Close();
        }

        private bool hayModificaciones()
        {
            if (txtNombreHotel.Text.Trim() == nombreViejo && txtMail.Text.Trim() == mailViejo && txtTelefono.Text.Trim() == telefonoViejo && txtDireccion.Text.Trim() == direccionVieja && txtNumero.Text.Trim() == numeroViejo && txtCiudad.Text.Trim() == ciudadVieja && txtPais.Text.Trim() == paisViejo && cantidadDeEstrellas == (cbCantidadEstrellas.SelectedIndex + 1).ToString() && !modificacionesEnRegimenes())
            {
                return false;
            }
            return true;
        }

        private bool modificacionesEnRegimenes()
        {
            bool hayModificaciones = false;
            foreach (DataGridViewRow regimen in dgRegimenes.SelectedRows)
            {
                if (dgRegimenes.SelectedRows.Contains(regimen) && regimen.Cells[3].Value.ToString() == "1")
                {
                    hayModificaciones = hayModificaciones || false;
                }
                else
                {
                    hayModificaciones = hayModificaciones || true;
                }
            }
            return hayModificaciones;
        }

        private bool completo()
        {
            int aux;
            if (txtNombreHotel.Text.Trim() == "")
            {
                lblNombreHotel.Visible = true;
            }
            else if (txtMail.Text.Trim() == "")
            {
                lblMail.Visible = true;
            }
            else if (txtTelefono.Text.Trim() == "" || !int.TryParse(txtTelefono.Text.Trim(), out aux))
            {
                lblTelefono.Visible = true;
            }
            else if (txtDireccion.Text.Trim() == "")
            {
                lblDireccion.Visible = true;
            }
            else if (txtNumero.Text.Trim() == "" || !int.TryParse(txtNumero.Text.Trim(), out aux))
            {
                lblDireccion.Visible = true;
            }
            else if (txtCiudad.Text.Trim() == "")
            {
                lblCiudad.Visible = true;
            }
            else if (txtPais.Text.Trim() == "")
            {
                lblPais.Visible = true;
            }
            else if (dtFechaCreacion.Value > DataBase.fechaSistema())
            {
                lblFecha.Visible = true;
            }
            else if (dgRegimenes.SelectedRows.Count == 0)
            {
                lblRegimenes.Visible = true;
            }
            else
            {
                return true;
            }
            return false;
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuHotel().Show();
        }
    }
}