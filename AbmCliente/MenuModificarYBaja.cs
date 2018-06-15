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
            DataSet huespedes = DataBase.realizarConsulta("select hues_mail as 'Mail', hues_nombre as 'Nombre', hues_apellido as 'Apellido', hues_documento as 'Documento', hues_documento_tipo as 'Tipo'  from CAIA_UNLIMITED.Huesped");
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
            string consulta;
            if (txtNombre.Text.Trim() == "" && txtEmail.Text.Trim() == "" && txtApellido.Text.Trim() == "" && txtNro_Identificacion.Text.Trim() == ""  && txtTipo_Identificacion.Text.Trim() == "")
            {
                consulta = "select hues_nombre as 'Nombre', hues_apellido as 'Apellido', hues_documento as'DNI', hues_documento_tipo as 'Tipo', hues_mail as 'E-Mail', hues_nacimiento as 'Fecha de nacimiento', hues_nacionalidad as 'Nacionalidad', dire_dom_calle as 'Calle', dire_nro_calle as 'Nro', dire_piso as 'Piso', dire_dpto as 'Dpto', dire_ciudad as 'Ciudad',dire_pais as 'Pais', dire_telefono as 'Telefono' from CAIA_UNLIMITED.Huesped H join CAIA_UNLIMITED.Direccion D on (H.dire_id = D.dire_id)";
            }
            else
            {
                consulta = "select hues_nombre as 'Nombre', hues_apellido as 'Apellido', hues_documento as'DNI', hues_documento_tipo as 'Tipo', hues_mail as 'E-Mail', hues_nacimiento as 'Fecha de nacimiento', hues_nacionalidad as 'Nacionalidad', dire_dom_calle as 'Calle', dire_nro_calle as 'Nro', dire_piso as 'Piso', dire_dpto as 'Dpto', dire_ciudad as 'Ciudad',dire_pais as 'Pais', dire_telefono as 'Telefono' from CAIA_UNLIMITED.Huesped H join CAIA_UNLIMITED.Direccion D on (H.dire_id = D.dire_id) where ";
                bool hayOtro = false;
                if (txtNombre.Text.Trim() != "")
                {
                    consulta += string.Format("hues_nombre LIKE '%{0}%'", txtNombre.Text.Trim());
                    hayOtro = true;
                }

                if (txtApellido.Text.Trim() != "")
                {
                    if (hayOtro)
                    {
                        consulta += ", ";
                    }
                    consulta += string.Format("hues_apellido LIKE '%{0}%'", txtApellido.Text.Trim());
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
                    consulta += string.Format("hues_documento_tipo LIKE '%{0}%'", txtTipo_Identificacion.Text.Trim());
                }

                if (txtEmail.Text.Trim() != "")
                {
                    if (hayOtro)
                    {
                        consulta += ", ";
                    }
                    consulta += string.Format("hues_mail LIKE '%{0}%'", txtEmail.Text.Trim());
                }
                
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
