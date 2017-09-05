using Policlinico.Data;
using Policlinico.Data.Dto;
using Policlinico.Data.Model;
using Policlinico.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Policlinico.Services
{
    public class ServicioPacientes
    {
        readonly Contexto ctx;

        public ServicioPacientes(Contexto cx)
        {
            ctx = cx;
        }
        public RptaServicio<List<PacienteDto>> ObtenerTodos(int pagina=0,int tmPagina = 20)
        {
            RptaServicio<List<PacienteDto>> rpta;
            try
            {
                List<PacienteDto> temp;
                IQueryable<Paciente> tempDB;
                if(pagina < 0)
                {
                    tempDB = ctx.Pacientes.Include("AtencionesAdmision").AsNoTracking();
                }
                else
                {
                    var offset = pagina * tmPagina;
                    tempDB = ctx.Pacientes.Include("AtencionesAdmision").AsNoTracking()
                                   .Skip(offset).Take(tmPagina);
                }

                temp = tempDB.OrderBy(p=>p.Id)
                            .OrderByDescending(p=>p.FechaNacimiento)
                            .Select(p => new PacienteDto
                {
                    Apellido = p.Apellido,
                    Nombre = p.Nombre,
                    TotalAtenciones = p.AtencionesAdmision.Count
                }).ToList();

                temp.ForEach(e=>e.Apellido = e.Apellido.Substring(0,1).ToUpper()  + e.Apellido.Substring(1));

                rpta = new RptaServicio<List<PacienteDto>>(temp);
            }
            catch (Exception ex)
            {
                rpta = new RptaServicio<List<PacienteDto>>(null, ex.Message);
            }
            return rpta;
        }
        public RptaServicio<List<AtencionAdmision>> ObtenerAtencionesPacientePorId (int id)
        {
            RptaServicio<List<AtencionAdmision>> rpta;
            try
            { 
                var temp = ctx.Pacientes.Include("AtencionesAdmision").AsNoTracking().FirstOrDefault(p=>p.Id==id);
                if(temp.Id != id)
                {
                    rpta = new RptaServicio<List<AtencionAdmision>>(null, $"El paciente con id:{id} no existe");
                }
                else
                {
                    rpta = new RptaServicio<List<AtencionAdmision>>(temp.AtencionesAdmision.ToList());
                }
            }
            catch (Exception ex)
            {
                rpta = new RptaServicio<List<AtencionAdmision>>(null, ex.Message);
            }
            return rpta;
        }
        public RptaServicio<List<Paciente>> BuscarPacientes(string filtro)
        {
            RptaServicio<List<Paciente>> rpta;
            try
            {
                var temp = ctx.Pacientes.AsNoTracking()
                                    .Where(p => p.Apellido.Contains(filtro) || 
                                                p.Nombre.Contains(filtro)  ||
                                                p.DocIdentitdad == filtro );

                rpta = new RptaServicio<List<Paciente>>(temp.ToList());
            }
            catch (Exception ex)
            {
                rpta = new RptaServicio<List<Paciente>>(null, ex.Message);
            }
            return rpta;
        }
        public RptaServicio<int> CrearPaciente(Paciente nuevoPaciente)
        {
            RptaServicio<int> rpta;
            try
            {
                //normalizar
                nuevoPaciente.Apellido = nuevoPaciente.Apellido.ToLower();
                //validar y aplicar logica de negocios
                if (nuevoPaciente.Edad < 18)
                {
                    rpta = new RptaServicio<int>(0, "No se pueden registrar menores de edad");
                }
                else
                {
                    ctx.Pacientes.Add(nuevoPaciente);
                    ctx.SaveChanges();
                    rpta = new RptaServicio<int>(nuevoPaciente.Id);

                }
            }
            catch (Exception ex)
            {
                rpta = new RptaServicio<int>(0, ex.Message);
            }
            return rpta;
        }
    }
}
