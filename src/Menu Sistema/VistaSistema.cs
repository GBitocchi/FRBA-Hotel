using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.Menu_Sistema
{
    public partial class VistaSistema : Form
    {
        decimal idHotel;
        decimal codigoRol;

        public VistaSistema(decimal _idHotel, decimal _codigoRol)
        {
            InitializeComponent();
            this.idHotel = _idHotel;
            this.codigoRol = _codigoRol;
        }

        public VistaSistema()
        {
            InitializeComponent();
        }
    }
}
