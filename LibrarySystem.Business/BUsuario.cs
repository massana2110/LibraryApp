
using System.Data;
using LibrarySystem.Data;



namespace LibrarySystem.Business
{
    public class BUsuario
    {
        public static DataTable BuscarProfesor(string Valor)
        {
            DUsuario Datas = new DUsuario();
            return Datas.BuscarProfesor(Valor);
        }
    }
}
