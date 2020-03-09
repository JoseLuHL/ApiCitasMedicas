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
    public class MedicosEspecialidadesController : ControllerBase
    {
        private readonly dbContext _context;

        public MedicosEspecialidadesController(dbContext context)
        {
            _context = context;
        }

        // GET: api/MedicosEspecialidades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicosEspecialidades>>> GetMedicosEspecialidades()
        {
            return await _context.MedicosEspecialidades.ToListAsync();
        }

        // GET: api/MedicosEspecialidades/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetMedicosEspecialidades(int id)
        {
            //var medicosEspecialidades = await _context.MedicosEspecialidades.Where(s=>s.Especialidadid.Equals(id)).ToListAsync();
            var ME = await (from me in _context.MedicosEspecialidades
                    join m in _context.Medicos on me.Medicoid equals m.Id
                    join e in _context.Especialidades on me.Especialidadid equals e.Id
                    where me.Especialidadid == id
                    select new
                    {
                        me.Id,
                        me.Medicoid,
                        me.Especialidadid,
                        me.Fecharegistro,
                        me.Activo,
                        nombreMedico = m.Nombres,
                        apellidoMedico = m.Apellidos,
                        nombreApellido = $"{ m.Nombres} { m.Apellidos}",
                        m.Dni,
                        nombreEspecialidad = e.Nombre,
                        e.Descripcion,
                        Especialidad = e,
                        Medico = m,
                        
                    }).ToListAsync();

                    //join es in _context.Especialidades on m.Id equals es
            if (ME == null)
            {
                return NotFound();
            }

            return Ok( ME);
        }

        // PUT: api/MedicosEspecialidades/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicosEspecialidades(int id, MedicosEspecialidades medicosEspecialidades)
        {
            if (id != medicosEspecialidades.Id)
            {
                return BadRequest();
            }

            _context.Entry(medicosEspecialidades).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicosEspecialidadesExists(id))
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

        // POST: api/MedicosEspecialidades
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<MedicosEspecialidades>> PostMedicosEspecialidades(MedicosEspecialidades medicosEspecialidades)
        {
            _context.MedicosEspecialidades.Add(medicosEspecialidades);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedicosEspecialidades", new { id = medicosEspecialidades.Id }, medicosEspecialidades);
        }

        // DELETE: api/MedicosEspecialidades/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MedicosEspecialidades>> DeleteMedicosEspecialidades(int id)
        {
            var medicosEspecialidades = await _context.MedicosEspecialidades.FindAsync(id);
            if (medicosEspecialidades == null)
            {
                return NotFound();
            }

            _context.MedicosEspecialidades.Remove(medicosEspecialidades);
            await _context.SaveChangesAsync();

            return medicosEspecialidades;
        }

        private bool MedicosEspecialidadesExists(int id)
        {
            return _context.MedicosEspecialidades.Any(e => e.Id == id);
        }
    }
}
