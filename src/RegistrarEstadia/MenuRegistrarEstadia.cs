using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.RegistrarEstadia
{
    public partial class MenuRegistrarEstadia : Form
    {
        public MenuRegistrarEstadia()
        {
            InitializeComponent();
        }

        private void bntIngresar_Click(object sender, EventArgs e)
        {
             string codigoIngresado = String.Format("SELECT rese_codigo FROM CAIA_UNLIMITED.Reserva WHERE rese_codigo = '{0}'",txtCodigo_Reserva.Text.Trim());

             if (DataBase.realizarConsulta(codigoIngresado).Tables[0].Rows.Count == 0)
             {
                 this.Hide();
                 new Registrar(txtCodigo_Reserva.Text).Show();
             }
             else
             {
                 MessageBox.Show("El codigo ingresado no es correcto");
             }
        }
    }
}
