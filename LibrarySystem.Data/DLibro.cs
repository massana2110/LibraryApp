using System;
using System.Data;
using LibrarySystem.Entities;
using System.Data.SqlClient;
namespace LibrarySystem.Data
{
    public class DLibro
    {
        public DataTable Listar()
        {
            SqlDataReader Outcome;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Connection.getInstance().createConnection();
                SqlCommand Command = new SqlCommand("libros_listar", SqlCon);
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
       
        public DataTable ListarDisponibles()
        {
            SqlDataReader Outcome;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Connection.getInstance().createConnection();
                SqlCommand Command = new SqlCommand("librosDisponibles_listar", SqlCon);
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

        public DataTable ListarNoDisponibles()
        {
            SqlDataReader Outcome;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Connection.getInstance().createConnection();
                SqlCommand Command = new SqlCommand("librosNoDisponibles_listar", SqlCon);
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
        public DataTable BuscarTitulo(string Valor)
        {
            SqlDataReader Outcome;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Connection.getInstance().createConnection();
                SqlCommand Command = new SqlCommand("libro_buscarTitulo", SqlCon);
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
        public DataTable BuscarId(string Valor)
        {
            SqlDataReader Outcome;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Connection.getInstance().createConnection();
                SqlCommand Command = new SqlCommand("libro_buscarId", SqlCon);
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
        public DataTable BuscarAutor(string Valor)
        {
            SqlDataReader Outcome;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Connection.getInstance().createConnection();
                SqlCommand Command = new SqlCommand("libro_buscarAutor", SqlCon);
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

        public DataTable BuscarTituloActivo(string Valor)
        {
            SqlDataReader Outcome;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Connection.getInstance().createConnection();
                SqlCommand Command = new SqlCommand("libroDisponible_buscarTitulo", SqlCon);
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
        public DataTable BuscarIdActivo(string Valor)
        {
            SqlDataReader Outcome;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Connection.getInstance().createConnection();
                SqlCommand Command = new SqlCommand("libroDisponible_buscarId", SqlCon);
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
        public DataTable BuscarAutorActivo(string Valor)
        {
            SqlDataReader Outcome;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Connection.getInstance().createConnection();
                SqlCommand Command = new SqlCommand("libroDisponible_buscarAutor", SqlCon);
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
        public string Insertar(Libro obj)
        {
            string Rpta = "";

            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Connection.getInstance().createConnection();
                SqlCommand Command = new SqlCommand("libro_insertar", SqlCon);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Add("@isbn", SqlDbType.VarChar).Value = obj.Isbn;
                Command.Parameters.Add("@titulo", SqlDbType.VarChar).Value = obj.Titulo;
                Command.Parameters.Add("@autor", SqlDbType.VarChar).Value = obj.Autor;
                Command.Parameters.Add("@editorial", SqlDbType.VarChar).Value = obj.Editorial;
                Command.Parameters.Add("@edicion", SqlDbType.VarChar).Value = obj.Edicion;
                Command.Parameters.Add("@numeroEdicion", SqlDbType.Int).Value = obj.NumeroEdicion;
                Command.Parameters.Add("@pais", SqlDbType.VarChar).Value = obj.Pais;
                Command.Parameters.Add("@idioma", SqlDbType.VarChar).Value = obj.Idioma;
                Command.Parameters.Add("@materia", SqlDbType.VarChar).Value = obj.Materia;
                Command.Parameters.Add("@numeroPaginas", SqlDbType.Int).Value = obj.NumeroPaginas;
                Command.Parameters.Add("@ubicacion", SqlDbType.VarChar).Value = obj.Ubicacion;
                Command.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = obj.Descripcion;
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
        public string Actualizar(Libro obj)
        {
            string Rpta = "";

            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Connection.getInstance().createConnection();
                SqlCommand Command = new SqlCommand("libro_actualizar", SqlCon);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Add("@idLibro", SqlDbType.Int).Value = obj.IdLibro;
                Command.Parameters.Add("@isbn", SqlDbType.VarChar).Value = obj.Isbn;
                Command.Parameters.Add("@titulo", SqlDbType.VarChar).Value = obj.Titulo;
                Command.Parameters.Add("@autor", SqlDbType.VarChar).Value = obj.Autor;
                Command.Parameters.Add("@editorial", SqlDbType.VarChar).Value = obj.Editorial;
                Command.Parameters.Add("@edicion", SqlDbType.VarChar).Value = obj.Edicion;
                Command.Parameters.Add("@numeroEdicion", SqlDbType.Int).Value = obj.NumeroEdicion;
                Command.Parameters.Add("@pais", SqlDbType.VarChar).Value = obj.Pais;
                Command.Parameters.Add("@idioma", SqlDbType.VarChar).Value = obj.Idioma;
                Command.Parameters.Add("@materia", SqlDbType.VarChar).Value = obj.Materia;
                Command.Parameters.Add("@numeroPaginas", SqlDbType.Int).Value = obj.NumeroPaginas;
                Command.Parameters.Add("@ubicacion", SqlDbType.VarChar).Value = obj.Ubicacion;
                Command.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = obj.Descripcion;
                Command.Parameters.Add("@estado", SqlDbType.Bit).Value = obj.Estado;

                SqlCon.Open();
                Rpta = Command.ExecuteNonQuery() == 1 ? "OK" : "No se pudo actualizar el registro";
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
                SqlCommand Command = new SqlCommand("libro_eliminar", SqlCon);
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

        public string ActivarEstado(int Id)
        {
            string Rpta = "";

            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Connection.getInstance().createConnection();
                SqlCommand Command = new SqlCommand("libro_activar", SqlCon);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Add("@idLibro", SqlDbType.Int).Value = Id;
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

        public string DesactivarEstado(int Id)
        {
            string Rpta = "";

            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Connection.getInstance().createConnection();
                SqlCommand Command = new SqlCommand("libro_desactivar", SqlCon);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Add("@idLibro", SqlDbType.Int).Value = Id;
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
    }
}




