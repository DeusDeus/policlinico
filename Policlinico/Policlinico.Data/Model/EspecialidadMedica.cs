using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Policlinico.Data.Model
{
    public class EspecialidadMedica : EntidadBase
    {
        public EspecialidadMedica()
        {
            Perfiles = new HashSet<Perfil>();
            Medicos= new HashSet<Medico>();
        } 

        [StringLength(45)]
        public string Nombre { get; set; }

        [StringLength(100)]
        public string Descripcion { get; set; }
        public ICollection<Perfil> Perfiles { get; set; }
        public ICollection<Medico> Medicos { get; set; }
    }
}
