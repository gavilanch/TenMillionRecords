using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlClient.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiezMillonesDemo
{
    public class EfficientCode
    {
        public static void InsertData(string ruta)
        {
            var connString = "Server=.;Database=MillonesDeRegistrosDB;Integrated Security=true;TrustServerCertificate=True";
            using (var connection = new SqlConnection(connString))
            {
                using (var command = new SqlCommand("Valores_InsertarListado", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter parametro = new SqlParameter("@ListadoValores", SqlDbType.Structured);
                    parametro.TypeName = "dbo.ListadoValores";
                    parametro.Value = GetData(ruta);
                    command.Parameters.Add(parametro);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private static IEnumerable<SqlDataRecord> GetData(string ruta)
        {
            SqlMetaData[] schema = new SqlMetaData[] {
      new SqlMetaData("valor", SqlDbType.NVarChar, 100)
   };
            SqlDataRecord _DataRecord = new SqlDataRecord(schema);
            using (StreamReader? reader = new StreamReader(ruta))
            {
                while (!reader.EndOfStream)
                {
                    _DataRecord.SetString(0, reader.ReadLine());
                    yield return _DataRecord;
                }
            }
        }

    }
}
