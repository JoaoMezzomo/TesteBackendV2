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
    public class equipment_stateController : ControllerBase
    {
        private readonly TesteBackendV2APIContext _context;

        public equipment_stateController(TesteBackendV2APIContext context)
        {
            _context = context;
        }

        // GET: api/equipment_state
        [HttpGet]
        public async Task<ActionResult<IEnumerable<equipment_state>>> Getequipment_state()
        {
            return await _context.equipment_state.ToListAsync();
        }

        // GET: api/equipment_state/5
        [HttpGet("{id}")]
        public async Task<ActionResult<equipment_state>> Getequipment_state(Guid id)
        {
            var equipment_state = await _context.equipment_state.FindAsync(id);

            if (equipment_state == null)
            {
                return NotFound();
            }

            return equipment_state;
        }

        // PUT: api/equipment_state/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putequipment_state(Guid id, equipment_state equipment_state)
        {
            if (id != equipment_state.id)
            {
                return BadRequest();
            }

            _context.Entry(equipment_state).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!equipment_stateExists(id))
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

        // POST: api/equipment_state
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<equipment_state>> Postequipment_state(equipment_state equipment_state)
        {
            _context.equipment_state.Add(equipment_state);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getequipment_state", new { id = equipment_state.id }, equipment_state);
        }

        // DELETE: api/equipment_state/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteequipment_state(Guid id)
        {
            var equipment_state = await _context.equipment_state.FindAsync(id);
            if (equipment_state == null)
            {
                return NotFound();
            }

            _context.equipment_state.Remove(equipment_state);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool equipment_stateExists(Guid id)
        {
            return _context.equipment_state.Any(e => e.id == id);
        }
    }
}
