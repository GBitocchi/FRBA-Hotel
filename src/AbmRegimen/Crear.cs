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
    public partial class Crear : Form
    {
        public Crear()
        {
            InitializeComponent();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (camposCompletos())
            {
                int estado;
                
                    estado = estadoActualRegimen();
                    ejecutarStoredProcedureCrear(estado);
                    MessageBox.Show("Regimen " + txtDescripcion.Text + " ingresado correctamente.");
                    RestaurarFormulario();

               

            }
            else
            {
                MessageBox.Show("Complete todo los campos");
            }

        }

        private void ejecutarStoredProcedureCrear(int estado)
        {
            SqlConnection db = DataBase.conectarBD();
            SqlCommand crearRegimen = new SqlCommand("sp_CrearRegi", db);
            crearRegimen.CommandType = CommandType.StoredProcedure;            
            crearRegimen.Parameters.AddWithValue("@descripcion", txtDescripcion.Text.Trim());
            crearRegimen.Parameters.AddWithValue("@precio_base", txtPrecio_Base.Text.Trim());
            crearRegimen.Parameters.AddWithValue("@estado", estado);
            crearRegimen.ExecuteNonQuery();
            db.Close();
        }


        private bool camposCompletos()
        {
            if (txtDescripcion.Text.Trim() == "")
            {
                return false;
            }            
            if (txtPrecio_Base.Text.Trim() == "")
            {
                return false;
            }            
            return true;
        }

        private void RestaurarFormulario()
        {
            txtDescripcion.Clear();
            txtPrecio_Base.Clear();
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuRegimen().Show();
        }


    }
}
