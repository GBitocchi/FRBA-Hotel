﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmHotel
{
    public partial class FechasMantenimiento : Form
    {
        string hotelID, fechaInicio, fechaFin;
        public FechasMantenimiento(string idHotel)
        {
            InitializeComponent();
            hotelID = idHotel;
            txtFechasIncorrectas.Visible = false;
            dtFin.Value = DataBase.fechaSistema();
            dtInicio.Value = DataBase.fechaSistema();
        }

        private void ejecutarStoredProcedure()
        {
            SqlConnection db = DataBase.conectarBD();
            SqlCommand bajaHotel = new SqlCommand("CAIA_UNLIMITED.sp_BajaHotel", db);
            bajaHotel.CommandType = CommandType.StoredProcedure;
            bajaHotel.Parameters.AddWithValue("@id_hotel", hotelID);
            bajaHotel.Parameters.AddWithValue("@fecha_inicio", dtInicio.Value);
            bajaHotel.Parameters.AddWithValue("@fecha_fin", dtFin.Value);
            bajaHotel.Parameters.AddWithValue("@descripcion", txtDescripcion.Text.Trim());
            bajaHotel.ExecuteNonQuery();
            db.Close();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
            new BajaHotel().Show();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            fechaInicio = dtInicio.Value.ToString("yyyyMMdd");
            fechaFin = dtFin.Value.ToString("yyyyMMdd");
            if (dtFin.Value >= dtInicio.Value)
            {
                string consultarPorReservas = queryReservas();
                if (DataBase.realizarConsulta(consultarPorReservas).Tables[0].Rows.Count == 0)
                {
                    Console.WriteLine("Pase");
                    string otrosMantenimientos = queryOtrosMantenimientos();
                    if (DataBase.realizarConsulta(otrosMantenimientos).Tables[0].Rows.Count == 0)
                    {
                        ejecutarStoredProcedure();
                        txtFechasIncorrectas.Visible = false;
                        MessageBox.Show("Baja de hotel exitosa.", "Baja exitosa", MessageBoxButtons.OK);
                        this.Hide();
                        new BajaHotel().Show();
                    }
                    else
                    {
                        MessageBox.Show("Hay mantenimientos en ese periodo de tiempo.", "Fechas incorrectas", MessageBoxButtons.OK);
                        txtFechasIncorrectas.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("Hay reservas para ese periodo de tiempo.", "Baja erronea", MessageBoxButtons.OK);
                    txtFechasIncorrectas.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Las fechas son incorrectas.", "Campos invalidos", MessageBoxButtons.OK);
                txtFechasIncorrectas.Visible = true;
            }
        }

        private string queryReservas()
        {
            string consultarPorReservas = string.Format("select * from CAIA_UNLIMITED.Reserva join CAIA_UNLIMITED.Habitacion_X_Reserva on (habi_rese_codigo = rese_codigo) where habi_rese_id = {0} and ((DATEDIFF(day, rese_fecha_desde,convert(datetime, '{1}', 121)) >= 0 and DATEDIFF(day, rese_fecha_desde, convert(datetime, '{1}', 121)) <= DATEDIFF(day, rese_fecha_desde, DATEADD(day, rese_cantidad_noches, rese_fecha_desde))) or (DATEDIFF(day, rese_fecha_desde, convert(datetime, '{2}', 121)) >= 0 and DATEDIFF(day, rese_fecha_desde, convert(datetime, '{2}', 121)) <= DATEDIFF(day, rese_fecha_desde, DATEADD(day, rese_cantidad_noches, rese_fecha_desde))) or (DATEDIFF(day, rese_fecha_desde, '{1}') <= 0 and DATEDIFF(day, DATEADD(day, rese_cantidad_noches, rese_fecha_desde), '{2}') >=0))",
            hotelID, fechaInicio, fechaFin);
            return consultarPorReservas;
        }

        private string queryOtrosMantenimientos()
        {
            Console.WriteLine("Entre");
            string otrosMantenimientos = string.Format("select * from CAIA_UNLIMITED.Mantenimiento where hote_id = {0} and ((DATEDIFF(day, mant_fecha_inicio, convert(datetime, '{1}', 121)) >= 0 and DATEDIFF(day, mant_fecha_inicio, convert(datetime, '{1}', 121)) <= DATEDIFF(day, mant_fecha_inicio, mant_fecha_fin)) or (DATEDIFF(day, mant_fecha_inicio, convert(datetime, '{2}', 121)) >= 0 and DATEDIFF(day, mant_fecha_inicio, convert(datetime, '{2}', 121)) <= DATEDIFF(day, mant_fecha_inicio, mant_fecha_fin)) or (DATEDIFF(day, mant_fecha_inicio, '{1}') <= 0 and DATEDIFF(day, mant_fecha_fin, '{2}') >=0))",
                hotelID, fechaInicio, fechaFin);
            Console.WriteLine("Sali");
            return otrosMantenimientos;
        }

    }
}