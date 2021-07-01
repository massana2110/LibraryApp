using System;
using System.Data;
using System.Data.SqlClient;

namespace LibrarySystem.Data
{
    public class DUsuario
    {
        public DataTable Listar()
        {
            SqlDataReader Outcome;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Connection.getInstance().createConnection();
                SqlCommand Command = new SqlCommand("usuario_listar", SqlCon);
                Command.CommandType = CommandType.StoredProcedure;
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

        public DataTable Login(string email, string contrasenia)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon = Connection.getInstance().createConnection();
                SqlCommand comando = new SqlCommand("usuario_login", SqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                comando.Parameters.Add("@contrasenia", SqlDbType.VarChar).Value = contrasenia;
                SqlCon.Open();
                Resultado = comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }
    }
}
