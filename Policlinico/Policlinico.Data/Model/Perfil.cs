using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Policlinico.Data.Model
{
    public class Perfil : EntidadBase
    {

        public Perfil()
        {
            AtencionesAdmision = new HashSet<AtencionAdmision>();
            Examenes = new HashSet<Examen>();
        } 
        [StringLength(45)]
        public string NombrePerfil { get; set; }
        public double Costo { get; set; }
        [StringLength(45)]
        public string Estado { get; set; }
        public int EspecialidadId  { get; set; }
        public EspecialidadMedica Especialidad { get; set; }
        public ICollection<AtencionAdmision> AtencionesAdmision { get; set; } 
        public ICollection<Examen> Examenes { get; set; }
    }
}
