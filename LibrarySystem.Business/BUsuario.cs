
using System.Data;
using LibrarySystem.Data;



namespace LibrarySystem.Business
{
    public class BUsuario
    {
        public static DataTable ListarProfesores()
        {
            DUsuario Datas = new DUsuario();
            return Datas.Listar();

        }
        public static DataTable BuscarProfesor(string Valor)
        {
            DUsuario Datas = new DUsuario();
            return Datas.BuscarProfesor(Valor);
        }

        public static DataTable Login(string email, string contrasenia)
        {
            DUsuario Datos = new DUsuario();
            return Datos.Login(email, contrasenia);
        }
    }
}
