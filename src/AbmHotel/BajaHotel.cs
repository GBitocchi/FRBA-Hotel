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
    public partial class BajaHotel : Form
    {
        public BajaHotel()
        {
            InitializeComponent();
            DataSet hoteles = DataBase.realizarConsulta("select hote_id as 'ID', hote_nombre as 'Nombre', hote_cant_estrellas as 'Estrellas', hote_mail as 'Mail', dire_dom_calle as 'Calle', dire_nro_calle as 'Numero', dire_ciudad as 'Ciudad', dire_pais as 'Pais' from CAIA_UNLIMITED.Hotel H join CAIA_UNLIMITED.Direccion D on (H.dire_id = D.dire_id)");
            dgHoteles.DataSource = hoteles.Tables[0];
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            new FechasMantenimiento(dgHoteles.SelectedRows[0].Cells[0].Value.ToString()).Show();
            this.Hide();
        }

        private void reiniciarVista()
        {
            txtNombreHotel.Clear();
            txtCiudad.Clear();
            txtCantidadEstrellas.Clear();
            txtPais.Clear();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string consultaHotel = generarConsulta();
            if (consultaHotel != "")
            {
                dgHoteles.DataSource = DataBase.realizarConsulta(consultaHotel).Tables[0];
            }
        }

        private string generarConsulta()
        {
            string consulta = "select hote_id as 'ID', hote_nombre as 'Nombre', hote_cant_estrellas as 'Estrellas', hote_mail as 'Mail', dire_dom_calle as 'Calle', dire_nro_calle as 'Numero', dire_ciudad as 'Ciudad', dire_pais as 'Pais', dire_telefono as 'Telefono' from CAIA_UNLIMITED.Hotel H join CAIA_UNLIMITED.Direccion D on (D.dire_id = H.dire_id)";
            bool hayOtro = false;
            if (txtNombreHotel.Text.Trim() != "")
            {
                consulta += " where ";
                consulta += string.Format("hote_nombre = '{0}'", txtNombreHotel.Text.Trim());
                hayOtro = true;
            }
            if (txtCantidadEstrellas.Text.Trim() != "")
            {
                if (hayOtro)
                {
                    consulta += ", ";
                }
                else
                {
                    consulta += " where ";
                }
                int cantidadEstrellas;
                if (int.TryParse(txtCantidadEstrellas.Text.Trim(), out cantidadEstrellas))
                {
                    consulta += string.Format("hote_cant_estrellas = {0}", cantidadEstrellas);
                }
                else
                {
                    MessageBox.Show("Las cantidad estrellas debe ser un numero.", "Campo invalido", MessageBoxButtons.OK);
                    return "";
                }
            }
            if (txtCiudad.Text.Trim() != "")
            {
                if (hayOtro)
                {
                    consulta += ", ";
                }
                else
                {
                    consulta += " where ";
                }
                consulta += string.Format("dire_ciudad = '{0}'", txtCiudad.Text.Trim());
            }
            if (txtPais.Text.Trim() != "")
            {
                if (hayOtro)
                {
                    consulta += ", ";
                }
                else
                {
                    consulta += " where ";
                }
                consulta += string.Format("dire_pais = '{0}'", txtPais.Text.Trim());
            }
            return consulta;
        }
    }
}
