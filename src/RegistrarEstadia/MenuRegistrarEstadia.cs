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
        string idHotelActual;
        public MenuRegistrarEstadia(string idHotel)
        {
            InitializeComponent();
            idHotelActual = idHotel;
        }

        private void bntIngresar_Click(object sender, EventArgs e)
        {
            if (camposValidos())
            {
                if (perteneceAlHotel())
                {
                    string codigoCanceladoIngresado = String.Format("SELECT reca_rese FROM CAIA_UNLIMITED.Reserva_Cancelada WHERE reca_rese = '{0}'", txtCodigo_Reserva.Text.Trim());

                    if (DataBase.realizarConsulta(codigoCanceladoIngresado).Tables[0].Rows.Count == 0)
                    {

                        string codigoIngresado = String.Format("SELECT rese_codigo FROM CAIA_UNLIMITED.Reserva WHERE rese_codigo = '{0}'", txtCodigo_Reserva.Text.Trim());

                        if (DataBase.realizarConsulta(codigoIngresado).Tables[0].Rows.Count == 0)
                        {
                            MessageBox.Show("El codigo ingresado no es correcto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        else
                        {
                            new Registrar(txtCodigo_Reserva.Text, idHotelActual).ShowDialog();
                            this.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Esta reserva fue cancelada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private bool perteneceAlHotel()
        {
            string codigoHotel = String.Format("select habi_rese_codigo from CAIA_UNLIMITED.Habitacion_X_Reserva where habi_rese_codigo='{0}' AND habi_rese_id='{1}' ",txtCodigo_Reserva.Text.Trim(),idHotelActual );

            if (DataBase.realizarConsulta(codigoHotel).Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("El codigo de reserva no corresponde al hotel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;

        }

        private bool camposValidos()
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtCodigo_Reserva.Text, @"^\d+$"))
            {
                MessageBox.Show("Solo se permiten valores numericos en el codigo de reserva", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            else 
            {
                return true;
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtCodigo_Reserva.Clear();
        }

    }
}
