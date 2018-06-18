using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.RegistrarConsumible
{
    public partial class MenuRegistrarConsumible : Form
    {
        public MenuRegistrarConsumible()
        {
            InitializeComponent();
            cbxConsumible.DataSource = DataBase.realizarConsulta("select * from CAIA_UNLIMITED.Consumible").Tables[0];
            cbxConsumible.DisplayMember = "cons_descripcion";
        }

        private void btnAgregar_Consumible_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Reserva_Click(object sender, EventArgs e)
        {
            string consultaHabitacion = string.Format("select habi_rese_numero as 'Numero habitacion' from CAIA_UNLIMITED.Reserva R join CAIA_UNLIMITED.Estadia E on (R.rese_codigo = E.rese_codigo) join CAIA_UNLIMITED.Habitacion_X_Reserva X on (X.habi_rese_codigo = R.rese_codigo) where esta_codigo={0}", txtCodigo_Estadia.Text);
            DataTable habitacion = DataBase.realizarConsulta(consultaHabitacion).Tables[0];
            txtHabitacion.Text = habitacion.Rows[0][0].ToString();

            string consultaHotel = string.Format("select habi_rese_id as 'Codigo hotel' from CAIA_UNLIMITED.Reserva R join CAIA_UNLIMITED.Estadia E on (R.rese_codigo = E.rese_codigo) join CAIA_UNLIMITED.Habitacion_X_Reserva X on (X.habi_rese_codigo = R.rese_codigo) where esta_codigo={0}", txtCodigo_Estadia.Text.Trim());            
            DataTable hotel = DataBase.realizarConsulta(consultaHotel).Tables[0];
            txtHotel.Text = hotel.Rows[0][0].ToString();

            string consultaRegimen = string.Format("select regi_descripcion as 'Regimen' from CAIA_UNLIMITED.Regimen R join CAIA_UNLIMITED.Regimen_X_Hotel X on (R.regi_codigo = X.regi_codigo) join CAIA_UNLIMITED.Hotel H on (H.hote_id = X.hote_id) where esta_codigo={0}", txtHotel.Text);           
            DataTable regimen = DataBase.realizarConsulta(consultaHabitacion).Tables[0];
            txtRegimen.Text = regimen.Rows[0][0].ToString();
        }
    }
}
