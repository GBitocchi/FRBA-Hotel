using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.SqlServer.Server;

namespace FrbaHotel
{   
    class DataBase
    {
        public static SqlConnection conectarBD()
        {
            SqlConnection Con = new SqlConnection(ConfigurationManager.AppSettings["conexionSQL"]);

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

        public static void procedureBD(string procedure)
        {
            SqlConnection Con = conectarBD();
            SqlDataAdapter DP = new SqlDataAdapter(procedure, Con);
            DP.SelectCommand.ExecuteNonQuery();
            Con.Close();
        }


        public static DateTime fechaSistema()
        {
            return DateTime.ParseExact(ConfigurationManager.AppSettings["fechaSistema"], "yyyy-MM-dd hh:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
        }
    }

    public class Habitacionalities
    {
        public decimal Habitacion { get; set; }
    }

    public class Funcionality
    {
        public decimal Funcionalidades { get; set; }
    }

    public class Rolities
    {
        public decimal Roles { get; set; }
    }

    public class Hotelities
    {
        public decimal Hoteles { get; set; }
    }

    public class HabitacionalitiesCollection : List<Habitacionalities>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            var sqlRow = new SqlDataRecord(new SqlMetaData("Habitacion", SqlDbType.Decimal));

            foreach (Habitacionalities cust in this)
            {
                sqlRow.SetDecimal(0, cust.Habitacion);
                yield return sqlRow;
            }
        }
    }

    public class FuncionalityCollection : List<Funcionality>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            var sqlRow = new SqlDataRecord(new SqlMetaData("Funcionalidades", SqlDbType.Decimal));

            foreach (Funcionality cust in this)
            {
                sqlRow.SetDecimal(0, cust.Funcionalidades);
                yield return sqlRow;
            }
        }
    }

    public class RolitiesCollection : List<Rolities>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            var sqlRow = new SqlDataRecord(new SqlMetaData("Roles", SqlDbType.Decimal));

            foreach (Rolities cust in this)
            {
                sqlRow.SetDecimal(0, cust.Roles);
                yield return sqlRow;
            }
        }
    }

    public class HotelitiesCollection : List<Hotelities>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            var sqlRow = new SqlDataRecord(new SqlMetaData("Hoteles", SqlDbType.Decimal));

            foreach (Hotelities cust in this)
            {
                sqlRow.SetDecimal(0, cust.Hoteles);
                yield return sqlRow;
            }
        }
    }
}
