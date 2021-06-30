using System;
using System.Data;
using LibrarySystem.Data;
using LibrarySystem.Entities;

namespace LibrarySystem.Business
{
    public class BLibro
    {
        public static DataTable Listar()
        {
            DLibro Datas = new DLibro();
            return Datas.Listar();

        }
        public static DataTable ListarDisponibles()
        {
            DLibro Datas = new DLibro();
            return Datas.ListarDisponibles();

        }
        public static DataTable BuscarTitulo(string Valor)
        {
            DLibro Datas = new DLibro();
            return Datas.BuscarTitulo(Valor);
        }

        public static DataTable BuscarId(string Valor)
        {
            DLibro Datas = new DLibro();
            return Datas.BuscarId(Valor);
        }
        public static DataTable BuscarAutor(string Valor)
        {
            DLibro Datas = new DLibro();
            return Datas.BuscarAutor(Valor);
        }

        public static DataTable BuscarTituloActivo(string Valor)
        {
            DLibro Datas = new DLibro();
            return Datas.BuscarTituloActivo(Valor);
        }

        public static DataTable BuscarIdActivo(string Valor)
        {
            DLibro Datas = new DLibro();
            return Datas.BuscarIdActivo(Valor);
        }
        public static DataTable BuscarAutorActivo(string Valor)
        {
            DLibro Datas = new DLibro();
            return Datas.BuscarAutorActivo(Valor);
        }

        public static string Insertar(string Isbn, string Titulo, string Autor, string Editorial, string Edicion, int NumeroEdicion, string Pais, string Idioma, string Materia, int NumeroPaginas, string Ubicacion, string Descripcion, bool Estado)
        {
            DLibro Datas = new DLibro();
            Libro Obj = new Libro();

            Obj.Isbn = Isbn;
            Obj.Titulo = Titulo;
            Obj.Autor = Autor;
            Obj.Editorial = Editorial;
            Obj.Edicion = Edicion;
            Obj.NumeroEdicion = NumeroEdicion;
            Obj.Pais = Pais;
            Obj.Idioma = Idioma;
            Obj.Materia = Materia;
            Obj.NumeroPaginas = NumeroPaginas;
            Obj.Ubicacion = Ubicacion;
            Obj.Descripcion = Descripcion;
            Obj.Estado = Estado;


            return Datas.Insertar(Obj);

        }

        public static string Actualizar(int Id, string Isbn, string Titulo, string Autor, string Editorial, string Edicion, int NumeroEdicion, string Pais, string Idioma, string Materia, int NumeroPaginas, string Ubicacion, string Descripcion, bool Estado)
        {
            DLibro Datas = new DLibro();
            Libro Obj = new Libro();
            Obj.IdLibro = Id;
            Obj.Isbn = Isbn;
            Obj.Titulo = Titulo;
            Obj.Autor = Autor;
            Obj.Editorial = Editorial;
            Obj.Edicion = Edicion;
            Obj.NumeroEdicion = NumeroEdicion;
            Obj.Pais = Pais;
            Obj.Idioma = Idioma;
            Obj.Materia = Materia;
            Obj.NumeroPaginas = NumeroPaginas;
            Obj.Ubicacion = Ubicacion;
            Obj.Descripcion = Descripcion;
            Obj.Estado = Estado;


            return Datas.Actualizar(Obj);
        }

        public static string Eliminar(int Valor)
        {
            DLibro Datas = new DLibro();
            return Datas.Eliminar(Valor);
        }

        public static string ActivarEstado(int Id)
        {
            DLibro Datas = new DLibro();
            return Datas.ActivarEstado(Id);
        }

        public static string DesactivarEstado(int Id)
        {
            DLibro Datas = new DLibro();
            return Datas.DesactivarEstado(Id);
        }


    }
}
