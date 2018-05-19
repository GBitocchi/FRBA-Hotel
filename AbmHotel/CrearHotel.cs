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
            string consulta_regimenes = "select regi_codigo as 'Codigo', regi_descripcion as 'Regimen', regi_precio_base as 'Precio base' from CAIA_UNLIMITED.Regimen";
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
           else if (cbEstrellas.SelectedItem.ToString() == "Cantidad de estrellas...")
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
            Completo();
            if (Completo())
            {
                string cant_estrellas = cbEstrellas.SelectedItem.ToString().Split(' ')[0];
                string existencia = "select hote_nombre, dire_dom_calle, dire_nro_calle, dire_telefono, dire_ciudad from CAIA_UNLIMITED.Hotel H join CAIA_UNLIMITED.Direccion D on (H.dire_id = D.dire_id) where hote_nombre =" + 
                    txtNombreHotel.Text.Trim() + " and hote_cant_estrellas=" + cant_estrellas + " and dire_dom_calle =" + txtDireccion.Text.Trim() + " and dire_nro_calle =" +
                    txtNumero.Text.Trim() + " and  dire_ciudad=" + txtCiudad.Text + " and dire_pais=" + txtPais.Text;
                try
                {
                    DataBase.realizarConsulta(existencia);
                }
                catch
                {
                    string crear_dire = "insert into CAIA_UNLIMITED.Direccion (dire_dom_calle, dire_nro_calle, dire_ciudad, dire_pais, dire_telefono) values('" + 
                        txtDireccion.Text.Trim() + "', " + txtNumero.Text.Trim() + ", '" + txtCiudad.Text.Trim() + "', '" + txtPais.Text.Trim() + "', '" +
                        txtTelefono.Text.Trim() + "')";
                    DataBase.procedureBD(crear_dire);
                    string obtener_id_direccion = "select dire_id from CAIA_UNLIMITED.Direccion where dire_dom_calle= '" + txtDireccion.Text.Trim() + "' and dire_nro_calle= " +
                        txtNumero.Text.Trim() + " and dire_ciudad= '" + txtCiudad.Text.Trim() + "' and dire_pais= '" + txtPais.Text.Trim() + "' and dire_telefono= '" +
                        txtTelefono.Text.Trim() + "'";
                    DataSet ds = new DataSet();
                    ds = DataBase.realizarConsulta(obtener_id_direccion);
                    string id_dire = ds.Tables[0].Rows[0][0].ToString();
                    string crear_hotel = "insert into CAIA_UNLIMITED.Hotel (hote_nombre, hote_mail, hote_cant_estrellas, dire_id) values('" + txtNombreHotel.Text.Trim() + "', '" + txtMail.Text.Trim() + "', " + 
                        cant_estrellas + ", " + id_dire + ")";
                    DataBase.procedureBD(crear_hotel);
                 
                }
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuHotel().Show();
        }
    }
}
