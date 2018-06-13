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

namespace FrbaHotel.AbmRegimen
{
    public partial class Modificacion : Form
    {
        string codigoAnt, descripcionAnt, precioBaseAnt;
        int estadoAnt;

        public Modificacion(string codigo)
        {
            InitializeComponent();
            string consultaRegimen = string.Format("select regi_codigo as 'Codigo', regi_descripcion as 'Descripcion', regi_precio_base as'Precio base', regi_estado as 'Estado' from CAIA_UNLIMITED.Regimen where regi_codigo={0}", codigo);
            DataTable regimen = DataBase.realizarConsulta(consultaRegimen).Tables[0];
            cargarInfo(regimen);
            valoresAnterioresRegimen();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (estaCompleto())
            {
                if (hayModificaciones())
                {
                    int estado = estadoActualRegimen();
                    ejecutarStoredProcedureModificar(estado);
                    MessageBox.Show("Regimen modificado exitosamente");
                    this.Hide();
                    new MenuModificarDarDeBaja().Show();
                }
                else
                {
                    MessageBox.Show("No se realizaron cambios en los campo/s");
                }

            }
            else
            {
                MessageBox.Show("Campo/s incompletos");
            }
        }

        private void ejecutarStoredProcedureModificar(int estado)
        {
            SqlConnection db = DataBase.conectarBD();
            SqlCommand crearRegimen = new SqlCommand("sp_ModificarRegimen", db);
            crearRegimen.CommandType = CommandType.StoredProcedure;
            crearRegimen.Parameters.AddWithValue("@codigo", txtCodigo.Text.Trim());
            crearRegimen.Parameters.AddWithValue("@descripcion", txtDescripcion.Text.Trim());
            crearRegimen.Parameters.AddWithValue("@precio_base", txtPrecio_Base.Text.Trim());
            crearRegimen.Parameters.AddWithValue("@estado", estado);
            crearRegimen.ExecuteNonQuery();
            db.Close();
        }

        private int estadoActualRegimen()
        {
            if (rbActivo.Checked)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private bool hayModificaciones()
        {
            //COMO CHEQUEAR SI EL BOTTON SE CAMBIO
            if (txtCodigo.Text.Trim() == codigoAnt && txtDescripcion.Text.Trim() == descripcionAnt && txtPrecio_Base.Text.Trim() == precioBaseAnt  && estadoActualRegimen()==estadoAnt)
            {
                return false;
            }
            return true;
        }

        private bool estaCompleto()
        {
            if (txtCodigo.Text.Trim() == "")
            {
                return false;
            }
            else if (txtDescripcion.Text.Trim() == "")
            {
                return false;
            }
            else if (txtPrecio_Base.Text.Trim() == "")
            {
                return false;
            }
            else             {
                
                return true;
            }

        }

        private void cargarInfo(DataTable regimen)
        {
            txtCodigo.Text = regimen.Rows[0][0].ToString();
            txtDescripcion.Text = regimen.Rows[0][1].ToString();
            txtPrecio_Base.Text = regimen.Rows[0][2].ToString();
            string estado = regimen.Rows[0][3].ToString();
            int est = Convert.ToInt32(estado);
            if ( est == 1)
            {
                rbActivo.PerformClick();
            }
            else
            {
                rbNo_activo.PerformClick();
            }
        }

        private void valoresAnterioresRegimen()
        {
            codigoAnt = txtCodigo.Text;
            descripcionAnt = txtDescripcion.Text;
            precioBaseAnt = txtPrecio_Base.Text;
            if (rbActivo.Checked)
            {
                estadoAnt = 1;
            }
            else
            {
                estadoAnt = 0;
            }

        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (hayModificaciones())
            {
                MessageBox.Show("No se puede dar de baja, se realizaron cambios en el regimen.");
            }
            else
            {
                //ejecutarStoredProcedureDarDeBaja();
                MessageBox.Show("Cliente dado de baja exitosamente");
                this.Hide();
                new MenuModificarDarDeBaja().Show();
            }
        }

        private void ejecutarStoredProcedureDarDeBaja(int estado)
        {
            SqlConnection db = DataBase.conectarBD();
            SqlCommand crearRegimen = new SqlCommand("sp_BajaRegimen", db);
            crearRegimen.CommandType = CommandType.StoredProcedure;
            crearRegimen.Parameters.AddWithValue("@codigo", txtCodigo.Text.Trim());
            crearRegimen.Parameters.AddWithValue("@descripcion", txtDescripcion.Text.Trim());
            crearRegimen.Parameters.AddWithValue("@precio_base", txtPrecio_Base.Text.Trim());
            crearRegimen.Parameters.AddWithValue("@estado", estado);
            crearRegimen.ExecuteNonQuery();
            db.Close();
        }
    }
}
