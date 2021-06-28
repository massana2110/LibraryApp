using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Entities
{
    public class Libro
    {
		public int IdLibro { get; set; }
		public string Isbn { get; set; }
		public string Titulo { get; set; }
		public string Autor { get; set; }
		public string Editorial { get; set; }
		public string Edicion { get; set; }
		public int NumeroEdicion { get; set; }
		public string Pais { get; set; }
		public string Idioma { get; set; }
		public string Materia { get; set; }
		public int NumeroPaginas { get; set; }
		public string Ubicacion { get; set; }
		public string Descripcion { get; set; }
		

	}
}
