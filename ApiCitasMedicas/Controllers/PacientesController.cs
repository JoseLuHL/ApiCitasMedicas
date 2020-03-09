using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiCitasMedicas.Data;
using ApiCitasMedicas.Models;

namespace ApiCitasMedicas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly dbContext _context;

        public PacientesController(dbContext context)
        {
            _context = context;
        }

        // GET: api/Pacientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paciente>>> GetPaciente()
        {
            return await _context.Paciente.ToListAsync();
        }

        // GET: api/Pacientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Paciente>> GetPaciente(string id)
        {
            //var paciente = await _context.Paciente.Include(c => c.PacCodCiudad).ToListAsync();
            var paciente = await (from pa in _context.Paciente
                                  join sexo in _context.Genero on pa.PacCodGenero equals sexo.GenCodigo
                                  join depar in _context.Departamento on pa.PacCodDepto equals depar.DeptCodigo
                                  join ciudad in _context.Ciudad on pa.PacCodCiudad equals ciudad.CiudCodigo
                                  join tipoIden in _context.TipoDocumento on pa.PacTipoIdentificacion equals tipoIden.TipoIdeCodigo
                                  join nivelEduca in _context.NivelEducativo on pa.PacCodNivelEducativo equals nivelEduca.NivEduCodigo
                                  join EstadoCivil in _context.EstadoCivil on pa.PacEstadoCivil equals EstadoCivil.EstCivilCodigo
                                  where pa.PacIdentificacion == id
                                  select new
                                  {
                                      pa.PacTipoIdentificacion,
                                      pa.PacIdentificacion,
                                      pa.PacNombre1,
                                      pa.PacNombre2,
                                      pa.PacApellido1,
                                      pa.PacApellido2,
                                      pa.PacDireccion,
                                      pa.PacTelefono,
                                      pa.PacFechaNacimiento,
                                      sexo.GenDescripcion,
                                      depar.DeptNombre,
                                      ciudad.CiudNombre,
                                      nivelEduca.NivEduDescripcion,
                                      pa.PacCodProfesion,
                                      pa.PacTipoSangre,
                                      EstadoCivil.EstCivilDescripcion,
                                      pa.PacFoto,
                                      pa.PacHuella,
                                      pa.PacFirma,
                                      pa.PacDominanciaCodigo,
                                      pa.PacFecha,
                                      pa.PacCodEps,
                                      pa.PacCodArl,
                                      NombreCompleto = $"{pa.PacNombre1} { pa.PacNombre2} {pa.PacApellido1} {pa.PacApellido2}",
                                  }).FirstAsync();

            if (paciente == null)
            {
                return Ok("No hay resultado para la identificación");
            }
            return Ok(paciente);
        }

        // PUT: api/Pacientes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaciente(string id, Paciente paciente)
        {
            if (id != paciente.PacIdentificacion)
            {
                return BadRequest();
            }

            _context.Entry(paciente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacienteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Pacientes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Paciente>> PostPaciente(Paciente paciente)
        {
            _context.Paciente.Add(paciente);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PacienteExists(paciente.PacIdentificacion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPaciente", new { id = paciente.PacIdentificacion }, paciente);
        }

        // DELETE: api/Pacientes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Paciente>> DeletePaciente(string id)
        {
            var paciente = await _context.Paciente.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }

            _context.Paciente.Remove(paciente);
            await _context.SaveChangesAsync();

            return paciente;
        }

        private bool PacienteExists(string id)
        {
            return _context.Paciente.Any(e => e.PacIdentificacion == id);
        }
    }
}
