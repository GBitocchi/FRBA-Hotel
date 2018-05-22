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
                string existencia_hotel = "select * from CAIA_UNLIMITED.Hotel H join CAIA_UNLIMITED.Direccion D on (H.dire_id = D.dire_id) where H.hote_nombre ='" + 
                    txtNombreHotel.Text.Trim() + "' and H.hote_cant_estrellas=" + cant_estrellas + " and D.dire_dom_calle ='" + txtDireccion.Text.Trim() + "' and D.dire_nro_calle =" +
                    txtNumero.Text.Trim() + " and  D.dire_ciudad='" + txtCiudad.Text.Trim() + "' and D.dire_pais='" + txtPais.Text.Trim() + "'";
                string existencia_direccion = "select * from CAIA_UNLIMITED.Direccion where dire_dom_calle='" + txtDireccion.Text.Trim() + "' and dire_nro_calle=" + txtNumero.Text.Trim() + " and dire_ciudad='" + txtCiudad.Text.Trim() +
                    "' and dire_pais='" + txtPais.Text.Trim() + "'";
                try
                {
                    DataBase.realizarConsulta(existencia_direccion);
                    DataBase.realizarConsulta(existencia_hotel);
                }
                catch
                {
                    Console.WriteLine("No existe");
                    NuevaDireccion();
                    string id_dire = ObtenerIDDireccion();
                    NuevoHotel(cant_estrellas, id_dire);
                    string id_hotel = ObtenerIDHotel(id_dire);
                    CrearRegimenXHotel(id_hotel);
                    new HotelCreado().Show();
                }
            }
        }

        private void CrearRegimenXHotel(string id_hotel)
        {
            foreach (DataGridViewRow regimen in dgRegimenes.SelectedRows)
            {
                string id_regimen = regimen.Cells[0].Value.ToString();
                string nuevo_hotel_regimen = "insert into CAIA_UNLIMITED.Regimen_X_Hotel (regi_hote_codigo, regi_hote_id) values (" + 
                    id_regimen +", " + id_hotel + ")";
                DataBase.procedureBD(nuevo_hotel_regimen);
            }
                
        }

        private string ObtenerIDHotel(string id_dire)
        {
            string obtener_id_hotel = "select hote_id from CAIA_UNLIMITED.Hotel where hote_nombre ='" + txtNombreHotel.Text.Trim() + "' and hote_mail='" + txtMail.Text.Trim() +
                "' and dire_id=" + id_dire;
            DataSet dh = DataBase.realizarConsulta(obtener_id_hotel);
            string id_hotel = dh.Tables[0].Rows[0][0].ToString();
            return id_hotel;
        }

        private void NuevoHotel(string cant_estrellas, string id_dire)
        {
            string nuevo_hotel = "insert into CAIA_UNLIMITED.Hotel (hote_nombre, hote_mail, hote_cant_estrellas, dire_id, hote_habilitado) values('" + txtNombreHotel.Text.Trim() + "', '" + txtMail.Text.Trim() + "', " +
                cant_estrellas + ", " + id_dire + ", " + 1 + ")";
            DataBase.procedureBD(nuevo_hotel);
        }

        private string ObtenerIDDireccion()
        {
            string obtener_id_direccion = "select dire_id from CAIA_UNLIMITED.Direccion where dire_dom_calle= '" + txtDireccion.Text.Trim() + "' and dire_nro_calle= " +
                txtNumero.Text.Trim() + " and dire_ciudad= '" + txtCiudad.Text.Trim() + "' and dire_pais= '" + txtPais.Text.Trim() + "' and dire_telefono= '" +
                txtTelefono.Text.Trim() + "'";
            DataSet dd = DataBase.realizarConsulta(obtener_id_direccion);
            string id_dire = dd.Tables[0].Rows[0][0].ToString();
            return id_dire;
        }

        private void NuevaDireccion()
        {
            string crear_dire = "insert into CAIA_UNLIMITED.Direccion (dire_dom_calle, dire_nro_calle, dire_ciudad, dire_pais, dire_telefono) values('" +
                txtDireccion.Text.Trim() + "', " + txtNumero.Text.Trim() + ", '" + txtCiudad.Text.Trim() + "', '" + txtPais.Text.Trim() + "', '" +
                txtTelefono.Text.Trim() + "')";
            DataBase.procedureBD(crear_dire);
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuHotel().Show();
        }
    }
}
