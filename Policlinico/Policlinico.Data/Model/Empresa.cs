using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Policlinico.Data.Model
{
    public class Empresa : EntidadBase
    {
    {
        public Empresa()
        {
            Actividades= new HashSet<Actividad>();
            AtencionesAdmision = new HashSet<AtencionAdmision>();
        }
         
        [StringLength(100)]
        public string RazonSocial { get; set; }
        [StringLength(100)]
        public string Direccion { get; set; }

        public string Telefono { get; set; }
        public string Ruc { get; set; }
        public string Celular { get; set; }
        [StringLength(45)]
        public string Correo { get; set; }
        [StringLength(45)]
        public string ContactoNombre { get; set; }
        public string ContactoCelular { get; set; }
        [StringLength(45)]
        public string ContactoCorreo { get; set; }
        public ICollection<Actividad> Actividades { get; set; }
        public ICollection<AtencionAdmision> AtencionesAdmision { get; set; }
    }
}
