using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Policlinico.Data.Model
{
    public partial class Examen : EntidadBase
    {
        public Examen()
        {
            AtencionesAdmision= new HashSet<AtencionAdmision>();
            Perfil = new HashSet<Perfil>();
        }
         
        [StringLength(45)]
        public string NombreExamen { get; set; }
        public double Costo { get; set; }
        [StringLength(45)]
        public string Recomendaciones { get; set; }
        public ICollection<AtencionAdmision> AtencionesAdmision{ get; set; }
        public virtual ICollection<Perfil> Perfil { get; set; }
    }
}
