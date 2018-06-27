using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

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
            if (camposValidos())
            {
                if (formatoMailCorrecto())
                {
                    string consulta = generarConsulta();
                    if (consulta != "")
                    {
                        DataSet huespedes = DataBase.realizarConsulta(consulta);
                        dgClientes.DataSource = huespedes.Tables[0];
                    }
                }
            }
        }

        private string generarConsulta()
        {
            string consulta;
            if (txtNombre.Text.Trim() == "" && txtEmail.Text.Trim() == "" && txtApellido.Text.Trim() == "" && txtNro_Identificacion.Text.Trim() == ""  && txtTipo_Identificacion.Text.Trim() == "")
            {
                consulta = "select hues_mail as 'E-Mail', hues_nombre as 'Nombre', hues_apellido as 'Apellido', hues_documento as'DNI', hues_documento_tipo as 'Tipo'  from CAIA_UNLIMITED.Huesped H join CAIA_UNLIMITED.Direccion D on (H.dire_id = D.dire_id)";
            }
            else
            {
                consulta = "select hues_mail as 'E-Mail', hues_nombre as 'Nombre', hues_apellido as 'Apellido', hues_documento as'DNI', hues_documento_tipo as 'Tipo'  from CAIA_UNLIMITED.Huesped H join CAIA_UNLIMITED.Direccion D on (H.dire_id = D.dire_id) where ";
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
                        consulta += " and ";
                    }
                    consulta += string.Format("hues_apellido LIKE '%{0}%'", txtApellido.Text.Trim());
                }

                if (txtNro_Identificacion.Text.Trim() != "")
                {
                    if (hayOtro)
                    {
                        consulta += " and ";
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
                        consulta += " and ";
                    }
                    consulta += string.Format("hues_documento_tipo LIKE '%{0}%'", txtTipo_Identificacion.Text.Trim());
                }

                if (txtEmail.Text.Trim() != "")
                {
                    if (hayOtro)
                    {
                        consulta += " and ";
                    }
                    consulta += string.Format("hues_mail LIKE '%{0}%'", txtEmail.Text.Trim());
                }
                
            }

            return consulta;
        }


        private bool formatoMailCorrecto()
        {
            if (txtEmail.Text != "")
            {
                Regex expEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                if (!expEmail.IsMatch(txtEmail.Text))
                {
                    MessageBox.Show("Formato de mail ingresado incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return true;
        }

        private bool camposValidos()
        {
            if( txtNro_Identificacion.Text != "")
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(txtNro_Identificacion.Text, @"^\d+$")  )
                {
                    MessageBox.Show("Solo se permiten valores numericos en el numero de identificacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;

                }
                else
                {
                    return true;
                }
            }
            return true;
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtEmail.Clear();
            txtNro_Identificacion.Clear();
            txtTipo_Identificacion.Clear();
        }

        private void btnReestablecer_Click(object sender, EventArgs e)
        {
            DataSet huespedes = DataBase.realizarConsulta("select hues_mail as 'Mail', hues_nombre as 'Nombre', hues_apellido as 'Apellido', hues_documento as 'Documento', hues_documento_tipo as 'Tipo'  from CAIA_UNLIMITED.Huesped");
            dgClientes.DataSource = huespedes.Tables[0];
        }

    }
}
