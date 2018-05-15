using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace FrbaHotel
{
    class DataBase
    {
        public static SqlConnection conectarBD()
        {
            SqlConnection Con = new SqlConnection(@"Data Source=localhost\SQLSERVER2012;Initial Catalog=GD1C2018;Persist Security Info=True;User ID=gdHotel2018;Password=gd2018");
            
            Con.Open();
           
            return Con;
        }

        public static DataSet realizarConsulta(string consulta)
        {
            SqlConnection Con = conectarBD();

            DataSet DS = new DataSet();
            SqlDataAdapter DP = new SqlDataAdapter(consulta, Con);

            DP.Fill(DS);

            Con.Close();

            return DS;
        }
    }
}
