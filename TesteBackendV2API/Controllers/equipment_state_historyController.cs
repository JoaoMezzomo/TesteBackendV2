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
    public class equipment_state_historyController : ControllerBase
    {
        private readonly TesteBackendV2APIContext _context;

        public equipment_state_historyController(TesteBackendV2APIContext context)
        {
            _context = context;
        }

        // GET: api/equipment_state_history
        [HttpGet]
        public async Task<ActionResult<IEnumerable<equipment_state_history>>> Getequipment_state_history()
        {
            return await _context.equipment_state_history.ToListAsync();
        }

        // POST: api/equipment_state_history
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IEnumerable<equipment_state_history>>> Postequipment_state_history(equipment_state_history equipment_state_history)
        {
            _context.equipment_state_history.Add(equipment_state_history);
            await _context.SaveChangesAsync();

            return await _context.equipment_state_history.ToListAsync();
        }
    }
}
