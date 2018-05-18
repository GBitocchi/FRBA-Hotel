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
    public partial class CrearHotel : Form
    {
        private void MostrarDG()
        {
            string consulta_regimenes = "select regi_descripcion as 'Regimen', regi_precio_base as 'Precio base' from CAIA_UNLIMITED.Regimen";
            DataSet ds = DataBase.realizarConsulta(consulta_regimenes);
            dgRegimenes.DataSource = ds.Tables[0];
        }
       private bool Completo() 
       {
           lblCiudad.Visible = false;
           lblDireccion.Visible = false;
           lblEstrellas.Visible = false;
           lblMail.Visible = false;
           lblNombreHotel.Visible = false;
           lblPais.Visible = false;
           lblTelefono.Visible = false;
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
           else if (txtCiudad.Text.Trim() == "")
           {
               lblCiudad.Visible = true;
           }
           else if (txtPais.Text.Trim() == "")
           {
               lblPais.Visible = true;
           }
           else if (cbEstrellas.SelectedValue == null)
           {
               lblEstrellas.Visible = true;
           }
           else
           {
               return true;
           }
           return false;
       }

        public CrearHotel()
        {
            InitializeComponent();
            lblCiudad.Visible = false;
            lblDireccion.Visible = false;
            lblEstrellas.Visible = false;
            lblMail.Visible = false;
            lblNombreHotel.Visible = false;
            lblPais.Visible = false;
            lblTelefono.Visible = false;
            MostrarDG();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (Completo())
            {
                string existencia = "select hote_nombre, dire_dom_calle, dire_nro_calle, dire_telefono, dire_ciudad from CAIA_UNLIMITED.Hotel H join CAIA_UNLIMITED.Direccion D on (H.dire_id = D.dire_id) where hote_nombre =" + txtNombreHotel.Text.Trim() "and dire_dom_calle =" + txtDireccion.Text.Trim() + " and dire_nro_calle =" + txtNumero.Text.Trim() +  
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuHotel().Show();
        }
    }
}
