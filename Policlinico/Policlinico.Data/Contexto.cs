using System;
using System.Collections.Generic;
using Policlinico.Data.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Policlinico.Data
{
    public class Contexto : DbContext
    {
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
        public Contexto() : base("policlinico") { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}


