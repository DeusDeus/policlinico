using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Policlinico.Data.Model
{
    public class AtencionAdmision:EntidadBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime FechaAtencion { get; set; }
         
        public ECalificacionAtencion Calificacion { get; set; }
        public EEstadoAtencion Estado { get; set; }
        public string Local { get; set; }
        //TODO: dato redundante?
        public string tipo_examen { get; set; }

        //TODO: es una relacion?
        public int? idarea { get; set; }

        public int? PerfilId { get; set; }
        public Perfil Perfil { get; set; }
        public int? ExamenId { get; set; }
        public Examen Examen { get; set; }
        public int? TipoExamenOcupacionalId { get; set; }
        public TipoExamenOcupacional TipoExamenOcupacional { get; set; }
        public int? PacienteId { get; set; }
        public Paciente Paciente { get; set; }
        public int? EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
    }
}
