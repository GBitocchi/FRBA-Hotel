using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmCliente
{
    public partial class MenuModificarYBaja : Form
    {
        public MenuModificarYBaja()
        {
            InitializeComponent();
            DataSet huespedes = DataBase.realizarConsulta("select hues_mail as 'Mail', hues_nombre as 'Nombre', hues_apellido as 'Apellido', hues_documento as 'Documento', hues_documento_tipo as 'Tipo' from CAIA_UNLIMITED.Huesped)");
            dgClientes.DataSource = huespedes.Tables[0];
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string consulta = generarConsulta();
            if (consulta != "")
            {
                DataSet huespedes = DataBase.realizarConsulta(consulta);
                dgClientes.DataSource = huespedes.Tables[0];
            }
        }

        private string generarConsulta()
        {
            string consulta = "select hues_mail as 'Mail', hues_nombre as 'Nombre', hues_apellido as 'Apellido', hues_documento as 'Documento', hues_documento_tipo as 'Tipo' from CAIA_UNLIMITED.Huesped where ";
            bool hayOtro = false;
            if (txtEmail.Text.Trim() != "")
            {
                consulta += string.Format("hues_mail = '{0}'", txtEmail.Text.Trim());
                hayOtro = true;
            }
            if (txtNombre.Text.Trim() != "")
            {
                if (hayOtro)
                {
                    consulta += ", ";
                }
                consulta += string.Format("hues_nombre = '{0}'", txtNombre.Text.Trim());
            }
            if (txtApellido.Text.Trim() != "")
            {
                if (hayOtro)
                {
                    consulta += ", ";
                }
                consulta += string.Format("dire_pais = '{0}'", txtApellido.Text.Trim());
            }
            if (txtNro_Identificacion.Text.Trim() != "")
            {
                if (hayOtro)
                {
                    consulta += ", ";
                }
                int documento;
                if (int.TryParse(txtNro_Identificacion.Text.Trim(), out documento))
                {
                    consulta += string.Format("hues_documento = {0}", documento);
                }
                else
                {
                    MessageBox.Show("Campo/s invalidos");
                    return "";
                }
            }
            if (txtTipo_Identificacion.Text.Trim() != "")
            {
                if (hayOtro)
                {
                    consulta += ", ";
                }
                consulta += string.Format("hues_documento_tipo = '{0}'", txtTipo_Identificacion.Text.Trim());
            }
           
            return consulta;
        }

        private void dgClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string mail = dgClientes.SelectedRows[0].Cells[0].Value.ToString();
            this.Hide();
            new Modificar(mail).Show();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuClientes().Show();
        }

    }
}
