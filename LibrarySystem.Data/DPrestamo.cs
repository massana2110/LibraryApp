using System;
using System.Data;
using LibrarySystem.Entities;
using System.Data.SqlClient;

namespace LibrarySystem.Data
{
    public class DPrestamo
    {
        public DataTable Listar()
        {
            SqlDataReader Outcome;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Connection.getInstance().createConnection();
                SqlCommand Command = new SqlCommand("prestamo_listar", SqlCon);
                Command.CommandType = CommandType.StoredProcedure;
                SqlCon.Open();
                Outcome = Command.ExecuteReader();
                Tabla.Load(Outcome);
                return Tabla;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }
        public DataTable Buscar(string Valor)
        {
            SqlDataReader Outcome;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Connection.getInstance().createConnection();
                SqlCommand Command = new SqlCommand("prestamo_buscar2", SqlCon);
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
        public string Insertar(Prestamo obj)
        {
            string Rpta = "";
            
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Connection.getInstance().createConnection();
                SqlCommand Command = new SqlCommand("prestamo_insertar", SqlCon);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Add("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario;
                Command.Parameters.Add("@idLibro", SqlDbType.Int).Value = obj.IdLibro;
                Command.Parameters.Add("@fechaPrestamo", SqlDbType.Date).Value = obj.FechaPrestamo;
                Command.Parameters.Add("@fechaDevolucion", SqlDbType.Date).Value = obj.FechaDevolucion;
                Command.Parameters.Add("@estado", SqlDbType.Bit).Value = obj.Estado;
                SqlCon.Open();
                Rpta = Command.ExecuteNonQuery() == 1 ? "OK" : "No se pudo ingresar el registro";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;

        }
        public string ActualizarDevolucion(int Id)
        {
            string Rpta = "";

            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Connection.getInstance().createConnection();
                SqlCommand Command = new SqlCommand("prestamo_desactivar", SqlCon);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Add("@idPrestamo", SqlDbType.Int).Value = Id;
                SqlCon.Open();
                Rpta = Command.ExecuteNonQuery() == 1 ? "OK" : "No se pudo desactivar el registro";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;

        }
        public string Eliminar(int Id)
        {
            string Rpta = "";

            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Connection.getInstance().createConnection();
                SqlCommand Command = new SqlCommand("prestamo_eliminar", SqlCon);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Add("@idLibro", SqlDbType.Int).Value = Id;
                SqlCon.Open();
                Rpta = Command.ExecuteNonQuery() == 1 ? "OK" : "No se pudo eliminar el registro";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;

        }
    }
}
