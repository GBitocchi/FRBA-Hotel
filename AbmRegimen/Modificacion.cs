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
        string descripcionAnt, precioBaseAnt,idCodigo;
        int estadoAnt;
        
        public Modificacion(string codigoId)
        {
            InitializeComponent();
            idCodigo = codigoId;
            string consultaRegimen = string.Format("select regi_descripcion as 'Descripcion', regi_precio_base as'Precio base', regi_estado as 'Estado' from CAIA_UNLIMITED.Regimen where regi_codigo='{0}'", codigoId);
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
                    ejecutarStoredProcedureModificar();
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

        private void ejecutarStoredProcedureModificar()
        {
            SqlConnection db = DataBase.conectarBD();
            SqlCommand crearRegimen = new SqlCommand("sp_Modificar", db);
            crearRegimen.CommandType = CommandType.StoredProcedure;
            crearRegimen.Parameters.AddWithValue("@codigo", idCodigo);
            crearRegimen.Parameters.AddWithValue("@descripcion", txtDescripcion.Text.Trim());
            crearRegimen.Parameters.AddWithValue("@precio_base", txtPrecio_Base.Text.Trim());
            if (rbActivo.Checked)
            {
                crearRegimen.Parameters.AddWithValue("@estado", 1);
            }
            else
            {
                crearRegimen.Parameters.AddWithValue("@estado", 0);
            }
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
            
            if (txtDescripcion.Text.Trim() == descripcionAnt && txtPrecio_Base.Text.Trim() == precioBaseAnt  && estadoActualRegimen()==estadoAnt)
            {
                return false;
            }
            return true;
        }

        private bool estaCompleto()
        {
           
            if (txtDescripcion.Text.Trim() == "")
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
            txtDescripcion.Text = regimen.Rows[0][0].ToString();
            txtPrecio_Base.Text = regimen.Rows[0][1].ToString();
            string estado = regimen.Rows[0][2].ToString();
            if (bool.Parse(estado))
            {
                rbActivo.Select();
            }
            else
            {
                rbNo_activo.Select();
            }
        }

        private void valoresAnterioresRegimen()
        {
            
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
                ejecutarStoredProcedureDarDeBaja();
                MessageBox.Show("Regimen dado de baja exitosamente");
                this.Hide();
                new MenuModificarDarDeBaja().Show();
            }
        }

        private void ejecutarStoredProcedureDarDeBaja()
        {
            SqlConnection db = DataBase.conectarBD();
            SqlCommand crearRegimen = new SqlCommand("sp_BajaRegi", db);
            crearRegimen.CommandType = CommandType.StoredProcedure;
            crearRegimen.Parameters.AddWithValue("@codigo", idCodigo);
            crearRegimen.ExecuteNonQuery();
            db.Close();
        }
    }
}
