using FrbaHotel.AbmFacturacion;
using FrbaHotel.AbmHabitacion;
using FrbaHotel.AbmHotel;
using FrbaHotel.ListadoEstadistico;
using FrbaHotel.Login;
using FrbaHotel.RegistrarConsumible;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);         
            Application.Run(new MenuRegistrarConsumible());       
        }
    }
}
