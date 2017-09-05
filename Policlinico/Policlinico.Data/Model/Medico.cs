using System;
using System.ComponentModel.DataAnnotations;

namespace Policlinico.Data.Model
{
    public class Medico : Persona
    {
        [StringLength(45)]
        public string RegistroCmp { get; set; }
        public DateTime? FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public int EspecialidadId { get; set; }
        public EspecialidadMedica Especialidad { get; set; }
    }
}
