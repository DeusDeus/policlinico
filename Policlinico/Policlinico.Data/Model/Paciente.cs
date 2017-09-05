using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Policlinico.Data.Model
{
    public class Paciente:Persona
    {
        public Paciente()
        {
            AtencionesAdmision= new HashSet<AtencionAdmision>();
        }
        [StringLength(45)]
        public string AreaTrabajo { get; set; }
        public int? HistoriaClinica { get; set; }
        
        public ICollection<AtencionAdmision> AtencionesAdmision{ get; set; }
    }
}
