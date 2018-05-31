using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            string consultaHotel = string.Format("select hote_nombre as 'Nombre hotel', hote_mail as 'Mail', hote_cant_estrellas as 'Cantidad de estrellas', dire_telefono as 'Telefono', dire_dom_calle as 'Calle', dire_nro_calle as 'Numero de calle', dire_ciudad as 'Ciudad', dire_pais as 'Pais' from CAIA_UNLIMITED.Hotel H join CAIA_UNLIMITED.Direccion D on (H.dire_id = D.dire_id) where hote_id = {0}", hotel_id);
            DataTable hotel = DataBase.realizarConsulta(consultaHotel).Tables[0];
            cargarTextBoxes(hotel);
            valoresViejos();
            ocultarErrores();
        }

        private void ocultarErrores()
        {
            lblCiudad.Visible = false;
            lblDireccion.Visible = false;
            lblMail.Visible = false;
            lblNombreHotel.Visible = false;
            lblPais.Visible = false;
            lblTelefono.Visible = false;
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
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (completo())
            {
            }
            this.Hide();
            //Abro la ventana de filtro


        }

        private bool completo()
        {
            if (txtNombreHotel.Text.Trim() == "")
            {
                lblNombreHotel.Visible = true;
            }
            else if (txtMail.Text.Trim() == "")
            {
                lblMail.Visible = true;
            }
            else if (txtTelefono.Text.Trim() == "")
            {
                lblTelefono.Visible = true;
            }
            else if (txtDireccion.Text.Trim() == "")
            {
                lblDireccion.Visible = true;
            }
            else if (txtNumero.Text.Trim() == "")
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
