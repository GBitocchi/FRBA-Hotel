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
    public partial class SeleccionRol : Form
    {
        List<String> listaRoles = new List<string>();
        
        public SeleccionRol(List<String> _listaRoles)
        {
            InitializeComponent();
            this.listaRoles = _listaRoles;
        }
    }
}
