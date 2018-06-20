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

namespace FrbaHotel.RegistrarConsumible
{
    public partial class MenuRegistrarConsumible : Form
    {
        public MenuRegistrarConsumible()
        {
            InitializeComponent();
            cbxConsumible.DataSource = DataBase.realizarConsulta("select * from CAIA_UNLIMITED.Consumible").Tables[0];
            cbxConsumible.DisplayMember = "cons_descripcion";
            cbxConsumible.ValueMember = "cons_descripcion";
        }

        private void btnAgregar_Consumible_Click(object sender, EventArgs e)
        {
            if (camposCompletosCantidad())
            {
                if (camposValidosCantidad())
                {
                    string consumible = Convert.ToString(cbxConsumible.SelectedValue);
                    txtCantidad.Text = consumible;
                    string cantidad = txtCantidad.Text;
                    string consultaPrecio = string.Format("select cons_precio from CAIA_UNLIMITED.Consumible where cons_descripcion='{0}'", consumible);
                    DataTable precioObtenido = DataBase.realizarConsulta(consultaPrecio).Tables[0];
                    string precio = precioObtenido.Rows[0][0].ToString();

                    string[] formato = { consumible, cantidad, precio };
                    var listViewItem = new ListViewItem(formato);
                    listaConsumibles.Items.Add(listViewItem);
                    cbxConsumible.SelectedIndex = 0;
                    txtCantidad.Text = "";                      
                }
            }
            else
            {
                MessageBox.Show("Complete la cantidad de consumibles", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool camposCompletosCantidad()
        {
            if (txtCantidad.Text.Trim() == "")
            {
                return false;
            }
            return true;
        }

        private bool camposValidosCantidad()
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtCantidad.Text, @"^\d+$"))
            {
                MessageBox.Show("Solo se permiten valores numericos en cantidad de consumibles", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            else
            {
                return true;
            }
        }

        private void btnAgregar_Reserva_Click(object sender, EventArgs e)
        {
            if (camposCompletos())
            {
                if (camposValidos())
                {
                    string codigoEstadiaIngresado = string.Format("select esta_codigo from CAIA_UNLIMITED.Estadia where esta_codigo='{0}'", txtCodigo_Estadia.Text);

                    if (DataBase.realizarConsulta(codigoEstadiaIngresado).Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("El codigo estadia es incorrecto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string consultaHabitacion = string.Format("select habi_rese_numero from CAIA_UNLIMITED.Habitacion_X_Reserva X join CAIA_UNLIMITED.Estadia E on (X.habi_rese_codigo = E.rese_codigo) where E.esta_codigo='{0}'", txtCodigo_Estadia.Text);
                        DataTable habitacion = DataBase.realizarConsulta(consultaHabitacion).Tables[0];
                        txtHabitacion.Text = habitacion.Rows[0][0].ToString();

                        string consultaHotelID = string.Format("select habi_rese_id from CAIA_UNLIMITED.Habitacion_X_Reserva X join CAIA_UNLIMITED.Estadia E on (X.habi_rese_codigo = E.rese_codigo) where E.esta_codigo='{0}'", txtCodigo_Estadia.Text);
                        DataTable hotel_ID = DataBase.realizarConsulta(consultaHotelID).Tables[0];
                        string hotelId = hotel_ID.Rows[0][0].ToString();

                        string consultaHotel = string.Format("select hote_nombre from CAIA_UNLIMITED.Hotel where hote_id='{0}'", hotelId);
                        DataTable hotel = DataBase.realizarConsulta(consultaHotel).Tables[0];
                        txtHotel.Text = hotel.Rows[0][0].ToString();

                        string consultaRegimenId = string.Format("select regi_descripcion from CAIA_UNLIMITED.Regimen R join CAIA_UNLIMITED.Reserva X on (R.regi_codigo = X.regi_codigo) join CAIA_UNLIMITED.Estadia E on (X.rese_codigo = E.rese_codigo) where E.esta_codigo='{0}'", txtCodigo_Estadia.Text);
                        DataTable regimenID = DataBase.realizarConsulta(consultaRegimenId).Tables[0];
                        txtRegimen.Text = regimenID.Rows[0][0].ToString();

                    }
                }

            }
            else
            {
                MessageBox.Show("Complete el codigo de estadia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool camposCompletos()
        {
            if (txtCodigo_Estadia.Text.Trim() == "")
            {
                return false;
            }
            return true;
        }

        private bool camposValidos()
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtCodigo_Estadia.Text, @"^\d+$"))
            {
                MessageBox.Show("Solo se permiten valores numericos en el codigo de estadia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            else
            {
                return true;
            }
        }


        private void btnEliminar_Consumible_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in listaConsumibles.SelectedItems)
            {
                listaConsumibles.Items.Remove(eachItem);
            }
        }

        private void btnIngresar_Consumibles_Click(object sender, EventArgs e)
        {
            SqlConnection db = DataBase.conectarBD();

            if (listaConsumibles != null)
            {
                foreach (ListViewItem eachItem in listaConsumibles.Items)
                {
                    
                    string consultaCodigo = string.Format("select cons_codigo from CAIA_UNLIMITED.Consumible where cons_descripcion='{0}' and cons_precio='{1}'", eachItem.SubItems[0].Text.Trim(), Convert.ToDouble(eachItem.SubItems[2].Text.Trim()));
                    DataTable codigoObtenido = DataBase.realizarConsulta(consultaCodigo).Tables[0];
                    string codigoConsumible = codigoObtenido.Rows[0][0].ToString();

                    SqlCommand registrarConsumible = new SqlCommand("CAIA_UNLIMITED.sp_RegistrarConsumible", db);
                    registrarConsumible.CommandType = CommandType.StoredProcedure;
                    registrarConsumible.Parameters.AddWithValue("@codigo_Estadia", txtCodigo_Estadia.Text.Trim());
                    registrarConsumible.Parameters.AddWithValue("@codigo_Consumible", codigoConsumible);

                    registrarConsumible.ExecuteNonQuery();

                    limpiarFormulario();

                    MessageBox.Show("Consumibles registrados correctamente", "Registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                db.Close();
            }
        }

        private void limpiarFormulario()
        {
            txtCodigo_Estadia.Clear();
                    txtCantidad.Clear();
                    txtHabitacion.Clear();
                    txtHotel.Clear();
                    txtRegimen.Clear();
                    cbxConsumible.SelectedIndex = 0;
                    listaConsumibles.Items.Clear();
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCodigo_Estadia.Clear();
            txtCantidad.Clear();
            txtHabitacion.Clear();
            txtHotel.Clear();
            txtRegimen.Clear();
            cbxConsumible.SelectedIndex = 0;
            listaConsumibles.Items.Clear();
        }

        private void listaConsumibles_SelectedIndexChanged(object sender, EventArgs e)
        {

        } 
    }
}