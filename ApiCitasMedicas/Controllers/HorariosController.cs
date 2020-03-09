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
    public class HorariosController : ControllerBase
    {
        private readonly dbContext _context;

        public HorariosController(dbContext context)
        {
            _context = context;
        }

        // GET: api/Horarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Horarios>>> GetHorarios()
        {
            return await _context.Horarios.ToListAsync();
        }
        // GET: api/Horarios/5
        [HttpGet("{dni}")]
        public async Task<ActionResult> GetHorarios(string dni)
        {
            var horario = await (from med in _context.Medicos
                                 join hor  in _context.Horarios on  med.Id equals hor.Medicoid
                                 where med.Dni == dni
                                 select new
                                 {
                                     hor.Id,
                                     hor.Medicoid,
                                     hor.Fechaatencion,
                                     hor.Inicioatencion,
                                     hor.Finatencion,
                                     hor.Activo,
                                     hor.Fecharegistro,
                                     hor.Nota,
                                     Medico = hor
                                 }).ToListAsync();
            if (horario.Count <= 0)
            {
                return NotFound((new { Estado = false, Mensaje = "No hay resultados para la busqueda", error = NotFound() }));
            }

            return Ok(horario);
        }

        // PUT: api/Horarios/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut]
        public async Task<IActionResult> PutHorarios(List<Horarios> horarios)
        {
            foreach (Horarios item in horarios)
            {
                //if (id != item.Id)
                //{
                //    return BadRequest();
                //}
                _context.Entry(item).State = EntityState.Modified;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                //if (!HorariosExists(id))
                //{
                return NotFound((new { Estado = false, Mensaje = "No se puede actualizar", error = ex.Message }));

                //}
                //else
                //{
                //    throw;
                //}
            }

            return Ok((new { Estado = true, Mensaje = "Datos actualizados", error = "" }));
        }

        // POST: api/Horarios
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Horarios>> PostHorarios(List<Horarios> horarios)
        {
            try
            {

            
            if (horarios == null)
            {
                return Ok(new
                {
                    Estado = false,
                    Mensaje = "Modelo vacio"
                });
            }

            foreach (Horarios item in horarios)
            {
                _context.Horarios.Add(item);
            }
            await _context.SaveChangesAsync();
            return Ok(new
            {
                Estado = true,
                Mensaje = "Datos insertados",
                //id = horarios
            });
            }
            catch (Exception ex)
            {
                return NotFound((new { Estado = false, Mensaje = "No se puede actualizar", error = ex.Message }));
            }
            //return CreatedAtAction("GetHorarios", new { id = horarios.Id }, horarios);
        }

        // DELETE: api/Horarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Horarios>> DeleteHorarios(int id)
        {
            var horarios = await _context.Horarios.FindAsync(id);
            if (horarios == null)
            {
                return NotFound();
            }

            _context.Horarios.Remove(horarios);
            await _context.SaveChangesAsync();

            return horarios;
        }

        private bool HorariosExists(int id)
        {
            return _context.Horarios.Any(e => e.Id == id);
        }
    }
}
