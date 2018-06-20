using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.GenerarModificacionReserva
{
    public partial class VariantesRegimenes : Form
    {
        bool eligio = false;
        decimal regimen;
        public bool eligioRegimen { get { return eligio; } }
        public decimal regimenElegido { get { return regimen; } }

        public VariantesRegimenes(decimal id_hotel)
        {
            InitializeComponent();
            string regimenes = string.Format("SELECT r.regi_codigo as Codigo, r.regi_descripcion as Descripcion, r.regi_precio_base as Precio FROM CAIA_UNLIMITED.Regimen r JOIN CAIA_UNLIMITED.Regimen_X_Hotel rh on r.regi_codigo = rh.regi_hote_codigo JOIN CAIA_UNLIMITED.Hotel h on h.hote_id = rh.regi_hote_id WHERE h.hote_id = '{0}' AND r.regi_estado = 1", id_hotel);
            DataSet dsRegimenes = DataBase.realizarConsulta(regimenes);
            dgvRegimenes.DataSource = dsRegimenes.Tables[0];
            DataGridViewButtonColumn botonSeleccionar = new DataGridViewButtonColumn();
            botonSeleccionar.HeaderText = "Elegir";
            botonSeleccionar.Text = "            Seleccionar          ";
            botonSeleccionar.UseColumnTextForButtonValue = true;
            dgvRegimenes.Columns.Add(botonSeleccionar);
        }

        private void dgvRegimenes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {    
        }

        private void dgvRegimenes_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            try
            {
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {
                    this.regimen = Convert.ToDecimal(dgvRegimenes.Rows[e.RowIndex].Cells["Codigo"].Value.ToString());
                    this.eligio = true;
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (IndexOutOfRangeException iorem)
            {

            }
        }
    }
}
