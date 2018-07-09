using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using FrbaHotel;
using System.Globalization;
using System.Web;
using FrbaHotel.Login;
using System.Text.RegularExpressions;

namespace FrbaHotel.AbmUsuario
{
    public partial class VistaUsuarioModificar : Form
    {
        DataGridView _usuarioAModificar;
        DataSet _dsRoles;
        DataSet _dsHoteles;
        decimal direccion;
        string nombreUsuario;
        bool fuiModificado = false;
        string miNombreUsuario;
        decimal codigoMiRol;
        decimal miHotel;

        private byte[] encryptPassword(string password)
        {
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding encoder = Encoding.UTF8;
                return hash.ComputeHash(encoder.GetBytes(password));
            }
        }

        private void limpiarErrores()
        {
            lblErrorDialogBirthday.Visible = false;
            lblErrorDialogBlock.Visible = false;
            lblErrorDialogBlockNumber.Visible = false;
            lblErrorDialogCity.Visible = false;
            lblErrorDialogCountry.Visible = false;
            lblErrorDialogDepartamento.Visible = false;
            lblErrorDialogDocument.Visible = false;
            lblErrorDialogDocumentType.Visible = false;
            lblErrorDialogHotel.Visible = false;
            lblErrorDialogNacionality.Visible = false;
            lblErrorDialogNoValueInField.Visible = false;
            lblErrorDialogUserName.Visible = false;
            lblErrorDialogSurname.Visible = false;
            lblErrorDialogNumericValue.Visible = false;
            lblErrorDialogPiso.Visible = false;
            lblErrorDialogPW.Visible = false;
            lblErrorDialogRole.Visible = false;
            lblErrorDialogUser.Visible = false;
            lblErrorDialogDateFormat.Visible = false;
            lblErrorDialogTelefono.Visible = false;
            lblErrorDialogMail.Visible = false;
            lblErrorDialogListBoxEmpty.Visible = false;
            lblErrorDialogFechaValida.Visible = false;
        }

        private void limpiarTextBox()
        {
            textBoxDialogBirthday.Clear();
            textBoxDialogBlock.Clear();
            textBoxDialogBlockNumber.Clear();
            textBoxDialogCity.Clear();
            textBoxDialogCountry.Clear();
            textBoxDialogDepartamento.Clear();
            textBoxDialogDocument.Clear();
            textBoxDialogNacionality.Clear();
            textBoxDialogDocumentType.Clear();
            textBoxDialogPiso.Clear();
            textBoxDialogPW.Clear();
            textBoxDialogSurname.Clear();
            textBoxDialogUser.Clear();
            textBoxDialogUsername.Clear();
            textBoxDialogTelefono.Clear();
            textBoxDialogMail.Clear();
        }

        private void limpiarListBox()
        {
            listBoxDialogHoteles.Items.Clear();
            listBoxDialogRoles.Items.Clear();
        }
      
        public VistaUsuarioModificar(DataGridView usuarioAModificar,DataGridViewCellEventArgs e,decimal hotel,string miUsuario,decimal codRol)
        {
            InitializeComponent();
            limpiarErrores();
            limpiarTextBox();
            limpiarListBox();
            cargarComboBoxRol();
            cargarComboBoxHotel();
            lblDialogBloqMayus.Visible = false;
            this._usuarioAModificar = usuarioAModificar;
            this.direccion = Convert.ToDecimal(usuarioAModificar.Rows[e.RowIndex].Cells["idDireccion"].Value.ToString());
            this.nombreUsuario = textBoxDialogUser.Text = usuarioAModificar.Rows[e.RowIndex].Cells["NombreDeUsuario"].Value.ToString();
            this.miNombreUsuario = miUsuario;
            this.codigoMiRol = codRol;
            this.miHotel = hotel;
            if (this.nombreUsuario == this.miNombreUsuario)
            {
                fuiModificado = true;
            }
            bool habilitado = (bool)usuarioAModificar.Rows[e.RowIndex].Cells["Habilitado"].Value;
            if (habilitado)
            {
                radioButtonHabilitado.Select();
            }
            else
            {
                radioButtonDeshabilitado.Select();
            }
            textBoxDialogUsername.Text = usuarioAModificar.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
            textBoxDialogSurname.Text = usuarioAModificar.Rows[e.RowIndex].Cells["Apellido"].Value.ToString();
            textBoxDialogDocumentType.Text = usuarioAModificar.Rows[e.RowIndex].Cells["TipoDocumento"].Value.ToString();
            textBoxDialogDocument.Text = usuarioAModificar.Rows[e.RowIndex].Cells["Documento"].Value.ToString();
            if (usuarioAModificar.Rows[e.RowIndex].Cells["Nacimiento"].Value.ToString() != "")
            {
                monthCalendarDialog.SetDate(Convert.ToDateTime(usuarioAModificar.Rows[e.RowIndex].Cells["Nacimiento"].Value.ToString()));
                textBoxDialogBirthday.Text = usuarioAModificar.Rows[e.RowIndex].Cells["Nacimiento"].Value.ToString();
            }
            textBoxDialogMail.Text = usuarioAModificar.Rows[e.RowIndex].Cells["Mail"].Value.ToString();
            textBoxDialogTelefono.Text = usuarioAModificar.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
            textBoxDialogBlock.Text = usuarioAModificar.Rows[e.RowIndex].Cells["Calle"].Value.ToString();
            textBoxDialogBlockNumber.Text = usuarioAModificar.Rows[e.RowIndex].Cells["NumeroCalle"].Value.ToString();
            textBoxDialogPiso.Text = usuarioAModificar.Rows[e.RowIndex].Cells["Piso"].Value.ToString();
            textBoxDialogDepartamento.Text = usuarioAModificar.Rows[e.RowIndex].Cells["Departamento"].Value.ToString();
            textBoxDialogCity.Text = usuarioAModificar.Rows[e.RowIndex].Cells["Ciudad"].Value.ToString();
            textBoxDialogCountry.Text = usuarioAModificar.Rows[e.RowIndex].Cells["Pais"].Value.ToString();
            textBoxDialogNacionality.Text = usuarioAModificar.Rows[e.RowIndex].Cells["Pais"].Value.ToString();

            string queryUser = string.Format("SELECT r.rol_nombre as Rol FROM CAIA_UNLIMITED.Usuario u JOIN CAIA_UNLIMITED.Rol_X_Usuario ru on ru.rol_usur_id = u.usur_id JOIN CAIA_UNLIMITED.Rol r on ru.rol_usur_codigo = r.rol_codigo WHERE u.usur_username = '{0}'", usuarioAModificar.Rows[e.RowIndex].Cells["NombreDeUsuario"].Value.ToString());
            DataSet dsInfoUser = DataBase.realizarConsulta(queryUser);
            
            foreach (DataRow unRol in dsInfoUser.Tables[0].Rows)
            {
                listBoxDialogRoles.Items.Add((string)unRol["Rol"]);
            }

            if (listBoxDialogRoles.Items.Count > 0)
            {
                listBoxDialogRoles.SelectedIndex = 0;
                listBoxDialogRoles.Sorted = true;
            }            
            string queryUser2 = string.Format("SELECT DISTINCT CONCAT(d.dire_dom_calle,'-',d.dire_nro_calle) as Hotel FROM CAIA_UNLIMITED.Usuario u JOIN CAIA_UNLIMITED.Usuario_X_Hotel uh on uh.usur_hote_idusur = u.usur_id JOIN CAIA_UNLIMITED.Hotel h on h.hote_id = uh.usur_hote_idhote INNER JOIN CAIA_UNLIMITED.Direccion d on (h.dire_id = d.dire_id) WHERE u.usur_username = '{0}'", usuarioAModificar.Rows[e.RowIndex].Cells["NombreDeUsuario"].Value.ToString());
            DataSet dsInfoUser2 = DataBase.realizarConsulta(queryUser2);

            foreach (DataRow unHotel in dsInfoUser2.Tables[0].Rows)
            {
                listBoxDialogHoteles.Items.Add((string)unHotel["Hotel"]);
            }

            if (listBoxDialogHoteles.Items.Count > 0)
            {
                listBoxDialogHoteles.SelectedIndex = 0;
                listBoxDialogHoteles.Sorted = true;
            }
        }

        private void VistaUsuarioModificar_Load(object sender, EventArgs e)
        {

        }

        private void textBoxDialogPW_TextChanged(object sender, EventArgs e)
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                lblDialogBloqMayus.Visible = true;
            }
            else
            {
                lblDialogBloqMayus.Visible = false;
            }
        }

        private void cargarComboBoxRol()
        {
            comboBoxDialogRole.Items.Clear();
            string roles = "SELECT rol_codigo, rol_nombre FROM CAIA_UNLIMITED.Rol";
            DataSet dsRoles = DataBase.realizarConsulta(roles);
            this._dsRoles = dsRoles;

            foreach (DataRow unRol in dsRoles.Tables[0].Rows)
            {
                comboBoxDialogRole.Items.Add((string)unRol["rol_nombre"]);
            }
            if (comboBoxDialogRole.Items.Count > 0)
            {
                comboBoxDialogRole.SelectedIndex = 0;
            }
        }

        private void cargarComboBoxHotel()
        {
            comboBoxDialogHoteles.Items.Clear();
            string hoteles = "SELECT CONCAT(d.dire_dom_calle,'-',d.dire_nro_calle) as Hotel, hote_id as idHotel FROM CAIA_UNLIMITED.Hotel ho INNER JOIN CAIA_UNLIMITED.Direccion d on (ho.dire_id = d.dire_id)";
            DataSet dsHoteles = DataBase.realizarConsulta(hoteles);
            this._dsHoteles = dsHoteles;

            foreach (DataRow unHotel in dsHoteles.Tables[0].Rows)
            {
                comboBoxDialogHoteles.Items.Add((string)unHotel["Hotel"]);
            }
            if (comboBoxDialogHoteles.Items.Count > 0)
            {
                comboBoxDialogHoteles.SelectedIndex = 0;
            }
        }

        private void buttonDialogLimpiar_Click(object sender, EventArgs e)
        {
            limpiarErrores();
            limpiarTextBox();
            limpiarListBox();
            cargarComboBoxRol();
            cargarComboBoxHotel();
        }

        private void buttonDialogAgregarRole_Click(object sender, EventArgs e)
        {
            if (comboBoxDialogRole.SelectedItem != null)
            {
                if (!listBoxDialogRoles.Items.Contains(comboBoxDialogRole.SelectedItem))
                {
                    listBoxDialogRoles.Items.Add(comboBoxDialogRole.SelectedItem);
                }
                listBoxDialogRoles.SelectedIndex = 0;
                comboBoxDialogRole.Items.Remove(comboBoxDialogRole.SelectedItem);
                if (comboBoxDialogRole.Items.Count > 0)
                    comboBoxDialogRole.SelectedIndex = 0;
                else
                    comboBoxDialogRole.ResetText();
            }
        }

        private void buttonDialogQuitarRole_Click(object sender, EventArgs e)
        {
            if (listBoxDialogRoles.SelectedItem != null)
            {
                if (!comboBoxDialogRole.Items.Contains(listBoxDialogRoles.SelectedItem))
                {
                    comboBoxDialogRole.Items.Add(listBoxDialogRoles.SelectedItem);
                }
                comboBoxDialogRole.Sorted = true;
                listBoxDialogRoles.Items.Remove(listBoxDialogRoles.SelectedItem);
                comboBoxDialogRole.SelectedIndex = 0;
                if (listBoxDialogRoles.Items.Count > 0)
                    listBoxDialogRoles.SelectedIndex = 0;
            }
        }

        private void buttonDialogAgregarHotel_Click(object sender, EventArgs e)
        {
            if (comboBoxDialogHoteles.SelectedItem != null)
            {
                if (!listBoxDialogHoteles.Items.Contains(comboBoxDialogHoteles.SelectedItem))
                {
                    listBoxDialogHoteles.Items.Add(comboBoxDialogHoteles.SelectedItem);
                }
                listBoxDialogHoteles.SelectedIndex = 0;
                comboBoxDialogHoteles.Items.Remove(comboBoxDialogHoteles.SelectedItem);
                if (comboBoxDialogHoteles.Items.Count > 0)
                    comboBoxDialogHoteles.SelectedIndex = 0;
                else
                    comboBoxDialogHoteles.ResetText();
            }
        }

        private void buttonDialogQuitarHotel_Click(object sender, EventArgs e)
        {
            if (listBoxDialogHoteles.SelectedItem != null)
            {
                if (!comboBoxDialogHoteles.Items.Contains(listBoxDialogHoteles.SelectedItem))
                {
                    comboBoxDialogHoteles.Items.Add(listBoxDialogHoteles.SelectedItem);
                }               
                comboBoxDialogHoteles.Sorted = true;
                listBoxDialogHoteles.Items.Remove(listBoxDialogHoteles.SelectedItem);
                comboBoxDialogHoteles.SelectedIndex = 0;
                if (listBoxDialogHoteles.Items.Count > 0)
                    listBoxDialogHoteles.SelectedIndex = 0;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonDialogGuardar_Click(object sender, EventArgs e)
        {
            limpiarErrores();
            DateTime Result;
            int parsedValue;
            DateTimeFormatInfo info = new DateTimeFormatInfo();
            CultureInfo culture;
            culture = CultureInfo.CreateSpecificCulture("en-US");
            info.ShortDatePattern = "dd/MM/yyyy";
            Regex expEmail = new Regex(@"^([\w.-]+)@([\w-]+)((.(\w){2,3})+)$");
            if (!(DateTime.TryParse(textBoxDialogBirthday.Text.Trim(), info, DateTimeStyles.None, out Result)))
            {
                lblErrorDialogDateFormat.Visible = true;
                lblErrorDialogBirthday.Visible = true;
            }
            else if (!int.TryParse(textBoxDialogDocument.Text.Trim(), out parsedValue))
            {
                lblErrorDialogNumericValue.Visible = true;
                lblErrorDialogDocument.Visible = true;
            }
            else if (listBoxDialogHoteles.Items.Count == 0)
            {
                lblErrorDialogListBoxEmpty.Visible = true;
                lblErrorDialogHotel.Visible = true;
            }
            else if ((DateTime.Compare(DataBase.fechaSistema(), DateTime.Parse(textBoxDialogBirthday.Text.Trim()))) <= 0)
            {
                lblErrorDialogBirthday.Visible = true;
                lblErrorDialogFechaValida.Visible = true;
            }
            else if (listBoxDialogRoles.Items.Count == 0)
            {
                lblErrorDialogListBoxEmpty.Visible = true;
                lblErrorDialogRole.Visible = true;
            }
            else if (!int.TryParse(textBoxDialogBlockNumber.Text.Trim(), out parsedValue))
            {
                lblErrorDialogNumericValue.Visible = true;
                lblErrorDialogBlockNumber.Visible = true;
            }
            else if (textBoxDialogPiso.Text != "" && (!int.TryParse(textBoxDialogPiso.Text.Trim(), out parsedValue)))
            {
                lblErrorDialogNumericValue.Visible = true;
                lblErrorDialogPiso.Visible = true;
            }
            else if (textBoxDialogUsername.Text == "")
            {
                lblErrorDialogNoValueInField.Visible = true;
                lblErrorDialogUserName.Visible = true;
            }
            else if (textBoxDialogPW.Text == "")
            {
                lblErrorDialogNoValueInField.Visible = true;
                lblErrorDialogPW.Visible = true;
            }
            else if (textBoxDialogMail.Text == "")
            {
                lblErrorDialogNoValueInField.Visible = true;
                lblErrorDialogMail.Visible = true;
            }
            else if (!expEmail.IsMatch(textBoxDialogMail.Text))
            {
                MessageBox.Show("Formato de mail ingresado incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblErrorDialogMail.Visible = true;
            }
            else if (textBoxDialogBlock.Text == "")
            {
                lblErrorDialogNoValueInField.Visible = true;
                lblErrorDialogBlock.Visible = true;
            }
            else if (textBoxDialogBlockNumber.Text == "")
            {
                lblErrorDialogNoValueInField.Visible = true;
                lblErrorDialogBlockNumber.Visible = true;
            }
            else if (textBoxDialogUser.Text == "")
            {
                lblErrorDialogNoValueInField.Visible = true;
                lblErrorDialogUser.Visible = true;
            }
            else if (textBoxDialogSurname.Text == "")
            {
                lblErrorDialogNoValueInField.Visible = true;
                lblErrorDialogSurname.Visible = true;
            }
            else if (textBoxDialogNacionality.Text == "")
            {
                lblErrorDialogNoValueInField.Visible = true;
                lblErrorDialogNacionality.Visible = true;
            }
            else if (textBoxDialogBirthday.Text == "")
            {
                lblErrorDialogNoValueInField.Visible = true;
                lblErrorDialogBirthday.Visible = true;
            }
            else if (textBoxDialogDocument.Text == "")
            {
                lblErrorDialogNoValueInField.Visible = true;
                lblErrorDialogDocument.Visible = true;
            }
            else if (textBoxDialogDocumentType.Text == "")
            {
                lblErrorDialogNoValueInField.Visible = true;
                lblErrorDialogDocumentType.Visible = true;
            }
            else
            {
                string usuarioExistente = string.Format("SELECT COUNT(*) FROM CAIA_UNLIMITED.Usuario WHERE usur_username = '{0}' AND usur_username != '{1}'", textBoxDialogUser.Text.Trim(),this.nombreUsuario);

                SqlConnection connectionExistente = DataBase.conectarBD();
                SqlCommand commUserExistente = new SqlCommand(usuarioExistente, connectionExistente);
                Int32 countExistente = Convert.ToInt32(commUserExistente.ExecuteScalar());
                
                if (countExistente > 0)
                {
                    connectionExistente.Close();
                    MessageBox.Show("Ya existe un nombre de usuario con el nombre indicado. Intente con otro nombre.");
                    lblErrorDialogUser.Visible = true;
                    return;
                }             

                RolitiesCollection rc = new RolitiesCollection();
                foreach (string rol in listBoxDialogRoles.Items)
                {
                    for (int i = 0; i < this._dsRoles.Tables[0].Rows.Count; i++)
                    {
                        if (((string)(_dsRoles.Tables[0].Rows[i]["rol_nombre"])) == rol)
                        {
                            rc.Add(new Rolities { Roles = ((decimal)(this._dsRoles.Tables[0].Rows[i]["rol_codigo"])) });
                        }
                    }
                }

                HotelitiesCollection hc = new HotelitiesCollection();
                foreach (string hotel in listBoxDialogHoteles.Items)
               {
                   for (int i = 0; i < this._dsHoteles.Tables[0].Rows.Count; i++)
                   {

                       if (((string)(_dsHoteles.Tables[0].Rows[i]["Hotel"])) == hotel)
                       {
                           hc.Add(new Hotelities { Hoteles = ((decimal)(this._dsHoteles.Tables[0].Rows[i]["idHotel"])) });
                       }
                   }
               }

                try
                {
                    SqlConnection createConnection = DataBase.conectarBD();
                    SqlCommand insertCommand = new SqlCommand("[CAIA_UNLIMITED].sp_ModificarUsuarios", createConnection);
                    insertCommand.CommandType = CommandType.StoredProcedure;
                    insertCommand.Parameters.AddWithValue("@idDireccion", this.direccion);
                    insertCommand.Parameters.AddWithValue("@username", textBoxDialogUser.Text.Trim());
                    insertCommand.Parameters.AddWithValue("@password", encryptPassword(textBoxDialogPW.Text.Trim()));
                    insertCommand.Parameters.AddWithValue("@name", textBoxDialogUsername.Text.Trim());
                    insertCommand.Parameters.AddWithValue("@apellido", textBoxDialogSurname.Text.Trim());
                    insertCommand.Parameters.AddWithValue("@nacionalidad", textBoxDialogNacionality.Text.Trim());
                    insertCommand.Parameters.AddWithValue("@tipoDocumento", textBoxDialogDocumentType.Text.Trim());
                    insertCommand.Parameters.AddWithValue("@documento", Decimal.Parse(textBoxDialogDocument.Text.Trim()));
                    insertCommand.Parameters.AddWithValue("@fechaNacimiento", DateTime.Parse(textBoxDialogBirthday.Text.Trim()));

                    if (radioButtonHabilitado.Checked)
                    {
                        insertCommand.Parameters.AddWithValue("@estado", true);
                    }
                    else
                    {
                        insertCommand.Parameters.AddWithValue("@estado", false);
                    }

                    if (textBoxDialogCountry.Text.Trim() == "")
                    {
                        insertCommand.Parameters.AddWithValue("@pais", DBNull.Value);
                    }
                    else
                    {
                        insertCommand.Parameters.AddWithValue("@pais", textBoxDialogCountry.Text.Trim());
                    }

                    if (textBoxDialogCity.Text.Trim() == "")
                    {
                        insertCommand.Parameters.AddWithValue("@ciudad", DBNull.Value);
                    }
                    else
                    {
                        insertCommand.Parameters.AddWithValue("@ciudad", textBoxDialogCity.Text.Trim());
                    }

                    insertCommand.Parameters.AddWithValue("@calle", textBoxDialogBlock.Text.Trim());
                    insertCommand.Parameters.AddWithValue("@numeroCalle", textBoxDialogBlockNumber.Text.Trim());

                    if (textBoxDialogPiso.Text.Trim() == "")
                    {
                        insertCommand.Parameters.AddWithValue("@piso", DBNull.Value);
                    }
                    else
                    {
                        insertCommand.Parameters.AddWithValue("@piso", Decimal.Parse(textBoxDialogPiso.Text.Trim()));
                    }

                    if (textBoxDialogDepartamento.Text.Trim() == "")
                    {
                        insertCommand.Parameters.AddWithValue("@departamento", DBNull.Value);
                    }
                    else
                    {
                        insertCommand.Parameters.AddWithValue("@departamento", textBoxDialogDepartamento.Text.Trim());
                    }

                    if (textBoxDialogTelefono.Text.Trim() == "")
                    {
                        insertCommand.Parameters.AddWithValue("@telefono", DBNull.Value);
                    }
                    else
                    {
                        insertCommand.Parameters.AddWithValue("@telefono", Decimal.Parse(textBoxDialogTelefono.Text.Trim()));
                    }

                    insertCommand.Parameters.AddWithValue("@mail", textBoxDialogMail.Text.Trim());
                    SqlParameter listRolesParam = insertCommand.Parameters.AddWithValue("@lista_Roles", rc);
                    listRolesParam.SqlDbType = SqlDbType.Structured;
                    listRolesParam.TypeName = "[CAIA_UNLIMITED].RolesLista";
                    SqlParameter listHotelesParam = insertCommand.Parameters.AddWithValue("@lista_Hoteles", hc);
                    listHotelesParam.SqlDbType = SqlDbType.Structured;
                    listHotelesParam.TypeName = "[CAIA_UNLIMITED].HotelesLista";
                    insertCommand.ExecuteNonQuery();
                    createConnection.Close();

                    MessageBox.Show("Usuario modificado exitosamente!");
                    limpiarErrores();
                    limpiarListBox();
                    limpiarTextBox();
                    cargarComboBoxRol();
                    cargarComboBoxHotel();

                    if (fuiModificado)
                    {
                        this.Hide();
                        new Usuario().Show();
                    }
                    else
                    {
                        this.Hide();
                        new VistaUsuario(this.miHotel,this.codigoMiRol,this.miNombreUsuario).Show();
                    }
                }
                catch (Exception errorDB)
                {
                    MessageBox.Show(errorDB.Message);
                }
            }
        }

        private void monthCalendarDialog_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBoxDialogBirthday.Text = monthCalendarDialog.SelectionStart.ToShortDateString();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            new VistaUsuario(this.miHotel, this.codigoMiRol, this.miNombreUsuario).Show();
        }
    }
}
