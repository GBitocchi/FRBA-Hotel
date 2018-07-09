using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using FrbaHotel;
using FrbaHotel.Login;

namespace FrbaHotel.AbmRol
{
    public partial class VistaRolModificar : Form
    {
        DataSet _dsFuncionalidades;
        string _nombreRol;
        bool noEsMiRol = false;
        decimal codRolMio;
        decimal hoteidMio;
        string usernameMio;
        
        private void cargarFuncionalidadesRol(string nombreRol)
        {
            listBoxFuncionalidades.Items.Clear();
            string funcionalidades = string.Format("SELECT f.func_detalle FROM CAIA_UNLIMITED.Funcionalidad f JOIN CAIA_UNLIMITED.Funcionalidad_X_Rol fr on f.func_codigo = fr.func_rol_codigo_func JOIN CAIA_UNLIMITED.Rol r on r.rol_codigo = fr.func_rol_codigo_rol WHERE r.rol_nombre = '{0}'", nombreRol);
            DataSet dsFuncionalidades = DataBase.realizarConsulta(funcionalidades);
            this._nombreRol = nombreRol;
            foreach (DataRow unaFuncionalidad in dsFuncionalidades.Tables[0].Rows)
            {
                listBoxFuncionalidades.Items.Add((string)unaFuncionalidad["func_detalle"]);
            }
            if (listBoxFuncionalidades.Items.Count > 0)
            {
                listBoxFuncionalidades.SelectedIndex = 0;
            }
        }

        private void cargarFuncionalidadesFaltantes(string nombreRol)
        {
            comboBoxFuncionalidades.Items.Clear();
            string funcionalidadesFaltantes = string.Format("SELECT f.func_detalle FROM CAIA_UNLIMITED.Funcionalidad f WHERE f.func_codigo NOT IN (SELECT fr.func_rol_codigo_func FROM CAIA_UNLIMITED.Funcionalidad_X_Rol fr JOIN CAIA_UNLIMITED.Rol r on fr.func_rol_codigo_rol = r.rol_codigo WHERE r.rol_nombre = '{0}')",nombreRol);
            DataSet dsFuncionalidadesFaltantes = DataBase.realizarConsulta(funcionalidadesFaltantes);
            foreach (DataRow unaFuncionalidadFaltante in dsFuncionalidadesFaltantes.Tables[0].Rows)
            {
                comboBoxFuncionalidades.Items.Add((string)unaFuncionalidadFaltante["func_detalle"]);
            }
            if (comboBoxFuncionalidades.Items.Count > 0)
            {
                comboBoxFuncionalidades.SelectedIndex = 0;
            }
        }

        public VistaRolModificar(string _nombreRol,decimal codigoMiRol,decimal miHotel, string miNombreUsuario)
        {
            InitializeComponent();
            cargarFuncionalidades();
            this.codRolMio = codigoMiRol;
            this.hoteidMio = miHotel;
            this.usernameMio = miNombreUsuario;
            lblErrorNombreRol.Visible = false;
            lblErrorFuncionalidad.Visible = false;
            txbRolNombre.Text = _nombreRol;
            cargarFuncionalidadesRol(_nombreRol);
            cargarFuncionalidadesFaltantes(_nombreRol);
            string esMiRol = string.Format("SELECT rol_codigo FROM CAIA_UNLIMITED.Rol WHERE rol_nombre = '{0}' AND rol_codigo = '{1}'",_nombreRol,codigoMiRol);
            DataSet dsEsMiRol = DataBase.realizarConsulta(esMiRol);

            if (dsEsMiRol == null || dsEsMiRol.Tables.Count <= 0 || dsEsMiRol.Tables[0].Rows.Count <= 0)
            {
                noEsMiRol = true;
            }          

            string rolHabilitacion = string.Format("SELECT rol_estado FROM CAIA_UNLIMITED.Rol WHERE rol_nombre = '{0}'",_nombreRol);
            DataSet dsRolHabilitacion = DataBase.realizarConsulta(rolHabilitacion);
            if (((bool)dsRolHabilitacion.Tables[0].Rows[0]["rol_estado"]) == true)
            {
                rbActivated.Select();
            }
            else
            {
                rbDeactivated.Select();
            }
        }

        private void cargarFuncionalidades()
        {
            comboBoxFuncionalidades.Items.Clear();
            string funcionalidades = "SELECT func_codigo, func_detalle FROM CAIA_UNLIMITED.Funcionalidad";
            DataSet dsFuncionalidades = DataBase.realizarConsulta(funcionalidades);
            this._dsFuncionalidades = dsFuncionalidades;
            foreach (DataRow unaFuncionalidad in dsFuncionalidades.Tables[0].Rows)
            {
                comboBoxFuncionalidades.Items.Add((string)unaFuncionalidad["func_detalle"]);
            }
            if (comboBoxFuncionalidades.Items.Count > 0)
            {
                comboBoxFuncionalidades.SelectedIndex = 0;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            listBoxFuncionalidades.Items.Clear();
            txbRolNombre.Clear();
            lblErrorFuncionalidad.Visible = false;
            lblErrorNombreRol.Visible = false;
            rbActivated.Select();
            cargarFuncionalidades();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            lblErrorFuncionalidad.Visible = false;
            lblErrorNombreRol.Visible = false;

            if (txbRolNombre.Text == "")
            {
                lblErrorNombreRol.Visible = true;
            }
            else if (listBoxFuncionalidades.Items.Count == 0)
            {
                lblErrorFuncionalidad.Visible = true;
            }
            else
            {
                FuncionalityCollection fc = new FuncionalityCollection();
                foreach (string funcionalidad in listBoxFuncionalidades.Items)
                {
                    for (int i = 0; i < _dsFuncionalidades.Tables[0].Rows.Count; i++)
                    {
                        if (((string)(_dsFuncionalidades.Tables[0].Rows[i]["func_detalle"])) == funcionalidad)
                        {
                            fc.Add(new Funcionality { Funcionalidades = ((decimal)(_dsFuncionalidades.Tables[0].Rows[i]["func_codigo"])) });
                        }
                    }
                }

                    try
                    {
                        string rolCodigo = string.Format("SELECT rol_codigo FROM CAIA_UNLIMITED.Rol WHERE rol_nombre = '{0}'", this._nombreRol);
                        DataSet dsRolCodigo = DataBase.realizarConsulta(rolCodigo);
                        SqlConnection rolCreateConnection = DataBase.conectarBD();
                        SqlCommand insertCommand = new SqlCommand("[CAIA_UNLIMITED].sp_ModificarRol", rolCreateConnection);
                        insertCommand.CommandType = CommandType.StoredProcedure;
                        insertCommand.Parameters.AddWithValue("@codigo_rol", (decimal)(dsRolCodigo.Tables[0].Rows[0]["rol_codigo"]));
                        insertCommand.Parameters.AddWithValue("@nombre_rol", txbRolNombre.Text.Trim());
                        if (rbActivated.Checked)
                        {
                            insertCommand.Parameters.AddWithValue("@estado_rol", true);
                        }
                        else
                        {
                            insertCommand.Parameters.AddWithValue("@estado_rol", false);
                        }
                        SqlParameter tvpParam = insertCommand.Parameters.AddWithValue("@lista_Funcionalidades", fc);
                        tvpParam.SqlDbType = SqlDbType.Structured;
                        tvpParam.TypeName = "[CAIA_UNLIMITED].FuncionalidadesList";
                        insertCommand.ExecuteNonQuery();
                        rolCreateConnection.Close();
                        MessageBox.Show("Rol modificado exitosamente!");

                        if (this.noEsMiRol)
                        {
                            this.Hide();
                            new VistaRol(this.hoteidMio,this.codRolMio,this.usernameMio).Show();
                        }
                        else
                        {
                            this.Hide();
                            new Usuario().Show();
                        }
                    }
                    catch (Exception errorDB)
                    {
                        MessageBox.Show(errorDB.Message);
                    }
              

            }
        }

        private void btnQuitarFuncionalidad_Click(object sender, EventArgs e)
        {
            if (listBoxFuncionalidades.SelectedItem != null)
            {
                comboBoxFuncionalidades.Items.Add(listBoxFuncionalidades.SelectedItem);
                comboBoxFuncionalidades.Sorted = true;
                listBoxFuncionalidades.Items.Remove(listBoxFuncionalidades.SelectedItem);
                comboBoxFuncionalidades.SelectedIndex = 0;
                if (listBoxFuncionalidades.Items.Count > 0)
                    listBoxFuncionalidades.SelectedIndex = 0;
            }
        }

        private void btnAñadirFuncionalidad_Click(object sender, EventArgs e)
        {
            if (comboBoxFuncionalidades.SelectedItem != null)
            {
                listBoxFuncionalidades.Items.Add(comboBoxFuncionalidades.SelectedItem);
                listBoxFuncionalidades.SelectedIndex = 0;
                comboBoxFuncionalidades.Items.Remove(comboBoxFuncionalidades.SelectedItem);
                if (comboBoxFuncionalidades.Items.Count > 0)
                    comboBoxFuncionalidades.SelectedIndex = 0;
                else
                    comboBoxFuncionalidades.ResetText();
            }
        }

        private void rbActivated_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbDeactivated_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txbRolNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void VistaRolModificar_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new VistaRol(this.hoteidMio, this.codRolMio, this.usernameMio).Show();
        }
    }
}
