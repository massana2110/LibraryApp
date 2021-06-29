using System;
using System.Data;
using LibrarySystem.Data;
using LibrarySystem.Entities;

namespace LibrarySystem.Business
{
    public class BPrestamo
    {

        public static DataTable Listar()
        {
            DPrestamo Datas = new DPrestamo();
            return Datas.Listar();

        }

        public static DataTable Buscar(string Valor)
        {
            DPrestamo Datas = new DPrestamo();
            return Datas.Buscar(Valor);
        }

        public static string Insertar(int IdUsuario, int IdLibro, DateTime fechaPrestamo, DateTime fechaDevolucion, bool estado) 
        {
            DPrestamo Datas = new DPrestamo();
            Prestamo Obj = new Prestamo();
            
            Obj.IdUsuario = IdUsuario;
            Obj.IdLibro =IdLibro ;
            Obj.FechaPrestamo= fechaPrestamo;
            Obj.FechaDevolucion =fechaDevolucion ;
            Obj.Estado = estado ;

            return Datas.Insertar(Obj);

        }

        public static string ActualizarDevolucion(int Id)
        {
            DPrestamo Datas = new DPrestamo();
            return Datas.ActualizarDevolucion(Id);
        }
        

        }





    }

