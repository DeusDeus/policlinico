using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Policlinico.Data.Model
{
    public class TipoExamenOcupacional : EntidadBase
    {
        public TipoExamenOcupacional()
        {
            Actividades = new HashSet<Actividad>();
            AtencionesAdminision = new HashSet<AtencionAdmision>();
        } 
        [StringLength(100)]
        public string Descripcion { get; set; }
        public virtual ICollection<Actividad> Actividades { get; set; }
        public virtual ICollection<AtencionAdmision> AtencionesAdminision{ get; set; }

    }
}
