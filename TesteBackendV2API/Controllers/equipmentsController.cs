using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteBackendV2API.Data;
using TesteBackendV2API.Models;

namespace TesteBackendV2API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class equipmentsController : ControllerBase
    {
        private readonly TesteBackendV2APIContext _context;

        public equipmentsController(TesteBackendV2APIContext context)
        {
            _context = context;
        }

        // GET: api/equipments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<equipment>>> Getequipment()
        {
            return await _context.equipment.ToListAsync();
        }

        // GET: api/equipments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<equipment>> Getequipment(Guid id)
        {
            var equipment = await _context.equipment.FindAsync(id);

            if (equipment == null)
            {
                return NotFound();
            }

            return equipment;
        }

        // PUT: api/equipments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putequipment(Guid id, equipment equipment)
        {
            if (id != equipment.id)
            {
                return BadRequest();
            }

            _context.Entry(equipment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!equipmentExists(id))
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

        // POST: api/equipments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<equipment>> Postequipment(equipment equipment)
        {
            _context.equipment.Add(equipment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getequipment", new { id = equipment.id }, equipment);
        }

        // DELETE: api/equipments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteequipment(Guid id)
        {
            var equipment = await _context.equipment.FindAsync(id);
            if (equipment == null)
            {
                return NotFound();
            }

            _context.equipment.Remove(equipment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool equipmentExists(Guid id)
        {
            return _context.equipment.Any(e => e.id == id);
        }
    }
}
