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
    public partial class FiltrarHotel : Form
    {
        public FiltrarHotel()
        {
            InitializeComponent();
            DataSet hoteles = DataBase.realizarConsulta("select hote_id as 'ID', hote_nombre as 'Nombre', hote_cant_estrellas as 'Estrellas', hote_mail as 'Mail', dire_dom_calle as 'Calle', dire_nro_calle as 'Numero', dire_ciudad as 'Ciudad', dire_pais as 'Pais', dire_telefono as 'Telefono' from CAIA_UNLIMITED.Hotel H join CAIA_UNLIMITED.Direccion D on (D.dire_id = H.dire_id)");
            dgHoteles.DataSource = hoteles.Tables[0];
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string consulta = generarConsulta();
            if (consulta != "")
            {
                DataSet hoteles = DataBase.realizarConsulta(consulta);
                dgHoteles.DataSource = hoteles.Tables[0];
            }
        }

        private string generarConsulta()
        {
            string consulta = "select hote_id as 'ID', hote_nombre as 'Nombre', hote_cant_estrellas as 'Estrellas', hote_mail as 'Mail', dire_dom_calle as 'Calle', dire_nro_calle as 'Numero', dire_ciudad as 'Ciudad', dire_pais as 'Pais', dire_telefono as 'Telefono' from CAIA_UNLIMITED.Hotel H join CAIA_UNLIMITED.Direccion D on (D.dire_id = H.dire_id) where ";
            bool hayOtro = false;
            if (txtNombreHotel.Text.Trim() != "")
            {
                consulta += string.Format("hote_nombre = '{0}'", txtNombreHotel.Text.Trim());
                hayOtro = true;
            }
            if (txtCantidadEstrellas.Text.Trim() != "")
            {
                if (hayOtro)
                {
                    consulta += ", ";
                }
                int cantidadEstrellas;
                if (int.TryParse(txtCantidadEstrellas.Text.Trim(), out cantidadEstrellas))
                {
                    consulta += string.Format("hote_cant_estrellas = {0}", cantidadEstrellas);
                }
                else
                {
                    new CampoInvalido().Show();
                    return "";
                }
            }
            if (txtCiudad.Text.Trim() != "")
            {
                if (hayOtro)
                {
                    consulta += ", ";
                }
                consulta += string.Format("dire_ciudad = '{0}'", txtCiudad.Text.Trim());
            }
            if (txtPais.Text.Trim() != "")
            {
                if (hayOtro)
                {
                    consulta += ", ";
                }
                consulta += string.Format("dire_pais = '{0}'", txtPais.Text.Trim());
            }
            return consulta;
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuHotel().Show();
        }

        private void dgHoteles_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string idHotel = dgHoteles.SelectedRows[0].Cells[0].Value.ToString();
            this.Hide();
            new ModificarHotel(idHotel).Show();
        }
    }
}
