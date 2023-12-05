using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjEfCore.Domain
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        // [Key] // esto define como clave primaria el Legajo
        public int Legajo { get; set; }
        public DateOnly FechaNacimiento { get; set; }

        public string? Direccion { get; set; }

    }
}
