using System;
using System.Data;
using System.Data.SqlClient;

namespace LibrarySystem.Data
{
    public class DUsuario
    {
        public DataTable BuscarProfesor(string Valor)
        {
            SqlDataReader Outcome;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Connection.getInstance().createConnection();
                SqlCommand Command = new SqlCommand("usuario_buscar", SqlCon);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Add("@valor", SqlDbType.VarChar).Value = Valor;
                SqlCon.Open();
                Outcome = Command.ExecuteReader();
                Tabla.Load(Outcome);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }
    }
}
