using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Entities
{
    public class Usuario
    {
		public int IdUsuario { get; set; }
		public int Nombre { get; set; }
		public string Apellido { get; set; }
		public string Email { get; set; }
		public string Contraseña { get; set; }
		public int IdRol { get; set; }
	}
}
