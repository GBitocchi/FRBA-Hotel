﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.Login
{
    public partial class Seleccion : Form
    {

        DataSet dsAutentificacion = new DataSet();

        public Seleccion(DataSet _dsAutentificacion)
        {
            InitializeComponent();
            this.dsAutentificacion = _dsAutentificacion;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
