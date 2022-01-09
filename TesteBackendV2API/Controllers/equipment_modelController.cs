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
    public class equipment_modelController : ControllerBase
    {
        private readonly TesteBackendV2APIContext _context;

        public equipment_modelController(TesteBackendV2APIContext context)
        {
            _context = context;
        }

        // GET: api/equipment_model
        [HttpGet]
        public async Task<ActionResult<IEnumerable<equipment_model>>> Getequipment_model()
        {
            return await _context.equipment_model.ToListAsync();
        }

        // GET: api/equipment_model/5
        [HttpGet("{id}")]
        public async Task<ActionResult<equipment_model>> Getequipment_model(Guid id)
        {
            var equipment_model = await _context.equipment_model.FindAsync(id);

            if (equipment_model == null)
            {
                return NotFound();
            }

            return equipment_model;
        }

        // PUT: api/equipment_model/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putequipment_model(Guid id, equipment_model equipment_model)
        {
            if (id != equipment_model.id)
            {
                return BadRequest();
            }

            _context.Entry(equipment_model).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!equipment_modelExists(id))
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

        // POST: api/equipment_model
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<equipment_model>> Postequipment_model(equipment_model equipment_model)
        {
            _context.equipment_model.Add(equipment_model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getequipment_model", new { id = equipment_model.id }, equipment_model);
        }

        // DELETE: api/equipment_model/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteequipment_model(Guid id)
        {
            var equipment_model = await _context.equipment_model.FindAsync(id);
            if (equipment_model == null)
            {
                return NotFound();
            }

            _context.equipment_model.Remove(equipment_model);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool equipment_modelExists(Guid id)
        {
            return _context.equipment_model.Any(e => e.id == id);
        }
    }
}
