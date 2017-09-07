namespace Policlinico.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actividads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false),
                        FechaInicial = c.DateTime(nullable: false),
                        FechaFinal = c.DateTime(nullable: false),
                        FechaInicialPlan = c.DateTime(nullable: false),
                        FechaFinalPlan = c.DateTime(nullable: false),
                        Estado = c.Int(nullable: false),
                        CampaniaId = c.Int(),
                        EmpresaId = c.Int(nullable: false),
                        TipoExamenOcupacionalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Campanias", t => t.CampaniaId)
                .ForeignKey("dbo.Empresas", t => t.EmpresaId, cascadeDelete: true)
                .ForeignKey("dbo.TipoExamenOcupacionals", t => t.TipoExamenOcupacionalId, cascadeDelete: true)
                .Index(t => t.CampaniaId)
                .Index(t => t.EmpresaId)
                .Index(t => t.TipoExamenOcupacionalId);
            
            CreateTable(
                "dbo.Campanias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        FechaPlan = c.DateTime(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Publicada = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Empresas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RazonSocial = c.String(maxLength: 100),
                        Direccion = c.String(maxLength: 100),
                        Telefono = c.String(),
                        Ruc = c.String(),
                        Celular = c.String(),
                        Correo = c.String(maxLength: 45),
                        ContactoNombre = c.String(maxLength: 45),
                        ContactoCelular = c.String(),
                        ContactoCorreo = c.String(maxLength: 45),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AtencionAdmisions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaAtencion = c.DateTime(nullable: false),
                        Calificacion = c.Int(nullable: false),
                        Estado = c.Int(nullable: false),
                        Local = c.String(),
                        tipo_examen = c.String(),
                        idarea = c.Int(),
                        PerfilId = c.Int(),
                        ExamenId = c.Int(),
                        TipoExamenOcupacionalId = c.Int(),
                        PacienteId = c.Int(),
                        EmpresaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empresas", t => t.EmpresaId)
                .ForeignKey("dbo.Examen", t => t.ExamenId)
                .ForeignKey("dbo.Perfils", t => t.PerfilId)
                .ForeignKey("dbo.Pacientes", t => t.PacienteId)
                .ForeignKey("dbo.TipoExamenOcupacionals", t => t.TipoExamenOcupacionalId)
                .Index(t => t.PerfilId)
                .Index(t => t.ExamenId)
                .Index(t => t.TipoExamenOcupacionalId)
                .Index(t => t.PacienteId)
                .Index(t => t.EmpresaId);
            
            CreateTable(
                "dbo.Examen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreExamen = c.String(maxLength: 45),
                        Costo = c.Double(nullable: false),
                        Recomendaciones = c.String(maxLength: 45),
                        EspecialidadId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EspecialidadMedicas", t => t.EspecialidadId, cascadeDelete: true)
                .Index(t => t.EspecialidadId);
            
            CreateTable(
                "dbo.EspecialidadMedicas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 45),
                        Descripcion = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Medicos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegistroCmp = c.String(maxLength: 45),
                        FechaAlta = c.DateTime(),
                        FechaBaja = c.DateTime(),
                        EspecialidadId = c.Int(nullable: false),
                        Nombre = c.String(maxLength: 100),
                        Apellido = c.String(maxLength: 100),
                        TipoDocIdentidad = c.String(maxLength: 45),
                        Direccion = c.String(maxLength: 200),
                        Telefono = c.String(maxLength: 45),
                        Celular = c.String(maxLength: 45),
                        LugarNacimiento = c.String(maxLength: 45),
                        FechaNacimiento = c.DateTime(),
                        GradoInstruccion = c.String(maxLength: 45),
                        Ocupacion = c.String(maxLength: 45),
                        EstadoCivil = c.String(maxLength: 45),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EspecialidadMedicas", t => t.EspecialidadId, cascadeDelete: true)
                .Index(t => t.EspecialidadId);
            
            CreateTable(
                "dbo.Perfils",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombrePerfil = c.String(maxLength: 45),
                        Costo = c.Double(nullable: false),
                        Estado = c.String(maxLength: 45),
                        EspecialidadMedica_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EspecialidadMedicas", t => t.EspecialidadMedica_Id)
                .Index(t => t.EspecialidadMedica_Id);
            
            CreateTable(
                "dbo.Pacientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AreaTrabajo = c.String(maxLength: 45),
                        HistoriaClinica = c.Int(),
                        Nombre = c.String(maxLength: 100),
                        Apellido = c.String(maxLength: 100),
                        TipoDocIdentidad = c.String(maxLength: 45),
                        Direccion = c.String(maxLength: 200),
                        Telefono = c.String(maxLength: 45),
                        Celular = c.String(maxLength: 45),
                        LugarNacimiento = c.String(maxLength: 45),
                        FechaNacimiento = c.DateTime(),
                        GradoInstruccion = c.String(maxLength: 45),
                        Ocupacion = c.String(maxLength: 45),
                        EstadoCivil = c.String(maxLength: 45),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoExamenOcupacionals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        NombreCompleto = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.PerfilExamen",
                c => new
                    {
                        Perfil_Id = c.Int(nullable: false),
                        Examen_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Perfil_Id, t.Examen_Id })
                .ForeignKey("dbo.Perfils", t => t.Perfil_Id, cascadeDelete: true)
                .ForeignKey("dbo.Examen", t => t.Examen_Id, cascadeDelete: true)
                .Index(t => t.Perfil_Id)
                .Index(t => t.Examen_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AtencionAdmisions", "TipoExamenOcupacionalId", "dbo.TipoExamenOcupacionals");
            DropForeignKey("dbo.Actividads", "TipoExamenOcupacionalId", "dbo.TipoExamenOcupacionals");
            DropForeignKey("dbo.AtencionAdmisions", "PacienteId", "dbo.Pacientes");
            DropForeignKey("dbo.Examen", "EspecialidadId", "dbo.EspecialidadMedicas");
            DropForeignKey("dbo.Perfils", "EspecialidadMedica_Id", "dbo.EspecialidadMedicas");
            DropForeignKey("dbo.PerfilExamen", "Examen_Id", "dbo.Examen");
            DropForeignKey("dbo.PerfilExamen", "Perfil_Id", "dbo.Perfils");
            DropForeignKey("dbo.AtencionAdmisions", "PerfilId", "dbo.Perfils");
            DropForeignKey("dbo.Medicos", "EspecialidadId", "dbo.EspecialidadMedicas");
            DropForeignKey("dbo.AtencionAdmisions", "ExamenId", "dbo.Examen");
            DropForeignKey("dbo.AtencionAdmisions", "EmpresaId", "dbo.Empresas");
            DropForeignKey("dbo.Actividads", "EmpresaId", "dbo.Empresas");
            DropForeignKey("dbo.Actividads", "CampaniaId", "dbo.Campanias");
            DropIndex("dbo.PerfilExamen", new[] { "Examen_Id" });
            DropIndex("dbo.PerfilExamen", new[] { "Perfil_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Perfils", new[] { "EspecialidadMedica_Id" });
            DropIndex("dbo.Medicos", new[] { "EspecialidadId" });
            DropIndex("dbo.Examen", new[] { "EspecialidadId" });
            DropIndex("dbo.AtencionAdmisions", new[] { "EmpresaId" });
            DropIndex("dbo.AtencionAdmisions", new[] { "PacienteId" });
            DropIndex("dbo.AtencionAdmisions", new[] { "TipoExamenOcupacionalId" });
            DropIndex("dbo.AtencionAdmisions", new[] { "ExamenId" });
            DropIndex("dbo.AtencionAdmisions", new[] { "PerfilId" });
            DropIndex("dbo.Actividads", new[] { "TipoExamenOcupacionalId" });
            DropIndex("dbo.Actividads", new[] { "EmpresaId" });
            DropIndex("dbo.Actividads", new[] { "CampaniaId" });
            DropTable("dbo.PerfilExamen");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.TipoExamenOcupacionals");
            DropTable("dbo.Pacientes");
            DropTable("dbo.Perfils");
            DropTable("dbo.Medicos");
            DropTable("dbo.EspecialidadMedicas");
            DropTable("dbo.Examen");
            DropTable("dbo.AtencionAdmisions");
            DropTable("dbo.Empresas");
            DropTable("dbo.Campanias");
            DropTable("dbo.Actividads");
        }
    }
}
