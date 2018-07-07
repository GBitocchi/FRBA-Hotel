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
using FrbaHotel;
using FrbaHotel.Menu_Sistema;

namespace FrbaHotel.AbmRol
{
    public partial class VistaRol : Form
    {
        DataSet _dsFuncionalidades;
        decimal _idHotel;
        decimal _codigoRol;
        string _nombreUsuario;

        private void cargarFuncionalidades()
        {
            cbFuncionalidades.Items.Clear();
            string funcionalidades = "SELECT func_codigo, func_detalle FROM CAIA_UNLIMITED.Funcionalidad";
            DataSet dsFuncionalidades = DataBase.realizarConsulta(funcionalidades);
            this._dsFuncionalidades = dsFuncionalidades;
            foreach (DataRow unaFuncionalidad in dsFuncionalidades.Tables[0].Rows)
            {
                cbFuncionalidades.Items.Add((string)unaFuncionalidad["func_detalle"]);
            }
            if (cbFuncionalidades.Items.Count > 0)
            {
                cbFuncionalidades.SelectedIndex = 0;
            }
        }
        
        public VistaRol(decimal idHotel, decimal codigoRol, string nombreUsuario)
        {
            InitializeComponent();
            lblErrorFuncionalidad.Visible = false;
            this._idHotel = idHotel;
            this._codigoRol = codigoRol;
            this._nombreUsuario = nombreUsuario;
            lblErrorNombreRol.Visible = false;
            rbActivated.Select();
            cargarFuncionalidades();
            string roles = "SELECT rol_codigo as Codigo, rol_nombre as Nombre, rol_estado as Estado FROM CAIA_UNLIMITED.Rol";
            DataSet dsRoles = DataBase.realizarConsulta(roles);
            dgvModificarRoles.DataSource = dsRoles.Tables[0];
            dgvModificarRoles.AllowUserToAddRows = false;
            DataGridViewButtonColumn botonModificar = new DataGridViewButtonColumn();
            botonModificar.HeaderText = "Seleccionar";
            botonModificar.Text = "            Modificar          ";
            botonModificar.UseColumnTextForButtonValue = true;
            dgvModificarRoles.Columns.Add(botonModificar);
            string rolesActivos = "SELECT rol_codigo as Codigo, rol_nombre as Nombre FROM CAIA_UNLIMITED.Rol WHERE rol_estado = 1";
            DataSet dsRolesActivos = DataBase.realizarConsulta(rolesActivos);
            dgvEliminarRoles.DataSource = dsRolesActivos.Tables[0];
            dgvEliminarRoles.AllowUserToAddRows = false;
            DataGridViewButtonColumn botonEliminar = new DataGridViewButtonColumn();
            botonEliminar.HeaderText = "Seleccionar";
            botonEliminar.Text = "            Eliminar          ";
            botonEliminar.UseColumnTextForButtonValue = true;
            dgvEliminarRoles.Columns.Add(botonEliminar);
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void VistaRol_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            lbFuncionalidades.Items.Clear();
            tbNombreRol.Clear();
            lblErrorFuncionalidad.Visible = false;
            lblErrorNombreRol.Visible = false;
            cargarFuncionalidades();
        }

        private void lbFuncionalidades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new VistaSistema(this._idHotel, this._codigoRol, this._nombreUsuario).Show();
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {           
            if (cbFuncionalidades.SelectedItem != null)
            {
                lbFuncionalidades.Items.Add(cbFuncionalidades.SelectedItem);
                lbFuncionalidades.SelectedIndex = 0;
                cbFuncionalidades.Items.Remove(cbFuncionalidades.SelectedItem);
                if (cbFuncionalidades.Items.Count > 0)
                    cbFuncionalidades.SelectedIndex = 0;
                else
                    cbFuncionalidades.ResetText();
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (lbFuncionalidades.SelectedItem != null)
            {
                cbFuncionalidades.Items.Add(lbFuncionalidades.SelectedItem);
                cbFuncionalidades.Sorted = true;
                lbFuncionalidades.Items.Remove(lbFuncionalidades.SelectedItem);
                cbFuncionalidades.SelectedIndex = 0;
                if (lbFuncionalidades.Items.Count > 0)
                    lbFuncionalidades.SelectedIndex = 0;
            }
        }

        private void cbFuncionalidades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            lblErrorFuncionalidad.Visible = false;
            lblErrorNombreRol.Visible = false;
            
            if (tbNombreRol.Text == "")
            {
                lblErrorNombreRol.Visible = true;
            }
            else if (lbFuncionalidades.Items.Count == 0)
            {
                lblErrorFuncionalidad.Visible = true;
            }
            else
            {
                FuncionalityCollection fc = new FuncionalityCollection();        
                foreach (string funcionalidad in lbFuncionalidades.Items){
                        for(int i=0; i<this._dsFuncionalidades.Tables[0].Rows.Count;i++)
                        {
                            if (((string)(this._dsFuncionalidades.Tables[0].Rows[i]["func_detalle"])) == funcionalidad)
                            {
                                fc.Add(new Funcionality { Funcionalidades = ((decimal)(this._dsFuncionalidades.Tables[0].Rows[i]["func_codigo"])) });
                            }
                        }
                }

                string rolExistente = string.Format("SELECT COUNT(*) FROM CAIA_UNLIMITED.Rol WHERE rol_nombre = '{0}'",tbNombreRol.Text.Trim());

                SqlConnection rolConnection = DataBase.conectarBD();
                SqlCommand comm = new SqlCommand(rolExistente, rolConnection);
                Int32 count = Convert.ToInt32(comm.ExecuteScalar());
                rolConnection.Close();             

                if(count>0){
                    MessageBox.Show("Ya existe un rol con el nombre indicado. Intente con otro nombre.");
                }
                else
                {
                    try{
                        SqlConnection rolCreateConnection = DataBase.conectarBD();
                        SqlCommand insertCommand = new SqlCommand("[CAIA_UNLIMITED].sp_CrearRol", rolCreateConnection);  
                        insertCommand.CommandType = CommandType.StoredProcedure;
                        insertCommand.Parameters.AddWithValue("@nombre_rol", tbNombreRol.Text.Trim());
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
                        string roles = "SELECT rol_codigo as Codigo, rol_nombre as Nombre, rol_estado as Estado FROM CAIA_UNLIMITED.Rol";
                        DataSet dsRoles = DataBase.realizarConsulta(roles);
                        dgvModificarRoles.DataSource = dsRoles.Tables[0];
                        dgvModificarRoles.AllowUserToAddRows = false;
                        string rolesHabilitados = "SELECT rol_codigo as Codigo, rol_nombre as Nombre FROM CAIA_UNLIMITED.Rol WHERE rol_estado = 1";
                        DataSet dsRolesHabilitados = DataBase.realizarConsulta(rolesHabilitados);
                        dgvEliminarRoles.DataSource = dsRolesHabilitados.Tables[0];
                        dgvEliminarRoles.AllowUserToAddRows = false;
                        MessageBox.Show("Rol creado exitosamente!");
                    }
                    catch (Exception errorDB)
                    {
                        MessageBox.Show(errorDB.Message);
                    }
                }

                
            }
        }

        private void dgvModificarRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            try
            {
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {
                    string rolNombre = dgvModificarRoles.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                    new VistaRolModificar(rolNombre).ShowDialog();
                    this.Show();
                    string rolesModificados = "SELECT rol_codigo as Codigo, rol_nombre as Nombre, rol_estado as Estado FROM CAIA_UNLIMITED.Rol";
                    DataSet dsRolesModificados = DataBase.realizarConsulta(rolesModificados);
                    dgvModificarRoles.DataSource = dsRolesModificados.Tables[0];
                    dgvModificarRoles.AllowUserToAddRows = false;
                    string roles = "SELECT rol_codigo as Codigo, rol_nombre as Nombre FROM CAIA_UNLIMITED.Rol WHERE rol_estado = 1";
                    DataSet dsRoles = DataBase.realizarConsulta(roles);
                    dgvEliminarRoles.DataSource = dsRoles.Tables[0];
                    dgvEliminarRoles.AllowUserToAddRows = false;
                }
            }   
            catch(IndexOutOfRangeException iorem)
            {
            
            }
        }

        private void dgvEliminarRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            try
            {
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {
                    string rolNombre = dgvEliminarRoles.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                    string queryChangePW = "UPDATE CAIA_UNLIMITED.Rol SET rol_estado = 0 WHERE rol_nombre = '" + rolNombre + "'";
                    DataBase.procedureBD(queryChangePW);
                    string rolesModificados = "SELECT rol_codigo as Codigo, rol_nombre as Nombre, rol_estado as Estado FROM CAIA_UNLIMITED.Rol";
                    DataSet dsRolesModificados = DataBase.realizarConsulta(rolesModificados);
                    dgvModificarRoles.DataSource = dsRolesModificados.Tables[0];
                    dgvModificarRoles.AllowUserToAddRows = false;
                    string roles = "SELECT rol_codigo as Codigo, rol_nombre as Nombre FROM CAIA_UNLIMITED.Rol WHERE rol_estado = 1";
                    DataSet dsRoles = DataBase.realizarConsulta(roles);
                    dgvEliminarRoles.DataSource = dsRoles.Tables[0];
                    dgvEliminarRoles.AllowUserToAddRows = false;
                    MessageBox.Show("Rol eliminado exitosamente!");
                }
            }
            catch (IndexOutOfRangeException ioree)
            {
            
            }
        }

        private void rbActivated_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
