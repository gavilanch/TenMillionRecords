using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiezMillonesDemo
{
    internal class InefficientCode
    {
        public static void InsertData(string route)
        {
            using (SqlConnection connection = new SqlConnection("Server=.;Database=MillonesDeRegistrosDB;Integrated Security=true;TrustServerCertificate=True"))
            {
                using (SqlCommand command = new SqlCommand("Valores_InsertarListado", connection))
                {
                    DataTable dt = GetData(route);
                    command.CommandType = CommandType.StoredProcedure;
                    var param = command.Parameters.AddWithValue("ListadoValores", dt);
                    param.SqlDbType = SqlDbType.Structured;
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private static DataTable GetData(string route)
        {
            var dt = new DataTable();
            dt.Columns.Add("valor", typeof(string));

            StreamReader? _FileReader = null;

            try
            {
                _FileReader = new StreamReader(route);

                while (!_FileReader.EndOfStream)
                {
                    dt.Rows.Add(_FileReader.ReadLine());
                }
            }
            finally
            {
                _FileReader?.Close();
            }

            return dt;
        }
    }
}
