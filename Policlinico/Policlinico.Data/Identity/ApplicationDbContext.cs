using Microsoft.AspNet.Identity.EntityFramework;
using Policlinico.Data.Model;
using System.Data.Entity;

namespace Policlinico.Data.Identity
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("policlinico", throwIfV1Schema: false)
        { }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Actividad> Actividades { get; set; }
        public DbSet<AtencionAdmision> AtencionesAdmision { get; set; }
        public DbSet<Campania> Campanias { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<EspecialidadMedica> EspecialidadesMedicas { get; set; }
        public DbSet<Examen> Examenes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Perfil> Perfiles { get; set; }
        public DbSet<TipoExamenOcupacional> TiposExamenesOcupacionales { get; set; }
    }
}
