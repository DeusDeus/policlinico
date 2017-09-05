using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Policlinico.Data.Model
{
    public class Campania : EntidadBase
    {
        public Campania()
        {
            Actividades = new HashSet<Actividad>();
        } 
        [Required]
        public string Nombre { get; set; }
        public DateTime FechaPlan { get; set; }
        public DateTime Fecha { get; set; }
        public bool Publicada { get; set; }
        public virtual ICollection<Actividad> Actividades { get; set; }
    }
}
