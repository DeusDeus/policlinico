using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Policlinico.Data.Model
{
    public abstract class Persona : EntidadBase
    {

        [StringLength(100)]
        public string Nombre { get; set; }
        [StringLength(100)]
        public string Apellido { get; set; }
        [NotMapped]
        public string NombreCompleto { get => $"{Apellido}, {Nombre}"; }
        [StringLength(45)]
        public string DocIdentitdad { get; set; }
        [StringLength(45)]
        public string TipoDocIdentidad { get; set; }
        [StringLength(200)]
        public string Direccion { get; set; }
        [StringLength(45)]
        public string Telefono { get; set; }
        [StringLength(45)]
        public string Celular { get; set; }
        [StringLength(45)]
        public string LugarNacimiento { get; set; }
        public DateTime? FechaNacimiento { get; set; }

        [NotMapped]
        public int Edad {
            get {
                if (!FechaNacimiento.HasValue) return 0;
                var now = DateTime.Today;
                var age = now.Year - FechaNacimiento.Value.Year;
                if (FechaNacimiento > now.AddYears(-age)) age--;
                return age;
            }
        }
        [StringLength(45)]
        public string GradoInstruccion { get; set; }
        [StringLength(45)]
        public string Ocupacion { get; set; }
        [StringLength(45)]
        public string EstadoCivil { get; set; }
    }
}
