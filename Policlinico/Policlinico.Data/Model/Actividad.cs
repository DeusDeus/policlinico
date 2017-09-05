using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Policlinico.Data.Model
{
    public class Actividad: EntidadBase
    {
       

        [Required]
        public string Descripcion { get; set; }

        public DateTime FechaInicial { get; set; }

        public DateTime FechaFinal { get; set; }

        public DateTime FechaInicialPlan { get; set; }

        public DateTime FechaFinalPlan { get; set; }

        public int Estado { get; set; } 

        public int? CampaniaId { get; set; }
        public Campania Campania { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; } 
        public int TipoExamenOcupacionalId { get; set; }
        public TipoExamenOcupacional TipoExamenOcupacional { get; set; }
    }
}
